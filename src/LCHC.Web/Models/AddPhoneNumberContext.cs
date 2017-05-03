using System.ComponentModel.DataAnnotations;

namespace LCHC.Web.Models
{
  public class AddPhoneNumberContext
  {
    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string Number { get; set; }
  }
}