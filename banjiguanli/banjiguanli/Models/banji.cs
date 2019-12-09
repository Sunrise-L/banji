namespace banjiguanli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("banji")]
    public partial class banji
    {
        [StringLength(20)]
        public string name { get; set; }

        public int id { get; set; }

        public int? Teacherid { get; set; }
    }
}
