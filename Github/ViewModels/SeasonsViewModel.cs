using System;
using System.Collections.ObjectModel;
using Github.Models;

namespace Github.ViewModels
{
    public class SeasonsViewModel : BaseViewModel
    {
        ObservableCollection<Season_Model> _collection;
        static string SeriesId;
        static int Season_Count;
        static string SerieName;
        public SeasonsViewModel()
        {
            _collection = new ObservableCollection<Season_Model>();
            LoadData();
        }

        public void  SetValues(string seriesid, int seasonCount,string serieName)
        {
            _collection = new ObservableCollection<Season_Model>();
            SeriesId = seriesid;
            SerieName = serieName;
            Season_Count = seasonCount;
            LoadData();
        }



        public ObservableCollection<Season_Model> Collection
        {
            get => _collection;
            set
            {
                if (value == _collection)
                    return;
                _collection = value;
                OnPropertyChanged(nameof(Collection));
            }
        }


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
