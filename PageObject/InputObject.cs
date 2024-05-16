using DemoQA_Project_SpecFlow.PageObject.alertsObject;
using DemoQA_Project_SpecFlow.PageObject.autoCompleteObject;
using DemoQA_Project_SpecFlow.PageObject.formObject;
using DemoQA_Project_SpecFlow.PageObject.textBoxObject;
using DemoQA_Project_SpecFlow.PageObject.webTableObject;
using System.Reflection;

namespace DemoQA_Project_SpecFlow.PageObject
{
    public class InputObject
    {
        //design pattern: factory method
        public static InputObject PrepareObject(string ObjectType, Dictionary<string, string> InputData)
        {
            switch (ObjectType)
            {

                case InputType.OBJECT_PRACTICEFORM:
                    return new PracticeFormObject(InputData);
                case InputType.OBJECT_WEBTABLE:
                    return new WebTableObject(InputData);
                case InputType.OBJECT_ALERT:
                    return new AlertsObject(InputData);
                case InputType.OBJECT_TEXTBOX:
                    return new TextBoxObject(InputData);
                case InputType.OBJECT_AUTOCOMPLETE:
                    return new AutoCompleteObject(InputData);

            }
            return null;
        }

        //reflection concept
        public void PopulateObject(Dictionary<string, string> Hash)
        {
            GetType().GetProperties(BindingFlags.Instance |
                   BindingFlags.NonPublic | BindingFlags.Public)
                .Where(propertyInfo => Hash.ContainsKey(propertyInfo.Name)).ToList()
                .ForEach(x => x.SetValue(this, Hash[x.Name]));
        }

        //generic method for returning the inputObject based on a specified cast
        public T GetSpecificObject<T>() where T : class
        {
            return (T)(object)this;
        }

    }
}
