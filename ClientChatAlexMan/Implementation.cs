using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ClientChatAlexMan
{
    public class Implementation
    {
        private String serverUrl;
        private String user;
        private String user2Speak;
        private List<String> messageList;

        public string ServerUrl { get => serverUrl; set => serverUrl = value; }
        public string User { get => user; set => user = value; }
        public List<string> MessageList { get => messageList; set => messageList = value; }

        public Implementation(string urlServidor)
        {
            this.serverUrl = urlServidor;
            messageList = new List<String>();
        }
        
        public List<string> userList()
        {
            List<string> usuaris = new List<string>();
            WebClient wc = new WebClient();
            var llistaUsuaris = wc.DownloadString(serverUrl + "/llistarusuaris");
            var splitUsuaris = llistaUsuaris.Split(';');
            foreach (var s in splitUsuaris) usuaris.Add(s);
            return usuaris;
        }
        public void registraUsuari(string usuari)
        {
            WebClient webC = new WebClient();
            webC.DownloadString(serverUrl + "/registrarusuari?u=" + usuari);
            this.User = usuari;
        }
       
       
        public List<string> messsagesTime(string usuari, string dataHora)
        {
            List<String> messages = new List<string>();
            WebClient webC = new WebClient();
            var messagesList = webC.DownloadString(serverUrl + "/rperdatahora?u=" + usuari + "&t=" + dataHora);
            var splitMessages = messagesList.Split(';');
            foreach (var y in splitMessages) messages.Add(y);
            return messages;
        }
      
        public string sendMessage(string msg, string usuariReceptor)
        {
            WebClient webC = new WebClient();
            return webC.DownloadString(serverUrl + "/enviar?u=" + usuariReceptor + "&ue=" + this.User + "&m=" + msg);
        }
       
        public List<string> reciveMessage(string usuariEmissor)
        {
            List<String> messages = new List<string>();
            WebClient webC = new WebClient();
            var messagesList = webC.DownloadString(serverUrl + "/rebre?u=" + usuariEmissor);
            var splitMessages = messagesList.Split(';');
            foreach (var y in splitMessages) messages.Add(y);
            return messages;
        }

    }
}
