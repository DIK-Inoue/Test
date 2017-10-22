using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp1.Converters
{
    class DecimalConverter : IValueConverter
    {
        private object prev;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Console.WriteLine("C : " + value);
            if (string.IsNullOrEmpty(value?.ToString()))
            {
                Console.WriteLine("  -> null");
                prev = null;
                return null;
            }
            if (decimal.TryParse(value.ToString(), out decimal ret))
            {
                Console.WriteLine("  -> decimal value");
                prev = value;
                return value;
            }
            Console.WriteLine("  -> fail");
            return prev;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(value, targetType, parameter, culture);
        }
    }
}
