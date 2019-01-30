using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using KingOfThievesWpfGemCalculator.Annotations;
using Prism.Commands;

namespace KingOfThievesWpfGemCalculator.ViewModels {
  public class GemCalculatorViewModel : INotifyPropertyChanged {
    private string _bonusPercentage;
    private string _firstGem;
    private string _secondGem;
    private string _thirdGem;

    private bool _perfectRitual;
    private bool _semiPerfectRitual;

    public GemCalculatorViewModel() {
      SemiPerfectRitual = true;

      RegisterCommands();
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

    public bool PerfectRitual {
      get => _perfectRitual;
      set {
        _perfectRitual = value;
        OnPropertyChanged();
      }
    }

    public bool SemiPerfectRitual {
      get => _semiPerfectRitual;
      set {
        _semiPerfectRitual = value;
        OnPropertyChanged();
      }
    }
    
    public ICommand AboutCommand { get; private set; }
    
    public ICommand CalculateRitualCommand { get; private set; }
    
    public ICommand ClearCommand { get; private set; }

    public ICommand ExitCommand { get; private set; }

    private void RegisterCommands() {
      AboutCommand = new DelegateCommand(About);
      CalculateRitualCommand = new DelegateCommand(CalculateRitual);
      ClearCommand = new DelegateCommand(Clear);
      ExitCommand = new DelegateCommand(Exit);
    }

    private void About() {

    }

    private void CalculateRitual() {

    }

    private void Clear() {
      BonusPercentage = null;
      FirstGem = null;
      SecondGem = null;
      ThirdGem = null;

      SemiPerfectRitual = true;
      PerfectRitual = false;
    }

    private static void Exit() {
      var result = MessageBox.Show("Are you sure you want to exit?", "Exit Gem Calculator", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);

      if (result == MessageBoxResult.Yes) {
        Environment.Exit(0);
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}