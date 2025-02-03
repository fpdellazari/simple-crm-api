using AutoMapper;
using SimpleCRM.Domain.Entities;
using SimpleCRM.Domain.Models;
using SimpleCRM.Domain.Repositories;
using SimpleCRM.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Application.Services {
    public class CustomerService : ICustomerService {

        private readonly IMapper _mapper;
        public readonly ICustomerRepository _customerRepository;

        public CustomerService(IMapper mapper, ICustomerRepository customerRepository) {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public IEnumerable<CustomerModel> Get() {
            var customers = _customerRepository.Get();
            var customersModel = _mapper.Map<List<CustomerModel>>(customers);
            return customersModel;
        }

        public void Insert(CustomerModel customerModel) {
            var customer = _mapper.Map<Customer>(customerModel);
            _customerRepository.Insert(customer);
        }

        public void Update(CustomerModel customerModel) {
            var customer = _mapper.Map<Customer>(customerModel);
            _customerRepository.Update(customer);
        }
    }
}
