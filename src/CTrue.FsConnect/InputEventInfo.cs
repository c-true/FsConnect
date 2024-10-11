using System;

namespace CTrue.FsConnect
{
    public class InputEventInfo
    {
        public Enum JoystickButtonEventId { get; }
        public Enum JoystickButtonEventGroup { get; }
        public Enum InputGroup { get; }
        public string InputDefinition { get; }

        public InputEventRaised InputEventRaisedDelegate { get; }

        public InputEventInfo(Enum joystickButtonEventId, Enum joystickButtonEventGroup, Enum inputGroup, string inputDefinition, InputEventRaised inputEventRaisedDelegate)
        {
            JoystickButtonEventId = joystickButtonEventId;
            JoystickButtonEventGroup = joystickButtonEventGroup;
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