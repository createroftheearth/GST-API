﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GST_API_Library.Models.GSTR2A
{
    public class GetTCSCreditGSTR2A
    {
        public List<TcsDatum> tcs_data { get; set; }
    }

    public class TcsDatum
    {
        public string chksum { get; set; }
        public string etin { get; set; }
        public string m_id { get; set; }
        public double sup_val { get; set; }
        public double tx_val { get; set; }
        public double irt { get; set; }
        public int iamt { get; set; }
        public double crt { get; set; }
        public double camt { get; set; }
        public double srt { get; set; }
        public double samt { get; set; }
        public int csrt { get; set; }
        public int csamt { get; set; }
    }

}
