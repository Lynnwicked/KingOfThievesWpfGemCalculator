using System.Windows;
using KingOfThievesWpfGemCalculator.Models;

namespace KingOfThievesWpfGemCalculator.Extensions {
  public static class GemExtensions {
    public static bool IsValid(this Gem g) {
      if (g.Amount != null && g.Amount > 0) {
        return true;
      }

      MessageBox.Show($"{g.Name} gem is invalid, please enter a valid positive number", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

      return false;
    }
  }
}