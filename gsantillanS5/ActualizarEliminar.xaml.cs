using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gsantillanS5
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ActualizarEliminar : ContentPage
	{
        private String url = "http://192.168.17.26/ws_uisrael/post.php";

        public ActualizarEliminar (int codigo, string nombre, string apellido, int edad)
		{
			InitializeComponent ();
            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
		}

        private void btnActualiza_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues(url+ "?codigo="+txtCodigo.Text+ "&nombre="+txtNombre.Text+ "&apellido="+txtApellido.Text+ "&edad="+txtEdad.Text, "PUT", parametros);
                var mensaje = "Estudiante actualizado con exito.";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                //DisplayAlert("Alerta", "Dato actualizado", "Cerrar");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                //DisplayAlert("Alerta", ex.ToString(), "Cerrar");
                DependencyService.Get<Mensaje>().longAlert(ex.ToString());
            }
        }
        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                cliente.UploadValues(url+ "?codigo="+txtCodigo.Text, "DELETE",parametros);
                //DisplayAlert("Alerta", "Dato eliminado", "Cerrar");
                var mensaje = "Estudiante eliminado con exito.";
                DependencyService.Get<Mensaje>().longAlert(mensaje);
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                //DisplayAlert("Alerta", ex.ToString(), "Cerrar");
                DependencyService.Get<Mensaje>().longAlert(ex.ToString());
            }
        }
    }
}