using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace TheWayShopProject.Models
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        public int PRODUCT_ID { get; set; }

        [StringLength(200)]
        public string PRODUCT_NAME { get; set; }

        [StringLength(50)]
        public string PRODUCT_DECRIPTION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRODUCT_PURCHASEPRICE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PRODUCT_SALEPRICE { get; set; }

        [StringLength(200)]
        public string PRODUCT_PICTURE { get; set; }

        [NotMapped]
        public HttpPostedFileBase PRO_PIC { get; set; }

        public int? CATEGORY_FID { get; set; }

        public virtual Category Category { get; set; }

        [NotMapped]
        public int PRO_QUANTITY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAILs { get; set; }

        public class Cart
        {
            public List<Product> Items { get; set; } = new List<Product>();

            public void AddItem(Product product)
            {
                Items.Add(product);
            }

            public void RemoveItem(Product product)
            {
                Items.Remove(product);
            }

            public decimal CalculateTotalPrice()
            {
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += (decimal)item.PRODUCT_SALEPRICE * (decimal)item.PRO_QUANTITY;
                }
                return total;
            }
        }
    }
}
