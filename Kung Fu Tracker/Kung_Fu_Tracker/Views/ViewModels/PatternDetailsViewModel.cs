using Kung_Fu_Tracker.DataManagement;
using Kung_Fu_Tracker.Models;
using Kung_Fu_Tracker.Views.DetailViews;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Kung_Fu_Tracker.Views.ViewModels
{
    public class PatternDetailsViewModel : INotifyPropertyChanged
    {

        public string Rank { get; set; }
        public List<PatternLine> patternLines;
        public List<PatternLine> PatternLines
        {
            get { return patternLines; }
            set
            {
                patternLines = value;
                OnPropertyChanged();
            }
        }
        public PatternLine SelectedItem { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public bool IsRefreshing { get; set; }
        public string content { get; set; }
        
        public PatternDetailsViewModel(string rank)
        {
            Rank = rank;
            InitGrid(Rank);

            RefreshCommand = new Command(OnRefreshCommand);
            DeleteCommand = new Command(OnDeleteCommand);
            NewCommand = new Command(OnNewCommand);
            CancelCommand = new Command(OnCancelCommand);
            EditCommand = new Command(OnEditCommand);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private async void InitGrid(string rank)
        {
            content = await App.restService.GetData();
            System.Diagnostics.Debug.WriteLine("\n\n\nContent:" + content + "\n\n\n");
            PatternLines = JsonConvert.DeserializeObject<List<PatternLine>>(content);
        }
        private async void OnRefreshCommand()
        {
            IsRefreshing = true;
            await Task.Delay(1000);
            IsRefreshing = false;
        }
        private void OnNewCommand() { }
        private void OnCancelCommand() { }
        private void OnEditCommand()
        {
            System.Diagnostics.Debug.WriteLine("\n\n\n" + SelectedItem.Feet + "\n\n\n");
            MessagingCenter.Send(this, "EditLine", SelectedItem);
        }
        private void OnDeleteCommand() { }

    }
}
