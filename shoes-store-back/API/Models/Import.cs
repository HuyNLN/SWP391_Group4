using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Import
    {
        [Key]
        public int ImportID {  get; set; }  
        public DateTime ImportDate { get; set; }
        public int VariantID {  get; set; } 
        public int Quantity { get; set; }
        [ForeignKey(nameof(VariantID))]
        public virtual ProductVariant? ProductVariant { get; set; } 
    }
}
