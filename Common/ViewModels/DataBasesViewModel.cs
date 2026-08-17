using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class DataBasesViewModel : 
        ObservableObject, 
        IHeader
    {
        public string Header => "Базы данных";

        public ObservableCollection<string> Databases { get; set; } = new();

        internal void LoadDatabases(List<string> databases)
        {
            Databases.Clear();

            foreach (var database in databases)
            {
                Databases.Add(database);
            }
        }
    }
}