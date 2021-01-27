using System;
using System.Collections.Generic;
using System.Text;

namespace GameProject
{
    interface ICampaignService
    {
        void CalculateSale(Game game);
        void SaleInformation(Game game);
    }
}
