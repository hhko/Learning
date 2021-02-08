using System;

namespace Null_03_Tutorials
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person(new Address("English"));
            Print(person);

            Person personNull = new Person(new AddressNull());
            Print(personNull);
        }

        static void Print(Person person)
        {
            //
            // 해결: 소비자는 Null을 확인하지 않는다(Null Object Pattern).
            //
            if (person.Address.Country == "English")
            {
                Console.WriteLine("English");
            }
            else
            {
                Console.WriteLine("Unknown");
            }
        }
    }
}
