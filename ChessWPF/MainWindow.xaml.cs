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
        Button btnFirstPosition;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btnClicked = (Button)sender;
                int row = Grid.GetRow(btnClicked);
                int col = Grid.GetColumn(btnClicked);

                if ((btnClicked.Content == null || 
                    (btnClicked.Content != null & btnClicked.Tag != null & btnClicked != btnFirstPosition)) & currentChess)
                {
                    ChessMovement(btnClicked, row, col);
                    return;
                }

                if (btnClicked.Content != null )
                {
                    ChessPreparation(sender, btnClicked, row, col);
                    return;
                }

                if (btnClicked.Content == null)
                {
                    ChessMake(btnClicked, row, col);
                    return;
                }
            }
            catch 
            { }
        }

        //Создание шахматной фигуры на доске
        public void ChessMake(Button btnClicked, int row, int col)
        {
            figure = PieceMaker.Make(chess, row, col);
            btnClicked.Tag = figure;
            btnClicked.Content = chess;
        }

        //Подготовка шахматной фигуру к ходу
        public void ChessPreparation(object sender, Button btnClicked, int row, int col)
        {
            currentChess = true;
            btnFirstPosition = (Button)sender;
            figure = btnClicked.Tag as Piece;
            chess = btnFirstPosition.Content.ToString();
        }
        
        //Ход шахматной фигуры в зависимости от правильности хода
        public void ChessMovement(Button btnClicked, int row, int col)
        {
            if (figure.TestMove(row, col))
            {
                figure.Move(row, col);
                btnClicked.Tag = figure;
                btnFirstPosition.Content = null;
                btnFirstPosition.Tag = null;
                btnClicked.Content = chess;
                chess = null;
                currentChess = false;
            }

            else
            {
                currentChess = false;
            }
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
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {

            MainWindow newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }
    }
}
