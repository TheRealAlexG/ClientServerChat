using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientChatAlexMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Implementation chatLogicImplementation;
        public MainWindow()
        {
            chatLogicImplementation = new Implementation("http://localhost:51111");
            InitializeComponent();
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var usuari = txtUsername.Text;
                if (!string.IsNullOrEmpty(usuari))
                {
                    this.chatLogicImplementation.registraUsuari(txtUsername.Text);
                    chat finestra = new chat(this.chatLogicImplementation);
                    finestra.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }


        }
    }
}