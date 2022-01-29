using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IDealManager
    {
        Deal CreateDeal(Deal deal);
        Deal UpdateDeal(Deal deal);
        void EndDeal(string dealId);
        Item ClaimDeal(string dealId, string userId);
    }
}
