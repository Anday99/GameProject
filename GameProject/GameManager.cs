using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class GameManager
    {
        List<Game> games = new List<Game>() { }; 

        public void Add(Game game)
        {
            games.Add(game);
            Console.WriteLine("{0} isimli oyun eklendi.",game.GameName);
        }

        public void Update(Game game)
        {

        }

        public void Delete(string GameName)
        {
            foreach (var game in games)
            {
                if (game.GameName == GameName)
                {
                    games.Remove(game);
                    Console.WriteLine("{0} , isimli oyuncu sistemden silindi.", game.GameName);
                    break;
                }

                else
                {
                    continue;
                }
            }

        }

        public void ListGame()
        {
            int i = 1;
            foreach (var game in games)
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("{0}.Oyun\nOyun Adı:{1}\nÇıkış Yılı:{2}\nOyunun Türü:{3}\nOyunun Fiyatı:{4}\nOyunun İnceleme Puanı:{5}", i,game.GameName,game.GameReleaseYear,game.GameType,game.GamePrice,game.GameReviewScore);
                Console.WriteLine("--------------------------");
                i += 1;
            }
        }

        public void GetGame(string GameName,ICampaignService campaign)
        {
            foreach (var game in games)
            {
                if (game.GameName == GameName)
                {
                    campaign.CalculateSale(game);
                    campaign.SaleInformation(game);
                }

                else
                {
                    continue;
                }
            }
        }

    }
}
