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
            g1.AddHandler(Student.NameChangedEvent, new RoutedEventHandler(StudentNameChangedHandler));
        }


        public void ReportTimeHandler(object sender, ReportTimeEventArgs e)
        {
            MessageBox.Show((sender as FrameworkElement).Name + "  " + e.ClickTime.ToString());
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student() { ID = 1, Name = "磊哥" };
            btn2.RaiseEvent(new RoutedEventArgs(Student.NameChangedEvent,student));
        }

        private void StudentNameChangedHandler(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((e.OriginalSource as Student).ID.ToString());
        }
    }

    public class ReportTimeEventArgs : RoutedEventArgs
    {
        public ReportTimeEventArgs(RoutedEvent e, object source) : base(e, source) { }

        public DateTime ClickTime { get; set; }

    }
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public static readonly RoutedEvent NameChangedEvent =
            EventManager.RegisterRoutedEvent("NameChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Student));

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

            RaiseEvent(reportTimeEventArgs);
        }
      

    }
}
