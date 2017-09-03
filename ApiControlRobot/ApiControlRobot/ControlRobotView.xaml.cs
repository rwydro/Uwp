using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ApiControlRobot.VIewModel;

namespace ApiControlRobot
{
    /// <summary>
    ///     Interaction logic for ControlRobotView.xaml
    /// </summary>
    public partial class ControlRobotView : Window
    {
        private readonly ChoiceDirection choiceDirection;

        public ControlRobotView()
        {
            InitializeComponent();
            choiceDirection = new ChoiceDirection();
            var viewModel = new ControlRobotViewModel(choiceDirection);
            DataContext = viewModel;
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var arrow = (Image) sender;
            choiceDirection.OnChoiceDrivingDirection(new DrivingDirectionEventArgs {Direction = arrow.Name});
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            choiceDirection.OnChoiceDrivingDirection(new DrivingDirectionEventArgs {Direction = "Stop"});
        }
    }
}