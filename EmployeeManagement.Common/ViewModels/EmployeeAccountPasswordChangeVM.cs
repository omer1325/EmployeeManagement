using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Common.ViewModels
{
    public class EmployeeAccountPasswordChangeVM
    {
        [Display(Name = "Eski şifreniz")]
        [Required(ErrorMessage = "Eski şifreniz gerekli")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifreniz en az 8 karakterli olmak zorundadır")]
        public string PasswordOld { get; set; }

        [Display(Name = "Yeni şifreniz")]
        [Required(ErrorMessage = "Yeni şifreniz gerekli")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifreniz en az 8 karakterli olmak zorundadır")]
        public string PasswordNew { get; set; }

        [Display(Name = "Onay yeni şifreniz")]
        [Required(ErrorMessage = "Onay yeni şifreniz gereklidir.")]
        [DataType(DataType.Password)]
        [MinLength(4, ErrorMessage = "Şifreniz en az 8 karakterli olmak zorundadır.")]
        [Compare("PasswordNew", ErrorMessage = "Yeni şifreniz ve onay şifreniz birbirinden farklıdır.")]
        public string PasswordConfirm { get; set; }
    }
}
