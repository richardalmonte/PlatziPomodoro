using PlatziPomodoro.ViewModels;
using PlatziPomodoro.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlatziPomodoro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            MessagingCenter.Subscribe<RootPageViewModel>(this, "GoToConfiguration", (a) =>
            {
                Detail = new NavigationPage(new ConfigurationPage());
                IsPresented = false;
            });

        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as RootPageMenuItem;
        //    if (item == null)
        //        return;

        //    var page = (Page)Activator.CreateInstance(item.TargetType);
        //    page.Title = item.Title;

        //    Detail = new NavigationPage(page);
        //    IsPresented = false;

        //    //MasterPage.ListView.SelectedItem = null;
        //}
    }
}