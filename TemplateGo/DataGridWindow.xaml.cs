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
            Student stu = contentPresenter.Content as Student;
            listViewStudent.SelectedItem = stu;
        
            ListViewItem lvi = listViewStudent.ItemContainerGenerator.ContainerFromItem(stu) as ListViewItem;
            CheckBox chb = FindVisualChild<CheckBox>(lvi);
            MessageBox.Show(chb.Name);
          
        }

        private T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return child as T;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
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
