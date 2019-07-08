using CitizenFX.Core;

namespace LifeUnderClouds.Boilerplate.Development.Client.Core {
  public class ClientAccessor : BaseScript {
    private Client Client { get; }

    protected ClientAccessor(Client client) {
      Client = client;
    }
  }
}
