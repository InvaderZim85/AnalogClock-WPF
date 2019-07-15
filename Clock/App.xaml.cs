using System.Windows;
using Clock.View;
using Clock.ViewModel;

namespace Clock
{
    public partial class App : Application
    {
        public App()
        {
            var mw = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            mw.Show();
        }
        
    }
}
