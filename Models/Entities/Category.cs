
namespace Models.Entities
{
    public class Category
    {
        // [Key]
        public int Id { get; set; }
        //  [Required]
        //  [MaxLength(50)]
        public string CatName { get; set; }
        // [Required]
        public int CatOrder { get; set; }
       
        public bool MarkedAsDeleted { get; set; } = false;
        
       
    }
}
