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

namespace ResourceGo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show(FindResource("str").ToString());
            //MessageBox.Show(Resources["dbl"].ToString()); //此类资源字典中
            Resources["t1"] = new TextBlock { Text = "动态改变" };
            //MessageBox.Show(Properties.Resources.ResourceManager.GetString("dog").ToString());
            string a = string.Empty;
            Properties.Resources.Creasoft_Utils_deps.ToList().ForEach(c => a += c.ToString());
            MessageBox.Show(a);

        }
    }
}
