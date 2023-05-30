using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; // INotifyPropertyChanged 상속
using System.Windows.Input;
using LoadImageFile.Command;
using LoadImageFile.Models;
using Microsoft.Win32;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace LoadImageFile.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private String _imageSource;
        private DelegateCommand _loadImageCommand = null;

        public MainWindowViewModel()
        {
            _loadImageCommand = new DelegateCommand(LoadImage);
        }

        public String ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged("ImageSource");
            }
        }

        public DelegateCommand LoadImageCommand
        {
            get { return _loadImageCommand; }
        }

        private void LoadImage()
        {
            OpenFileDialog dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "Image Files (*.jpg, *.png) | *.jpg; *.png | All files (*.*) | *.*";

            if (dlgOpenFile.ShowDialog() == true)
            {
                string filename = dlgOpenFile.FileName;
                ImageSource = filename;
            }
        }
     
        #region NotifyPropertyChanged 인터페이스 구현

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }

}
