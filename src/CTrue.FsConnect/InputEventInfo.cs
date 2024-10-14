using System;

namespace CTrue.FsConnect
{
    /// <summary>
    /// The <see cref="InputEventInfo"/> is used to register a binding between an input event and client event.
    /// </summary>
    public class InputEventInfo
    {
        public Enum ClientEventId { get; }
        public string ClientEventName { get; }
        public Enum NotificationGroupId { get; }
        public Enum InputGroup { get; }
        public string InputDefinition { get; }

        public InputEventRaised InputEventRaisedDelegate { get; }

        /// <summary>
        /// Creates an <see cref="InputEventInfo"/> instance.
        /// </summary>
        /// <param name="clientEventId"></param>
        /// <param name="notificationGroupId"></param>
        /// <param name="inputGroup"></param>
        /// <param name="inputDefinition"></param>
        /// <param name="inputEventRaisedDelegate"></param>
        public InputEventInfo(Enum clientEventId, Enum notificationGroupId, Enum inputGroup, string inputDefinition, InputEventRaised inputEventRaisedDelegate)
        : this(clientEventId, null, notificationGroupId, inputGroup, inputDefinition, inputEventRaisedDelegate)
        {
        }

        public InputEventInfo(Enum clientEventId, string clientEventName, Enum notificationGroupId, Enum inputGroup, string inputDefinition,
            InputEventRaised inputEventRaisedDelegate)
        {
            ClientEventId = clientEventId;
            ClientEventName = clientEventName;
            NotificationGroupId = notificationGroupId;
            InputGroup = inputGroup;
            InputDefinition = inputDefinition;
            InputEventRaisedDelegate = inputEventRaisedDelegate;
        }

        /// <summary>
        /// Invokes the registered delegate.
        /// </summary>
        public void RaiseInputEvent()
        {
            InputEventRaisedDelegate?.Invoke(this);
        }
    }

    public delegate void InputEventRaised(InputEventInfo iei);
}