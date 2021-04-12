using System.Collections;
using System.Collections.Generic;
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
    }
}
