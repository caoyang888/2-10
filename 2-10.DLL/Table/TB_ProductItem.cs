using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2_10.Model
{
    public class TB_ProductItem : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Number { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Remark { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
