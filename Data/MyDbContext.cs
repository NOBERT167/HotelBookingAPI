using Microsoft.EntityFrameworkCore;
using HotelBookingAPI.Models;

namespace HotelBookingAPI.Data
{
	public class MyDbContext: DbContext //Inheritance
	{
		public DbSet<HotelBooking> Bookings { get; set; }
		public MyDbContext(DbContextOptions<MyDbContext> options) //Contructor
		: base (options)
		{

		}
	
	}
}
