using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject.Interface
{
    interface IPlayer
    {
        public string PlayerName { get; set; }
        public string PlayerSurname { get; set; }
        public string TcNo { get; set; }
        public int BirthYear { get; set; }
    }
}
