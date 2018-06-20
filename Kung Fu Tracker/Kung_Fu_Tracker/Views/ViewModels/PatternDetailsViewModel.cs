﻿using Kung_Fu_Tracker.DataManagement;
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
        private List<PatternLine> patternLines;
        private List<PatternLine> rankLines;
        public List<PatternLine> RankLines
        {
            get { return rankLines; }
            set
            {
                rankLines = value;
                OnPropertyChanged();
            }
        }
        public PatternLine SelectedItem { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand EditCommand { get; set; }
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        
        public string content { get; set; }
        
        public PatternDetailsViewModel(string rank)
        {
            Rank = rank;
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
            //get the patternlines as a json string and add it to the datagrid.
            content = await App.restService.GetData(rank);
            patternLines = JsonConvert.DeserializeObject<List<PatternLine>>(content);
            RankLines = patternLines;
            IsRefreshing = false;
        }
        public void OnRefreshCommand()
        {
            //show the spinner and get the datagrid data
            IsRefreshing = true;
            InitGrid(Rank);
        }
        private void OnNewCommand()
        {
            MessagingCenter.Send(this, "NewLine", Rank);
        }
        private void OnCancelCommand() { }
        private void OnEditCommand()
        {
            if (SelectedItem != null)
                MessagingCenter.Send(this, "EditLine", SelectedItem);
        }
        private void OnDeleteCommand()
        {
            if (SelectedItem != null)
                MessagingCenter.Send(this, "DeleteLine", SelectedItem.ID);
        }

    }
}
