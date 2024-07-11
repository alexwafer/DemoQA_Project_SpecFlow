using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using System.Diagnostics;
using System.Reflection;

namespace DemoQA_Project_SpecFlow.loggerUtility
{
    public class LoggerUtility
    {
        private readonly static string regressionLogFile = "RegressionLogs";
        private readonly static string logConfigFile = "log4net.config";
        public static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string testName = string.Empty;

        static LoggerUtility()
        {
            XmlConfigurator.Configure(new FileInfo($"{GetDirectoryPath()}{logConfigFile}"));
        }

        public static void StartFeature(string featureName)
        {
            testName = featureName;
            BasicConfigurator.Configure(CreateFileAppender(featureName));

            var logMessage = $"************** FEATURE STARTED : {featureName} **************";
            logger.Info(GetBackgroundLog(logMessage));
            logger.Info(logMessage);
        }

        public static void StartScenario(string scenarioName)
        {
            logger.Info($"************** SCENARIO STARTED => {scenarioName} **************");
        }

        public static void StartStep(string stepMessage)
        {
            logger.Info($"************** STEP STARTED => {stepMessage} **************");
        }

        public static void StopStep(string stepMessage)
        {
            logger.Info($"************** STEP ENDED => {stepMessage} **************");
        }

        public static void StopScenario(string scenarioName)
        {
            logger.Info($"************** SCENARIO ENDED => {scenarioName} **************");
        }

        public static void StopFeature(string featureName)
        {
            var logMessage = $"************** FEATURE ENDED : {featureName} **************";
            logger.Info(logMessage);
            logger.Info(GetBackgroundLog(logMessage));
        }

        public static void Info(string Message)
        {
            logger.Info($"{testName} <-> {GetCallInfo()} {Message}");
        }

        public static void Error(string Message)
        {
            logger.Error($"{testName} <-> {GetCallInfo()} {Message}");
        }

        private static FileAppender CreateFileAppender(string filename)
        {
            FileAppender fa = new FileAppender();
            /*fa.Name = filename;
            fa.File = Path.Combine(GetDirectoryPath(), $"{regressionLogFile}.log");
            fa.Layout = new PatternLayout(" %date %-5level - %message%newline");
            fa.Threshold = Level.Info;
            fa.AppendToFile = true;
            fa.ImmediateFlush = true;
            fa.ActivateOptions();*/
            return fa;
        }

        private static string GetCallInfo()
        {
            StackTrace stackTrace = new StackTrace(true);
            StackFrame frame = stackTrace.GetFrame(2);
            string className = GetClassName(frame);
            string methodName = GetMethodName(frame);
            return $"{className}:{methodName} ==> ";
        }

        private static string GetClassName(StackFrame frame)
        {
            string className = frame.GetMethod().DeclaringType.Name;
            if (className.Contains("<>"))
            {
                string classPath = frame.GetFileName();
                string[] splitArray = classPath.Split(new string[] { "\\", ".cs" }, StringSplitOptions.None);
                className = splitArray[splitArray.Length - 2];
            }
            return className;
        }

        private static string GetMethodName(StackFrame frame)
        {
            string methodName = frame.GetMethod().Name;
            if (methodName.Contains("<") && methodName.Contains(">"))
            {
                string[] splitArray = methodName.Split(new string[] { "<", ">" }, StringSplitOptions.None);
                methodName = splitArray[splitArray.Length - 2];
            }
            return methodName;
        }

        public static void ClearFolderLogs()
        {
            string[] files = Directory.GetFiles(GetDirectoryPath());
            var filesToDelete = files
                .Where(file => Path.GetFileName(file).Contains(regressionLogFile))
                .ToList();

            foreach (var fileToDelete in filesToDelete)
            {
                try
                {
                    File.Delete(fileToDelete);
                }
                catch (IOException e)
                {
                    Debug.WriteLine($"Failed to delete {fileToDelete}: {e.Message}");
                }
            }
        }

        private static string GetBackgroundLog(string message)
        {
            int length = message.Length;
            string backgroundValue = string.Empty;
            for (int index = 0; index < length; index++)
            {
                backgroundValue += "*";
            }
            return backgroundValue;
        }

        public static string GetDirectoryPath()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (path.Contains("\\bin\\Debug"))
            {
                return Directory.GetParent(path).Parent.Parent.Parent.FullName + "\\";
            }
            else
            {
                return Directory.GetParent(path).Parent.Parent.Parent.Parent.FullName + "\\";
            }
        }
    }
}
