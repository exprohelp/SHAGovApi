using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SHAGovWebApi.Models
{
   
        public class dataSet
        {
            public string Msg { get; set; }
            public DataSet ResultSet { get; set; }
        }
        public class ipMemberKey
        {
            public string  pmrssm_id { get; set; }
            public string  AuthKey { get; set; }
        }
    public class SyncChandanPatientData
    {
        public string SGHS_Card { get; set; }
        public string abhaNo { get; set; }
        public string claim_id { get; set; }
        public string visit_id { get; set; }
        public string benef_Name { get; set; }
        public string tyepOfEmployee { get; set; }
        public string empcode { get; set; }
        public DateTime d_o_b { get; set; }
        public string depttCode { get; set; }
        public string depttName { get; set; }
        public string tres_code { get; set; }
        public string tres_Name { get; set; }
        public decimal totalcost { get; set; }
        public decimal discount { get; set; }
        public decimal net { get; set; }
        public string billFile { get; set; }
        public string prescrFile { get; set; }
        public string vendorID { get; set; }
        public string PayVendSyncFlag { get; set; }
        public DateTime PayVendSyncDate { get; set; }
    }
}