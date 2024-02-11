using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ClientChatAlexMan
{
    /// <summary>
    /// Interaction logic for chat.xaml
    /// </summary>
    public partial class chat : Window
    {
        private Implementation chatImplementation;
        public chat(Implementation chatImp )
        {
            this.chatImplementation = chatImp;
            InitializeComponent();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            string date = txtFiltrarMissatgesDataHora.Text;
            if (!string.IsNullOrEmpty(date))
            {
                var llistaMissatges = chatImplementation.messsagesTime(chatImplementation.User, date);
                foreach (var item in llistaMissatges)
                {
                    txtXat.AppendText(item);
                    txtXat.AppendText(Environment.NewLine);
                }
            }
            else MessageBox.Show("the textBox is empty !!");


        }

        private void btnRebre_Click(object sender, RoutedEventArgs e)
        {
            string emissor = txtReceptor.Text;
            string msg = txtMissatge.Text;
            if (!string.IsNullOrEmpty(emissor))
            {
                var llistaMissatges = chatImplementation.reciveMessage(emissor);
                foreach (var item in llistaMissatges)
                {
                    txtXat.AppendText(item);
                    txtXat.AppendText(Environment.NewLine);
                }
            }
            else MessageBox.Show("Emissor buit!");

        }


        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            string receptor = txtReceptor.Text;
            string msg = txtMissatge.Text;
            if (!string.IsNullOrEmpty(receptor) && !string.IsNullOrEmpty(msg))
            {
                string msgEnviat = chatImplementation.sendMessage(msg, receptor);
                txtXat.AppendText(msgEnviat);
                txtXat.AppendText(Environment.NewLine);
            }
            else MessageBox.Show("Receptor o Missatge buits!");


        }

        private void btnListUsers_Click(object sender, RoutedEventArgs e)
        {
            var llistaUsuaris = chatImplementation.userList();

            foreach (var item in llistaUsuaris)
            {
                txtXat.AppendText(item);
                txtXat.AppendText(Environment.NewLine);
            }

        }
    }
}
