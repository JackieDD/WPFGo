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

namespace EventGO
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent e, object source) : base(e, source) { }

        public DateTime ClickTime { get; set; }

    }

    public class TimeButton : Button
    {
        public static readonly RoutedEvent ReportTimeEvent = EventManager.RegisterRoutedEvent
            ("ReportTime", RoutingStrategy.Bubble, typeof(EventHandler<ReportTimeEventArgs>), typeof(TimeButton));
        public event RoutedEventHandler ReportTime
        {
            add
            {
                AddHandler(ReportTimeEvent, value);
            }
            remove
            {
                RemoveHandler(ReportTimeEvent, value);
            }
        }

        protected override void OnClick()
        {
            base.OnClick();
            ReportTimeEventArgs reportTimeEventArgs = new ReportTimeEventArgs(ReportTimeEvent, this) { ClickTime = DateTime.Now };
            ReportTime += TimeButton_ReportTime;
            RaiseEvent(reportTimeEventArgs);
        }

        private void TimeButton_ReportTime(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((ReportTimeEventArgs)e).ClickTime.ToString());
        }
    }
}
