using Common.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Common.ViewModels
{
    public partial class TablesViewModel : 
        ObservableObject, 
        IHeader
    {
        private readonly IDataService _dataService;

        [ObservableProperty]
        private string? _selectedTable;
        private string? _dbName;

        public event Action<string?, string?>? TableChanged;

        public string Header => "Таблицы";

        public ObservableCollection<string> Tables { get; set; } = new();



        public TablesViewModel(
            IDataService dataService
            )
        {
            _dataService = dataService;
        }

        partial void OnSelectedTableChanged(string? value)
        {
            TableChanged?.Invoke(_dbName, value);
        }


        internal void Clear()
        {
            Tables.Clear();
        }

        internal void LoadTables(IEnumerable<string> tables)
        {
            Tables.Clear();

            foreach (var table in tables)
            {
                Tables.Add(table);
            }
        }

        internal void LoadTablesFromDatabase(string? dbName)
        {
            _dbName = dbName;
            
            var tables = _dataService.GetTables(dbName);

            Tables.Clear();

            foreach (var table in tables)
            {
                Tables.Add(table);
            }
        }
    }
}