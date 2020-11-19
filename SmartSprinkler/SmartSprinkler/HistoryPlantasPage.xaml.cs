using SmartSprinkler.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartSprinkler
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPlantasPage : ContentPage
    {
        public HistoryPlantasPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<TiposPlantas>();
                var posts = conn.Table<TiposPlantas>().ToList();
                postsListView.ItemsSource = posts;
            }
            
        }

    }
}