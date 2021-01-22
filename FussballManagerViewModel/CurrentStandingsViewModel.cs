using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using FussballManagerLogic;

namespace FussballManagerViewModel
{
    public class CurrentStandingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _day = 1;
        private ObservableCollection<Standing> entries;
        public CurrentStandingsViewModel()
        {
            entries = new ObservableCollection<Standing>(Saison.GetStanding(_day));
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
