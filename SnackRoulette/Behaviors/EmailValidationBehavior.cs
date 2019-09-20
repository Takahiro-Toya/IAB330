using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace SnackRoulette.Behaviors
{
    public class EmailValidationBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey ValidationKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(EmailValidationBehavior), false);
        static readonly BindableProperty ValidationProperty = ValidationKey.BindableProperty;

        string emailPattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        public bool IsValid
        {
            get { return (bool)base.GetValue(ValidationProperty); }
            private set { base.SetValue(ValidationKey, value); }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEmailEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEmailEntryTextChanged;
        }

        void OnEmailEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            IsValid = (Regex.IsMatch(args.NewTextValue, emailPattern));
            ((Entry)sender).TextColor = IsValid ? Color.Default : Color.Red;
        }

    }
}
