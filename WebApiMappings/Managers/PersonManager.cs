using System.Collections.Generic;
using WebApiMappings.Controllers;

namespace WebApiMappings.Managers
{
    public class PersonManager
    {

        private static PersonManager _instance = null;
        private List<Person> _persons = new List<Person>();

        public static PersonManager Instance //SINGELTON
        { get 
            {  
                if (_instance == null)
                {
                    return _instance = new PersonManager();
                }
                return _instance;
            }  
        }

        private PersonManager(){}

        public List<Person> List()
        {
            return _persons;
        }

        public string Create(Person person)
        {
            _persons.Add(person);
            return $"Person added!";
        }

        public Person GetPerson(int personId)
        {
            foreach (var item in _persons)
            {
                if (item.Id == personId)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
