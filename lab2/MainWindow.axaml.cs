using Avalonia.Controls;
using Avalonia.Media;
using System.Drawing;

namespace Avalonia_
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button.Background != null)
            {
                Rect.Fill = button.Background;
            }
        }
    }
}