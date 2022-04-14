namespace ConfigEditor.ViewModels
{
    internal interface INotifyViewModel
    {
        event EventHandler<ChangedEventArgs>? Changed;
    }
}
