using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using mactinite.ToolboxCommons;

namespace mactinite.GlobalEventsManager
{
    public class GlobalEventsManager : MonoBehaviour
    {

        private Dictionary<string, Action<GenericDictionary>> eventDictionary;

        private static GlobalEventsManager eventManager;

        public bool debugLogs;

        public static bool HasInstance
        {
            get
            {
                return !!eventManager;
            }
        }

        public static GlobalEventsManager instance
        {
            get
            {
                if (!eventManager)
                {
                    eventManager = FindObjectOfType(typeof(GlobalEventsManager)) as GlobalEventsManager;

                    if (!eventManager)
                    {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                    else
                    {
                        eventManager.Init();
                    }
                }

                return eventManager;
            }
        }

        void Init()
        {
            if (eventDictionary == null)
            {
                eventDictionary = new Dictionary<string, Action<GenericDictionary>>();
            }
        }

        public static void StartListening(string eventName, Action<GenericDictionary> listener)
        {
            Action<GenericDictionary> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                //Add more event to the existing one
                thisEvent += listener;

                //Update the Dictionary
                instance.eventDictionary[eventName] = thisEvent;
            }
            else
            {
                //Add event to the Dictionary for the first time
                thisEvent += listener;
                instance.eventDictionary.Add(eventName, thisEvent);
            }
        }

        public static void StopListening(string eventName, Action<GenericDictionary> listener)
        {
            if (eventManager == null) return;
            Action<GenericDictionary> thisEvent;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                //Remove event from the existing one
                thisEvent -= listener;

                //Update the Dictionary
                instance.eventDictionary[eventName] = thisEvent;
            }
        }

        public static void TriggerEvent(string eventName)
        {
            Action<GenericDictionary> thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                if (instance.debugLogs)
                    Debug.Log($"Triggering Event {eventName}");
                if (thisEvent != null)
                    thisEvent.Invoke(null);
            }
        }

        public static void TriggerEvent(string eventName, GenericDictionary headers)
        {
            Action<GenericDictionary> thisEvent = null;
            if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
            {
                if (instance.debugLogs)
                    Debug.Log($"Triggering Event {eventName}");
                if (thisEvent != null)
                    thisEvent.Invoke(headers);
            }
        }
    }
}