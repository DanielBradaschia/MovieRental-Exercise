using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using MovieRental.Data;

namespace MovieRental.Rental
{
	public class RentalFeatures : IRentalFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public RentalFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}

		//TODO: make me async :(
		//public Rental Save(Rental rental)
		//{
		//	_movieRentalDb.Rentals.Add(rental);
		//	_movieRentalDb.SaveChanges();
		//	return rental;
		//}

		public async Task<Rental> Save(Rental rental) 
		{
			await _movieRentalDb.Rentals.AddAsync(rental);
			await _movieRentalDb.SaveChangesAsync();

			return rental;
		}

		//TODO: finish this method and create an endpoint for it
		//public IEnumerable<Rental> GetRentalsByCustomerName(string customerName)
		//{
		//	return _movieRentalDb.Rentals.Where(c => c.CustomerName.Equals(customerName));
		//}

        public IEnumerable<Rental> GetRentalsByCustomerName(string customerName)
        {
			var customerRentals = _movieRentalDb.Customers.Find(customerName).Rentals;

			if(customerRentals == null || !customerRentals.Any())
				return Enumerable.Empty<Rental>();

            return customerRentals;
        }

    }
}
