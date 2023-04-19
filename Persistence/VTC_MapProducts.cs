namespace Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VTC_MapProducts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VTC_MapProducts()
        {
            VTC_Order_Detail = new HashSet<VTC_Order_Detail>();
        }

        [Key]
        [StringLength(40)]
        public string VTC_Product_Code { get; set; }

        [Required]
        [StringLength(40)]
        public string VTC_Product_Id { get; set; }

        [StringLength(20)]
        public string Abaha_Product_Code { get; set; }

        public string ProductName { get; set; }

        [StringLength(20)]
        public string ShortName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VTC_Order_Detail> VTC_Order_Detail { get; set; }
    }
}
