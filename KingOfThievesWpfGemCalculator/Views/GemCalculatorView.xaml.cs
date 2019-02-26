using KingOfThievesWpfGemCalculator.ViewModels;

namespace KingOfThievesWpfGemCalculator.Views {
  public partial class GemCalculatorView {
    public GemCalculatorView() {
      InitializeComponent();

      DataContext = new GemCalculatorViewModel();

      FirstGemTextBox.Focus();
    }
  }
}