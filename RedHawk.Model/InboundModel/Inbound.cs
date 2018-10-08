using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RedHawk.Model.AccountModel;

namespace RedHawk.Model.InboundModel
{
    public class InboundModel
    {
        public int CompanyId { get; set; }
        public int CeaXmlId { get; set; }
        public string CompanionPolicyNumber { get; set; }
        public int PolicyId { get; set; }
        public string PolicyNumber { get; set; }
        public string FileName { get; set; }
        public string TransactionType { get; set; }
        public string ProcessingStatus { get; set; }//edit this column (drop down) 
        public string PolicyExpirationDate { get; set; }
        public string PolicyEffectiveDate { get; set; }
        public InboundXmlViewModel.Policy_transaction_group InboundXml { get; set; }
        public  string InboundXMLString { get; set; }
    }
    public class InboundEditModel
    {
        public int CeaXmlId { get; set; }

        public string InboundXml { get; set; }
    }


}