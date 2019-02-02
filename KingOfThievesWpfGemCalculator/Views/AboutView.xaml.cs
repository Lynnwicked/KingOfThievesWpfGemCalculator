using KingOfThievesWpfGemCalculator.ViewModels;

namespace KingOfThievesWpfGemCalculator.Views {
  public partial class AboutView {
    public AboutView() {
      InitializeComponent();

      DataContext = new AboutViewModel();
    }
  }
}