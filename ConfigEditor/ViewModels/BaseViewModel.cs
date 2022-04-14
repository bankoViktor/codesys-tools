namespace ConfigEditor.ViewModels
{
    internal class BaseViewModel<T> : INotifyViewModel
    {
        protected readonly T _model;

        public event EventHandler<ChangedEventArgs>? Changed;


        public BaseViewModel(T model)
        {
            _model = model;
        }

        protected void ChangeProperty(string propertyName, object? value)
        {
            var property = GetType().GetProperty(propertyName);
            var oldValue = property?.GetValue(this, null);

            var modelProperty = typeof(T).GetProperty(propertyName);
            modelProperty?.SetValue(_model, value, null);

            if (Changed is not null)
            {
                var args = new ChangedEventArgs(propertyName, oldValue, value);
                Changed.Invoke(this, args);
            }
        }
    }
}
