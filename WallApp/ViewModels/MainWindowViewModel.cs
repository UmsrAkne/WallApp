using Prism.Mvvm;

namespace WallApp.ViewModels
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";

        private double width = 600;
        private double height = 480;
        private double posX;
        private double posY;
        private bool isTopMost = true;

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public double Width { get => width; set => SetProperty(ref width, value); }

        public double Height { get => height; set => SetProperty(ref height, value); }

        public double PosX { get => posX; set => SetProperty(ref posX, value); }

        public double PosY { get => posY; set => SetProperty(ref posY, value); }

        public bool IsTopMost { get => isTopMost; set => SetProperty(ref isTopMost, value); }
    }
}