using Microsoft.Practices.Unity;
using Prism.Unity;
using PrismDemo.Views;
using Xamarin.Forms;

namespace PrismDemo
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override Page CreateMainPage()
        {
            return Container.Resolve<MainPage>();
        }

        protected override void RegisterTypes()
        {
            //default convention - NavigationService.Navigate("ViewA");
            Container.RegisterTypeForNavigation<ViewA>();

            //provide custom string as a unique name - NavigationService.Navigate("A");
            //Container.RegisterTypeForNavigation<ViewA>("A");

            //use a ViewModel class to act as the unique name - NavigationService.Navigate<ViewAViewModel>();
            //Container.RegisterTypeForNavigation<ViewA, ViewAViewModel>();
        }
    }
}
