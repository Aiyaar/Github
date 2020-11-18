using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Github.Models;

namespace Github.ViewModels
{
    public class SeasonsViewModel : BaseViewModel
    {
        static string SeriesId;
        static int Season_Count;
        static string SerieName;

        public SeasonsViewModel()
        {
            // Ideally, you DO NOT want to load data in the constructor. Most MvvM frameworks that have a separate Init() or OnViewAppearing() method in which you shouls load data.
            // Alternatively, you can just call a LoadData() method in the ViewAppearing();
            // LoadData(); 

        }

        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            
            SetValues("1", 4, "My Series");
            
            LoadData();
        }

        private void  SetValues(string seriesid, int seasonCount,string serieName)
        {
            SeriesId = seriesid;
            SerieName = serieName;
            Season_Count = seasonCount;
        }

        // this will automatically receive an INPC implentation automatically at compile-time, by virtue of the inherited BaseViewModel that has the [AddINotifyPropertyChangedInterface] attribute
        public ObservableCollection<Season_Model> Collection { get; } = new ObservableCollection<Season_Model>();


        void LoadData()
        {
            try
            {
                for (int i = 1; i <= Season_Count; i++)
                {
                    Collection.Add(
                        new Season_Model
                        {
                            SeasonName = "Season" + " " + i.ToString(),
                            Season = i,
                        });
                }
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }
    }
}
