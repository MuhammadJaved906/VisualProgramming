using System.Collections.ObjectModel;
using System.Windows;

namespace CricketTeamManager
{
    public partial class MainWindow : Window
    {
        // ObservableCollection to hold the list of players
        public ObservableCollection<string> Players { get; set; } = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

            // Bind the ListBox to the ObservableCollection
            PlayerListBox.ItemsSource = Players;
        }

        // Event handler for Add Player button
        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string playerName = PlayerNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(playerName))
            {
                MessageBox.Show("Player name cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (Players.Contains(playerName))
            {
                MessageBox.Show("This player is already in the roster.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Players.Add(playerName);
            PlayerNameTextBox.Clear();
            MessageBox.Show($"Player '{playerName}' added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Event handler for Remove Player button
        private void RemovePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedPlayer = PlayerListBox.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedPlayer))
            {
                MessageBox.Show("Please select a player to remove.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Players.Remove(selectedPlayer);
            MessageBox.Show($"Player '{selectedPlayer}' removed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
