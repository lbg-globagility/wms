using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using WarehouseManagementSystem.Core.Entities.Base;

namespace WarehouseManagementSystem.Core.Entities
{
    [Table("cartonsizes")]
    public partial class CartonSize : AuditableEntity
    {
        public string SizeName { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string LengthUOM { get; set; }
        public string WidthUOM { get; set; }
        public string HeightUOM { get; set; }
        public string Status { get; set; }
    }

    public partial class CartonSize
    {
        public static string DEFUALT_NAME = "DEFAULT";

        private CartonSize() { }

        public CartonSize(int organizationId,
            int userId,
            string sizeName)
        {
            AuditUser(userId: userId);
            OrganizationID = organizationId;
            SizeName = sizeName;
            Status = "Active";
        }

        public virtual ICollection<PackingListCarton> PackingListCartons { get; set; }
        
        public void AddPackingListCartons(List<PackingListCarton> packingListCartons)
        {
            if (packingListCartons == null) return;

            if (PackingListCartons == null) PackingListCartons = new List<PackingListCarton>();

            foreach (var packingListCarton in packingListCartons)
            {
                var exitingPackingListCarton = PackingListCartons?
                    .FirstOrDefault(t => t.CartonSizeID == packingListCarton.CartonSizeID);

                if (exitingPackingListCarton == null)
                    PackingListCartons.Add(packingListCarton);
                else
                    continue;
            }
        }
        public static CartonSize NewCartonSize(int organizationId,
            int userId,
            string sizeName) => new CartonSize(organizationId: organizationId,
                userId: userId,
                sizeName: sizeName);
    }
}
