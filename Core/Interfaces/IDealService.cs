using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IDealService
    {
        Deal CreateDeal(Deal deal);
        Deal UpdateDeal(string dealId, Deal deal);
        void EndDeal(string dealId);
        Item ClaimDeal(string dealId, string userId );
    }
}
