using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("accounts")]
    public partial class Account : AuditableEntity
    {
        public int? PrimaryContactID { get; set; }
        public int? PrimaryAddressID { get; set; }
        public int? PrimaryRepID { get; set; }
        public int? ParentAccountID { get; set; }
        public int? PickListGroupID { get; set; }
        public int? BranchID { get; set; }
        public int AccountNo { get; set; }
        public AccountType AccountType { get; set; }
        public string CompanyName { get; set; }
        public string TradeName { get; set; }
        public string MainPhone { get; set; }
        public string AltPhone { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public string VATRegistrationNo { get; set; }
        public string Website { get; set; }
        public string Comments { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string DeliveryHours { get; set; }
        public string AltEmailAddress { get; set; }
        public string MobilePhone { get; set; }
        public string ManagerName { get; set; }
        public string BusinessType { get; set; }
        public char? GoodStandingFlg { get; set; }
        public int? CreditDays { get; set; }
        public decimal? YearsInBusiness { get; set; }
        public DateTime? CustomerSinceDate { get; set; }

        //public longblob? Image { get; set; }
        public int? AgentID { get; set; }
    }

    public partial class Account
    {
        private Account()
        { }

        public Account(int organizationId, int userId)
        {
        }

        public virtual Contact Agent { get; set; }
        public bool IsCustomerType => AccountType == AccountType.Customer;
        public bool IsSupplierType => AccountType == AccountType.Supplier;
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Account> SubAccounts { get; set; }
        public virtual Account ParentAccount { get; set; }
        public virtual Address Address { get; set; }
        public string FullAddress => Address?.FullAddress;
    }
}