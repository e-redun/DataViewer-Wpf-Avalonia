using DataViewer.UI.Wpf.Templates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DataViewer.UI.Wpf.Helpers
{
    internal class CellTemplateSelector : DataTemplateSelector
    {

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return CellTemplates.Instance.TestTemplate;
        }
    }
}
