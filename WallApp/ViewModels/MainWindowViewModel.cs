using System.Windows;
using NAudio.CoreAudioApi;
using Prism.Commands;
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
        private int beforeVolume;
        private bool mute;

        public MainWindowViewModel()
        {
            IsTopMost = true;
        }

        public string Title
        {
            get { return title; }
            private set { SetProperty(ref title, value); }
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

        public bool IsTopMost
        {
            get => isTopMost;
            set
            {
                SetProperty(ref isTopMost, value);
                Title = value ? "最前面固定中" : "WallApp";
            }
        }

        public bool Mute { get => mute; set => SetProperty(ref mute, value); }

        public DelegateCommand ToggleTopMostPropertyCommand => new DelegateCommand(() =>
        {
            IsTopMost = !IsTopMost;
        });

        public DelegateCommand ToggleMuteCommand => new DelegateCommand(() =>
        {
            SetVolume(Mute ? 0 : beforeVolume);
        });

        public DelegateCommand TopMostAndMuteCommand => new DelegateCommand(() =>
        {
            IsTopMost = true;
            Mute = true;
            SetVolume(Mute ? 0 : beforeVolume);
        });

        private void SetVolume(int value)
        {
            MMDeviceEnumerator devEnum = new();
            MMDevice device = devEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            var current = device.AudioEndpointVolume.MasterVolumeLevelScalar;
            if (current != 0)
            {
                beforeVolume = (int)(current * 100);
            }

            device.AudioEndpointVolume.MasterVolumeLevelScalar = value / 100.0f;
        }
    }
}