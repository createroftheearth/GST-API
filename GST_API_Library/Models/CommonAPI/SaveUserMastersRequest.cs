using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.CommonAPI
{
    public class SaveUserMastersRequest
    {
        public string userGstin { get; set; }
        public List<ProductsMaster> productsMasters { get; set; }
        public List<SupplierRecipientMaster> supplierRecipientMasters { get; set; }
    }
    public class ProductsMaster
    {
        public string hsn { get; set; }
        public string uqc { get; set; }
        public int igst { get; set; }
        public string productName { get; set; }
        public string actionFlag { get; set; }
    }

    public class SupplierRecipientMaster
    {
        public string gstin { get; set; }
        public string supplierRecipientName { get; set; }
        public string supplierRecipientFlag { get; set; }
        public string actionFlag { get; set; }
    }
}
