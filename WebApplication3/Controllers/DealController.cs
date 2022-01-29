using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("v1.0/deals")]
    public class DealController : ControllerBase
    {
        private readonly IDealService _dealService;
        public DealController(IDealService dealService)
        {
            _dealService = dealService;
        }

        [HttpPost]
        [Route("items/{itemId}")]
        public IActionResult CreateDeal([FromBody]Deal deal, string itemId)
        {
            deal.ItemId = itemId;
            var response = _dealService.CreateDeal(deal);
            return Ok(response);
        }

        [HttpPut]
        [Route("{dealId}/items/{itemId}")]
        public IActionResult UpdateDeal(string dealId, [FromBody] Deal deal, string itemId)
        {
            deal.ItemId = itemId;
            var response = _dealService.UpdateDeal(dealId, deal);
            return Ok(response);
        }

        [HttpDelete]
        [Route("{dealId}")]
        public IActionResult DelateDeal(string dealId)
        {
            _dealService.EndDeal(dealId);
            return Ok();
        }

        [HttpGet]
        [Route("{dealId}/users/{userId}")]
        public IActionResult ClaimDeal(string dealId, string userId)
        {
            var response = _dealService.ClaimDeal(dealId, userId);
            return Ok(response);
        }
    }
}
