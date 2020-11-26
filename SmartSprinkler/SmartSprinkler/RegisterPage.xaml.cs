using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSprinkler.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSprinkler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            if(PasswordEntry.Text == confirmPasswordEntry.Text)
            {
                //We can register the user
                Users user = new Users()
                {
                    Email = EmailAdressEntry.Text,
                    Password = PasswordEntry.Text
                };

                await App.MobileService.GetTable<Users>().InsertAsync(user);
            }
            else
            {
                await DisplayAlert("Error", "Passowrd don't match", "Ok");
            }

        }
    }
}