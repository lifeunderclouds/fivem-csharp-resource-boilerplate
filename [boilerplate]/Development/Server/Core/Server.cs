using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace LifeUnderClouds.Boilerplate.Development.Server.Core {
  // ReSharper disable once ClassNeverInstantiated.Global
  public class Server : BaseScript {
    public Server() {
      ClassLoader.Init(this);
    }

    /// <summary>
    ///   Register a network event listener
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RegisterEventHandler(string name, Delegate action) {
      try {
        EventHandlers[name] += action;
      } catch (Exception exception) {
        HandleException(exception);
      }
    }

    /// <summary>
    ///   Register a (chat) command.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    /// <param name="restricted"></param>
    public void RegisterCommandHandler(string name, Delegate action, bool restricted) {
      try {
        API.RegisterCommand(name, action, restricted);
      } catch (Exception exception) {
        HandleException(exception);
      }
    }

    /// <summary>
    ///   Add or remove an Action to the Tick handler
    /// </summary>
    /// <param name="action"></param>
    /// <param name="register"></param>
    public void RegisterTickHandler(Func<Task> action, bool register = true) {
      try {
        if (register) {
          Tick += action;
        } else {
          Tick -= action;
        }
      } catch (Exception exception) {
        HandleException(exception);
      }
    }

    /// <summary>
    ///   Register an export function
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RegisterExport(string name, Delegate action) {
      try {
        Exports.Add(name, action);
      } catch (Exception exception) {
        HandleException(exception);
      }
    }

    /// <summary>
    ///   Handles provided exceptions
    /// </summary>
    /// <param name="exception"></param>
    private static void HandleException(Exception exception) {
      Debug.WriteLine($"^1[^5{API.GetCurrentResourceName()}^1]^2 {exception.Message}^7");
    }
  }
}
