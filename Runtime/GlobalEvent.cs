using System;
using System.Collections;
using System.Collections.Generic;
using mactinite.ToolboxCommons;
using UnityEngine;

namespace mactinite.GlobalEventsManager
{
    /// <summary>
    /// Used as a key for global events.
    /// Less error prone than plain String IDs for events.
    /// Simply read as a string in the event trigger and event receiver scripts.
    /// </summary>
    [CreateAssetMenu(fileName = "New Global Event", menuName = "GlobalEventsManager/New Global Event")]
    public class GlobalEvent : ScriptableObject
    {
        /*Nothing... yet.*/
        
        public void TriggerEvent()
        {
            GlobalEventsManager.TriggerEvent(this.name);
        }
        
        public void TriggerEvent(GenericDictionary headers)
        {
            GlobalEventsManager.TriggerEvent(this.name, headers);
        }
        
        public void Listen(Action<GenericDictionary> listener)
        {
            GlobalEventsManager.StartListening(this.name, listener);
        }
        
        public void StopListening(Action<GenericDictionary> listener)
        {
            GlobalEventsManager.StopListening(this.name, listener);
        }
    }
}
