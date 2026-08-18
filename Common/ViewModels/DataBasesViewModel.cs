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
        [ObservableProperty]
        private string? _selectedDatabase;

        public string Header => "Базы данных";

        public event Action<string?>? DatabaseChanged;

        public ObservableCollection<string> Databases { get; set; } = new();


        internal void LoadDatabases(IEnumerable<string> databases)
        {
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