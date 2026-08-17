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
        [ObservableProperty] 
        private string? _selectedDatabase;      
        
        // Выбранная строка-имя таблицы
        [ObservableProperty] 
        private string? _selectedTable;         
        
        // Выбранная УНИВЕРСАЛЬНАЯ строка таблицы
        [ObservableProperty] 
        private RowModel? _selectedRow;   


        public MainWindowModel(
            IDataService dataService,
            DataBasesViewModel dataBasesVM,
            TablesViewModel tablesVM,
            TableContentViewModel tableContentVM,
            PropertiesViewModel propertiesVM)
        {
            _dataService = dataService;

            _dataBasesVM = new DataBasesViewModel();
            _tablesVM = new TablesViewModel();
            _tableContentVM = new TableContentViewModel();
            _propertiesVM = new PropertiesViewModel();

            _dataBasesVM.LoadDatabases(_dataService.GetDatabases());
        }

        // Логика связывания при смене выбранной БД
        void OnSelectedDatabaseChanged(string? oldValue, string? newValue)
        {
            SelectedTable = null;
            SelectedRow = null;

            if (newValue == null)
            {
                _tablesVM.Clear();
                return;
            }

            // Загружаем список таблиц для выбранной БД
            var tables = _dataService.GetTables(newValue);
            _tablesVM.LoadTables(tables);
        }

        // Логика связывания при смене выбранной таблицы
        void OnSelectedTableChanged(string? oldValue, string? newValue)
        {
            SelectedRow = null;

            if (newValue == null || SelectedDatabase == null)
            {
                _tableContentVM.Clear();
                return;
            }

            // Загружаем контент таблицы
            var content = _dataService.GetTableContent(SelectedDatabase, newValue);
            _tableContentVM.LoadContent(content);
        }

        // Логика связывания при клике на СТРОКУ таблицы
        void OnSelectedRowChanged(Models.RowModel? oldValue, Models.RowModel? newValue)
        {
            if (newValue == null)
            {
                _propertiesVM.Clear();
                return;
            }

            // Отправляем всю строку (список ячеек CellModel) в панель свойств
            _propertiesVM.LoadProperties(newValue.Cells);
        }

        [RelayCommand]
        private void CloseApplication()
        {
            CloseRequest?.Invoke();
        }

    }
}