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

        public static bool IsValidPassword(string password)
        {
            if(password != "" && password != null)
            {
                var passwordPattern = @"(?=^[^\s]{6,}$)(?=.*\d)(?=.*[a-zA-Z])";
                if (Regex.IsMatch(password, passwordPattern))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static bool IsPasswordMatch(string password, string confirmedPassword)
        {
            if(password != "" && password != null && confirmedPassword != "" && confirmedPassword != null)
            {
                if (password.Equals(confirmedPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }

    }

