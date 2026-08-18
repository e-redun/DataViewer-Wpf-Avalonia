using System.Windows;

namespace DataViewer.UI.Wpf.Templates
{
    public partial class CellTemplates
    {
        internal static readonly CellTemplates Instance = new CellTemplates();
        public DataTemplate TestTemplate => (DataTemplate)this["TestTemplate"];


        public CellTemplates()
        {
            InitializeComponent();
        }
    }
}
