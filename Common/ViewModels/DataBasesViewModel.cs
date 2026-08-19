using Common.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class DataBasesViewModel : 
        ObservableObject, 
        IHeader
    {
        private readonly IDataService _dataService;

        [ObservableProperty]
        private string? _selectedDatabase;

        public string Header => "Базы данных";

        public event Action<string?>? DatabaseChanged;

        public ObservableCollection<string> Databases { get; set; } = new();

        public DataBasesViewModel(
            IDataService dataService
            )
        {
            _dataService = dataService;
        }
        internal void LoadDatabases()
        {
            var databases = _dataService.GetDatabases();

            Databases.Clear();

            foreach (var database in databases)
            {
                Databases.Add(database);
            }
        }

        partial void OnSelectedDatabaseChanged(string? value)
        {
            DatabaseChanged?.Invoke(value);
        }
    }
}