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
using System.Windows.Shapes;

namespace TemplateGo
{
    /// <summary>
    /// DataGridWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridWindow : Window
    {
        public DataGridWindow()
        {
            InitializeComponent();
        }

        private void TextBoxName_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = e.OriginalSource as TextBox;
            ContentPresenter contentPresenter = tb.TemplatedParent as ContentPresenter;
                
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Skill { get; set; }
        public bool HasJob { get; set; }
    }
}
