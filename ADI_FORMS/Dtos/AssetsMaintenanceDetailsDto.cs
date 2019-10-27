using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.Dtos
{
    public class AssetsMaintenanceDetailsDto
    {
        public int Id { get; set; }
        public FixedAssetDto FixedAsset { get; set; }
        public int FixedAssetId { get; set; }
        public string MaintenanceSupervisor { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string Maint_Description { get; set; }
        public long? GLDebit { get; set; }
        public long? GLCredit { get; set; }
    }
}