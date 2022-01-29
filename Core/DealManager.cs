using Core.Interfaces;
using Services;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class DealManager : IDealManager
    {
        private Dictionary<string, Deal> _deals;
        private Dictionary<string, Item> _items;
        private Dictionary<string, List<string>> _dealUserMapping;

        public DealManager()
        {
            _deals = new Dictionary<string, Deal>();
            _items = new Dictionary<string, Item>
            {
                { "123", new Item { Id = "123", Name = "item1", Price = 234.54 } },
                { "234", new Item { Id = "234", Name = "item2", Price = 234.54 } },
                { "456", new Item { Id = "456", Name = "item3", Price = 234.54 } },
                { "678", new Item { Id = "678", Name = "item4", Price = 234.54 } },
            };
            _dealUserMapping = new Dictionary<string, List<string>>();
        }

        public Item ClaimDeal(string dealId, string userId)
        {
            if (!_deals.ContainsKey(dealId))
            {
                throw new Exception($"Deal does not exists with Id: {dealId}");
            }

            if (_dealUserMapping.ContainsKey(dealId))
            {
                var userList = _dealUserMapping[dealId];
                if(userList.Any(x => x.Equals(userId, StringComparison.OrdinalIgnoreCase)))
                {
                    throw new Exception("User already claimed this deal");
                }
            }

            if (!_deals[dealId].IsActive.Value)
            {
                throw new Exception("Deal is not Active");
            }
            var deal = _deals[dealId];
            var itemId = deal.ItemId;
            deal.NumberOfItems -= 1;

            if (_dealUserMapping.ContainsKey(dealId))
            {
                _dealUserMapping[dealId].Add(userId);
            }
            else
            {
                _dealUserMapping.Add(dealId, new List<string> { userId });
            }

            if (!_items.ContainsKey(itemId))
            {
                throw new Exception("No Item Exists with the given ItemId");
            }

            return _items[itemId];
        }

        public Deal CreateDeal(Deal deal)
        {
            var id = Guid.NewGuid().ToString();
            deal.Id = id;
            _deals.Add(id, deal);

            return deal;
        }

        public void EndDeal(string dealId)
        {
            if (_deals.ContainsKey(dealId))
            {
                _deals[dealId].IsActive = false;
            }
            else
            {
                throw new Exception($"Deal does not exists wit Id: {dealId}");
            }
        }

        public Deal UpdateDeal(Deal deal)
        {
            if (!_deals.ContainsKey(deal.Id))
            {
                throw new Exception($"Deal does not exists wit Id: {deal.Id}");
            }

            _deals[deal.Id] = deal;
            return deal;
        }
    }
}
