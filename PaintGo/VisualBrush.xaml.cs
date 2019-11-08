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

namespace PaintGo
{
    /// <summary>
    /// VisualBrush.xaml 的交互逻辑
    /// </summary>
    public partial class VisualBrushGo : Window
    {
        double O = 1;
        public VisualBrushGo()
        {
            InitializeComponent();
        }

        private void CloneVisual(object sender, RoutedEventArgs e)
        {
            VisualBrush visualBrush = new VisualBrush(realButton);
            Rectangle rectangle = new Rectangle();
            rectangle.Width = realButton.ActualWidth;
            rectangle.Height = realButton.ActualHeight;
            rectangle.Fill = visualBrush;
            rectangle.Opacity = O;
            O -= 0.2;
            stackPanelRight.Children.Add(rectangle);
        }
    }
}
