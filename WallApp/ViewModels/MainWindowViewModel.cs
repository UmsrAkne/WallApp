using System.Windows;
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

        public double Width
        {
            get => width;
            set
            {
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Width = value;
                }

                SetProperty(ref width, value);
            }
        }

        public double Height
        {
            get => height;
            set
            {
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Height = value;
                }

                SetProperty(ref height, value);
            }
        }

        public double PosX
        {
            get => posX;
            set
            {
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Left = value;
                }

                SetProperty(ref posX, value);
            }
        }

        public double PosY
        {
            get => posY;
            set
            {
                if (Application.Current.MainWindow != null)
                {
                    Application.Current.MainWindow.Top = value;
                }

                SetProperty(ref posY, value);
            }
        }

        public bool IsTopMost { get => isTopMost; set => SetProperty(ref isTopMost, value); }
    }
}