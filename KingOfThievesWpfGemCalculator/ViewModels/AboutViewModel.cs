using System;
using System.Media;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;

namespace KingOfThievesWpfGemCalculator.ViewModels {
  public class AboutViewModel {
    private SoundPlayer _sp;

    public AboutViewModel() {
      RegisterCommands();
    }

    public ICommand EasterEggCommand { get; private set; }

    public ICommand OkCommand { get; private set; }

    private void RegisterCommands() {
      EasterEggCommand = new DelegateCommand(ExecuteEasterEggCommand);
      OkCommand = new DelegateCommand<Window>(ExecuteOkCommand);
    }

    private void ExecuteEasterEggCommand() {
      using (var song = Properties.Resources.CrossingField)
      using (_sp = new SoundPlayer(song)) {
        _sp.Play();
      }
    }

    private void ExecuteOkCommand(Window window) {
      _sp?.Stop();

      window.Close();
    }
  }
}