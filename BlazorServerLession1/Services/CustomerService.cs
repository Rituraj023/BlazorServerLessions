using BlazorServerLession1.Data;
using BlazorServerLession1.Models;

namespace BlazorServerLession1.Services
{
    public class CustomerService
    {
        

        public IEnumerable<Customer> GetAllCustomers()
        {
            return CustomerData.customers;
        }

        public Customer GetCustomerById(int id)
        {
            return CustomerData.customers.FirstOrDefault(c => c.Id == id) ?? new Customer();
        }

        //public void AddCustomer(Customer customer)
        //{
        //    if (customers.Any())
        //    {
        //        customer.Id = CustomerData.customers.Max(c => c.Id) + 1;
        //    }
        //    else
        //    {
        //        customer.Id = 1;
        //    }
        //    CustomerData.customers.Add(customer);
        //}

        public string AddCustomer(Customer customer)
        {
            // Check if the customer's name is not empty or null
            if (string.IsNullOrWhiteSpace(customer.Name))
            {
                return "Customer name cannot be empty."; // Return a message instead of throwing an exception
            }

            // Assign the new customer ID as latest ID + 1
            customer.Id = CustomerData.customers.Any() ? CustomerData.customers.Max(c => c.Id) + 1 : 1;
            CustomerData.customers.Add(customer);

            return "Customer added successfully."; // Return a success message
        }


        //public void UpdateCustomer(Customer customer)
        //{
        //    var existingCustomer = CustomerData.customers.FirstOrDefault(c => c.Id == customer.Id);
        //    if (existingCustomer != null)
        //    {
        //        existingCustomer.Name = CustomerData.customers.Name;
        //        existingCustomer.Email = CustomerData.customers.Email;
        //        // Update other fields as necessary
        //    }
        //}

        public string UpdateCustomer(Customer customer)
        {
            var existingCustomer = CustomerData.customers.FirstOrDefault(c => c.Id == customer.Id);
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
            var customer = CustomerData.customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                CustomerData.customers.Remove(customer);
            }
        }
    }
}
