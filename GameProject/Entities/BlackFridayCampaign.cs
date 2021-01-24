using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    class BlackFridayCampaign : ICampaignService
    {
        public void CalculateSale(Game game)
        {
            game.GamePrice -= game.GamePrice * (0.15);
        }

        public void SaleInformation(Game game)
        {
            Console.WriteLine("{0} isimli oyuna kara cuma kampanyası uygulandı.\nYeni Fiyat:{1} TL\n", game.GameName, game.GamePrice);
        }
    }
}
