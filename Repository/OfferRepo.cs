using OfferMicroservice.Infrastructure;
using OfferMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OfferMicroservice.Repository
{
    public class OfferRepo : IOffer
    {
        private static List<Offer> offers = new List<Offer>
            {
                 new Offer { employeeId=101,offerId = 1, status = "Available", likes = 10, category = "Electronics", openedDate =new DateTime(2022,05,01), details="Resale of Mobile",closedDate=new DateTime(),engagedDate=new DateTime()},

                 new Offer { employeeId=102,offerId = 2, status = "Engaged", likes = 55, category = "Electronics", openedDate = new DateTime(2022,05,04),closedDate=new DateTime() , details="Resale of washing machine",engagedDate=new DateTime(2022,05,08)},

                 new Offer { employeeId=103,offerId = 3, status = "Engaged", likes = 20, category = "Pets", openedDate = new DateTime(2022,05,04),closedDate=new DateTime() , details="Golden Retriever for Adoption",engagedDate=new DateTime(2022,05,09)},

                 new Offer { employeeId=103,offerId = 4, status = "Available", likes = 25, category = "Electronics", openedDate = new DateTime(2022,05,09),closedDate=new DateTime() , details="Resale of Mobile",engagedDate=new DateTime()},

                 new Offer { employeeId=103,offerId = 5, status = "Available", likes = 10, category = "Electronics", openedDate = new DateTime(2022,05,09),closedDate=new DateTime() , details="Resale of Laptop",engagedDate=new DateTime()},

                 new Offer { employeeId=103,offerId = 6 ,status = "Closed", likes = 24, category = "Books", openedDate = new DateTime(2022,05,09),engagedDate=new  DateTime(2022,05,09), closedDate=new DateTime(2022,05,10),details="Wings Of Fire"},

                 new Offer {employeeId=104,offerId = 7, status = "Available", likes = 25, category = "Pets", openedDate =new DateTime(2022,05,18), details="Schitzu for Adoption",closedDate=new DateTime(),engagedDate=new DateTime()},

                 new Offer { employeeId=105,offerId = 8, status = "Engaged", likes = 22, category = "Electronics", openedDate = new DateTime(2022,04,04),closedDate=new DateTime() , details="Resale of Mobile",engagedDate=new DateTime(2022,04,06)},

                 new Offer { employeeId=105,offerId = 9, status = "Closed", likes = 18, category = "Books", openedDate = new DateTime(2022,05,01),engagedDate=new  DateTime(2022,05,03), closedDate=new DateTime(2022,05,05),details="Harry Potter Books"},

            };
        public OfferRepo()
        {

        }
        public Offer Edit(Offer updatedOffer)
        {
            Offer offer = offers.FirstOrDefault(c => c.offerId == updatedOffer.offerId && c.employeeId == updatedOffer.employeeId);
            return offer;
        }

        public Offer Engage(int offerId)
        {
            Offer offer = offers.FirstOrDefault(c => c.offerId == offerId);
            return offer;
        }

        public Offer Like(int offerId)
        {
            Offer offer = offers.FirstOrDefault(c => c.offerId == offerId);
            return offer;
        }

        public IEnumerable<Offer> OfferByCategory(string category)
        {
            var offer = from c in offers where c.category == category select c;
            return offer;
        }

        public Offer OfferById(int id)
        {
            var offer = offers.FirstOrDefault(c => c.offerId == id);
            return offer;
        }

        public IEnumerable<Offer> OfferByOpenedDate(string openedDate)
        {
            var offer = from c in offers where c.openedDate.ToString("dd-MM-yyyy") == openedDate select c;
            return offer;
        }

        public IEnumerable<Offer> OfferByTopThreeLikes()
        {
            var offer = (from c in offers where 1 == 1 orderby c.likes descending select c).Take(3);
            return offer;
        }

        public IEnumerable<Offer> OfferList()
        {
            return offers;
        }

        public IEnumerable<Offer> Post(Offer newOffer)
        {
            if (newOffer.offerId == 0 || newOffer.employeeId == 0 || newOffer.category == null || newOffer.details == null)

            {
                return offers;
            }
            else
            {
                newOffer.openedDate = DateTime.Now;
                newOffer.engagedDate = new DateTime();
                newOffer.closedDate = new DateTime();
                offers.Add(newOffer);
            }

            return offers;
        }
    }
}
