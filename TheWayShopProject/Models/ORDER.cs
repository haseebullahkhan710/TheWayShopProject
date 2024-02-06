namespace TheWayShopProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            ORDERDETAILs = new HashSet<ORDERDETAIL>();
        }

        [Key]
        public int ORDER_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_NAME { get; set; }

        [StringLength(50)]
        public string ORDER_EMAIL { get; set; }

        public DateTime? ORDER_DATE { get; set; }

        [StringLength(50)]
        public string ORDER_STATUS { get; set; }

        [StringLength(50)]
        public string ORDER_TYPE { get; set; }

        [Required]
        [StringLength(50)]
        public string ORDER_CONTACT { get; set; }

        [StringLength(50)]
        public string ORDER_ADDRESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDERDETAIL> ORDERDETAILs { get; set; }
    }
}
