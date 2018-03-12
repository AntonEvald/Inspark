using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
namespace Inspark.Services
{
    public class EmailBehaviors : Behavior<Entry>
    {
		protected override void OnAttachedTo(Entry bindable)
		{
            base.OnAttachedTo(bindable);

            bindable.TextChanged += BindableonTextChanged;

           
		}

		protected override void OnDetachingFrom(Entry bindable)
		{
            base.OnDetachingFrom(bindable);

            bindable.TextChanged -= BindableonTextChanged;
		}

		private void BindableonTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {

            var email = textChangedEventArgs.NewTextValue;

            var pattern = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

            var emailEntry = sender as Entry;

            if (Regex.IsMatch(email, pattern))
            {
                emailEntry.BackgroundColor = Color.Transparent;
            }
            else
            {
                emailEntry.BackgroundColor = Color.Red;
            }
        }

	}
}
