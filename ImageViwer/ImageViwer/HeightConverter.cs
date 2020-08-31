using System;
using System.Globalization;
using System.Windows.Data;

namespace ImageViwer
{
    class HeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Double height = 0;
            switch (value.ToString())
            {
                case "1":
                    height = Properties.Settings.Default.thumbnailSmall * 3;
                    break;
                case "2":
                    height = Properties.Settings.Default.thumbnailMiddle * 3;
                    break;
                case "3":
                    height = Properties.Settings.Default.thumbnailLarge * 3;
                    break;
            }
            return height;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
