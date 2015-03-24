using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PrismDemo
{
    public class App : Application
    {
        public App()
        {
            Bootstrapper bs = new Bootstrapper();
            bs.Run(this);
        }
    }
}
