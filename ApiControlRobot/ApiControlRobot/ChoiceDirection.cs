using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiControlRobot
{
    public class DrivingDirectionEventArgs : EventArgs
    {
        public string Direction { get; set; }
    }
    public class ChoiceDirection
    {
        public event EventHandler<DrivingDirectionEventArgs> ChoiceDirectionEventHandler;

        public void OnChoiceDrivingDirection(DrivingDirectionEventArgs e)
        {
            EventHandler<DrivingDirectionEventArgs> choiceDirectionEventHandler = ChoiceDirectionEventHandler;
            if (choiceDirectionEventHandler !=null)
            {
                choiceDirectionEventHandler(this, e);
            }
        }
    }


}
