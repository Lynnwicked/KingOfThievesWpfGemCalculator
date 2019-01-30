using System.Text.RegularExpressions;
using System.Windows.Input;
using KingOfThievesWpfGemCalculator.ViewModels;

namespace KingOfThievesWpfGemCalculator.Views {
  public partial class GemCalculatorView {
    public GemCalculatorView() {
      InitializeComponent();

      DataContext = new GemCalculatorViewModel();

      FirstGemTextBox.Focus();
    }

    private void NumberTextBoxValueChanged(object sender, TextCompositionEventArgs e) {
      e.Handled = IsNumberEntered(e.Text);
    }

    private static bool IsNumberEntered(string text) {
      var result = Regex.IsMatch(text, "[^0-9]+");

      return result;
    }
  }
}