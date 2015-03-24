using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
    {
        public INavigationService NavigationService { get; set; }

        string _title = "View A";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }

        IEventAggregator _eventAggregator;
        public ViewAViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            NavigateCommand = new DelegateCommand(GoBack);
        }

        void GoBack()
        {
            _eventAggregator.GetEvent<GoBackEvent>().Publish("ViewA Message");
            NavigationService.GoBack();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = (string)parameters["message"];
        }        
    }
}
