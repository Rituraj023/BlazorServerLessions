using BlazorServerLession1.Models;

namespace BlazorServerLession1.Services
{
    public class CustomerService
    {
        private static readonly List<Customer> customers = new()
        {
            // Initialize with some dummy data
            new Customer { Id = 1, Name = "John Doe", Email = "john@example.com" },
            // Add more customers as needed
        };

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer GetCustomerById(int id)
        {
            return customers.FirstOrDefault(c => c.Id == id) ?? new Customer();
        }

        //public void AddCustomer(Customer customer)
        //{
        //    if (customers.Any())
        //    {
        //        customer.Id = customers.Max(c => c.Id) + 1;
        //    }
        //    else
        //    {
        //        customer.Id = 1;
        //    }
        //    customers.Add(customer);
        //}

        public string AddCustomer(Customer customer)
        {
            // Check if the customer's name is not empty or null
            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                return "Customer name cannot be empty."; // Return a message instead of throwing an exception
            }

            // Assign the new customer ID as latest ID + 1
            customer.Id = customers.Any() ? customers.Max(c => c.Id) + 1 : 1;
            customers.Add(customer);

            return "Customer added successfully."; // Return a success message
        }


        //public void UpdateCustomer(Customer customer)
        //{
        //    var existingCustomer = customers.FirstOrDefault(c => c.Id == customer.Id);
        //    if (existingCustomer != null)
        //    {
        //        existingCustomer.Name = customer.Name;
        //        existingCustomer.Email = customer.Email;
        //        // Update other fields as necessary
        //    }
        //}

        public string UpdateCustomer(Customer customer)
        {
            var existingCustomer = customers.FirstOrDefault(c => c.Id == customer.Id);
            if (existingCustomer == null)
            {
                return "Customer not found."; // Indicate if the customer wasn't found
            }

            // Assuming name validation is also required for updates
            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                return "Customer name cannot be empty."; // Validation message
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            // Update other fields as necessary

            return "Customer updated successfully."; // Success message
        }


        public void DeleteCustomer(int id)
        {
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customers.Remove(customer);
            }
        }
    }
}
