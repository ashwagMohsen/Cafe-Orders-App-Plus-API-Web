namespace CafeeAFM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        public int? ServiceID { get; set; }

        public int? Coffee_ID { get; set; }

        public int? SweetID { get; set; }

        public int? TableNumber { get; set; }

        public int? Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal? Total_Price { get; set; }

        public virtual Coffee Coffee { get; set; }

        public virtual Service Service { get; set; }

        public virtual Sweet Sweet { get; set; }
    }
}
