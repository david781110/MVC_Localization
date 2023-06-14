using System.ComponentModel.DataAnnotations;

namespace MVC_Localization.Models
{
    internal class AuthorsMetadata
    {
        [Required(ErrorMessage ="{0}未填寫")]
        [Display(Name = "作者名稱")]
        [StringLength(40)]
        public string AuLname { get; set; }


        [Display(Name ="電話號碼")]
        public string Phone { get; set; }

    }
}