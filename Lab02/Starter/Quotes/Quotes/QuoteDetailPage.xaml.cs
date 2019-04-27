using Quotes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quotes
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuoteDetailPage : ContentPage
	{
        Quote WorkingCopy = new Quote();
		public QuoteDetailPage (Data.Quote quote)
		{
            BindingContext = quote;
            InitializeComponent();
            WorkingCopy = quote;
		}

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditQuotePage(WorkingCopy));
        }

        void SayQuote(object sender, System.EventArgs e)
        {
            QuoteManager.Instance.SayQuote(BindingContext as Quote);
        }
    }
}