using System.Collections.Generic;

namespace LCHC.Web.Models
{
  public class ConfigureTwoFactorContext
  {
    public string SelectedProvider { get; set; }
    public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
  }
}