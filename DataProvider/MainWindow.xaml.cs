using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace DataProvider
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Trace.WriteLine("111");
            InitializeComponent();
            ObjectDataProvider objectDataProvider = new ObjectDataProvider
            {
                // ObjectInstance = new Calculator(),
                ObjectType = typeof(Calculator),
                MethodName = "Add"
            };
            objectDataProvider.MethodParameters.Add("0");
            objectDataProvider.MethodParameters.Add("0");
            addParam1.SetBinding(TextBox.TextProperty, new Binding("MethodParameters[0]") { Source = objectDataProvider, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, BindsDirectlyToSource = true });
            addParam2.SetBinding(TextBox.TextProperty, new Binding("MethodParameters[1]") { Source = objectDataProvider, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, BindsDirectlyToSource = true });
            addResult.SetBinding(TextBox.TextProperty, new Binding(".") { Source = objectDataProvider, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged/*, BindsDirectlyToSource = true*/ });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObjectDataProvider objectDataProvider = new ObjectDataProvider
            {
                ObjectInstance = new Calculator(),
                MethodName = "Add"
            };
            objectDataProvider.MethodParameters.Add("1");
            objectDataProvider.MethodParameters.Add("2");
            MessageBox.Show(objectDataProvider.Data.ToString());
            Dictionary<string,string> keyValuePairs= new Dictionary<string, string> { [""]=""};
        }
    }

    public class Calculator
    {
        public long Add(string a, string b)
        {
            try
            {
                return long.Parse(a) + long.Parse(b);
            }
            catch (Exception)
            {
                return 0;

            }

        }
    }
}
