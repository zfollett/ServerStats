using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatClient.Lib
{
    public class ViewModel : INotifyPropertyChanged
    {
        IRestClient _restClient;
        public ViewModel(IRestClient client = null)
        {
            _restClient = client;
        }


        public string ServerName
        {
            get
            { return _serverName; }
            set
            {
                _serverName = value;
                OnPropertyChanged("ServerName");
            }
        }
        private string _serverName = "localhost";

        public ObservableCollection<StatTableRow> Stats
        {
            get
            {
                if (_stats == null)
                    _stats = new ObservableCollection<StatTableRow>();
                return _stats;
            }
            set
            {
                _stats = value;
                OnPropertyChanged("Stats");
            }

        }
        private ObservableCollection<StatTableRow> _stats;
        

        private ICommand _loadLastHour;
        public ICommand LoadLastHour
        {
            get
            {
                if (_loadLastHour == null)
                    _loadLastHour = new CommandBinder(_onLoadLastHour);
                return _loadLastHour;
            }
        }
        private async void _onLoadLastHour(object parameter)
        {
            await loadstats(1);
        }

        private ICommand _loadLastDay;
        public ICommand LoadLastDay
        {
            get
            {
                if (_loadLastDay == null)
                    _loadLastDay = new CommandBinder(_onLoadLastDay);
                return _loadLastDay;
            }
        }
        private async void _onLoadLastDay(object parameter)
        {
            await loadstats(24);
        }

        private async Task loadstats(int lastHours)
        {
            StatDownloader downloader = new StatDownloader(_restClient);
            List<StatTableRow> stats = await downloader.GetStats(this.ServerName, DateTime.Now.AddHours(-lastHours));
            Stats.Clear();
            foreach (var stat in stats)
                Stats.Add(stat);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Used to write data back up to the bound XAML elements
        /// </summary>
        /// <param name="propertyName">Name of the property that need to 
        /// be written up to the XAML</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
