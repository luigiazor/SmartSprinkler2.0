using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartSprinkler
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isEmailEmpty = String.IsNullOrEmpty(EmailAdressEntry.Text);
            bool isPasswordEmpty = String.IsNullOrEmpty(PasswordEntry.Text);
            if(isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }

        private void registerUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
