using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AForge.Video;

namespace ApiControlRobot
{
    /// <summary>
    /// Interaction logic for CameraStreamView.xaml
    /// </summary>
    public partial class CameraStreamView : UserControl
    {
        private MJPEGStream myStream;
        public CameraStreamView()
        {
            InitializeComponent();
            myStream = new MJPEGStream("http://192.168.0.21:8081");
            myStream.NewFrame += stream_NewFrame;
            myStream.Start();
        }

        private void stream_NewFrame(object sender, NewFrameEventArgs eventargs)
        {
            BitmapImage mapImage;
            using (var bitmap = (Bitmap)eventargs.Frame.Clone())
            {
                mapImage = bitmap.ToBitMapImage();
            }
            mapImage.Freeze();

            Dispatcher.BeginInvoke(new ThreadStart(delegate { picture.Source = mapImage; }));
        }

    }
}
