using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp2.Helpers
{
    public class TabSizeConvert : IMultiValueConverter
    {
      
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            TabControl tabControl = values[0] as TabControl;
            double width = tabControl.ActualWidth / tabControl.Items.Count - tabControl.Items.Count;
            //Subtract 1, otherwise we could overflow to two rows.
            return (width <= 1) ? 0 : (width );
        }

       

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
