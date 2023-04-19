namespace Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VTC_Orders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VTC_Orders()
        {
            VTC_Order_Detail = new HashSet<VTC_Order_Detail>();
        }

        [Key]
        [StringLength(20)]
        public string RefId { get; set; }

        [StringLength(20)]
        public string UserId { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrdersTime { get; set; }

        [StringLength(20)]
        public string Total { get; set; }

        public bool Status_sms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VTC_Order_Detail> VTC_Order_Detail { get; set; }
    }
}
