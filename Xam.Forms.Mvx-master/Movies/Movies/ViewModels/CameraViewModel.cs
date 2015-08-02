using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.IO;
using Cirrious.MvvmCross.Plugins.PictureChooser;


namespace CoolBeans.ViewModels
{
    class CameraViewModel : MvxViewModel
    {
        
        private readonly IMvxPictureChooserTask _pictureChooserTask;
        private ImageSource _imageSource;
        public string test;

        public CameraViewModel(IMvxPictureChooserTask pictureChooserTask)
        {
            test = "splash.png";
            _pictureChooserTask = pictureChooserTask;
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _takePictureCommand;
        public System.Windows.Input.ICommand TakePictureCommand
        {
            get
            {

                _takePictureCommand = _takePictureCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoTakePicture);

                return _takePictureCommand;

            }
        }

        private void DoTakePicture()
        {
            _pictureChooserTask.TakePicture(400, 95, OnPicture, () => { });
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand _choosePictureCommand;
        public System.Windows.Input.ICommand ChoosePictureCommand
        {
            get
            {
                _choosePictureCommand = _choosePictureCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand(DoChoosePicture);
                return _choosePictureCommand;
            }
        }

        private void DoChoosePicture()
        {
            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnPicture, () => {});
        }

        private byte[] _bytes;
        public byte[] Bytes
        {
            get { return _bytes; }
            set { _bytes = value; RaisePropertyChanged(() => Bytes); }
        }


        public ImageSource ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                _imageSource = value; RaisePropertyChanged("ImageSource");
            }
        }

        private void OnPicture(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);
            Bytes = memoryStream.ToArray();
            
            _imageSource = ImageSource.FromStream(() => new MemoryStream(Bytes));
        }
         
    }
}
