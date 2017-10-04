using System;

namespace ApiControlRobot
{
    public class DrivingDirectionEventArgs : EventArgs
    {
        public string Direction { get; set; }
    }

    public class ChoiceDirectionEvent
    {
        public event EventHandler<DrivingDirectionEventArgs> ChoiceDirectionEventHandler;

        public void OnChoiceDrivingDirection(DrivingDirectionEventArgs e)
        {
            var choiceDirectionEventHandler = ChoiceDirectionEventHandler;
            if (choiceDirectionEventHandler != null)
                choiceDirectionEventHandler(this, e);
        }
    }
}