using Common.Models;
using Common.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class TableContentViewModel : 
        ObservableObject, 
        IHeader
    {
        public string Header => "Таблица " + _tableData?.Name;
        
        public event Action<IEnumerable<FieldModel>?>? RowChanged;


        [ObservableProperty] 
        private TableModel? _tableData;

        [ObservableProperty]
        private ObservableCollection<RowModel> _rows = new();
        private string? _selectedDatabaseName;
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

        internal void GetDatabaseName(string? dbName)
        {
            _selectedDatabaseName = dbName;
        }


        internal void LoadContentFromTable(string? tableName)
        {
            var tableContent = _dataService.GetTableContent(_selectedDatabaseName, tableName);

            TableData = tableContent;

            Rows.Clear();

            foreach (var row in tableContent.Rows)
            {
                Rows.Add(row);
            }

            OnPropertyChanged(nameof(Header));
        }

    }
}