using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismDemo.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        string _title = "Main Page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;

            NavigateCommand = new DelegateCommand(Navigate);

            eventAggregator.GetEvent<GoBackEvent>().Subscribe(HandleEvent);
        }

        void HandleEvent(string payload)
        {
            Title = payload;
        }

        void Navigate()
        {
            NavigationParameters parameters = new NavigationParameters();
            parameters.Add("message", "Message from MainPage");

            _navigationService.Navigate("ViewA", parameters);

            //other ways of navigating depending on how you registered your views for navigation
            //_navigationService.Navigate("A", parameters);
            //_navigationService.Navigate<ViewAViewModel>(parameters);
        }        
    }
}
