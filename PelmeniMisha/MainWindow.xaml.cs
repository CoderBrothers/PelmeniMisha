using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace PelmeniMisha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int _hours = 0;
        private int _minutes = 0;
        private int _seconds = 0;
        private bool _active;
        DispatcherTimer _timer;
        private void PlusHours_Click(object sender, RoutedEventArgs e)
        {
            if(_hours < 99) _hours++;
            Hours.Text = _hours.ToString("00");
        }

        private void MinusHours_Click(object sender, RoutedEventArgs e)
        {
            if (_hours > 0) _hours--;
            Hours.Text = _hours.ToString("00");
        }

        private void PlusMinutes_Click(object sender, RoutedEventArgs e)
        {
            if (_minutes > 58) 
            {
                _minutes = 0;
                Minutes.Text = _minutes.ToString("00");
                PlusHours_Click(sender, e);
                return;
            }
            _minutes++;
            Minutes.Text = _minutes.ToString("00");
        }

        private void MinusMinutes_Click(object sender, RoutedEventArgs e)
        {
            if (_minutes > 0) _minutes--;
            Minutes.Text = _minutes.ToString("00");
        }

        private void PlusSeconds_Click(object sender, RoutedEventArgs e)
        {
            if(_seconds > 58)
            {
                _seconds = 0;
                Seconds.Text = _seconds.ToString("00");
                PlusMinutes_Click(sender, e);
                return;
            }
            _seconds++;
            Seconds.Text = _seconds.ToString("00");
        }

        private void MinusSeconds_Click(object sender, RoutedEventArgs e)
        {
            if (_seconds > 0) _seconds--;
            Seconds.Text = _seconds.ToString("00");
        }
        private void Countdown(object sender, EventArgs e)
        {
            if (_seconds > 0) _seconds--;
            else if (_seconds == 0 && _minutes > 0)
            {
                _minutes--;
                _seconds = 59;
            } 
            else if(_seconds == 0 && _minutes == 0 && _hours > 0)
            {
                _hours--;
                _minutes = 59;
                _seconds = 59;
            }
            else 
            {
                _timer.Stop();
                _active = false;
                Start.Content = "Start";
                WindowState = WindowState.Normal;
                Console.Beep(500, 250);
                Console.Beep(500, 250);
                Console.Beep(500, 250);
            }
            Seconds.Text = _seconds.ToString("00");
            Minutes.Text = _minutes.ToString("00");
            Hours.Text = _hours.ToString("00");
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (!_active)
            {
                _timer = new DispatcherTimer(new TimeSpan(0,0,1), DispatcherPriority.Normal, Countdown, Application.Current.Dispatcher);
                _timer.Start();
                _active = true;
                Start.Content = "Stop";
            }
            else
            {
                _timer.Stop();
                _active = false;
                Start.Content = "Start";
            }
        }
    }
}
