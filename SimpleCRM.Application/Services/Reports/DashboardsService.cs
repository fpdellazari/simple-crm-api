using AutoMapper;
using SimpleCRM.Domain.Models;
using SimpleCRM.Domain.Models.Reports;
using SimpleCRM.Domain.Repositories;
using SimpleCRM.Domain.Repositories.Reports;
using SimpleCRM.Domain.Services.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Application.Services.Reports {
    public class DashboardsService : IDashboardsService {

        private readonly IMapper _mapper;
        public readonly IDashboardsRepository _dashboardsRepository;

        public DashboardsService(IMapper mapper, IDashboardsRepository dashboardsRepository) {
            _mapper = mapper;
            _dashboardsRepository = dashboardsRepository;
        }

        public OverviewReport Get() {
            var overviewReport = _dashboardsRepository.Get();
            return overviewReport;
        }

    }
}
