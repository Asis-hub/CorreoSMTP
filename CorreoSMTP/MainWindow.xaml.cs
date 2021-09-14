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
            string prueba = "Prueba git"
        }


        private void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
        // Envíar datos de entrada al nuevo xaml.
            String correoUsuario = txt_correo.Text;
            String password = txt_password.Password;
            Window1 ventanaCorreo = new Window1();
            ventanaCorreo.Show();
            // this.Close();
        }
    }
}
