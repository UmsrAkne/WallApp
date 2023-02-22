using Prism.Mvvm;

namespace WallApp.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}