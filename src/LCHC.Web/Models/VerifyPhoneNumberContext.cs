using System.ComponentModel.DataAnnotations;

namespace LCHC.Web.Models
{
  public class VerifyPhoneNumberContext
  {
    [Required]
    [Display(Name = "Code")]
    public string Code { get; set; }

    [Required]
    [Phone]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }
  }
}