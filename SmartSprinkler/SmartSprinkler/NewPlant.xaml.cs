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

        private void Salvar_Clicked(object sender, EventArgs e)
        {
            TiposPlantas plantas = new TiposPlantas()
            {
                Nomeplantas = plantEntry.Text
            };
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TiposPlantas>();
                int rows = conn.Insert(plantas);

                if (rows > 0)
                    DisplayAlert("Success", "Inserido com sucesso", "ok");
                else
                    DisplayAlert("Failure", "Não foi possivel inserir", "ok");
            }
        }
    }
}