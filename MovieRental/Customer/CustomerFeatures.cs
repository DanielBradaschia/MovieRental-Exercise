using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Customer
{
    public class CustomerFeatures : ICustomerFeatures
    {
        private readonly MovieRentalDbContext _movieRentalDb;
        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _movieRentalDb.Customers.ToListAsync();

            return customers;
        }
    }
}
