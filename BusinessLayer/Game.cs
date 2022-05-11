using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayer
{
    public class Game
    {
        [Key]
        public int ID { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        private Game()
        {

        }

        public Game(string name)
        {
            Name = name;
        }
    }
}
