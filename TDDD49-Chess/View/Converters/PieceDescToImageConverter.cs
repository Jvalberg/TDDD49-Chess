using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TDDD49_Chess.View.Converters
{
    public class PieceDescToImageConverter : DependencyObject, IMultiValueConverter
    {
        ImageSource[] WhitePieces;
        ImageSource[] BlackPieces;

        public PieceDescToImageConverter()
        {
            Initialize();
        }

        public void Initialize()
        {
            WhitePieces = new BitmapImage[6];
            WhitePieces[0] = new BitmapImage(new Uri("/View/Resources/w_king.png", UriKind.Relative));
            WhitePieces[1] = new BitmapImage(new Uri("/View/Resources/w_queen.png", UriKind.Relative));
            WhitePieces[2] = new BitmapImage(new Uri("/View/Resources/w_bishop.png", UriKind.Relative));
            WhitePieces[3] = new BitmapImage(new Uri("/View/Resources/w_knight.png", UriKind.Relative));
            WhitePieces[4] = new BitmapImage(new Uri("/View/Resources/w_rook.png", UriKind.Relative));
            WhitePieces[5] = new BitmapImage(new Uri("/View/Resources/w_pawn.png", UriKind.Relative));

            BlackPieces = new BitmapImage[6];
            BlackPieces[0] = new BitmapImage(new Uri("/View/Resources/b_king.png", UriKind.Relative));
            BlackPieces[1] = new BitmapImage(new Uri("/View/Resources/b_queen.png", UriKind.Relative));
            BlackPieces[2] = new BitmapImage(new Uri("/View/Resources/b_bishop.png", UriKind.Relative));
            BlackPieces[3] = new BitmapImage(new Uri("/View/Resources/b_knight.png", UriKind.Relative));
            BlackPieces[4] = new BitmapImage(new Uri("/View/Resources/b_rook.png", UriKind.Relative));
            BlackPieces[5] = new BitmapImage(new Uri("/View/Resources/b_pawn.png", UriKind.Relative));
        }

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int piece = (int)values[0];
            int side = (int)values[1];

            if(side == ChessColor.BLACK)
            {
                if (piece >= 0 && piece < 6)
                    return BlackPieces[piece];
            }
            else
            {
                if (piece >= 0 && piece < 6)
                    return WhitePieces[piece];
            }
            return null; //No image
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
