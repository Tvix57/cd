using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesckCalcSH
{
    public class MyFlyoutPage : FlyoutPage
    {
        public MyFlyoutPage()
        {
            Flyout = new NavigationPage(new MyFlyoutPage()); // добавляем страницу в Flyout
            Detail = new NavigationPage(new MainPage()); // устанавливаем Detail страницу
        }
    }
}
