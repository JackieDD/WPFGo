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

namespace CommandGo
{
    /// <summary>
    /// CommandParameter.xaml 的交互逻辑
    /// </summary>
    public partial class CommandParameter : Window
    {
        public CommandParameter()
        {
            InitializeComponent();
        }

        private void New_CanExcute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrWhiteSpace(nameTextBox.Text);
        }

        private void New_Excuted(object sender, ExecutedRoutedEventArgs e)
        {
            string name = nameTextBox.Text;
            if (e.Parameter.ToString() == "Teacher")
                listBoxItems.Items.Add($"New teacher {name}");
            else
                listBoxItems.Items.Add($"New Student {name}");
        }
    }
}
