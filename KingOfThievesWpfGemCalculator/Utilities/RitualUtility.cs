using System;
using KingOfThievesWpfGemCalculator.Enums;
using KingOfThievesWpfGemCalculator.Resources.Constants;

namespace KingOfThievesWpfGemCalculator.Utilities {
  public static class RitualUtility {
    public static string GetGemResultImage(int size, GemColor color) {
      string result;

      // "pack://application:,,,/Images/Small_32bit/unformattedtext.png"
      if (size > 0 && size <= 299) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassOne.png";
      }
      else if (size > 300 && size <= 999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassTwo.png";
      }
      else if (size > 1000 && size <= 2999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassThree.png";
      }
      else if (size > 3000 && size <= 9999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassFour.png";
      }
      else if (size > 10000 && size <= 29999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassFive.png";
      }
      else if (size > 30000 && size <= 99999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassSix.png";
      }
      else if (size > 100000 && size <= 299999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassSeven.png";
      }
      else if (size > 300000 && size <= Constants.SEMI_PERFECT_GEM_SIZE) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassEight.png";
      }
      else if (size > 1000000 && size < Constants.PERFECT_GEM_SIZE) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassNine.png";
      }
      else if (size == Constants.PERFECT_GEM_SIZE) {
        result = "pack://application:,,,/Resources/Images/Gems/Perfect/Perfect.png";
      }
      else {
        throw new InvalidOperationException($"Invalid gem size: {size}");
      }

      return result;
    }

    public static string GetPotionResultImage(GemColor color1, GemColor color2, GemColor color3) {
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