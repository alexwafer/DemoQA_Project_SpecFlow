using Newtonsoft.Json;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA_Project_SpecFlow.PageObject.formObject
{
    public class PracticeFormObject : InputObject
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string UserEmail { get; private set; }
        public string UserNumber { get; private set; }
        public string CurrentAddress { get; private set; }
        public string Gender { get; private set; }
        public IList<string> Hobbies { get; private set; }
        public string Hobby { get; private set; }
        public IList<string> Subjects { get; private set; }
        public string Subject { get; set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Day { get; private set; }
        public string Month { get; private set; }
        public string Year { get; private set; }
        public IList<string> ActualPracticeFormValues { get; private set; }

        public PracticeFormObject() 
        {

        }
        public PracticeFormObject(Dictionary<string, string> Hash)
        {
            PopulateObject(Hash);
            SplitPropertiesIntoSeparateLists();
            PrepareActualResultsIntoList(Hash);
        }


        public void SplitPropertiesIntoSeparateLists()
        {
            string[] splitSubjectValues = Subject.Split(',');
            Subjects = splitSubjectValues.Select(x => x).ToList();
            string[] splitHobbyValues = Hobby.Split(',');
            Hobbies = splitHobbyValues.Select(x => x).ToList();
        }

        public void PrepareActualResultsIntoList(Dictionary<string, string> Hash)
        {
            ActualPracticeFormValues = Hash.Values.ToList();
            Subjects.ToList().ForEach(subject => ActualPracticeFormValues.Add(subject));
            Hobbies.ToList().ForEach(hobby => ActualPracticeFormValues.Add(hobby));
            ActualPracticeFormValues.Where(element => element.Contains(",")).ToList().ForEach(result => ActualPracticeFormValues.Remove(result));
        }

        public void PrepareActualResultsIntoList(Table table)
        {
            ActualPracticeFormValues = table.Rows.Select(row => row.ToString()).ToList();
            Subjects.ToList().ForEach(subject => ActualPracticeFormValues.Add(subject));
            Hobbies.ToList().ForEach(hobby => ActualPracticeFormValues.Add(hobby));
            ActualPracticeFormValues.Where(element => element.Contains(",")).ToList().ForEach(result => ActualPracticeFormValues.Remove(result));
        }
    }


}
