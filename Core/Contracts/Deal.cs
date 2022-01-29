using System;

namespace Services
{
    public class Deal
    {
        public string Id { get; set; }
        public string ItemId { get; set; }
        public int NumberOfItems { get; set; }
        public bool? IsActive { get; set; }
    }
}
