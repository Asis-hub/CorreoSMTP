using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CorreoSMTP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            ValidarCorreo();
            String correoUsuario = txt_correo.Text;
            String password = txt_password.Password;
        }

        private bool ValidarCorreo()
        {
            if (txt_correo.Text.Length == 0 || txt_password.Password.Length ==0)
            {
                MessageBox.Show("Faltan campos por llenar.");
                return false;
            }
            if (!Regex.IsMatch(txt_correo.Text, @"^[a-z,A-Z]{1,10}((-|.)\w+)*@\w+.\w{3}$"))
            {
                MessageBox.Show("El destinatario no es un mail válido.");
                return false;
            }
            Window1 ventanaCorreo = new Window1();
            ventanaCorreo.Show();
            return true;
        }
    }
}
