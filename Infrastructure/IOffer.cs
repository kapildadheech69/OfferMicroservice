using OfferMicroservice.Models;
using System.Collections.Generic;

namespace OfferMicroservice.Infrastructure
{
    public interface IOffer
    {
        IEnumerable<Offer> OfferList();
        Offer OfferById(int id);
        IEnumerable<Offer> Post(Offer newOffer);
        Offer Edit(Offer updatedOffer);
        IEnumerable<Offer> OfferByCategory(string category);
        IEnumerable<Offer> OfferByOpenedDate(string openedDate);
        IEnumerable<Offer> OfferByTopThreeLikes();
        Offer Engage(int offerId);
        Offer Like(int offerId);

    }
}
