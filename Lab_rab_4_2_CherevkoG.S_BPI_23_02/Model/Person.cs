using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02.Model
{
    public class Person
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public Person() { }

        public Person(int id, int roleId, string firstName, string lastName, DateTime birthday)
        {
            this.Id = id;
            this.RoleId = roleId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }

        public Person CopyFromPersonDPO(PersonDpo perDpo, List<Role> roles)
        {
            int roleId = 0;
            foreach (var r in roles)
            {
                if (r.NameRole == perDpo.RoleName)
                {
                    roleId = r.Id;
                    break;
                }
            }

            Person person = new Person();
            person.Id = perDpo.Id;
            person.RoleId = roleId;
            person.FirstName = perDpo.FirstName;
            person.LastName = perDpo.LastName;
            person.Birthday = perDpo.Birthday;
            return person;
        }
    }
}