using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lenz.ShopwareApi.Models.Customers
{
    public class Country
    {
        public int? id;                 // primary key
        public string name;
        public string iso;
        public string isoName;
        public int? position;
        public string description;
        public bool? shippingFree;
        public int? taxFree;
        public int? taxFreeUstId;
        public int? taxFreeUstIdChecked;
        public bool? active;
        public string iso3;
        public bool? displayStateInRegistration;
        public bool? forceStateInRegistration;
        public int areaId;
    }

    public class State
    {
        public int? id;
    }

    public class AddressAttributes
    {
        public int? id;
        public int? customerAddressId;
        public string text1;
        public string text2;
        public string text3;
        public string text4;
        public string text5;
        public string text6;
    }

    public class Address        // as of shopware 5.2, data when retrieving information
    {
        public int? id;
        public string company;
        public string department;
        public string salutation;
        public string firstname;
        public string title;
        public string lastname;
        public string street;
        public string zipcode;
        public string city;
        public string phone;
        public string vatId;
        public string additionalAddressLine1;
        public string additionalAddressLine2;
        public int? countryId;
        public int? stateId;
        public AddressAttributes attribute;
        public Country country;
        public State state;
    }

    public class AddressPost        // address when creating/updating data
    {
        public int? id;
        public string company;
        public string department;
        public string salutation;
        public string firstname;
        public string title;
        public string lastname;
        public string street;
        public string zipcode;
        public string city;
        public string phone;
        public string vatId;
        public string additionalAddressLine1;
        public string additionalAddressLine2;
        public int country;
        public int state;
        public AddressAttributes attribute;
    }

    public class CustomerAttributes
    {
        public int? id;                 // primary key
        public int? customerId;         // foreign key to customer's primary key
        public int? swagPricegroup;         // foreign key to customer price group  (PLUGIN: for special prices for a customer)
        public string memaAcctmngr;         // link to account manager in ERP  (PLUGIN: MemaxHistory)
        public string netiRegisterNumber;   // link to Consultant (PLUGIN: NetiConsultantTools)
    }

    public class CustomerPaymentData
    {
        public int? id;
        public int? paymentMeanId;
        public string useBillingData;
        public string bankName;
        public string bic;
        public string iban;
        public string accountNumber;
        public string bankCode;
        public string accountHolder;
        public string createdAt;
    }

    public class Debit
    {
        public int? id;
        public int? customerId;
        public string account;
        public string bankCode;
        public string bankName;
        public string accountHolder;
    }

    public class Customer
    {
        // data for list or single customer

        public int? id;             // primary key
        public int? paymentId;      // foreign key to s_core_paymentmeans.id
        public string groupKey;     // foreign key to s_core_customergroups.id  ("EK" and "H" are defaults)
        public int? shopId;         // foreign key to shop
        public int? priceGroupId;   // foreign key to priceGroup
        public string encoderName;  // 'md5' or 'bcrypt'
        public string hashPassword; // password hashed with specified encoder
        public bool active;
        public string email;
        public string firstLogin;
        public string lastLogin;
        public int accountMode;
        public string confirmationKey;
        public string sessionId;
        public int newsletter;
        public string validation;
        public int affiliate;
        public int paymentPreset;
        public string languageId;  // returns a string, but is foreign key (int) to language shop
        public string referer;
        public string internalComment;
        public int failedLogins;
        public string lockedUntil;
        public string salutation;
        public string title;
        public string firstname;
        public string number;       // customer number
        public string lastname;
        public string birthday;

        // additional data when querying for one customer
        public CustomerAttributes attribute;
        public Address defaultBillingAddress;
        public List<CustomerPaymentData> paymentData;
        public Address defaultShippingAddress;
        public Debit debit;

        // additional data when creating/updating a customer
        public string rawPassword;          // this password will not be hashed on save
        public string password;             // this password will be hashed with default encoder on save
        public AddressPost billing;
        public AddressPost shipping;

    }
}
