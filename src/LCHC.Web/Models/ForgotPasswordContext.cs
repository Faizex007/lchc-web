using System.ComponentModel.DataAnnotations;

namespace LCHC.Web.Models
{
  public class ForgotPasswordContext
  {
    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}