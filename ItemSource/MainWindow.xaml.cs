using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Xml;
using System.Xml.Linq;

namespace ItemSource
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Student_Id=5;
        public ObservableCollection<Student> list;
        public MainWindow()
        {
            InitializeComponent();
            list = new ObservableCollection<Student> {
                new Student { Name = "威震天",ID=1 },
                new Student { Name = "擎天柱",ID=2 },
                new Student { Name = "大黄蜂",ID=3 },
                new Student { Name = "汽车人",ID=4 },
                new Student { Name = "霸天虎",ID=5 }
            };
            studentList.ItemsSource = list;
           
            studentList.DisplayMemberPath = "Name";
            Binding binding = new Binding { Path = new PropertyPath("SelectedItem.ID"), Source = studentList };
            studentId.SetBinding(TextBox.TextProperty, binding);

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student_Id++;
            list.Add(new Student { Name = "人类", ID = Student_Id });
        }
    }


    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        public int ID { get; set; }
        public string Name
        {
            get { return name; }

            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));

            }
        }

    }
}
