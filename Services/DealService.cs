using Core.Interfaces;
using FluentValidation;
using Services.Contracts;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class DealService : IDealService
    {
        private readonly IValidator<Deal> _validator;
        private readonly IDealManager _dealManager;

        public DealService(IValidator<Deal> validator, IDealManager dealManager)
        {
            _validator = validator;
            _dealManager = dealManager;
        }

        public Item ClaimDeal(string dealId, string userId)
        {
            if (string.IsNullOrWhiteSpace(dealId))
            {
                throw new Exception($"Mandatory Field: dealId");
            }

            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new Exception($"Mandatory Field: userId");
            }

            return _dealManager.ClaimDeal(dealId, userId);
        }

        public Deal CreateDeal(Deal deal)
        {
            var validationResult = _validator.Validate(deal);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            return _dealManager.CreateDeal(deal);
        }

        public void EndDeal(string dealId)
        {
            if (string.IsNullOrWhiteSpace(dealId))
            {
                throw new Exception($"Mandatory Field: dealId");
            }

            _dealManager.EndDeal(dealId);
        }

        public Deal UpdateDeal(string dealId, Deal deal)
        {
            if (string.IsNullOrWhiteSpace(dealId))
            {
                throw new Exception($"Mandatory Field: dealId");
            }

            var validationResult = _validator.Validate(deal);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            deal.Id = dealId;
            return _dealManager.UpdateDeal(deal);
        }
    }
}
