using System.Windows;
using GerenciadorDeTorneios.ViewModel;

namespace GerenciadorDeTorneios
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // inserindo o DataContext, na prática faz: todos os Bindings do XAML devem usar o MainWindowViewModel como fonte de dados.
            DataContext = new MainWindowViewModel();
        }
    }
}