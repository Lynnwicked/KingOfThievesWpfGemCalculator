using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using KingOfThievesWpfGemCalculator.Annotations;
using KingOfThievesWpfGemCalculator.Resources.Constants;
using KingOfThievesWpfGemCalculator.Utilities;
using KingOfThievesWpfGemCalculator.Views;
using Prism.Commands;

namespace KingOfThievesWpfGemCalculator.ViewModels {
  public class GemCalculatorViewModel : INotifyPropertyChanged {
    private string _bonus;
    private string _bonusPercentage;
    private string _firstGem;
    private string _firstGemColor;
    private string _gemTotal;
    private string _gemResult;
    private string _goal;
    private string _potionResult;
    private string _remaining;
    private string _resultTotal;
    private string _secondGem;
    private string _secondGemColor;
    private string _thirdGem;
    private string _thirdGemColor;
    private string _totalWithBonus;
    
    private int _numericBonus;
    private int _numericBonusPercentage;
    private int _numericResultTotal;
    private int _numericTotal;
    private int _numericTotalWithBonus;

    public GemCalculatorViewModel() {
      RegisterCommands();
    }

    public string Bonus {
      get => _bonus;
      set {
        _bonus = value;
        OnPropertyChanged();
      }
    }

    public string BonusPercentage {
      get => _bonusPercentage;
      set {
        _bonusPercentage = value;
        OnPropertyChanged();
      }
    }

    public string FirstGem {
      get => _firstGem;
      set {
        _firstGem = value;
        OnPropertyChanged();
      }
    }

    public string GemTotal {
      get => _gemTotal;
      set {
        _gemTotal = value;
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

    public string Goal {
      get => _goal;
      set {
        _goal = value;
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

    public string Remaining {
      get => _remaining;
      set {
        _remaining = value;
        OnPropertyChanged();
      }
    }

    public string ResultTotal {
      get => _resultTotal;
      set {
        _resultTotal = value;
        OnPropertyChanged();
      }
    }

    public string SecondGem {
      get => _secondGem;
      set {
        _secondGem = value;
        OnPropertyChanged();
      }
    }

    public string ThirdGem {
      get => _thirdGem;
      set {
        _thirdGem = value;
        OnPropertyChanged();
      }
    }

    public string TotalWithBonus {
      get => _totalWithBonus;
      set {
        _totalWithBonus = value;
        OnPropertyChanged();
      }
    }

    public ICommand AboutCommand { get; private set; }

    public ICommand CalculateRitualCommand { get; private set; }

    public ICommand ClearCommand { get; private set; }

    public ICommand ExitCommand { get; private set; }

    public void SetGemColor(object tag) {
      var split = ((string) tag).Split('|');

      var type = split[0];
      var color = split[1];

      switch (type) {
        case "first":
          _firstGemColor = color;

          break;
        case "second":
          _secondGemColor = color;

          break;
        case "third":
          _thirdGemColor = color;

          break;
        default:

          throw new InvalidOperationException($"Invalid gem type: {type}");
      }
    }

    private void RegisterCommands() {
      AboutCommand = new DelegateCommand(About);
      CalculateRitualCommand = new DelegateCommand(CalculateRitual);
      ClearCommand = new DelegateCommand(Clear);
      ExitCommand = new DelegateCommand(Exit);
    }

    private static void About() {
      var about = new AboutView();

      about.ShowDialog();
    }

    private void CalculateActualBonus(int goal) {
      _numericBonus = _numericBonus - Math.Abs(goal - _numericTotalWithBonus);

      Bonus = _numericBonus.ToString();

      ResultTotal = Goal;

      _numericResultTotal = int.Parse(ResultTotal);

      Remaining = "0";
    }

    private void CalculateRitual() {
      var valid = Validate();

      if (!valid) {
        return;
      }

      CalculateTotals();

      if (_numericTotalWithBonus <= (Constants.SEMI_PERFECT_GEM_SIZE + _numericBonus)) {
        CalculateSemiPerfectRitual();
      }
      else {
        CalculatePerfectRitual();
      }

      GemResult = RitualUtility.GetGemResultImage(_numericResultTotal, _thirdGemColor);
      PotionResult = RitualUtility.GetPotionResultImage(_firstGemColor, _secondGemColor, _thirdGemColor);
    }

    private void CalculatePerfectRitual() {
      var goal = Constants.PERFECT_GEM_SIZE;

      Goal = goal.ToString();

      if (_numericTotalWithBonus >= goal) {
        CalculateActualBonus(goal);
      }
      else {
        CalculateRemaining(goal);
      }
    }

    private void CalculateRemaining(int goal) {
      ResultTotal = TotalWithBonus;

      _numericResultTotal = int.Parse(ResultTotal);

      var percentage = (double) _numericBonusPercentage / 100 + 1;

      var maxWithoutBonus = (int) Math.Round(goal / percentage);

      var result = maxWithoutBonus - _numericTotal;

      Remaining = result.ToString();
    }

    private void CalculateSemiPerfectRitual() {
      var goal = Constants.SEMI_PERFECT_GEM_SIZE;

      Goal = goal.ToString();

      var max = goal + _numericBonus;

      if (_numericTotalWithBonus >= goal & _numericTotalWithBonus <= max) {
        CalculateActualBonus(goal);
      }
      else {
        CalculateRemaining(goal);
      }
    }

    private void CalculateTotalWithBonus() {
      _numericBonusPercentage = int.Parse(BonusPercentage);

      _numericBonus = (int) Math.Round((double) _numericTotal * _numericBonusPercentage / 100);

      Bonus = _numericBonus.ToString();

      _numericTotalWithBonus = _numericTotal + _numericBonus;

      TotalWithBonus = _numericTotalWithBonus.ToString();
    }

    private void CalculateTotals() {
      _numericTotal = int.Parse(FirstGem) + int.Parse(SecondGem) + int.Parse(ThirdGem);

      GemTotal = _numericTotal.ToString();

      CalculateTotalWithBonus();
    }

    private void Clear() {
      Bonus = null;
      Bonus = null;
      BonusPercentage = null;
      FirstGem = null;
      ResultTotal = null;
      Goal = null;
      GemTotal = null;
      Remaining = null;
      SecondGem = null;
      ThirdGem = null;
      TotalWithBonus = null;
    }

    private static void Exit() {
      var result = MessageBox.Show("Are you sure you want to exit?", "Exit Gem Calculator", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

      if (result == MessageBoxResult.Yes) {
        Environment.Exit(0);
      }
    }

    private bool Validate() {
      if (string.IsNullOrWhiteSpace(FirstGem) || !int.TryParse(FirstGem, out var value) || value < 1) {
        MessageBox.Show("First gem is invalid, please enter a valid positive number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        return false;
      }

      if (string.IsNullOrWhiteSpace(SecondGem) || !int.TryParse(SecondGem, out value) || value < 1) {
        MessageBox.Show("Second gem is invalid, please enter a valid positive number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        return false;
      }

      if (string.IsNullOrWhiteSpace(ThirdGem) || !int.TryParse(ThirdGem, out value) || value < 1) {
        MessageBox.Show("Third gem is invalid, please enter a valid positive number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        return false;
      }

      if (string.IsNullOrWhiteSpace(BonusPercentage) || !int.TryParse(BonusPercentage, out value) || value < 1) {
        MessageBox.Show("Bonus percentage is invalid, please enter a valid positive number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

        return false;
      }

      return true;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}