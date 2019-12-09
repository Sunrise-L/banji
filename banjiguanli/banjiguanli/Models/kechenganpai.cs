namespace banjiguanli.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kechenganpai")]
    public partial class kechenganpai
    {
        public int Id { get; set; }

        public int SubjectId { get; set; }

        public int BanjiId { get; set; }

        public int TeacherId { get; set; }
    }
}
