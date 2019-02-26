using System.ComponentModel;
using System.Runtime.CompilerServices;
using KingOfThievesWpfGemCalculator.Annotations;
using KingOfThievesWpfGemCalculator.Enums;

namespace KingOfThievesWpfGemCalculator.Models {
  public class Gem : INotifyPropertyChanged {
    private int? _amount;
    private GemColor _color;

    public int? Amount {
      get => _amount;
      set {
        _amount = value;
        OnPropertyChanged();
      }
    }

    public GemColor Color {
      get => _color;
      set {
        _color = value;
        OnPropertyChanged();
      }
    }

    public string Name { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
  }
}