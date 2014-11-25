using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TDDD49_Chess.View.Converters
{
    public class IndexToBackgroundConverter : DependencyObject, IMultiValueConverter
    {
        public static readonly DependencyProperty OddColorProperty =
            DependencyProperty.Register("OddColor", typeof(Color), typeof(IndexToBackgroundConverter));
        public Color OddColor
        {
            get { return (Color)this.GetValue(OddColorProperty); }
            set { this.SetValue(OddColorProperty, value); }
        }

        public static readonly DependencyProperty EvenColorProperty =
            DependencyProperty.Register("EvenColor", typeof(Color), typeof(IndexToBackgroundConverter));
        public Color EvenColor
        {
            get { return (Color)this.GetValue(EvenColorProperty); }
            set { this.SetValue(EvenColorProperty, value); }
        }


        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var x = (int)values[0];
            var y = (int)values[1];
            var validMove = (Boolean)values[2];
            if(validMove != null)
            {
                if(validMove)
                {
                    return Brushes.Crimson;
                }
            }
            if ((x + y) % 2 == 0)
                return new SolidColorBrush(EvenColor);
            else
                return new SolidColorBrush(OddColor);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
