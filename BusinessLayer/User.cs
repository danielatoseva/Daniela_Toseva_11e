using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string FamilyName { get; set; }

        [Required, Range(10, 80)]
        public int Age { get; set; }

        [Required, MaxLength(20)]
        public string UserName { get; set; }

        [Required, MaxLength(70)]
        public string Password { get; set; }

        [Required, MaxLength(20)]
        public string Email { get; set; }

        public IEnumerable<User> FriendList { get; set; }

        public IEnumerable<Game> Games { get; set; }

        private User()
        {

        }

        public User(string firstName, string familyName, int age, string userName, string password, string email)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Age = age;
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
