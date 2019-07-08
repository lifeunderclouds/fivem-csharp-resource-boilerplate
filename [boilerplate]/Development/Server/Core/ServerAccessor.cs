using CitizenFX.Core;

namespace LifeUnderClouds.Boilerplate.Development.Server.Core {
  public class ServerAccessor : BaseScript {
    private Server Server { get; }

    protected ServerAccessor(Server server) {
      Server = server;
    }
  }
}
