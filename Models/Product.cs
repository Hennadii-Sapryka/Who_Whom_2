using System.ComponentModel.DataAnnotations;

namespace Who_Whom_.Models
{
    public class Product
    {
        [Display(Name = "№")]
        public int Id { get; set; }
       
        [Required]
        [Display(Name="Що купив")]
        public string Name { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "лише числа які більше 0")]
        [Display(Name = "Ціна")]
        public int Price { get; set; }
        
        [Required]
        [Display(Name = "Хто купив")]
        public string User { get; set; }


    }
}
