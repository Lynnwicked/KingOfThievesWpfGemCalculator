using System;
using KingOfThievesWpfGemCalculator.Models;

namespace KingOfThievesWpfGemCalculator.Extensions {
  public static class RitualExtensions {
    public static bool IsSemiPerfectRitual(this Ritual r) {
      return r.TotalWithBonus <= Constants.Constants.GemSizes.SEMI_PERFECT + r.Bonus;
    }

    public static void CalculateTotalWithBonus(this Ritual r, int bonusPercentage) {
      var bonus = (int) Math.Round((double) r.GemTotal * bonusPercentage / 100);

      r.Bonus = bonus;

      r.TotalWithBonus = r.GemTotal + bonus;
    }

    public static void CalculatePerfectRitual(this Ritual r, int bonusPercentage) {
      r.Goal = Constants.Constants.GemSizes.PERFECT;

      if (r.TotalWithBonus >= r.Goal) {
        CalculateActualBonus(r);
      }
      else {
        CalculateRemaining(r, bonusPercentage);
      }
    }

    public static void CalculateSemiPerfectRitual(this Ritual r, int bonusPercentage) {
      r.Goal = Constants.Constants.GemSizes.SEMI_PERFECT;

      var max = r.Goal + r.Bonus;

      if (r.TotalWithBonus >= r.Goal & r.TotalWithBonus <= max) {
        CalculateActualBonus(r);
      }
      else {
        CalculateRemaining(r, bonusPercentage);
      }
    }

    public static bool ValidateGems(this Ritual r, Gem firstGem, Gem secondGem, Gem thirdGem) {
      var firstGemSize = firstGem.GetGemSize();
      var secondGemSize = secondGem.GetGemSize();
      var thirdGemSize = thirdGem.GetGemSize();

      if (firstGemSize == 0 || secondGemSize == 0 || thirdGemSize == 0) {
        return false;
      }

      r.GemTotal = firstGemSize + secondGemSize + thirdGemSize;

      return true;
    }

    private static void CalculateActualBonus(Ritual r) {
      r.Bonus = r.Bonus - Math.Abs(r.Goal - r.TotalWithBonus);

      r.ResultTotal = r.Goal;
    }

    private static void CalculateRemaining(Ritual r, int bonusPercentage) {
      r.ResultTotal = r.TotalWithBonus;

      var percentage = (double) bonusPercentage / 100 + 1;

      var maxWithoutBonus = (int) Math.Round(r.Goal / percentage);

      r.Remaining = maxWithoutBonus - r.GemTotal;
    }
  }
}