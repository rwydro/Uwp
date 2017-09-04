using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ApiControlRobot.VIewModel;

namespace ApiControlRobot
{
    /// <summary>
    ///     Interaction logic for ControlRobotView.xaml
    /// </summary>
    public partial class ControlRobotView : Window
    {
        private readonly ChoiceDirection choiceDirection;
        private ControlRobotViewModel viewModel;

        public ControlRobotView()
        {
            InitializeComponent();
            choiceDirection = new ChoiceDirection();
            viewModel = new ControlRobotViewModel(choiceDirection);
            DataContext = viewModel;
            this.KeyDown += new KeyEventHandler(UIElement_OnKeyDown);
            this.KeyUp += new KeyEventHandler(UIElement_OnKeyUp);
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var arrow = ((Image) sender).Parent as Button;
            arrow.Opacity = 0.25;
            choiceDirection.OnChoiceDrivingDirection(new DrivingDirectionEventArgs {Direction = arrow.Name});
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var button = (Button) sender;
            button.Opacity = 1;
            choiceDirection.OnChoiceDrivingDirection(new DrivingDirectionEventArgs {Direction = "Stop"});
        }

        private void UIElement_OnKeyUp(object sender, KeyEventArgs e)
        {
            this.Up.Opacity = 1;
            this.Down.Opacity = 1;
            this.Right.Opacity = 1;
            this.Left.Opacity = 1;
            choiceDirection.OnChoiceDrivingDirection(new DrivingDirectionEventArgs { Direction = "Stop" });
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {

            var key = e.Key;
            
            switch (key)
            {
                case  Key.Up:
                    this.Up.Opacity = 0.25;
                    choiceDirection.OnChoiceDrivingDirection(new DrivingDirectionEventArgs { Direction = "Up" });
                    break;
                case Key.Down:
                    this.Down.Opacity = 0.25;
                    choiceDirection.OnChoiceDrivingDirection(new DrivingDirectionEventArgs { Direction = "Down" });
                    break;
                case Key.Left:
                    this.Left.Opacity = 0.25;
                    choiceDirection.OnChoiceDrivingDirection(new DrivingDirectionEventArgs { Direction = "Left" });
                    break;
                case Key.Right:
                    this.Right.Opacity = 0.25;
                    choiceDirection.OnChoiceDrivingDirection(new DrivingDirectionEventArgs { Direction = "Right" });
                    break;
            }

        }
    }
}