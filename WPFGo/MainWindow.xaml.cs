using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WPFGo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    /// 
    public delegate void DoEventHandler(object sender, DoEventArgs e);
    public partial class MainWindow : Window
    {
        public event DoEventHandler doSomething;
        public MainWindow()
        {

            InitializeComponent();
            //Binding binding = new Binding("Value") { ElementName = "slider", UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged, NotifyOnValidationError = true };
            //binding.ValidationRules.Add(new RangeValidationRule { ValidatesOnTargetUpdated = true });
            //sliderNum.SetBinding(TextBox.TextProperty, binding);
            sliderNum.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(ValidationError));
        
        }

        void ValidationError(object sender,RoutedEventArgs e)
        {
            if (Validation.GetErrors(sliderNum).Any())
                sliderNum.ToolTip = Validation.GetErrors(sliderNum)[0].ErrorContent.ToString();
        }
    }

    public class RangeValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (double.TryParse(value.ToString(), out double d))
            {
                if (d >= 0 && d <= 100)
                {
                    return new ValidationResult(true, null);
                }
            }
            return new ValidationResult(false, "Validation Failed");
        }
    }


    public class DoEventArgs : EventArgs
    {

    }
}
