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
    /// MyCommand.xaml 的交互逻辑
    /// </summary>
    public partial class MyCommand : Window
    {
        public MyCommand()
        {
      
            InitializeComponent();
            ClearCommand clearCommand = new ClearCommand();
            ctrlClear.Command = clearCommand;
            ctrlClear.CommandTarget = miniView;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            MainWindow mainWindow = new MainWindow();
            GetWindow(this).Close();
            mainWindow.Show();
           
        }
    }
    public class ClearCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            (parameter as IView)?.Clear();
            
        }
    }

    public class MyCommandSource : UserControl, ICommandSource
    {
        public ICommand Command { get; set; }

        public object CommandParameter { get; set; }

        public IInputElement CommandTarget { get; set; }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            Command?.Execute(CommandTarget);
        }
    }
}
