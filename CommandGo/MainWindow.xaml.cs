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

namespace CommandGo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeCommand();
        }
        private RoutedCommand ClearCmd = new RoutedCommand("Clear", typeof(MainWindow));
        private void InitializeCommand()
        {
            button1.Command = ClearCmd; //赋值给命令源
            ClearCmd.InputGestures.Add(new KeyGesture(Key.C, ModifierKeys.Alt)); //快捷键
            button1.CommandTarget = textBoxA; //命令目标
            //创建命令关联
            CommandBinding cb = new CommandBinding(ClearCmd, new ExecutedRoutedEventHandler(ExecutedRoutedHandler), new CanExecuteRoutedEventHandler(CanExecuteRoutedHandler));
            CommandBindings.Add(cb);
            
        }

        private void ExecutedRoutedHandler(object sender, ExecutedRoutedEventArgs e)
        {            
            textBoxA.Clear();
            e.Handled = true;
        }

        private void CanExecuteRoutedHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrWhiteSpace(textBoxA.Text);
            e.Handled = true;
        }
    }
}
