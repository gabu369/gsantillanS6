using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gsantillanS5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Insertar : ContentPage
	{
        private String url = "http://192.168.20.16/ws_uisrael/post.php";
        public Insertar ()
		{
			InitializeComponent ();
		}

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues(url, "POST", parametros);
                DisplayAlert("Alerta","Dato insertado","Cerrar");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta",ex.ToString(),"Cerrar");
            }
        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {

        }
    }
}