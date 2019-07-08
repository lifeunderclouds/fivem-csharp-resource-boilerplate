using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CitizenFX.Core.Native;
using CitizenFX.Core.UI;
using LifeUnderClouds.Boilerplate.Development.Client.Core;

namespace LifeUnderClouds.Boilerplate.Development.Client {
  public class Example : ClientAccessor {
    public Example(Core.Client client) : base(client) {
      client.RegisterCommandHandler("example", new Action<int, List<dynamic>, string>(ExampleCommandHandler), false);
      client.RegisterEventHandler("LifeUnderClouds.Boilerplate.Example", new Action<string>(ExampleEventHandler));
      client.RegisterTickHandler(ShowHelpMessageEachTick);
    }

    /// <summary>
    /// Every time the server sends an example message, show it as an ingame notification.
    /// </summary>
    /// <param name="message"></param>
    private static async void ExampleEventHandler(string message) {
      if (!string.IsNullOrWhiteSpace(message)) {
        Screen.ShowSubtitle($"[~r~{API.GetCurrentResourceName()}~w~] Server Event Message:\n{message}");
      }

      await Task.FromResult(0);
    }

    /// <summary>
    /// Use `/example` in chat to see the Example subtitle for 2.5 seconds.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="arguments"></param>
    /// <param name="rawCommand"></param>
    private static async void ExampleCommandHandler(int source, List<dynamic> arguments, string rawCommand) {
      Screen.ShowSubtitle($"[~r~{API.GetCurrentResourceName()}~w~] Hello, World!");

      await Task.FromResult(0);
    }

    /// <summary>
    /// This will show every frame, rendered in the top left corner.
    /// </summary>
    /// <returns></returns>
    private static async Task ShowHelpMessageEachTick() {
      Screen.DisplayHelpTextThisFrame($"[~r~{API.GetCurrentResourceName()}~w~] Hello, World!");

      await Task.FromResult(0);
    }
  }
}
