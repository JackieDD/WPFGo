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

namespace BindingGo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly List<Student> studentList;
        public MainWindow()
        {
            DataContext = "磊哥大黑狗";
            InitializeComponent();
            studentList = new List<Student> { new Student { Students=new List<Student> { new Student()} } };
            Binding binding = new Binding("/Students/Name") // /表示默认元素 后面紧接属性
            {
                Source = studentList,
                Mode=BindingMode.OneWay
               // Path = new PropertyPath(nameof(stu.Name)),              
            };
            BindingOperations.SetBinding(textBoxName, TextBox.TextProperty, binding);
            //textBoxName.SetBinding(TextBox.TextProperty, binding);

           // RelativeSource relativeSource = new RelativeSource(RelativeSourceMode.FindAncestor);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            studentList[0].Students[0].Name += textBoxName.DataContext.ToString();
        }
    }
}
