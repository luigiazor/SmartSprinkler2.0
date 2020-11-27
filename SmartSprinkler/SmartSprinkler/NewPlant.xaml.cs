using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartSprinkler.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSprinkler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewPlant : ContentPage
    {
        public NewPlant()
        {
            InitializeComponent();
        }

        private async void Salvar_Clicked(object sender, EventArgs e)
        {
            try
            {


                TiposPlantas plantas = new TiposPlantas()
                {
                    Nomeplantas = plantEntry.Text,
                    Water = App.StringToNullableInt(waterEntry.Text.ToString()),
                    UserId = App.user.Id
                };

                /*using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<TiposPlantas>();
                    int rows = conn.Insert(plantas);

                    if (rows > 0)
                        DisplayAlert("Success", "Inserido com sucesso", "ok");
                    else
                        DisplayAlert("Failure", "Não foi possivel inserir", "ok");
                }*/
                await App.MobileService.GetTable<TiposPlantas>().InsertAsync(plantas);

                await DisplayAlert("Success", "Inserido com sucesso", "ok");
            }
            catch(NullReferenceException nre)
            {
                await DisplayAlert("Failure", "Não foi possivel inserir", "ok");
            }
            catch(Exception ex)
            {
                await DisplayAlert("Failure", "Não foi possivel inserir", "ok");
            }
        }


    }
}