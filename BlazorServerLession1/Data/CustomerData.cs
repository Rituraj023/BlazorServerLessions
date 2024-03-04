using BlazorServerLession1.Models;

namespace BlazorServerLession1.Data
{
    public class CustomerData
    {
        public static readonly List<Customer> customers = new()
        {
            // Initialize with some dummy data
            new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" },
            // Add more customers as needed
        };
    }
}
