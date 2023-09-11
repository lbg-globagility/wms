using System;
using System.ComponentModel.DataAnnotations.Schema;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("contacts")]
    public partial class Contact : AuditableEntity
    {
        public int? AccountID { get; set; }
        public int? AddressID { get; set; }
        public int? ContactNo { get; set; }
        public DateTime? Birthday { get; set; }
        public ContactType Type { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string Salutation { get; set; }
        public string Nickname { get; set; }
        public string MainPhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AlternatePhone { get; set; }
        public string FaxNumber { get; set; }
        public string TINNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string JobTitle { get; set; }
        public string CivilStatus { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        //public char? EmployeeFlg { get; set; }
    }

    public partial class Contact
    {
        public bool IsAgent => Type == ContactType.Agent;
        public bool IsContact => Type == ContactType.Contact;
        public bool IsDriver => Type == ContactType.Driver;
        public bool IsHelper => Type == ContactType.Helper;
        public bool IsPacker => Type == ContactType.Packer;
        public bool IsPicker => Type == ContactType.Picker;
    }
}