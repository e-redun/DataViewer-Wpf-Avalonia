using System.Windows;

namespace DataViewer.UI.Wpf.Templates
{
    public partial class FieldTemplates
    {
        internal static readonly FieldTemplates Instance = new FieldTemplates();
        public DataTemplate TestTemplate => (DataTemplate)this["TestTemplate"];


        public FieldTemplates()
        {
            InitializeComponent();
        }
    }
}
