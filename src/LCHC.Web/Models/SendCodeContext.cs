using System.Collections.Generic;
using System.Web.Mvc;

namespace LCHC.Web.Models
{
  public class SendCodeContext
  {
    public string SelectedProvider { get; set; }
    public ICollection<SelectListItem> Providers { get; set; }
    public string ReturnUrl { get; set; }
    public bool RememberMe { get; set; }
  }
}