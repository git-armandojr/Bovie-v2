using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bovie
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            Detail = new NavigationPage(new MenuDetail());
        }

		private void GoPageFarm(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new Farm());
			IsPresented = false;
		}
		private void GoPageHerd(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new Herd());
			IsPresented = false;
		}		
		private void GoPageDevice(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new Device());
			IsPresented = false;
		}
		private void GoPageFence(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new Fence());
			IsPresented = false;
		}
		private void GoPageConfig(object sender, System.EventArgs e)
		{
			Detail.Navigation.PushAsync(new Device());
			IsPresented = false;
		}
	}
}