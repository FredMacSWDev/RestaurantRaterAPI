using RestaurantRaterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRaterAPI.Controllers
{
    public class RatingController : ApiController
    {
        private readonly RestaurantDBContext _context = new RestaurantDBContext();

        [HttpPost]
        public async Task<IHttpActionResult> PostRating(Rating model)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Restaurant restaurant = await _context.Restaurants.FindAsync(model.RestaurantID);
            if (restaurant == null)
            {
                return BadRequest($"The target restaurant with the ID of {model.RestaurantID} does not exist.");
            }

            _context.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
            {
                return Ok($"You've rated {restaurant.Name} successfully!");
            }

            return InternalServerError();
        }

        // GetAllRatings?
        // GetRatingsByID?
        // Get Rating by Restaurant ID?

        // Update Rating

        // Delete Rating
    }
}
