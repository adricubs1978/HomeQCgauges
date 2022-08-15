using Prism.Mvvm;

namespace HomeQCGauges.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "House Tracking App";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
