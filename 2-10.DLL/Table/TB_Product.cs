using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2_10.Model
{
    [Table("Product")]
    public class TB_Product : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Total { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
