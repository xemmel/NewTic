using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using TicItNow.Web.Models;

namespace TicItNow.Web.Controllers
{
    public class SubscriptionApiController : ApiController
    {
        private TICDataContext db = new TICDataContext();

        // GET api/SubscriptionApi
        public IEnumerable<Subscription> GetSubscriptions()
        {
            return db.Subscriptions.AsEnumerable();
        }

        // GET api/SubscriptionApi/5
        public Subscription GetSubscription(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return subscription;
        }

        // PUT api/SubscriptionApi/5
        public HttpResponseMessage PutSubscription(int id, Subscription subscription)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != subscription.SubscriptionId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(subscription).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/SubscriptionApi
        public HttpResponseMessage PostSubscription(Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                db.Subscriptions.Add(subscription);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, subscription);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = subscription.SubscriptionId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/SubscriptionApi/5
        public HttpResponseMessage DeleteSubscription(int id)
        {
            Subscription subscription = db.Subscriptions.Find(id);
            if (subscription == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Subscriptions.Remove(subscription);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, subscription);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}