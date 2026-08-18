using Common.Models;
using Common.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class MainWindowModel : ObservableObject
    {
        public event Action? CloseRequest;

        private readonly IDataService _dataService;

        [ObservableProperty]
        private DataBasesViewModel _dataBasesVM;

        [ObservableProperty]
        private TablesViewModel _tablesVM;

        [ObservableProperty]
        private TableContentViewModel _tableContentVM;

        [ObservableProperty]
        private PropertiesViewModel _propertiesVM;


        // Свойства для хранения выделенного состояния (выборов пользователя)
        // Выбранная строка-имя БД
        //[ObservableProperty] 
        //private string? _selectedDatabase;

        // Выбранная строка-имя таблицы
        [ObservableProperty]
        private string? _selectedTable;

        // Выбранная УНИВЕРСАЛЬНАЯ строка таблицы
        [ObservableProperty] 
        private RowModel? _selectedRow;   


        public MainWindowModel(
            //IDataService dataService,
            DataBasesViewModel dataBasesVM,
            TablesViewModel tablesVM,
            TableContentViewModel tableContentVM,
            PropertiesViewModel propertiesVM)
        {
            //_dataService = dataService;

            _dataBasesVM = dataBasesVM;
            _tablesVM = tablesVM;
            _tableContentVM = tableContentVM;
            _propertiesVM = propertiesVM;

            //_dataBasesVM.DatabaseChanged += (dbName) => _tablesVM.LoadTables2(dbName);
            _dataBasesVM.DatabaseChanged += _tablesVM.LoadTablesFromDatabase;
            _dataBasesVM.DatabaseChanged += _tableContentVM.GetDatabaseName;
            _tablesVM.TableChanged += _tableContentVM.LoadContentFromTable;
            //_tableContentVM.RowChanged += _propertiesVM.LoadProperties2;
            //_dataBasesVM.LoadDatabases(_dataService.GetDatabases());
        }


        //partial void OnSelectedDatabaseChanged(string? value)
        //{
        //    SelectedTable = null;
        //    SelectedRow = null;

        //    if (value == null)
        //    {
        //        _tablesVM.Clear();
        //        return;
        //    }

        //    // Загружаем список таблиц для выбранной БД
        //    var tables = _dataService.GetTables(value);
        //    _tablesVM.LoadTables(tables);
        //}

        partial void OnSelectedTableChanged(string? value)
        {
            //SelectedRow = null;

            //if (value == null || SelectedDatabase == null)
            //{
            //    _tableContentVM.Clear();
            //    return;
            //}

            //// Загружаем контент таблицы
            //var content = _dataService.GetTableContent(SelectedDatabase, value);
            //_tableContentVM.LoadContent(content);
        }

        partial void OnSelectedRowChanged(RowModel? value)
        {
            //if (value == null)
            //{
            //    _propertiesVM.Clear();
            //    return;
            //}

            //// Отправляем всю строку (список ячеек CellModel) в панель свойств
            //_propertiesVM.LoadProperties(value.Cells);
        }

        [RelayCommand]
        private void CloseApplication()
        {
            CloseRequest?.Invoke();
        }

    }
}