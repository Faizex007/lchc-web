using System.ComponentModel.DataAnnotations;

namespace LCHC.Web.Models
{
  public class ForgotContext
  {
    [Required]
    [Display(Name = "Email")]
    public string Email { get; set; }
  }
}