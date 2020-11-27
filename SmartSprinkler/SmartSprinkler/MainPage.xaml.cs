using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SmartSprinkler.Model;

namespace SmartSprinkler
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {

            bool isEmailEmpty = String.IsNullOrEmpty(EmailAdressEntry.Text);
            bool isPasswordEmpty = String.IsNullOrEmpty(PasswordEntry.Text);
            if(isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {

                var user = (await App.MobileService.GetTable<Users>().Where(u => u.Email == EmailAdressEntry.Text).ToListAsync()).FirstOrDefault();

                if(user != null)
                {
                    if (user.Password == PasswordEntry.Text)
                        await Navigation.PushAsync(new HomePage());
                    else
                        await DisplayAlert("Error", "email or password are incorrect", "Ok");
                }
                else
                {
                    await DisplayAlert("Error", "There is a error", "Ok");
                }
                
            }
        }

        private void registerUserButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
