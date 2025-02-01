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
    public class ContactHistoryService : IContactHistoryService {

        private readonly IMapper _mapper;
        public readonly IContactHistoryRepository _contactHistoryRepository;

        public ContactHistoryService(IMapper mapper, IContactHistoryRepository contactHistoryRepository) {
            _mapper = mapper;
            _contactHistoryRepository = contactHistoryRepository;
        }

        public IEnumerable<ContactHistoryModel> Get() {
            var contactHistories = _contactHistoryRepository.Get();
            var contactHistoriesModel = _mapper.Map<List<ContactHistoryModel>>(contactHistories);
            return contactHistoriesModel;
        }

        public void Insert(ContactHistoryModel contactHistoryModel) {
            var ContactHistory = _mapper.Map<ContactHistory>(contactHistoryModel);
            _contactHistoryRepository.Insert(ContactHistory);
        }
    }
}
