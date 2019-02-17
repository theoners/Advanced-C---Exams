using System;
namespace Repository
{
    public class Person
    {
        public Person(string name, int age, DateTime birthDay)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthDay;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
