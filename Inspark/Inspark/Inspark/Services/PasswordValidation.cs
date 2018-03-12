using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;
namespace Inspark.Services
{
    public class  PasswordBehavior : Behavior<Entry>
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
            var passwordPattern = @"(?=^[^\s]{6,}$)(?=.*\d)(?=.*[a-zA-Z])";

            var password = textChangedEventArgs.NewTextValue;

            var passwordEntry = sender as Entry;

            if (Regex.IsMatch(password, passwordPattern))
            {
                passwordEntry.TextColor = Color.Green;
            }
            else
            {
                passwordEntry.TextColor = Color.Red;
            }

        }
    }

    }

