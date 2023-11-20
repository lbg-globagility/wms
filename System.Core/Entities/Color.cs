using System.Collections.Generic;
using WarehouseManagementSystem.Core.Entities.Base;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Core.Entities
{
    public partial class Color : AuditableEntity
    {
        public string ColorName { get; set; }
        public string ColorValue { get; set; }
        public ColorStatus Status { get; set; }
    }

    public partial class Color
    {
        private Color()
        {
        }

        public Color(int organizationId,
            int userId,
            string name,
            string value)
        {
            OrganizationID = organizationId;
            AuditUser(userId);
            ColorName = name;
            ColorValue = value;
        }

        public ICollection<ProductColor> ProductColors { get; set; }

        public static Color NewColor(int organizationId,
            int userId,
            string name,
            string value) => new Color(organizationId: organizationId,
                userId: userId,
                name: name,
                value: value);

        public void AddProductColors(List<ProductColor> productColors)
        {
            if (ProductColors == null) ProductColors = new List<ProductColor>();

            foreach (var productColor in productColors)
                ProductColors.Add(productColor);
        }
    }
}