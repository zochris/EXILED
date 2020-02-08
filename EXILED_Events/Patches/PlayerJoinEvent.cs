using System;
using EXILED.Extensions;
using Harmony;

namespace EXILED.Patches
{
  [HarmonyPatch(typeof(NicknameSync), "SetNick")]
	public class PlayerJoinEvent
  {
    public static void Postfix(NicknameSync __instance)
    {
      if (EventPlugin.PlayerJoinEventPatchDisable)
        return;
      
      try
      {
        ReferenceHub hub = Player.GetPlayer(__instance.gameObject);
        if (!string.IsNullOrEmpty(hub.characterClassManager.UserId))
          Events.InvokePlayerJoin(hub);
      }
      catch (Exception e)
      {
        Log.Error($"PlayerJoin Event error: {e}");
      }
    }
  }
}