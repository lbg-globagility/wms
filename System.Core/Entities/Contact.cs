using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
        public int? ProvinceID { get; set; }
        public int? RegionID { get; set; }
        public List<ContactCity> Cities { get; set; }
        //public char? EmployeeFlg { get; set; }
    }

    public partial class Contact
    {
        public static string DEFAULT_NAME = "DEFAULT";
        private Contact()
        { }

        public Contact(int organizationId,
            string lastName,
            string firstName,
            ContactType type,
            string workPhone,
            string email,
            string comments,
            int regionId,
            int provinceId,
            List<ContactCity> cities,
            string status = "Active")
        {
            OrganizationID = organizationId;
            LastName = lastName;
            FirstName = firstName;
            Type = type;
            WorkPhone = workPhone;
            EmailAddress = email;
            Comments = comments;
            RegionID = regionId;
            ProvinceID = provinceId;
            Status = status;
            Cities = cities;
        }

        public Contact(int organizationId,
            string lastName,
            string firstName,
            ContactType type,
            string workPhone,
            string email,
            string comments,
            string status = "Active")
        {
            OrganizationID = organizationId;
            LastName = lastName;
            FirstName = firstName;
            Type = type;
            WorkPhone = workPhone;
            EmailAddress = email;
            Comments = comments;
            Status = status;
        }

        public bool IsAgent => Type == ContactType.Agent;
        public bool IsContact => Type == ContactType.Contact;
        public bool IsDriver => Type == ContactType.Driver;
        public bool IsHelper => Type == ContactType.Helper;
        public bool IsPacker => Type == ContactType.Packer;
        public bool IsPicker => Type == ContactType.Picker;
        public bool IsCustomer => Type == ContactType.Customer;

        public string FullNameLastNameFirst
        {
            get
            {
                string[] names = { LastName, FirstName };
                return string.Join(", ", names.Where(n => !string.IsNullOrEmpty(n)).ToArray());
            }
        }

        public static Contact NewContact(int organizationId,
            string lastName,
            string firstName,
            ContactType type,
            string workPhone,
            string email = "",
            string comments = "",
            int regionId = 0,
            int provinceId = 0,
            List<ContactCity> cities = null,
            string status = "Active") => new Contact(organizationId: organizationId,
                lastName: lastName,
                firstName: firstName,
                type: type,
                workPhone: workPhone,
                email: email,
                comments: comments,
                regionId: regionId,
                provinceId: provinceId,
                status: status,
                cities: cities);

        public static Contact BlankAgent(int organizationId)
        {
            var blankAgent = new Contact(organizationId: organizationId,
                lastName: "[NO AGENT]",
                firstName: string.Empty,
                type: ContactType.Agent,
                workPhone: string.Empty,
                email: string.Empty,
                comments: string.Empty);

            blankAgent.RowID = 0;

            return blankAgent;
        }

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}