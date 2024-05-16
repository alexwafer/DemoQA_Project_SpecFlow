using log4net.Appender;
using log4net.Core;
using TechTalk.SpecFlow.Infrastructure;

namespace DemoQA_Project_SpecFlow.loggerUtility
{
    public class CustomLogAppender : AppenderSkeleton
    {
        private readonly ISpecFlowOutputHelper _outputHelper;

        public CustomLogAppender(ISpecFlowOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            _outputHelper.WriteLine(loggingEvent.RenderedMessage);
        }
    }
}
