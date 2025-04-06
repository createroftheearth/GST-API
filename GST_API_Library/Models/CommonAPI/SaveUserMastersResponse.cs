using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.CommonAPI
{
    public class SaveUserMastersResponse
    {
        public string userGstin { get; set; }
        public List<ProductsMaster1> productsMasters { get; set; }
        public List<ProductsWithError> productsWithError { get; set; }
        public List<SupplierRecipientMaster1> supplierRecipientMasters { get; set; }
        public List<SupplierRecipientsWithError> supplierRecipientsWithError { get; set; }
    }

    public class ProductsMaster1
    {
        public string productName { get; set; }
        public string hsn { get; set; }
        public string productDescription { get; set; }
        public int igst { get; set; }
        public double cgst { get; set; }
        public double sgst { get; set; }
        public string uqc { get; set; }
    }

    public class ProductsWithError
    {
        public string productName { get; set; }
        public string hsn { get; set; }
        public int igst { get; set; }
        public string errMsg { get; set; }
        public string errCd { get; set; }
    }
    public class SupplierRecipientMaster1
    {
        public string gstin { get; set; }
        public string supplierRecipientName { get; set; }
        public string legalName { get; set; }
        public string tradeName { get; set; }
        public string supplierRecipientFlag { get; set; }
        public string registrationStatus { get; set; }
        public string taxpayerType { get; set; }
    }

    public class SupplierRecipientsWithError
    {
        public string gstin { get; set; }
        public string supplierRecipientName { get; set; }
        public string supplierRecipientFlag { get; set; }
        public string errMsg { get; set; }
        public string errCd { get; set; }
    }

}
