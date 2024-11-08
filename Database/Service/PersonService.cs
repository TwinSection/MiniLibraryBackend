using MiniLibrary.Database.Repository;
using MiniLibrary.Models;

namespace MiniLibrary.Database.Service
{
    public interface IPersonService {
        public bool Add(Person p);
    }

    public class PersonService : IPersonService
    {
        IPersonRepository personRepository;

        public PersonService(IPersonRepository per)
        {
            personRepository = per;
        }

        public bool Add(Person p)
        {
            if(string.IsNullOrEmpty(p.Name) && string.IsNullOrEmpty(p.Surname) && string.IsNullOrEmpty(p.Nickname))
            {
                return false;
            }

            personRepository.Add(p);
            personRepository.Save();

            return true;
        }
    }
}
