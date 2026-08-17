using Common.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class PropertiesViewModel : 
        ObservableObject, 
        IHeader
    {
        public string Header => "Свойства";

        internal void Clear()
        {
        }

        internal void LoadProperties(List<CellModel> cells)
        {
        }
    }
}