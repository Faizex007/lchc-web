using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace LCHC.Web.Models
{
  public class ManageLoginsContext
  {
    public IList<UserLoginInfo> CurrentLogins { get; set; }
    public IList<AuthenticationDescription> OtherLogins { get; set; }
  }
}