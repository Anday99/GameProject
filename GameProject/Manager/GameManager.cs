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
                    Console.WriteLine("{0} , isimli oyun sistemden silindi.", game.GameName);
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

        public void SortByReviewScores()
        {
            List<Game> temp = new List<Game>() { };
            temp.Add(new Game(){});

            for (int i = 0; i < games.Count; i++)
            {
                for (int j = i; j < games.Count; j++)
                {
                    if (games[i].GameReviewScore<games[j].GameReviewScore)
                    {
                        temp[0] = games[i];
                        games[i] = games[j];
                        games[j] = temp[0];
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine("---------------------");
            int a = 1;
            foreach (var game1 in games)
            {
                Console.WriteLine($"{a}.{game1.GameName.PadRight(20,' ')}({game1.GameReviewScore})");
                a += 1;
            }
            Console.WriteLine("---------------------");
        }

    }
}
