using Common.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public partial class PropertiesViewModel : 
        ObservableObject, 
        IHeader
    {
        [ObservableProperty]
        private ObservableCollection<FieldModel> _fields = new();

        public string Header => "Свойства";


        internal void LoadProperties(RowModel? row)
        {
            _fields.Clear();

            foreach (var field in row.Fields)
            {
                _fields.Add(field);
            }
        }

    }
}