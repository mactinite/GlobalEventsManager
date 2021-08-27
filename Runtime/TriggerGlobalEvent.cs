using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;

namespace mactinite.GlobalEventsManager
{
    public class TriggerGlobalEvent : MonoBehaviour
    {
        public GlobalEvent gameEvent;
        public string optionalParameterName;

        public void TriggerEvent()
        {
            GenericDictionary headers = new GenericDictionary();
            headers.SetHeaderValue("Position", (Vector2)transform.position);
            GlobalEventsManager.TriggerEvent(gameEvent.name, headers);
        }

        public void TriggerFloatEvent(float value)
        {
            GenericDictionary headers = new GenericDictionary();
            headers.SetHeaderValue("Position", (Vector2)transform.position);
            if(!string.IsNullOrEmpty(optionalParameterName)){
                headers.SetHeaderValue(optionalParameterName, value);
            } else {
                headers.SetHeaderValue("Value", value);
            }
            GlobalEventsManager.TriggerEvent(gameEvent.name, headers);
        }
    }
}
