using CommunityToolkit.Mvvm.ComponentModel;

namespace ToDoList.ViewModels;
public partial class ToDoItemViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial bool? IsChecked { get; set; }

    [ObservableProperty]
    public partial string? Content { get; set; }

    public ToDoItemViewModel()
    {
    }

    public ToDoItemViewModel(ToDoItem item)
    {
        IsChecked = item.IsChecked;
        Content = item.Content;
    }
}