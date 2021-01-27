using GameProject.Interface;
using System;
using System.Collections.Generic;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer player1 = new OldPlayer() { TcNo = "1", BirthYear = 1999, PlayerName = "Anday", PlayerSurname = "Aktaş", MembershipYear = 2 };
            IPlayer player2 = new OldPlayer() { TcNo = "2", BirthYear = 1985, PlayerName = "Engin", PlayerSurname = "Demiroğ", MembershipYear = 20 };
            PlayerManager playerManager = new PlayerManager();
            playerManager.Add(player1);
            playerManager.Add(player2);

            GameManager gameManager = new GameManager();
            gameManager.Add(new Game() { GameName = "Death Stranding", GameType = "Action", GamePrice = 499, GameReleaseYear = 2018, GameReviewScore = 8.3 });
            gameManager.Add(new Game() { GameName = "Days Gone", GameType = "Action,Zombie", GamePrice = 139, GameReleaseYear = 2018, GameReviewScore = 7.3 });
            gameManager.Add(new Game() { GameName = "Persona 5", GameType = "JRPG", GamePrice = 99, GameReleaseYear = 2015, GameReviewScore = 9.1 });
            gameManager.Add(new Game() { GameName = "Cyberpunk 2077", GameType = "RPG", GamePrice = 499, GameReleaseYear = 2020, GameReviewScore = 7.1 });
            gameManager.Add(new Game() { GameName = "Witcher 3", GameType = "RPG", GamePrice = 49, GameReleaseYear = 2015, GameReviewScore = 9.3 });

            while (true)
            {
                Console.WriteLine("**********MENU**********");
                Console.WriteLine("1-)Oyuncu Ekle\n2-)Oyuncu Sil\n3-)Kullanıcıları Listele\n4-)Oyun Ekle\n5-)Oyun Sil\n6-)Oyunları Listele\n7-)Oyunları İnceleme Puanına Göre Listele\n8-)Oyunları Çıkış Yıllarına Göre Sırala\n9-)Kampanya Seçiniz\n10-)Çıkış");
                Console.WriteLine("************************");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (choice==1 || choice == 2 || choice == 3 || choice == 4 || choice == 5 || choice == 6 || choice == 7 || choice == 8 || choice == 9)
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Eklemek istediğiniz kullanıcı bilgilerini giriniz");
                            Console.WriteLine("Tc no:");
                            string TcNo = Console.ReadLine();
                            Console.WriteLine("Ad:");
                            string PlayerName = Console.ReadLine();
                            Console.WriteLine("Soyad:");
                            string PlayerSurname = Console.ReadLine();
                            Console.WriteLine("Doğum Yılı:");
                            int BirthYear = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Kaç yıl kullanmayı taahhüt ediyorsunuz:");
                            int UndertakingYear = Convert.ToInt32(Console.ReadLine());

                            playerManager.Add(new NewPlayer() { TcNo = TcNo, PlayerName = PlayerName, PlayerSurname = PlayerSurname, BirthYear = BirthYear, UndertakingYear = UndertakingYear });
                            break;
                        case 2:
                            Console.WriteLine("Silmek istediğiniz oyuncunun Tc Numarasını giriniz:");
                            playerManager.Delete(Console.ReadLine());
                            break;
                        case 3:
                            playerManager.ListPlayer();
                            break;
                        case 4:
                            Console.WriteLine("Eklemek istediğiniz oyunun bilgilerini giriniz");
                            Console.WriteLine("Oyun Adı:");
                            string GameName = Console.ReadLine();
                            Console.WriteLine("Oyunun Çıkış Yılı:");
                            int GameReleaseYear = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Oyunun Türü:");
                            string GameType = Console.ReadLine();
                            Console.WriteLine("Oyunun Fiyatı:");
                            double GamePrice = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Oyunun İnceleme Puanı:");
                            double GameReviewScore = Convert.ToDouble(Console.ReadLine());

                            gameManager.Add(new Game() { GameName = GameName, GameReleaseYear = GameReleaseYear, GameType = GameType, GamePrice = GamePrice, GameReviewScore = GameReviewScore });
                            break;
                        case 5:
                            Console.WriteLine("Silmek istediğiniz oyunun Adını giriniz:");
                            gameManager.Delete(Console.ReadLine());
                            break;
                        case 6:
                            gameManager.ListGame();
                            break;
                        case 7:
                            gameManager.SortByReviewScores();
                            break;
                        case 8:
                            gameManager.SortByReleaseYear();
                            break;
                        case 9:
                            while (true)
                            {
                                Console.WriteLine("**********KAMPANYALAR**********");
                                Console.WriteLine("-1-Öğrenci Kampanyası\n-2-Kara Cuma Kampanyası\n-3-Ana Menüye Dön");
                                Console.WriteLine("*******************************");

                                int choice2 = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (choice2 == 1 || choice2 == 2)
                                {
                                    switch (choice2)
                                    {
                                        case 1:
                                            gameManager.ListGame();
                                            Console.WriteLine("Yukarıdaki oyunlardan öğrencisi kampanyası uygulamak istediğiniz oyunun adını yazınız:");
                                            string nameStudentCampaign = Console.ReadLine();
                                            Console.Clear();
                                            ICampaignService campaignStudent = new StudentCampaign();
                                            gameManager.GetGame(nameStudentCampaign, campaignStudent);
                                            break;
                                        case 2:
                                            gameManager.ListGame();
                                            Console.WriteLine("Yukarıdaki oyunlardan kara cuma kampanyası uygulamak istediğiniz oyunun adını yazınız:");
                                            string nameBlackFridayCampaign = Console.ReadLine();
                                            Console.Clear();
                                            ICampaignService campaignBlackFriday = new BlackFridayCampaign();
                                            gameManager.GetGame(nameBlackFridayCampaign, campaignBlackFriday);
                                            break;
                                        default:
                                            break;
                                    }
                                }

                                else
                                {
                                    break;
                                }
                            }
                            break;

                        default:
                            break;
                    }
                
                }
                else
                {
                    Console.WriteLine("Programdan çıkış yaptınız.\nİyi günler...");
                    break;
                }
            }
        }
    }
}
