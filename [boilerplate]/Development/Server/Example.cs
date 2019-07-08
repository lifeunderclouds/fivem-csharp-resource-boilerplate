using System.Threading.Tasks;
using LifeUnderClouds.Boilerplate.Development.Server.Core;

namespace LifeUnderClouds.Boilerplate.Development.Server {
  public class Example : ServerAccessor {
    public Example(Core.Server server) : base(server) {
      server.RegisterTickHandler(Every30Seconds);
    }

    private static async Task Every30Seconds() {
      await Delay(30000);

      TriggerClientEvent("LifeUnderClouds.Boilerplate.Example", "Hello, from the other siiiiiiddddeeee!!!");

      await Task.FromResult(0);
    }
  }
}
