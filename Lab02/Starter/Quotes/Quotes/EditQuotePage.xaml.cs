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
	public partial class EditQuotePage : ContentPage
	{
        bool EditFlag = false;
        Quote OriginalQuote = new Quote();
		public EditQuotePage ()
		{
            BindingContext = new Quote();
			InitializeComponent ();
		}

        public EditQuotePage(Quote quote)
        {
            BindingContext = new Quote(quote);
            InitializeComponent();
            EditFlag = true;
            OriginalQuote = quote;
        }

        async void SaveQuote(object sender, EventArgs e)
        {
            if (EditFlag == true)
            {
                QuoteManager.Instance.Quotes.Remove(OriginalQuote);
                QuoteManager.Instance.Quotes.Add((Quote)BindingContext);
                Navigation.RemovePage(this);
                await Navigation.PopAsync();
            }
            else
            {
                QuoteManager.Instance.Quotes.Add((BindingContext as Quote));
                await Navigation.PopAsync();
            }
        }
    }
}