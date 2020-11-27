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

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Nomeplantas = plantasEntry.Text;
            selectedPost.Water = StringToNullableInt(waterEntryedit.Text.ToString());

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TiposPlantas>();
                int rows = conn.Update(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Alterado com sucesso", "ok");
                else
                    DisplayAlert("Failure", "Não foi possivel alterar", "ok");
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TiposPlantas>();
                int rows = conn.Delete(selectedPost);

                if (rows > 0)
                    DisplayAlert("Success", "Apagado com sucesso", "ok");
                else
                    DisplayAlert("Failure", "Não foi possivel apagar", "ok");
            }
        }
        public static int StringToNullableInt(string strNum)
        {
            int valor = Convert.ToInt32(strNum);
            return (valor);
        }
    }
}