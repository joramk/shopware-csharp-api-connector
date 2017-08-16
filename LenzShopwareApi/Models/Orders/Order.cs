using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Orders
{
    public class Dispatch
    {
        public int? id;
        public string name;
        public int? type;
        public string description;
        public string comment;
        public bool? active;
        public int? position;
        public int? calculation;
        public int? surchargeCalculation;
        public int? taxCalculation;
        public bool? shippingFree;
        public int? multiShopId;
        public int? customerGroupId;
        public int? bindShippingFree;
        public int? bindTimeFrom;
        public int? bindTimeTo;
        public int? bindInStock;
        public int? bindLastStock;
        public int? bindWeekdayFrom;
        public int? bindWeekdayTo;
        public int? bindWeightFrom;
        public string bindWeightTo;
        public string bindPriceFrom;
        public string bindPriceTo;
        public string bindSql;
        public string statusLink;
        public string calculationSql;
        public string attribute;
    }

    public class Status
    {
        public int? id;
        public string name;
        public string description;
        public int? position;
        public string group;
        public bool sendMail;
    }

    public class DocumentType
    {
        public int? id;
        public string name;
        public string template;
        public string numbers;
        public int left;
        public int right;
        public int top;
        public int bottom;
        public int pageBreak;
    }

    public class DocumentAttribute
    {
        public int? id;
        public int? documentId;
    }

    public class Document
    {
        public int? id;
        public string date;
        public int? typeId;
        public int? customerId;
        public int? orderId;
        public double amount;
        public int? documentId;
        public string hash;
        public DocumentType type;
        public DocumentAttribute attribute;
    }

    public class OrderDetailAttributes
    {
        public int? id;
        public int? orderDetailId;
        public string attribute1;
        public string attribute2;
        public string attribute3;
        public string attribute4;
        public string attribute5;
        public string attribute6;
    }

    public class Detail
    {
        public int? id;                 // primary key
        public int? orderId;
        public int? articleId;
        public int? taxId;
        public double taxRate;
        public int? statusId;
        public string number;
        public string articleNumber;
        public double price;
        public int quantity;
        public string articleName;
        public bool shipped;
        public int? shippedGroup;
        public string releaseDate;
        public int? mode;
        public int? esdArticle;
        public string config;
        public string ean;
        public string unit;
        public string packUnit;
        public OrderDetailAttributes attribute;
    }

    public class BillingAttributes
    {
        public int? id;
        public int? orderBillingId;
        public string text1;
        public string text2;
        public string text3;
        public string text4;
        public string text5;
        public string text6;
    }

    public class ShippingAttributes
    {
        public int? id;
        public int? orderShippingId;
        public string text1;
        public string text2;
        public string text3;
        public string text4;
        public string text5;
        public string text6;
    }

    public class OrderAttributes
    {
        public int? id;
        public int? orderId;
        public string attribute1;
        public string attribute2;
        public string attribute3;
        public string attribute4;
        public string attribute5;
        public string attribute6;
    }

    public class BillingAddress
    {
        public string title;
        public string additionalAddressLine1;
        public string additionalAddressLine2;
        public int? id;
        public int? orderId;
        public int? customerId;
        public int? countryId;
        public int? stateId;
        public string company;
        public string department;
        public string salutation;
        public string number;
        public string firstName;
        public string lastName;
        public string street;
        // public string streetNumber;
        public string zipCode;
        public string city;
        public string phone;
        public string fax;
        public string vatId;
        public Customers.Country country;
        public Customers.State state;
        public BillingAttributes attribute;
    }

    public class ShippingAddress
    {
        public string title;
        public string additionalAddressLine1;
        public string additionalAddressLine2;
        public int? id;
        public int? orderId;
        public int? customerId;
        public int? countryId;
        public int? stateId;
        public string company;
        public string department;
        public string salutation;
        public string number;
        public string firstName;
        public string lastName;
        public string street;
        public string streetNumber;
        public string zipCode;
        public string city;
        public string state;
        public string phone;
        public string fax;
        public string vatId;
        public Customers.Country country;
        public ShippingAttributes attribute;
    }

    public class Order
    {
        public int? id;
        public string number;
        public int? customerId;
        public int? paymentId;
        public int? dispatchId;
        public string partnerId;
        public int? shopId;
        public double? invoiceAmount;
        public double? invoiceAmountNet;
        public double? invoiceShipping;
        public double? invoiceShippingNet;
        public string orderTime;
        public string transactionId;
        public string comment;
        public string customerComment;
        public string internalComment;
        public int? net;
        public int? taxFree;
        public string temporaryId;
        public string referer;
        public string clearedDate;
        public string trackingCode;
        public string languageIso;
        public string currency;
        public double? currencyFactor;
        public string remoteAddress;
        public string deviceType;
        public List<Detail> details;
        public List<Document> documents;
        public Payments.Payment payment;
        public Status paymentStatus;
        public Status orderStatus;
        public Customers.Customer customer;
        public List<Payments.PaymentInstances> paymentInstances;
        public BillingAddress billing;
        public ShippingAddress shipping;
        public Shops.Shop shop;
        public Dispatch dispatch;
        public OrderAttributes attribute;
        public Shops.Shop languageSubShop;
        public int? paymentStatusId;
        public int? orderStatusId;
    }
}
