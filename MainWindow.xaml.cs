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
using System.ComponentModel;

namespace ConwaysGameOfLife
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameOfLife life;
        private DispatcherTimer timer;
        public double TimerMilliseconds
        {
            get
            {
                return timer.Interval.TotalMilliseconds;
            }
            set
            {
                timer.Interval = TimeSpan.FromMilliseconds(Convert.ToInt32(value));
            }
        }

        public string TimerText
        { get
            {
                return timer.Interval.ToString() + ":";
            } }
        public MainWindow()
        {
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            InitializeComponent();
            life = new GameOfLife();
            Spielfeld.ItemsSource = life.spielfeld;

        }

        private void BtnSingleStep_Click(object sender, RoutedEventArgs e)
        {
            life.StepLife();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            life.StepLife();
        }

        private void BtnAutoPlay_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                btnAutoPlay.Content = "Start Auto Play";
            }
            else
            {
                timer.Start();
                btnAutoPlay.Content = "Stop Auto Play";
            }
        }
    }
}
