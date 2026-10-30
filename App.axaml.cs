using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using ToDoList.ViewModels;
using ToDoList.Views;

namespace ToDoList;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private readonly MainViewModel _mainViewModel = new MainViewModel();

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = _mainViewModel,
            };

            // Do the ShutdownRequested event
            desktop.ShutdownRequested += DesktopOnShutdownRequested;
        }

        base.OnFrameworkInitializationCompleted();
    }

    // Used to check if the window can be closed
    private bool _canClose;
    private async void DesktopOnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        // Stop the window from closing the first time around
        e.Cancel = !_canClose;

        if (!_canClose)
        {
            // Map items in ToDoItems to ToDoItem-Model
            var itemsToSave = _mainViewModel.ToDoItems.Select(item => item.GetToDoItem());
            await ToDoListFileService.SaveToFileAsync(itemsToSave);

            // Set _canClose to true and close the window
            _canClose = true;
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Shutdown();
            }
        }
    }
}