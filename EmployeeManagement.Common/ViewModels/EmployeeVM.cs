using EmployeeManagement.Common.ConstantModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EmployeeManagement.Common.ViewModels
{
    public class EmployeeVM
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Gereklidir.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Display(Name = "Telefon No")]
        [RegularExpression(@"^(0(\d{3}) (\d{3}) (\d{2}) (\d{2}))$", ErrorMessage = "Telefon numarası uygun formatta değil")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email adresi gereklidir.")]
        [Display(Name = "Email adresi")]
        [EmailAddress(ErrorMessage = "Email adresiniz doğru formatta değil.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kullanıcı şifresi gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Doğum tarihi")]
        [DataMember]
        public DateTime? BirthDay { get; set; }

        public string Picture { get; set; }
        
        [Display(Name = "Şehir")]
        public string City { get; set; }

        [Display(Name = "Cinsiyet")]
        public EnumEmployeeGender Gender { get; set; }

        [Display(Name = "İsim")]
        public string FirstName { get; set; }

        [Display(Name = "Soy İsim")]
        public string LastName { get; set; }

        [Display(Name = "Veri No")]
        public string TaxId { get; set; }
        
    }
}
