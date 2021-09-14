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
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace CorreoSMTP
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            lb_Usuario.Content = ((MainWindow)Application.Current.MainWindow).txt_correo.Text;
            string remitente = ((MainWindow)Application.Current.MainWindow).txt_correo.Text;
            string password = ((MainWindow)Application.Current.MainWindow).txt_password.Password;
        }

        private void btnEnviarCorreo_Click(object sender, RoutedEventArgs e)
        {
            ValidarDatosCorreo();
        }

        private bool ValidarDatosCorreo()
        {
            if(txt_destinatario.Text.Length == 0 || txt_asunto.Text.Length == 0 || txt_cuerpo.Text.Length == 0)
            {
                MessageBox.Show("Faltan campos por llenar.");
                return false;
            }
            if (!Regex.IsMatch(txt_destinatario.Text, @"^[a-z,A-Z]{1,10}((-|.)\w+)*@\w+.\w{3}$"))
            {
                MessageBox.Show("El destinatario no es un mail válido.");
                return false;
            }
            if (txt_asunto.Text.Length > 100)
            {
                MessageBox.Show("El asunto del correo es demasiado largo.");
                return false;
            }
            if (txt_cuerpo.Text.Length > 5000)
            {
                MessageBox.Show("El mensaje del correo es demasiado largo.");
                return false;
            }
            string password = ((MainWindow)Application.Current.MainWindow).txt_password.Password;
            string remitente = ((MainWindow)Application.Current.MainWindow).txt_correo.Text;
            string asunto = txt_asunto.Text;
            string cuerpoMail = txt_cuerpo.Text;
            string destinatario = txt_destinatario.Text;
            MailMessage mensaje = new MailMessage(remitente, destinatario, asunto, cuerpoMail);
            SmtpClient email = new SmtpClient("smtp-mail.outlook.com")
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(remitente, password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                Port = 587
            };
            email.Send(mensaje);
            MessageBox.Show("¡Mensaje enviado a " + destinatario + "!");
            this.Close();
            return true;
        }

    }
}
