using Common.Models;
using Common.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Common.ViewModels
{
    public partial class TableContentViewModel : 
        ObservableObject, 
        IHeader
    {
        private TableModel? _table;
        private readonly IDataService _dataService;
        
        [ObservableProperty]
        private ObservableCollection<RowModel> _rows = new();

        [ObservableProperty]
        private RowModel? _selectedRow;

        public event Action<RowModel?>? RowChanged;
        public string Header => "Таблица " + _table?.Name;

        public TableContentViewModel(
            IDataService dataService
            )
        {
            _dataService = dataService;
        }

        partial void OnSelectedRowChanged(RowModel? value)
        {
            RowChanged?.Invoke(value);
        }


        internal void LoadContentFromTable(string? dbName, string? tableName)
        {
            _table = _dataService.GetTable(dbName, tableName);

            Rows.Clear();

            foreach (var row in _table.Rows)
            {
                Rows.Add(row);
            }

            OnPropertyChanged(nameof(Header));
        }

    }
}