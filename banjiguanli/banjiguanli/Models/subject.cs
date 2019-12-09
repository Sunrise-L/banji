namespace banjiguanli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("subject")]
    public partial class subject
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string SubjectName { get; set; }
    }
}
