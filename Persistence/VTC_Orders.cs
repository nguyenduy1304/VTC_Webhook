namespace Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VTC_Orders
    {
        [StringLength(40)]
        public string Id { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string RefId { get; set; }

        [StringLength(40)]
        public string Abaha_Product_Code { get; set; }

        [StringLength(30)]
        public string Key_Value { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ActivationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Expires { get; set; }

        [Required]
        [StringLength(20)]
        public string RequestId_Activate { get; set; }

        [StringLength(20)]
        public string RequestId_ShippingData { get; set; }

        [StringLength(40)]
        public string Product_Code { get; set; }

        public bool Status_sms { get; set; }

        public virtual VTC_MapProducts VTC_MapProducts { get; set; }
    }
}
