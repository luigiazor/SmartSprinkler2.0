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
    public partial class PostDetailPage : ContentPage
    {
        TiposPlantas selectedPost;
        public PostDetailPage(TiposPlantas selectedPost)
        {
            InitializeComponent();

            this.selectedPost = selectedPost;
            plantasEntry.Text = selectedPost.Nomeplantas;

            
        }

        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Nomeplantas = plantasEntry.Text;
            selectedPost.Water = App.StringToNullableInt(waterEntryedit.Text.ToString());

            /* using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TiposPlantas>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Alterado com sucesso", "ok");
                else
                    DisplayAlert("Failure", "Não foi possivel alterar", "ok");
            }*/

            await App.MobileService.GetTable<TiposPlantas>().UpdateAsync(selectedPost);
            await DisplayAlert("Success", "alterado com sucesso", "ok");
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            /* using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TiposPlantas>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Apagado com sucesso", "ok");
                else
                    DisplayAlert("Failure", "Não foi possivel apagar", "ok");
            }*/
            await App.MobileService.GetTable<TiposPlantas>().DeleteAsync(selectedPost);

            await DisplayAlert("Success", "Deletado com sucesso", "ok");
        }
        
    }
}