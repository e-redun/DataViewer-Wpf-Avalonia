using Common.Models;
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
    public partial class TableContentViewModel : 
        ObservableObject, 
        IHeader
    {
        public string Header => "Таблица " + _tableData?.Name;
        
        public event Action<string?>? RowChanged;


        [ObservableProperty] 
        private TableModel? _tableData;

        [ObservableProperty]
        private ObservableCollection<RowModel> _rows = new();
        private string? _selectedDatabase;
        private readonly IDataService _dataService;

        public TableContentViewModel(
            IDataService dataService
            )
        {
            _dataService = dataService;
        }

        internal void LoadContent(TableModel content)
        {
            TableData = content;
            
            Rows.Clear();
            
            foreach (var row in content.Rows)
            {
                Rows.Add(row);
            }
            
            OnPropertyChanged(nameof(Rows));

            OnPropertyChanged(nameof(Header));
        }

        internal void Clear()
        {
            TableData = null;
            Rows.Clear();
            OnPropertyChanged(nameof(Header));
        }

        internal void GetDatabaseName(string? dbName)
        {
            _selectedDatabase = dbName;
        }


        internal void LoadContentFromTable(string? tableName)
        {
            _dataService.GetTableContent(_selectedDatabase, tableName);
        }

    }
}