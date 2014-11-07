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
            DependencyProperty.Register("OddColor", typeof(SolidColorBrush), typeof(IndexToBackgroundConverter));
        public SolidColorBrush OddColor
        {
            get { return (SolidColorBrush)this.GetValue(OddColorProperty); }
            set { this.SetValue(OddColorProperty, value); }
        }

        public static readonly DependencyProperty EvenColorProperty =
            DependencyProperty.Register("EvenColor", typeof(SolidColorBrush), typeof(IndexToBackgroundConverter));
        public SolidColorBrush EvenColor
        {
            get { return (SolidColorBrush)this.GetValue(EvenColorProperty); }
            set { this.SetValue(EvenColorProperty, value); }
        }


        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var x = (int)values[0];
            var y = (int)values[1];
            if ((x + y) % 2 == 0)
                return EvenColor;
            else
                return OddColor;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
