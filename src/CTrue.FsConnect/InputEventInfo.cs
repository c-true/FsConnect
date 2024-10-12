using System;

namespace CTrue.FsConnect
{
    public class InputEventInfo
    {
        public Enum ClientEventId { get; }
        public Enum NotificationGroupId { get; }
        public Enum InputGroup { get; }
        public string InputDefinition { get; }

        public InputEventRaised InputEventRaisedDelegate { get; }

        public InputEventInfo(Enum clientEventId, Enum notificationGroupId, Enum inputGroup, string inputDefinition, InputEventRaised inputEventRaisedDelegate)
        {
            ClientEventId = clientEventId;
            NotificationGroupId = notificationGroupId;
            InputGroup = inputGroup;
            InputDefinition = inputDefinition;
            InputEventRaisedDelegate = inputEventRaisedDelegate;
        }

        public void RaiseInputEvent()
        {
            InputEventRaisedDelegate.Invoke();
        }
    }

    public delegate void InputEventRaised();
}