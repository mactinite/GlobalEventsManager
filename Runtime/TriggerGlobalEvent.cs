using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;

namespace mactinite.GlobalEventsManager
{
    public class TriggerGlobalEvent : MonoBehaviour
    {
        public GlobalEvent gameEvent;

        public void TriggerEvent()
        {
            GenericDictionary headers = new GenericDictionary();
            headers.SetHeaderValue("Position", (Vector2)transform.position);
            GlobalEventsManager.TriggerEvent(gameEvent.name, headers);
        }
    }
}
