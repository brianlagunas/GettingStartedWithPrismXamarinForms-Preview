using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismDemo.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
    {
        private readonly INavigationService _navigationService;
        readonly IEventAggregator _eventAggregator;

        string _title = "View A";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }

        public ViewAViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            
            NavigateCommand = new DelegateCommand(GoBack);
        }

        void GoBack()
        {
            _eventAggregator.GetEvent<GoBackEvent>().Publish("ViewA Message");
            _navigationService.GoBack();
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
