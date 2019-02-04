using System;
using System.Linq;
using System.Collections.Generic;
using Entities;

namespace Stefanini.Models
{
    public class CustomerList
    {
        public CustomerList()
        {
            this.Customers = new List<Customer>();
            this.Search = new Search();
        }
        public CustomerList(IEnumerable<Customer> customers)
            : this()
        {
            if(customers != null)
            {
                this.Customers.AddRange(customers.Select(c => c));
            }
        }

        public Search Search { get; set; }
        public List<Customer> Customers { get; set; }
    }
}