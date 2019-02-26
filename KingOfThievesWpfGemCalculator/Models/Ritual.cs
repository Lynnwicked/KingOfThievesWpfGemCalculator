using System.ComponentModel;
using System.Runtime.CompilerServices;
using KingOfThievesWpfGemCalculator.Annotations;

namespace KingOfThievesWpfGemCalculator.Models {
  public class Ritual : INotifyPropertyChanged {
    private int _bonus;
    private int _gemTotal;
    private int _goal;
    private int _remaining;
    private int _resultTotal;
    private int _totalWithBonus;

    public int Bonus {
      get => _bonus;
      set {
        _bonus = value;
        OnPropertyChanged();
      }
    }

    public int GemTotal {
      get => _gemTotal;
      set {
        _gemTotal = value;
        OnPropertyChanged();
      }
    }

    public int Goal {
      get => _goal;
      set {
        _goal = value;
        OnPropertyChanged();
      }
    }

    public int Remaining {
      get => _remaining;
      set {
        _remaining = value;
        OnPropertyChanged();
      }
    }

    public int ResultTotal {
      get => _resultTotal;
      set {
        _resultTotal = value;
        OnPropertyChanged();
      }
    }

    public int TotalWithBonus {
      get => _totalWithBonus;
      set {
        _totalWithBonus = value;
        OnPropertyChanged();
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}