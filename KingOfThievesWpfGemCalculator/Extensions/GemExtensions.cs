using System.Windows;
using KingOfThievesWpfGemCalculator.Models;
using KingOfThievesWpfGemCalculator.Utilities;

namespace KingOfThievesWpfGemCalculator.Extensions {
  public static class GemExtensions {
    public static string GetGemImage(this Gem g) {
      if (g.Amount == null) {
        return string.Empty;
      }

      var result = GemUtility.GetGemImage(g.Amount.Value, g.Color);

      return result;
    }

    public static int GetGemSize(this Gem g) {
      if (g.Amount != null && g.Amount > 0) {
        return g.Amount.Value;
      }

      MessageBox.Show($"{g.Name} gem is invalid, please enter a valid positive number", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

      return 0;
    }
  }
}