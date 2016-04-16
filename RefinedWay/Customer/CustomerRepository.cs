using System;

namespace RefinedWay
{

    public class CustomerRepository
    {
        public IValidation<Exception, Customer> GetById(int id)
        {

            if (id < 0)
                return new None<Customer>().ToValidationT<Exception>(new Exception("Customer Id less than zero"));

            return new Just<Customer>(new Customer("Structerre")).ToValidationT<Exception>();
        }
    }

}
