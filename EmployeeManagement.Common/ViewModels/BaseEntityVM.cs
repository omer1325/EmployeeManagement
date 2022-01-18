using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Common.ViewModels
{
    public class BaseEntityVM
    {
        [Key]
        public int Id { get; set; }
    }
}
