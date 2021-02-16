using Project2_1.BusinessLogic.Services.Messaging;
using Project2_1.Services.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2_1.BusinessLogic.Services.Dialog;
using Project2_1.Services.Dialog;
using Unity;
using Unity.Lifetime;

namespace Project2_1.Dependencies
{
  public static class Configuration
  {
    private static bool configured = false;

    public static void Configure(IUnityContainer container)
    {
      if (configured)
        return;

      container.RegisterType<IMessagingService, MessagingService>(new ContainerControlledLifetimeManager());
      container.RegisterType<IDialogService, DialogService>();
      Project2_1.BusinessLogic.Dependencies.Configuration.Configure(container);

      configured = true;
    }
  }
}