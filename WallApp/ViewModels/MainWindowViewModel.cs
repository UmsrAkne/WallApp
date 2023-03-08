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

        public DelegateCommand ToggleTopMostPropertyCommand => new(() =>
        {
            IsTopMost = !IsTopMost;
        });

        public DelegateCommand ToggleMuteCommand => new(() =>
        {
            SetVolume(Mute ? 0 : beforeVolume);
        });

        public DelegateCommand TopMostAndMuteCommand => new(() =>
        {
            IsTopMost = true;
            Mute = true;
            SetVolume(Mute ? 0 : beforeVolume);
        });

        public DelegateCommand DeActiveCommand => new(() =>
        {
            IsTopMost = false;
            Mute = false;
            SetVolume(Mute ? 0 : beforeVolume);

            Application.Current.MainWindow!.WindowState = WindowState.Minimized;
        });

        public DelegateCommand ExitCommand => new(() =>
        {
            if (beforeVolume != 0)
            {
                SetVolume(beforeVolume);
            }
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