using System;
using System.Collections.Generic;

namespace GameProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new OldPlayer() { TcNo = "1", BirthYear = 1999, PlayerName = "Anday", PlayerSurname = "Aktaş", MembershipYear = 2 };
            PlayerManager playerManager = new PlayerManager();
            playerManager.Add(player1);
     
            GameManager gameManager = new GameManager();
            gameManager.Add(new Game() { GameName = "Death Stranding", GameType = "Action", GamePrice = 499, GameReleaseYear = 2018, GameReviewScore = 8.3 });
            gameManager.Add(new Game() { GameName = "Days Gone", GameType = "Action,Zombie", GamePrice = 139, GameReleaseYear = 2018, GameReviewScore = 7.3 });
            gameManager.Add(new Game() { GameName = "Persona 5", GameType = "JRPG", GamePrice = 99, GameReleaseYear = 2015, GameReviewScore = 9.1 });

            while (true)
            {
                Console.WriteLine("**********MENU**********");
                Console.WriteLine("1-)Oyuncu Ekle\n2-)Oyuncu Sil\n3-)Kullanıcıları Listele\n4-)Oyun Ekle\n5-)Oyun Sil\n6-)Oyunları Listele\n7-)Kampanya Seçiniz\n8-)Çıkış");
                Console.WriteLine("************************");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice==1)
                {
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

                    playerManager.Add(new NewPlayer() {TcNo=TcNo,PlayerName=PlayerName,PlayerSurname=PlayerSurname,BirthYear=BirthYear,UndertakingYear= UndertakingYear });
                }

                else if (choice==2)
                {
                    Console.WriteLine("Silmek istediğiniz oyuncunun Tc Numarasını giriniz:");
                    playerManager.Delete(Console.ReadLine());
                }

                else if (choice==3)
                {
                    playerManager.ListPlayer();
                }

                else if (choice==4)
                {
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
                }

                else if (choice==5)
                {
                    Console.WriteLine("Silmek istediğiniz oyuncunun Adını giriniz:");
                    gameManager.Delete(Console.ReadLine());
                }

                else if (choice==6)
                {
                    gameManager.ListGame();
                }

                else if (choice==7)
                {
                    while (true)
                    {
                        Console.WriteLine("**********KAMPANYALAR**********");
                        Console.WriteLine("-1-Öğrenci Kampanyası\n-2-Kara Cuma Kampanyası\n-3-Ana Menüye Dön");
                        Console.WriteLine("*******************************");

                        int choice2 = Convert.ToInt32(Console.ReadLine());

                        if (choice2==1)
                        {
                            gameManager.ListGame();
                            Console.WriteLine("Yukarıdaki oyunlardan öğrencisi kampanyası uygulamak istediğiniz oyunun adını yazınız:");
                            string name = Console.ReadLine();
                            ICampaignService campaign = new StudentCampaign();
                            gameManager.GetGame(name, campaign);
                        }
                        else if (choice2==2)
                        {
                            gameManager.ListGame();
                            Console.WriteLine("Yukarıdaki oyunlardan kara cuma kampanyası uygulamak istediğiniz oyunun adını yazınız:");
                            string name = Console.ReadLine();
                            ICampaignService campaign = new StudentCampaign();
                            gameManager.GetGame(name, campaign);
                        }
                        else
                        {
                            break;
                        }
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
