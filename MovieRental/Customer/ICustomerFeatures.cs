namespace MovieRental.Customer;

public interface ICustomerFeatures
{
    Task<IEnumerable<Customer>> GetAll();

}