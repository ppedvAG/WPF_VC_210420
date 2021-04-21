using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Setzen des DataContext des Fensters auf sich selbst (Einfache Bindungen zu Properties in diesem Objekt möglich)
            this.DataContext = this;
        }

        //Properties vom Typ ObservableCollection informieren die GUI automatisch über Veränderungen (z.B. neuer Listeneintrag). Sie eignen sich besonders gut
        //für eine Bindung an ein ItemControl (z.B. ComboBox, ListBox, DataGrid, ...)
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Vorname="Anna", Nachname="Nass", Alter=36},
            new Person(){Vorname="Rainer", Nachname="Zufall", Alter=67},
        };

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show((Spl_DataContextBsp.DataContext as Person).Vorname);

            //Erhöhung des Alters der Person im DataContextes des StackPanels
            (Spl_DataContextBsp.DataContext as Person).Alter++;
        }

        private void Btn_Neu_Click(object sender, RoutedEventArgs e)
        {
            //Hinzufügen einer neuen Person
            Personenliste.Add(new Person() { Vorname = "Hugo", Nachname = "Meier", Alter = 25 });
        }

        private void Btn_Loeschen_Click(object sender, RoutedEventArgs e)
        {
            //Löschen der in dem ListView angewählten Person
            if (Lbx_Personen.SelectedItem is Person)
                Personenliste.Remove(Lbx_Personen.SelectedItem as Person);
        }
    }
}
