using System;

namespace UserList
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();   //Generate unique Id for each instance
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public User(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public override string ToString()
        {
            return "User Id: " + Id + "\n" + "First Name: " + firstName + "\n" + "Last Name: " + lastName + "\n" + "User Id: " +
                "Age: " + age;
        }
    }
}
