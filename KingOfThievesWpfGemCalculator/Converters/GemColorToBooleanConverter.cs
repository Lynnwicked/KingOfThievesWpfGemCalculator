using System;
using System.Globalization;
using System.Windows.Data;
using KingOfThievesWpfGemCalculator.Enums;

namespace KingOfThievesWpfGemCalculator.Converters {
  public class GemColorToBooleanConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
      if (parameter == null) {
        throw new InvalidOperationException("Parameter cannot be null or empty");
      }

      return value.ToString() == parameter.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
      if (parameter == null) {
        throw new InvalidOperationException("Parameter cannot be null or empty");
      }

      var result = Enum.Parse(typeof(GemColor), parameter.ToString());

      return result;
    }
  }
}