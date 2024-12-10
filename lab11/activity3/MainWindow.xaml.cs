using System.Windows;
using System.Windows.Controls;

namespace WPFComboBoxControl
{
    public partial class MainWindow : Window
    {

        public MainWindow() { InitializeComponent(); }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox.Text = comboBox.SelectedItem.ToString();
        }

        private void Combo1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox1.Text = comboBox1.SelectedItem.ToString();
        }
    }
}
