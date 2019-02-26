using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using KingOfThievesWpfGemCalculator.Annotations;
using KingOfThievesWpfGemCalculator.Enums;
using KingOfThievesWpfGemCalculator.Extensions;
using KingOfThievesWpfGemCalculator.Models;
using KingOfThievesWpfGemCalculator.Utilities;
using KingOfThievesWpfGemCalculator.Views;
using Prism.Commands;

namespace KingOfThievesWpfGemCalculator.ViewModels {
  public class GemCalculatorViewModel : INotifyPropertyChanged {
    private Gem _firstGem;
    private string _firstGemImage;

    private Gem _secondGem;
    private string _secondGemImage;

    private Gem _thirdGem;
    private string _thirdGemImage;

    private int? _bonusPercentage;

    private Ritual _ritual;

    private string _gemResult;
    private string _potionResult;

    public GemCalculatorViewModel() {
      Reset();

      RegisterCommands();
    }

    public Gem FirstGem {
      get => _firstGem;
      set {
        _firstGem = value;
        OnPropertyChanged();
      }
    }

    public string FirstGemImage {
      get => _firstGemImage;
      set {
        _firstGemImage = value;
        OnPropertyChanged();
      }
    }

    public Gem SecondGem {
      get => _secondGem;
      set {
        _secondGem = value;
        OnPropertyChanged();
      }
    }

    public string SecondGemImage {
      get => _secondGemImage;
      set {
        _secondGemImage = value;
        OnPropertyChanged();
      }
    }

    public Gem ThirdGem {
      get => _thirdGem;
      set {
        _thirdGem = value;
        OnPropertyChanged();
      }
    }

    public string ThirdGemImage {
      get => _thirdGemImage;
      set {
        _thirdGemImage = value;
        OnPropertyChanged();
      }
    }

    public int? BonusPercentage {
      get => _bonusPercentage;
      set {
        _bonusPercentage = value;
        OnPropertyChanged();
      }
    }

    public Ritual Ritual {
      get => _ritual;
      set {
        _ritual = value;
        OnPropertyChanged();
      }
    }

    public string GemResult {
      get => _gemResult;
      set {
        _gemResult = value;
        OnPropertyChanged();
      }
    }

    public string PotionResult {
      get => _potionResult;
      set {
        _potionResult = value;
        OnPropertyChanged();
      }
    }

    public ICommand AboutCommand { get; private set; }

    public ICommand CalculateRitualCommand { get; private set; }

    public ICommand ClearCommand { get; private set; }

    public ICommand ExitCommand { get; private set; }

    private void Reset() {
      FirstGem = new Gem {
        Color = GemColor.Blue,
        Name = "First"
      };

      SecondGem = new Gem {
        Color = GemColor.Blue,
        Name = "Second"
      };

      ThirdGem = new Gem {
        Color = GemColor.Blue,
        Name = "Third"
      };

      BonusPercentage = null;

      Ritual = new Ritual();;

      FirstGemImage = null;
      SecondGemImage = null;
      ThirdGemImage = null;

      GemResult = null;

      PotionResult = null;
    }

    private void GetResultImages() {
      FirstGemImage = FirstGem.GetGemImage();
      SecondGemImage = SecondGem.GetGemImage();
      ThirdGemImage = ThirdGem.GetGemImage();

      GemResult = GemUtility.GetGemImage(Ritual.ResultTotal, ThirdGem.Color);

      PotionResult = RitualUtility.GetPotionResult(FirstGem.Color, SecondGem.Color, ThirdGem.Color);
    }

    private void CalculateRitual() {
      if (!_ritual.ValidateGems(FirstGem, SecondGem, ThirdGem)) {
        return;
      }

      if (BonusPercentage == null || BonusPercentage.Value < 1) {
        MessageBox.Show("Bonus percentage is invalid, please enter a valid positive number", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);

        return;
      }

      var bonusPercentage = BonusPercentage.Value;

      Ritual.CalculateTotalWithBonus(bonusPercentage);

      if (Ritual.IsSemiPerfectRitual()) {
        Ritual.CalculateSemiPerfectRitual(bonusPercentage);
      }
      else {
        Ritual.CalculatePerfectRitual(bonusPercentage);
      }

      GetResultImages();
    }

    private static void Exit() {
      var result = MessageBox.Show("Are you sure you want to exit?", "Exit Gem Calculator", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

      if (result == MessageBoxResult.Yes) {
        Environment.Exit(0);
      }
    }

    private void RegisterCommands() {
      AboutCommand = new DelegateCommand(ShowAbout);
      CalculateRitualCommand = new DelegateCommand(CalculateRitual);
      ClearCommand = new DelegateCommand(Reset);
      ExitCommand = new DelegateCommand(Exit);
    }

    private static void ShowAbout() {
      var about = new AboutView();

      about.ShowDialog();
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}