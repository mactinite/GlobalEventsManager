using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Events;
using mactinite.ToolboxCommons;

namespace mactinite.GlobalEventsManager
{
    public class ListenToGlobalEvent : MonoBehaviour
    {
        public string eventName = "EventName";
        public string headerName = "Count";
        public HeaderType headerType = HeaderType.Float;
        public enum HeaderType
        {
            Int,
            Float,
            String,
            Null,
        }
        [ShowIf("@headerType == HeaderType.Float")]
        public FloatUnityEvent OnTriggeredFloat = new FloatUnityEvent();
        [ShowIf("@headerType == HeaderType.Int")]
        public IntUnityEvent OnTriggeredInt = new IntUnityEvent();
        [ShowIf("@headerType == HeaderType.String")]
        public StringUnityEvent OnTriggeredString = new StringUnityEvent();
        [ShowIf("@headerType == HeaderType.Null")]
        public UnityEvent OnTriggered = new UnityEvent();
        // Start is called before the first frame update
        void Start()
        {
            GlobalEventsManager.StartListening(eventName, EventTriggered);
        }
        public void EventTriggered(GenericDictionary headers)
        {
            switch (headerType)
            {
                case HeaderType.Float:
                    ExtractFloatProperty(headers);
                    break;
                case HeaderType.Int:
                    ExtractIntProperty(headers);
                    break;
                case HeaderType.String:
                    ExtractStringProperty(headers);
                    break;
                case HeaderType.Null:
                    OnTriggered.Invoke();
                    break;
                default:
                    Debug.LogWarning($"No Handler implemented for {headerType}");
                    break;
            }
        }


        private void ExtractFloatProperty(GenericDictionary headers)
        {
            float? property = headers.GetHeaderValue<float>(headerName);

            if (property.HasValue)
            {
                OnTriggeredFloat.Invoke(property.Value);
            }
            else
            {
                OnTriggeredFloat.Invoke(-1);
            }
        }

        private void ExtractIntProperty(GenericDictionary headers)
        {
            int? property = headers.GetHeaderValue<int>(headerName);

            if (property.HasValue)
            {
                OnTriggeredInt.Invoke(property.Value);
            }
            else
            {
                OnTriggeredInt.Invoke(-1);
            }
        }

        private void ExtractStringProperty(GenericDictionary headers)
        {
            string property = headers.GetHeaderValue(headerName).ToString();

            OnTriggeredString.Invoke(property);
        }

    }
}
