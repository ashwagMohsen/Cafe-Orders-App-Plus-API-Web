namespace CafeeAFM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class add_coffes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int? add_id { get; set; }

        public int? coofe_id { get; set; }

        public virtual Addition Addition { get; set; }

        public virtual Coffee Coffee { get; set; }
    }
}
