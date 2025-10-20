﻿using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.ViewModel;


namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02.Model
{
    public class PersonDpo : INotifyPropertyChanged
    {
        private string _roleName;
        private string firstName;
        private string lastName;
        private DateTime birthday;

        public int Id { get; set; }

        public string RoleName
        {
            get { return _roleName; }
            set
            {
                _roleName = value;
                OnPropertyChanged("RoleName");
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set
            {
                birthday = value;
                OnPropertyChanged("Birthday");
            }
        }

        public PersonDpo() { }

        public PersonDpo(int id, string roleName, string firstName, string lastName, DateTime birthday)
        {
            this.Id = id;
            this.RoleName = roleName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Birthday = birthday;
        }

        public PersonDpo ShallowCopy()
        {
            return (PersonDpo)this.MemberwiseClone();
        }

        public PersonDpo CopyFromPerson(Person person)
        {
            PersonDpo perDpo = new PersonDpo();
            RoleViewModel vmRole = new RoleViewModel();
            string role = string.Empty;

            foreach (var r in vmRole.ListRole)
            {
                if (r.Id == person.RoleId)
                {
                    role = r.NameRole;
                    break;
                }
            }

            if (role != string.Empty)
            {
                perDpo.Id = person.Id;
                perDpo.RoleName = role;
                perDpo.FirstName = person.FirstName;
                perDpo.LastName = person.LastName;
                perDpo.Birthday = person.Birthday;
            }

            return perDpo;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

