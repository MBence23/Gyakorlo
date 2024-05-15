using Gyakorlo.Command;
using Gyakorlo.New;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlo.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set { 
                currentView = value;
                PropertyChanged?.Invoke(this, new
                    PropertyChangedEventArgs("CurrentView"));
            }
        }

        private GreemView greemView;
        private YellowView yellowView;
        private LillaView lillaView;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentView"));
        }

        public RelayCommand YellowViewCommand { get; }
        public RelayCommand GreemViewCommand { get; }
        public RelayCommand LillaViewCommand { get; }

        public MainViewModel() 
        {

            yellowView = new YellowView();
            greemView = new GreemView();
            lillaView = new LillaView();
            CurrentView = yellowView;

            YellowViewCommand = new RelayCommand(setYellow);
            GreemViewCommand = new RelayCommand(x => CurrentView = greemView);
            LillaViewCommand = new RelayCommand(x => CurrentView = lillaView);


        }

        private void setYellow(object v)
        {
            CurrentView = yellowView;
        }
    }
}
