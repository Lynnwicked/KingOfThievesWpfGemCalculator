using System;

namespace KingOfThievesWpfGemCalculator.Utilities {
  public static class RitualUtility {
    public static string GetGemResultImage(int gemSize, string gemColor) {
      string result;

      // "pack://application:,,,/Images/Small_32bit/unformattedtext.png"
      if (gemSize > 0 && gemSize <= 299) {
        result = $"pack://application:,,,/Resources/Images/Gems/{gemColor}/{gemColor}ClassOne.png";
      }
      else if (gemSize > 300 && gemSize <= 999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{gemColor}/{gemColor}ClassTwo.png";
      }
      else if (gemSize > 1000 && gemSize <= 2999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{gemColor}/{gemColor}ClassThree.png";
      }
      else if (gemSize > 3000 && gemSize <= 9999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{gemColor}/{gemColor}ClassFour.png";
      }
      else if (gemSize > 10000 && gemSize <= 29999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{gemColor}/{gemColor}ClassFive.png";
      }
      else if (gemSize > 30000 && gemSize <= 99999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{gemColor}/{gemColor}ClassSix.png";
      }
      else if (gemSize > 100000 && gemSize <= 299999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{gemColor}/{gemColor}ClassSeven.png";
      }
      else if (gemSize > 300000 && gemSize <= 999999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{gemColor}/{gemColor}ClassEight.png";
      }
      else if (gemSize > 1000000 && gemSize < 2999997) {
        result = $"pack://application:,,,/Resources/Images/Gems/{gemColor}/{gemColor}ClassNine.png";
      }
      else if (gemSize == 2999997) {
        result = $"pack://application:,,,/Resources/Images/Gems/Perfect/Perfect.png";
      }
      else {
        throw new InvalidOperationException($"Invalid gem size: {gemSize}");
      }

      return result;
    }

    public static string GetPotionResultImage(string gemColor1, string gemColor2, string gemColor3) {
      if (gemColor1 != gemColor2 || gemColor2 != gemColor3 || gemColor3 != gemColor1) {
        return null;
      }

      string result;

      switch (gemColor1) {
        case "Blue":
          result = "pack://application:,,,/Resources/Images/Potions/GangOfThieves.png";

          break;
        case "Green":
          result = "pack://application:,,,/Resources/Images/Potions/SlowMotion.png";

          break;
        case "Purple":
          result = "pack://application:,,,/Resources/Images/Potions/Ghost.png";

          break;
        case "Red":
          result = "pack://application:,,,/Resources/Images/Potions/DisableTrap.png";

          break;
        case "Yellow":
          result = "pack://application:,,,/Resources/Images/Potions/DoubleGold.png";

          break;
        default:

          throw new InvalidOperationException($"Invalid gem color: {gemColor1}");
      }

      return result;
    }
  }
}