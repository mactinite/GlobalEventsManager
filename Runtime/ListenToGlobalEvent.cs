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
        public GlobalEvent gameEvent;

        [BoxGroup("Headers")]
        [InfoBox("Headers can be used to pass information to subscribers of GlobalEvents. You can select a header value here to be passed as a parameter to the subscribers of the UnityEvent. More headers can be accessed via code", InfoMessageType.None)]
        public string headerName = "Count";
        [BoxGroup("Headers")]
        public HeaderType headerType = HeaderType.Float;

        public enum HeaderType
        {
            Int,
            Float,
            String,
            Null,
        }
        [BoxGroup("Headers")]
        [ShowIf("@headerType == HeaderType.Float")]
        public FloatUnityEvent OnTriggeredFloat = new FloatUnityEvent();
        [BoxGroup("Headers")]
        [ShowIf("@headerType == HeaderType.Int")]
        public IntUnityEvent OnTriggeredInt = new IntUnityEvent();
        [BoxGroup("Headers")]
        [ShowIf("@headerType == HeaderType.String")]
        public StringUnityEvent OnTriggeredString = new StringUnityEvent();
        [BoxGroup("Headers")]
        [ShowIf("@headerType == HeaderType.Null")]
        public UnityEvent OnTriggered = new UnityEvent();

        void Awake()
        {
            GlobalEventsManager.StartListening(gameEvent.name, EventTriggered);
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
