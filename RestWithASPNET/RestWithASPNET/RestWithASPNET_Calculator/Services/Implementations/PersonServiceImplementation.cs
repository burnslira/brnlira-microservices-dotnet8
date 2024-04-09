using RestWithASPNET_Calculator.Model;

namespace RestWithASPNET_Calculator.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                Person person = MockPerson(i);
                persons.Add(new Person());
            }
            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            { 
                id = IncrementAndGet(),
                firstName = "Bruno",
                lastName = "Lira",
                address = "São Paulo - São Paulo - Brasil",
                gender = "Male"
            };

        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                id = IncrementAndGet() + i,
                firstName = "Person Name " + i,
                lastName = "Person Lastname " + i,
                address = "Some address - Person: " + i,
                gender = "Male " + i
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
