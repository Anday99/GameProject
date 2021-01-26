using GameProject.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class NewPlayer: IPlayer
    {
        public int UndertakingYear { get; set; }
        public string PlayerName { get; set; }
        public string PlayerSurname { get; set; }
        public string TcNo { get; set; }
        public int BirthYear { get; set; }
    }
}
