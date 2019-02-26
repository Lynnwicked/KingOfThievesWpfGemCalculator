using System;
using KingOfThievesWpfGemCalculator.Enums;
using KingOfThievesWpfGemCalculator.Resources.Constants;

namespace KingOfThievesWpfGemCalculator.Utilities {
  public static class GemUtility {
    public static string GetGemImage(int size, GemColor color) {
      string result;

      if (size > 0 && size <= 299) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassOne.png";
      }
      else if (size > 299 && size <= 999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassTwo.png";
      }
      else if (size > 999 && size <= 2999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassThree.png";
      }
      else if (size > 2999 && size <= 9999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassFour.png";
      }
      else if (size > 9999 && size <= 29999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassFive.png";
      }
      else if (size > 29999 && size <= 99999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassSix.png";
      }
      else if (size > 99999 && size <= 299999) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassSeven.png";
      }
      else if (size > 299999 && size <= Constants.GemSizes.SEMI_PERFECT) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassEight.png";
      }
      else if (size > Constants.GemSizes.SEMI_PERFECT && size < Constants.GemSizes.PERFECT) {
        result = $"pack://application:,,,/Resources/Images/Gems/{color}/{color}ClassNine.png";
      }
      else if (size == Constants.GemSizes.PERFECT) {
        result = "pack://application:,,,/Resources/Images/Gems/Perfect/Perfect.png";
      }
      else {
        throw new InvalidOperationException($"Invalid gem size: {size}");
      }

      return result;
    }
  }
}