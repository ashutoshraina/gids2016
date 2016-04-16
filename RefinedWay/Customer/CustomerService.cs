using System;

namespace RefinedWay
{

    public class CustomerService
    {
        CustomerRepository customerRepository;

        public CustomerService(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;

        }

        public void Delete(int id)
        {
            customerRepository.GetById(id)
                .SelectMany(x => SendEmail(x).SelectMany(y => LogResult(y)));

        }

        public IValidation<Exception, Customer> LogResult(Customer c)
        {
            Console.WriteLine("Deleting: " + c.Name);
            return new ValidationSuccess<Exception, Customer>(c);
            //return new ValidationError<Exception, Customer>(new Exception("Unable write log"));
        }

        private IValidation<Exception, Customer> SendEmail(Customer c)
        {
            Console.WriteLine("Emailing: " + c.Name);
            return new ValidationSuccess<Exception, Customer>(c);
        }

    }

}
