using System;
using AIMP.SDK;
using AIMP.SDK.MessageDispatcher;

namespace AIMP_Discord_Rich_Presence.Aimp
{
    public class MessageHook : IAimpMessageHook
    {
        public AimpActionResult CoreMessage(AimpCoreMessageType message, int param1, IntPtr param2)
        {
            var onCoreMessage = OnCoreMessage;
            if (onCoreMessage != null)
            {
                var num = (int)onCoreMessage(message, param1, param2);
            }

            return new AimpActionResult(ActionResultType.OK);
        }

        public event MessageHookAction OnCoreMessage;

        public delegate ActionResultType MessageHookAction(AimpCoreMessageType message, int param1, IntPtr param2);
    }
}