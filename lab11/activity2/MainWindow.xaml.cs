using System.Windows;
using System.Windows.Controls;

namespace WPFCheckBoxControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb.Name == "checkBox1") textBox1.Text = "2 state CheckBox is checked."; else textBox2.Text = "3 state CheckBox is checked.";
          
        






}

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;

            if (cb.Name == "checkBox1") textBox1.Text = "2 state CheckBox is unchecked."; else textBox2.Text = "3 state CheckBox is unchecked.";
        }

        private void HandleThirdState(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            textBox2.Text = "3 state CheckBox is in indeterminate state.";
        }

    }
}
