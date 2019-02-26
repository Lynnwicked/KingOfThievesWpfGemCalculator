using System;
using KingOfThievesWpfGemCalculator.Enums;

namespace KingOfThievesWpfGemCalculator.Utilities {
  public static class RitualUtility {
    public static string GetPotionResult(GemColor color1, GemColor color2, GemColor color3) {
      if (color1 != color2 || color2 != color3 || color3 != color1) {
        return null;
      }

      string result;

      switch (color1) {
        case GemColor.Blue:
          result = "pack://application:,,,/Resources/Images/Potions/GangOfThieves.png";

          break;
        case GemColor.Green:
          result = "pack://application:,,,/Resources/Images/Potions/SlowMotion.png";

          break;
        case GemColor.Purple:
          result = "pack://application:,,,/Resources/Images/Potions/Ghost.png";

          break;
        case GemColor.Red:
          result = "pack://application:,,,/Resources/Images/Potions/DisableTrap.png";

          break;
        case GemColor.Yellow:
          result = "pack://application:,,,/Resources/Images/Potions/DoubleGold.png";

          break;
        default:

          throw new InvalidOperationException($"Invalid gem color: {color1}");
      }

      return result;
    }
  }
}