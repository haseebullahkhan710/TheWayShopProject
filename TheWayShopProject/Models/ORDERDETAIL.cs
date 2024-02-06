namespace TheWayShopProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERDETAIL")]
    public partial class ORDERDETAIL
    {
        [Key]
        public int ORDERDETAIL_ID { get; set; }

        public int? ORDER_FID { get; set; }

        public int? PRODUCT_FID { get; set; }

        public decimal? SALE_PRICE { get; set; }

        public decimal? PURCHASE_PRICE { get; set; }

        public int? QUANTITY { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual Product Product { get; set; }
    }
}
