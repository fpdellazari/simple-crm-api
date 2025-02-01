using SimpleCRM.Domain.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Domain.Services.Reports {
    public interface IDashboardsService {
        OverviewReport Get();
    }
}
