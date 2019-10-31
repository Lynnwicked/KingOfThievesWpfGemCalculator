using System;
using System.Reflection;
using KingOfThievesWpfGemCalculator.ViewModels;

namespace KingOfThievesWpfGemCalculator.Views {
  public partial class GemCalculatorView {
    public GemCalculatorView() {
      InitializeDependencies();

      InitializeComponent();

      DataContext = new GemCalculatorViewModel();

      FirstGemTextBox.Focus();
    }

    private void InitializeDependencies() {
      AppDomain.CurrentDomain.AssemblyResolve += (sender, args) => {
        var resourceName = new AssemblyName(args.Name).Name + ".dll";
        var resource = Array.Find(GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource)) {
          var assemblyData = new byte[stream.Length];
          stream.Read(assemblyData, 0, assemblyData.Length);

          return Assembly.Load(assemblyData);
        }
      };
    }
  }
}