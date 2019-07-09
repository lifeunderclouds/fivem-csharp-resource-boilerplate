using CitizenFX.Core;

namespace LifeUnderClouds.Boilerplate.Development.Server.Core {
  public class ServerAccessor : BaseScript {
    protected ServerAccessor(Server server) {
      Server = server;
    }

    private Server Server { get; }
  }
}
