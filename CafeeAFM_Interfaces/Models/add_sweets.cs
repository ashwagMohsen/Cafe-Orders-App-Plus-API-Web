namespace CafeeAFM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class add_sweets
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? add_id { get; set; }

        public int? sweet_id { get; set; }

        public virtual Addition Addition { get; set; }

        public virtual Sweet Sweet { get; set; }
    }
}
