using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferMicroservice.Infrastructure;
using OfferMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfferMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OfferController : ControllerBase
    {
        private readonly IOffer _offer;
        public OfferController(IOffer offer)
        {
            _offer = offer;
        }


        // GET: api/<OfferController>
        [HttpGet]
        [Route("GetOffersList")]
        public IEnumerable<Offer> GetOffersList()
        {
            var offers = _offer.OfferList();
            return offers;
        }

        // GET api/<OfferController>/5
        [HttpGet]
        [Route("GetOfferById/{id}")]
        public ActionResult<Offer> GetOfferById(int id)
        {

            var offer = _offer.OfferById(id);
            if (offer == null)
            {
                return NotFound();
            }

            return offer;

        }

        // POST api/<OfferController>
        [HttpPost]
        [Route("PostOffer")]
        public ActionResult<IEnumerable<Offer>> PostOffer(Offer newOffer)
        {
            var offers = _offer.Post(newOffer);

            return Ok(offers);
        }

        // PUT api/<OfferController>/5
        [HttpPost]
        [Route("EditOffer")]

        public ActionResult<Offer> EditOffer(Offer updatedOffer)

        {

            Offer offer = _offer.Edit(updatedOffer);
            if (offer == null)
            {
                return NotFound("Offer not found");
            }



            //offer.closedDate = updatedOffer.closedDate;

            //offer.status = updatedOffer.status;

            offer.details = updatedOffer.details;

            offer.category = updatedOffer.category;

            //if (offer.closedDate > offer.engagedDate && offer.status != "Closed")
            //{
            //return BadRequest("Please update status to Closed");
            //}

            return Ok(offer);

            //return offers;

        }




        [HttpGet]
        [Route("GetOfferByCategory/{category}")]
        public ActionResult<Offer> GetOfferByCategory(string category)
        {

            var offer = _offer.OfferByCategory(category);
            if (offer.Count() == 0)
            {
                return NotFound();
            }
            return Ok(offer); // results in 200 ok status 

        }

        [HttpGet]
        [Route("GetOfferByOpenedDate/{openedDate}")]
        public ActionResult<Offer> GetOfferByOpenedDate(string openedDate)
        {

            var offer = _offer.OfferByOpenedDate(openedDate);
            if (offer.Count() == 0)
            {
                return NotFound();
            }
            return Ok(offer); // results in 200 ok status 

        }


        [HttpGet]
        [Route("GetOfferByTopThreeLikes")]
        public ActionResult<Offer> GetOfferByTopThreeLikes()
        {

            var offer = _offer.OfferByTopThreeLikes();
            if (offer.Count() == 0)
            {
                return NotFound();
            }
            return Ok(offer); // results in 200 ok status 

        }

        [HttpPost]
        [Route("EngageOffer/{offerId}")]
        public ActionResult EngageOffer(int offerId)
        {
            //Offer o = new Offer();
            //o.OfferId = offerDetails.OfferId;
            //o.EmployeeId = offerDetails.EmployeeId;

            Offer offer = _offer.Engage(offerId);
            if (offer == null)
            {
                return NotFound("Offer not found");
            }
            else if (offer.status == "Engaged" || offer.status == "Closed")
            {

                return BadRequest("Offer is either Engaged or Closed");
            }

            else
            {

                //Note : Display Status as Engaged in ViewBag in Views

                offer.status = "Engaged";
                offer.engagedDate = DateTime.Now;
                return Ok();
                //return offers;
            }

        }
        [HttpGet]
        [Route("EditOfferList")]
        public ActionResult<Offer> EditOfferList(Offer offer)
        {
            //Offer o = new Offer();
            //o.OfferId = offerDetails.OfferId;
            //o.EmployeeId = offerDetails.EmployeeId;

            offer.employeeId = Convert.ToInt32(HttpContext.Session.GetInt32("EmployeeId"));


            //Offer offerObj = offers.FirstOrDefault(c => c.OfferId == offer.OfferId && c.EmployeeId == offer.EmployeeId);
            /*
             if (offerObj == null)
             {
                 return NotFound("Offer not found");
             }
            */

            return offer;


        }
        [HttpPost]
        [Route("LikeOffer/{offerid}")]
        public ActionResult LikeOffer(int offerid)
        {


            // Like like = new Like();

            Offer offer = _offer.Like(offerid);
            if (offer == null)
            {
                return NotFound("Offer not found");
            }

            else
            {

                //Note : Display Status as Engaged in ViewBag in Views

                offer.likes = offer.likes + 1;
                //like.OfferId = o.OfferId;
                //like.LikeDate = DateTime.Now;
                //Likes.Add(like);

                return Ok();
                //return offers;
            }

        }
        // DELETE api/<OfferController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
