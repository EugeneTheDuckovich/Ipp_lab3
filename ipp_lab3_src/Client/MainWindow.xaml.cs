using CursorLibrary;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TcpClient _client;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ClientDataContext();

            _client = new TcpClient();
            Task.WaitAll(_client.ConnectAsync("127.0.0.1",8888));
        }

        private async void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox is null) return;

            var cursor = (ServerCursor)comboBox.SelectedItem;
            var bytes = BitConverter.GetBytes((int)cursor);
            await _client.GetStream().WriteAsync(bytes);
        }
    }
}
