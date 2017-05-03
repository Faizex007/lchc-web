using System;
using System.Configuration;
using DocumentDB.AspNet.Identity;
using LCHC.Web.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace LCHC.Web.Authentication
{
  // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
  public class ApplicationUserManager : UserManager<ApplicationUser>
  {
    public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
    {
    }

    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
    {
      var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(
        ConfigurationManager.AppSettings["DocumentDb.Endpoint"],
        ConfigurationManager.AppSettings["DocumentDb.AccessToken"],
        ConfigurationManager.AppSettings["DocumentDb.Database.User"],
        ConfigurationManager.AppSettings["DocumentDb.Collection.UserLogin"]));

      // Configure validation logic for usernames
      manager.UserValidator = new UserValidator<ApplicationUser>(manager)
      {
        AllowOnlyAlphanumericUserNames = false,
        RequireUniqueEmail = true
      };

      // Configure validation logic for passwords
      manager.PasswordValidator = new PasswordValidator
      {
        RequiredLength = int.Parse(ConfigurationManager.AppSettings["User.Password.RequiredLength"]),
        RequireNonLetterOrDigit = true,
        RequireDigit = true,
        RequireLowercase = true,
        RequireUppercase = true,
      };

      // Configure user lockout defaults
      manager.UserLockoutEnabledByDefault = true;
      manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings["User.Lockout.DefaultAccountLockoutTimeSpan"]));
      manager.MaxFailedAccessAttemptsBeforeLockout = int.Parse(ConfigurationManager.AppSettings["User.Lockout.MaxFailedAccessAttemptsBeforeLockout"]);

      // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
      // You can write your own provider and plug it in here.
      manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
      {
        MessageFormat = "Your security code is {0}"
      });

      manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
      {
        Subject = "Security Code",
        BodyFormat = "Your security code is {0}"
      });

      manager.EmailService = new EmailService();
      manager.SmsService = new SmsService();

      var dataProtectionProvider = options.DataProtectionProvider;
      if (dataProtectionProvider != null)
        manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));

      return manager;
    }
  }
}