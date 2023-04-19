namespace Persistence
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VTC_Order_Detail
    {
        [StringLength(40)]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string RefId_Abaha { get; set; }

        [Required]
        [StringLength(30)]
        public string RefId_Telcohub { get; set; }

        [StringLength(30)]
        public string Key_Value { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ActivationDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Expires { get; set; }

        [StringLength(40)]
        public string Abaha_Product_Code { get; set; }

        [StringLength(40)]
        public string Product_Code { get; set; }

        [Required]
        [StringLength(20)]
        public string RequestId_Activate { get; set; }

        [StringLength(20)]
        public string RequestId_ShippingData { get; set; }

        public virtual VTC_MapProducts VTC_MapProducts { get; set; }

        public virtual VTC_Orders VTC_Orders { get; set; }
    }
}
