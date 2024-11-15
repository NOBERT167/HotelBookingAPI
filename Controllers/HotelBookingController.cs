using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBookingAPI.Models;
using HotelBookingAPI.Data;

namespace HotelBookingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HotelBookingController : ControllerBase
	{
		private readonly MyDbContext _context;
		public HotelBookingController(MyDbContext context)
		{
			_context = context;
		}

		//Create/edit 
		[HttpPost]
		public JsonResult CreateEdit(HotelBooking booking)
		{
			if (booking.Id == 0)
			{
				_context.Bookings.Add(booking);
			}
			else
			{
				var BookingInDb = _context.Bookings.Find(booking.Id);
				if (BookingInDb == null)
				{
					return new JsonResult("Not Found");
				} else
				{
					BookingInDb = booking;
				}
			}
			_context.SaveChanges();
			return new JsonResult(Ok(booking));
		}

		//Get All
		[HttpGet("All")]
		public JsonResult Get()
		{
			var results = _context.Bookings.ToList();
			if (results == null)
				return new JsonResult("Not Bookings Found");
			return new JsonResult(results);
		}

		//Get By Id
		[HttpGet("{id}")]
		public JsonResult Get(int id)
		{
			var results = _context.Bookings.Find(id);
			if (results == null)
			{
				return new JsonResult($"User with id: {id} not Found");
			}
			return new JsonResult(results);
		}

		//Delete
		[HttpDelete]
		public JsonResult Delete(int id)
		{
			var results = _context.Bookings.Find(id);
			if (results == null)
			{
				return new JsonResult($"User with id: {id} not Found");
			}
			_context.Bookings.Remove(results);
			_context.SaveChanges();
			return new JsonResult("Deleted");
		}
		
	}
}
