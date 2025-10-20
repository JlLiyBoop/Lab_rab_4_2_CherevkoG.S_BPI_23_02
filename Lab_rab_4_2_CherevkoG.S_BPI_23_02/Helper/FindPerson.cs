using System;
using Lab_rab_4_2_CherevkoG.S_BPI_23_02.Model;

namespace Lab_rab_4_2_CherevkoG.S_BPI_23_02.Helper
{
    public class FindPerson
    {
        private int Id;

        public FindPerson(int id)
        {
            Id = id;
        }

        public bool PersonPredicate(Person person)
        {
            return person.Id == Id;
        }
    }
}
