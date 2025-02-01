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
    public class SaleService : ISaleService {

        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;

        public SaleService(IMapper mapper, ISaleRepository saleRepository) {
            _mapper = mapper;
            _saleRepository = saleRepository;
        }

        public IEnumerable<SaleModel> Get() {
            var sales = _saleRepository.Get();
            return _mapper.Map<List<SaleModel>>(sales);
        }

        public void Insert(SaleModel saleModel) {
            var sale = _mapper.Map<Sale>(saleModel);
            _saleRepository.Insert(sale);
        }
    }
}
