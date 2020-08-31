using System;
using System.Globalization;
using System.Windows.Data;

namespace ImageViwer
{
    class ThumbnailSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string thumbnailSize = "Middle";
            switch (value.ToString())
            {
                case "1":
                    thumbnailSize = "Small";
                    break;
                case "2":
                    thumbnailSize = "Middle";
                    break;
                case "3":
                    thumbnailSize = "Large";
                    break;
            }
            return thumbnailSize;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
