using System.ComponentModel.DataAnnotations;

namespace SinavUygulamasiData.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } 
        public bool IsDeleted { get; set; }

    }
}
