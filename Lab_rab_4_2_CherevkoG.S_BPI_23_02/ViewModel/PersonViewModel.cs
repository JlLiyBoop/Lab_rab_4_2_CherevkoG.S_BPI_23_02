using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.Helper;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.Model;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.View;

namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02.ViewModel
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private PersonDpo selectedPersonDpo;
        public PersonDpo SelectedPersonDpo
        {
            get { return selectedPersonDpo; }
            set
            {
                selectedPersonDpo = value;
                OnPropertyChanged("SelectedPersonDpo");
            }
        }

        public ObservableCollection<Person> ListPerson { get; set; } = new ObservableCollection<Person>();
        public ObservableCollection<PersonDpo> ListPersonDpo { get; set; } = new ObservableCollection<PersonDpo>();
        private List<Role> roles;

        public PersonViewModel()
        {
            // Инициализируем список ролей
            roles = new RoleViewModel().ListRole.ToList();

            ListPerson.Add(new Person { Id = 1, RoleId = 1, FirstName = "Иван", LastName = "Иванов", Birthday = new DateTime(1980, 02, 28) });
            ListPerson.Add(new Person { Id = 2, RoleId = 2, FirstName = "Петр", LastName = "Петров", Birthday = new DateTime(1981, 03, 20) });
            ListPerson.Add(new Person { Id = 3, RoleId = 3, FirstName = "Виктор", LastName = "Викторов", Birthday = new DateTime(1982, 04, 15) });
            ListPerson.Add(new Person { Id = 4, RoleId = 3, FirstName = "Сидор", LastName = "Сидоров", Birthday = new DateTime(1983, 05, 10) });

            ListPersonDpo = GetListPersonDpo();
        }

        public ObservableCollection<PersonDpo> GetListPersonDpo()
        {
            ListPersonDpo.Clear();
            foreach (var person in ListPerson)
            {
                PersonDpo p = new PersonDpo();
                p = p.CopyFromPerson(person, roles);
                ListPersonDpo.Add(p);
            }
            return ListPersonDpo;
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var r in ListPerson)
            {
                if (max < r.Id) max = r.Id;
            }
            return max;
        }

        private RelayCommand addPerson;
        public RelayCommand AddPerson
        {
            get
            {
                return addPerson ??
                  (addPerson = new RelayCommand(obj =>
                  {
                      WindowNewEmployee wnPerson = new WindowNewEmployee
                      {
                          Title = "Новый сотрудник"
                      };
                      int maxIdPerson = MaxId() + 1;
                      PersonDpo per = new PersonDpo
                      {
                          Id = maxIdPerson,
                          Birthday = DateTime.Now
                      };
                      wnPerson.DataContext = per;
                      wnPerson.CbRole.ItemsSource = roles;

                      if (wnPerson.ShowDialog() == true)
                      {
                          Role r = (Role)wnPerson.CbRole.SelectedValue;
                          if (r != null)
                          {
                              per.RoleName = r.NameRole;
                              ListPersonDpo.Add(per);

                              Person p = new Person();
                              p = p.CopyFromPersonDPO(per, roles);
                              ListPerson.Add(p);
                          }
                      }
                  }, (obj) => true));
            }
        }

        private RelayCommand editPerson;
        public RelayCommand EditPerson
        {
            get
            {
                return editPerson ??
                  (editPerson = new RelayCommand(obj =>
                  {
                      WindowNewEmployee wnPerson = new WindowNewEmployee()
                      {
                          Title = "Редактирование данных сотрудника",
                      };
                      PersonDpo personDpo = SelectedPersonDpo;
                      PersonDpo tempPerson = personDpo.ShallowCopy();
                      wnPerson.DataContext = tempPerson;
                      wnPerson.CbRole.ItemsSource = roles;

                      var currentRole = roles.FirstOrDefault(role => role.NameRole == tempPerson.RoleName);
                      wnPerson.CbRole.SelectedItem = currentRole;

                      if (wnPerson.ShowDialog() == true)
                      {
                          Role r = (Role)wnPerson.CbRole.SelectedValue;
                          if (r != null)
                          {
                              personDpo.RoleName = r.NameRole;
                              personDpo.FirstName = tempPerson.FirstName;
                              personDpo.LastName = tempPerson.LastName;
                              personDpo.Birthday = tempPerson.Birthday;

                              FindPerson finder = new FindPerson(personDpo.Id);
                              List<Person> listPerson = ListPerson.ToList();
                              Person p = listPerson.Find(new Predicate<Person>(finder.PersonPredicate));
                              if (p != null)
                              {
                                  p = p.CopyFromPersonDPO(personDpo, roles);
                              }
                          }
                      }
                  }, (obj) => SelectedPersonDpo != null && ListPersonDpo.Count > 0));
            }
        }

        private RelayCommand deletePerson;
        public RelayCommand DeletePerson
        {
            get
            {
                return deletePerson ??
                  (deletePerson = new RelayCommand(obj =>
                  {
                      PersonDpo person = SelectedPersonDpo;
                      MessageBoxResult result = MessageBox.Show(
                          "Удалить данные по сотруднику: \n" + person.LastName + " " + person.FirstName,
                          "Предупреждение",
                          MessageBoxButton.OKCancel,
                          MessageBoxImage.Warning
                      );
                      if (result == MessageBoxResult.OK)
                      {
                          ListPersonDpo.Remove(person);

                          Person per = new Person();
                          per = per.CopyFromPersonDPO(person, roles);
                          ListPerson.Remove(per);
                      }
                  }, (obj) => SelectedPersonDpo != null && ListPersonDpo.Count > 0));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}