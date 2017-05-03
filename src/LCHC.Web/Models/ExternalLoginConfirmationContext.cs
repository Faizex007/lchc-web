using System.ComponentModel.DataAnnotations;

namespace LCHC.Web.Models
{
  public class ExternalLoginConfirmationContext
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}