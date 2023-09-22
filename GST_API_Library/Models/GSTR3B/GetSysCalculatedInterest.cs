using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GST_API_Library.Models.GSTR3B
{
    public class GetSysCalculatedInterest
    {
        public string gstin { get; set; }
        public string ret_period { get; set; }
        public string filed_period { get; set; }
        public string filingdt { get; set; }
        public string computedt { get; set; }
        public Txpay txpay { get; set; }
        public Pdcash pdcash { get; set; }
        public Pditc pditc { get; set; }
        public Interest interest { get; set; }
        public List<Interestbreakup> interestbreakup { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Challan
    {
        public string ret_period { get; set; }
        public Pdcash pdcash { get; set; }
    }

    public class Interest
    {
        public int iamt { get; set; }
        public int samt { get; set; }
        public int camt { get; set; }
        public int csamt { get; set; }
    }

    public class Interestbreakup
    {
        public string ret_period { get; set; }
        public string profile { get; set; }
        public string duedate { get; set; }
        public int aato { get; set; }
        public string aato_final_flag { get; set; }
        public string aato_fy { get; set; }
        public string not_name { get; set; }
        public string not_dt { get; set; }
        public Txpay txpay { get; set; }
        public TxpayDeclared txpay_declared { get; set; }
        public List<Challan> challan { get; set; }
        public List<Rate> rates { get; set; }
    }

    public class Pdcash
    {
        public int iamt { get; set; }
        public int samt { get; set; }
        public int camt { get; set; }
        public int csamt { get; set; }
    }

    public class Pditc
    {
        public int iamt { get; set; }
        public int samt { get; set; }
        public int camt { get; set; }
        public int csamt { get; set; }
    }

    public class Rate
    {
        public string start_dt { get; set; }
        public string end_dt { get; set; }
        public int rate { get; set; }
        public int delay { get; set; }
        public Interest interest { get; set; }
    }

    public class Txpay
    {
        public int iamt { get; set; }
        public int samt { get; set; }
        public int camt { get; set; }
        public int csamt { get; set; }
    }

    public class TxpayDeclared
    {
        public int iamt { get; set; }
        public int samt { get; set; }
        public int camt { get; set; }
        public int csamt { get; set; }
    }


}
