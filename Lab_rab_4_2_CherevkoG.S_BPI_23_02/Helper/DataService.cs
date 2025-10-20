using System.Collections.ObjectModel;
using System.IO;
using System.Xml;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.Model;
using Newtonsoft.Json;


namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02.Helper
{
    public class DataService
    {
        private readonly string _dataDirectory = "Data";
        private readonly string _rolesFile = "roles.json";
        private readonly string _personsFile = "persons.json";

        public DataService()
        {
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }
        }

        public ObservableCollection<Role> LoadRoles()
        {
            string filePath = Path.Combine(_dataDirectory, _rolesFile);

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                return JsonConvert.DeserializeObject<ObservableCollection<Role>>(json);
            }
            else
            {
                return new ObservableCollection<Role>();
            }
        }

        public void SaveRoles(ObservableCollection<Role> roles)
        {
            string filePath = Path.Combine(_dataDirectory, _rolesFile);

            string json = JsonConvert.SerializeObject(roles, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filePath, json);
        }

        public ObservableCollection<Person> LoadPersons()
        {
            string filePath = Path.Combine(_dataDirectory, _personsFile);

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);

                return JsonConvert.DeserializeObject<ObservableCollection<Person>>(json);
            }
            else
            {
                return new ObservableCollection<Person>();
            }
        }

        public void SavePersons(ObservableCollection<Person> persons)
        {
            string filePath = Path.Combine(_dataDirectory, _personsFile);

            string json = JsonConvert.SerializeObject(persons, Newtonsoft.Json.Formatting.Indented);

            File.WriteAllText(filePath, json);
        }
    }
}
