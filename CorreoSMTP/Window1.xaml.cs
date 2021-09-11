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
            //((MainWindow)Application.Current.MainWindow).txtForm1TextBox.Text = "Some text";
            string password = ((MainWindow)Application.Current.MainWindow).txt_password.Password;
        }

        private void btnEnviarCorreo_Click(object sender, RoutedEventArgs e)
        {

            string remitente = ((MainWindow)Application.Current.MainWindow).txt_correo.Text;
            //((MainWindow)Application.Current.MainWindow).txtForm1TextBox.Text = "Some text";
            string password = ((MainWindow)Application.Current.MainWindow).txt_password.Password;
            Console.WriteLine(remitente);
            Console.WriteLine(password);

            SmtpClient email = new SmtpClient
            {
                Credentials = new NetworkCredential(remitente, password),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Host = "smtp.gmail.com",
                Port = 587
            };
            string asunto = txt_asunto.Text;
            string cuerpoMail = txt_cuerpo.Text;
            string destinatario = txt_destinatario.Text;
            MailMessage mensaje = new MailMessage(remitente, destinatario);
            mensaje.Body = cuerpoMail;
            

            //email.Send(remitente, destinatario, asunto, cuerpoMail);
            email.Send(mensaje);
        }

    }
}
