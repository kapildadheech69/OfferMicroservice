using System;

namespace OfferMicroservice.Models
{
    public class Offer
    {

        public int offerId { get; set; }

        public int employeeId { get; set; }

        public string status { get; set; }

        public int likes { get; set; }

        public string category { get; set; }

        public string details { get; set; }

        public DateTime openedDate { get; set; }

        public DateTime engagedDate { get; set; }

        public DateTime closedDate { get; set; }

    }
}
