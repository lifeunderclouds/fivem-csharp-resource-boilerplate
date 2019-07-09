using CitizenFX.Core;

namespace LifeUnderClouds.Boilerplate.Development.Client.Core {
  public class ClientAccessor : BaseScript {
    protected ClientAccessor(Client client) {
      Client = client;
    }

    private Client Client { get; }
  }
}
