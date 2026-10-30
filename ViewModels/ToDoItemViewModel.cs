using CommunityToolkit.Mvvm.ComponentModel;
using Models;

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

    public ToDoItem GetToDoItem()
    {
        return new ToDoItem()
        {
            IsChecked = this.IsChecked ?? false,
            Content = this.Content
        };
    }
}