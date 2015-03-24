using Prism.Unity;
using PrismDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace PrismDemo
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override Xamarin.Forms.Page CreateMainPage()
        {
            return Container.Resolve<MainPage>();
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<ViewA>();

            //override convention
            //Container.RegisterTypeForNavigation<ViewA>("A");
        }
    }
}
