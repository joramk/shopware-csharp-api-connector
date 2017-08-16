using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Payments
{
    public class Payment
    {
        public int? id;
        public string name;
        public string description;
        public string template;
        public string @class;
        public string table;
        public bool hide;
        public string additionalDescription;
        public double? debitPercent;
        public double? surcharge;
        public string surchargeString;
        public int? position;
        public bool? active;
        public bool? esdActive;
        public bool? mobileInactive;
        public string embedIFrame;
        public int? hideProspect;
        public string action;
        public int? pluginId;
        public string source;
        public string attribute;
    }

    public class PaymentInstances
    {
        public string firstName;
        public string lastName;
        public string address;
        public string zipCode;
        public string city;
        public string bankName;
        public string bankCode;
        public string accountNumber;
        public string accountName;
        public string bic;
        public string iban;
        public string amount;
        public string createdAt;
        public int? id;
    }
}
