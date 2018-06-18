using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.BasicClasses
{
    class Player
    {
        public int Id { get; }

        public Team Team;

        public Player(int id)
        {
            Id = id;
        }
    }
}
