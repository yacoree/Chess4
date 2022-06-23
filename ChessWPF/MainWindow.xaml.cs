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
        Piece figure;
        string chess;
        bool currentChess;
        Button bntFirstPosition;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btnClicked = (Button)sender;
                int row = Grid.GetRow(btnClicked);
                int col = Grid.GetColumn(btnClicked);
                
                if ((btnClicked.Content == null & currentChess))
                {
                    if (figure.TestMove(row, col))
                    {
                        figure.Move(row, col);
                        btnClicked.Tag = figure;
                        bntFirstPosition.Content = null;
                        btnClicked.Content = chess;
                        chess = null;
                    }

                    else
                    {
                        throw new Exception("Invalid position");
                    }
                    currentChess = false;
                    return;
                }

                if (btnClicked.Content != null)
                {
                    currentChess = true;
                    bntFirstPosition = (Button)sender;
                    figure = btnClicked.Tag as Piece;
                    btnClicked.Tag = null;
                    chess = bntFirstPosition.Content.ToString();
                    return;
                }

                if (btnClicked.Content == null)
                {
                    figure = PieceMaker.Make(chess, row, col);
                    btnClicked.Tag = figure;
                    btnClicked.Content = chess;
                    return;
                }
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
                case "King": chess = "King";
                    break;
                case "Queen": chess = "Queen";
                    break;
                case "Rook": chess = "Rook";
                    break;
                case "Bishop": chess = "Bishop";
                    break;
                case "Knight": chess = "Knight";
                    break;
            }
        }
    }
}
