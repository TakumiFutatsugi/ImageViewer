using System;
using System.Globalization;
using System.Windows.Data;

namespace ImageViwer
{
    class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Double width = 0;
            switch (value.ToString())
            {
                case "1":
                    width = Properties.Settings.Default.thumbnailSmall * 4;
                    break;
                case "2":
                    width = Properties.Settings.Default.thumbnailMiddle * 4;
                    break;
                case "3":
                    width = Properties.Settings.Default.thumbnailLarge * 4;
                    break;
            }
            return width;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
