public class ToDoItem
{
    public bool IsChecked { get; set; }

    public string? Content { get; set; }

    public ToDoItem GetToDoItem()
    {
        return new ToDoItem()
        {
            IsChecked = this.IsChecked,
            Content = this.Content
        };
    }
}