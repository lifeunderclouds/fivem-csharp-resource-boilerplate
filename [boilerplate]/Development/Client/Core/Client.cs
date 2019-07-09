using System;
using System.Threading.Tasks;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace LifeUnderClouds.Boilerplate.Development.Client.Core {
  // ReSharper disable once ClassNeverInstantiated.Global
  public class Client : BaseScript {
    public Client() {
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
    ///   Register a NUI event listener
    /// </summary>
    /// <param name="name"></param>
    /// <param name="action"></param>
    public void RegisterNuiEventHandler(string name, Delegate action) {
      try {
        Function.Call(Hash.REGISTER_NUI_CALLBACK_TYPE, name);
        RegisterEventHandler(string.Concat("__cfx_nui:", name), action);
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
      Debug.WriteLine($"[{API.GetCurrentResourceName()}] {exception.Message}");
    }
  }
}
