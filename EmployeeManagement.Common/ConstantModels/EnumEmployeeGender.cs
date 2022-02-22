
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Common.ConstantModels
{
    public enum EnumEmployeeGender
    {
        [Display(Name = "Belirtilmemiş")]
        Unspecified = 0,
        [Display(Name = "Erkek")]
        Male = 1,
        [Display(Name = "Kadın")]
        Female = 2
    }
}
