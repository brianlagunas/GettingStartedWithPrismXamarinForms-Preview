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
    public class MainPageViewModel : BindableBase, INavigationServiceAware
    {
        public INavigationService NavigationService { get; set; }

        string _title = "Main Page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }

        public MainPageViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<GoBackEvent>().Subscribe(HandleEvent);

            NavigateCommand = new DelegateCommand(Navigate);
        }

        void HandleEvent(string payload)
        {
            Title = payload;
        }

        void Navigate()
        {
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("message", "Message from MainPage");

            NavigationService.Navigate("ViewA", parameters);
        }        
    }
}
