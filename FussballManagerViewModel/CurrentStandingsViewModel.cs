using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FussballManagerLogic;
using FussballManagerTest;

namespace FussballManagerViewModel
{
    public class CurrentStandingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _day = 1;
        private ObservableCollection<Standing> entries;
        public CurrentStandingsViewModel()
        {
            // create dummy teams and save in database
            //Team t = Helper.CreateTeam();
            //Database.SaveTeamToDatabase(t);

            //create dummy season and save in database
            Saison dummySeason = Helper.CreateAndPlaySeason();
            Database.SaveSeasonToDatabase(dummySeason);

            entries = new ObservableCollection<Standing>(Saison.GetStanding(_day)); //get dummy list //TODO: GetStanding() get data from database
        }
        public int Day
        {
            get { return _day; }
            set
            {
                if (_day != value)
                {
                    _day = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Day)));
                }
            }
        }

        public ObservableCollection<Standing> EntryList
        {
            get => entries;
            set
            {
                if (entries != value)
                {
                    entries = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EntryList)));
                }
            }
        }

    }
}
