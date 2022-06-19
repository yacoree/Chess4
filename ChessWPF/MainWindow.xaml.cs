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

namespace ChessWPF
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
        List<string> chess = new List<string>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btnClicked = (Button)sender;
                int row = Grid.GetRow(btnClicked);
                int col = Grid.GetColumn(btnClicked);
                Piece f = PieceMaker.Make(chess[0], row, col);
                btnClicked.Content = "King";
                chess.Clear();
            }
            catch 
            { }
        }

        private void cbPieces_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbTemp = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)cbTemp.SelectedItem;
            switch (selectedItem.Content)
            {
                case "King": chess.Add("King");
                break;
            }
        }
    }
}
