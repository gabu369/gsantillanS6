using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Xamarin.Forms.Internals.Profile;

namespace gsantillanS5
{
    public partial class MainPage : ContentPage
    {
        private String url = "http://192.168.17.26/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiante> post;
        public MainPage()
        {
            InitializeComponent();
            ObtenerDatos();
        }

        public async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(url);
            List<Estudiante> listaPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            post = new ObservableCollection<Estudiante>(listaPost);

            listaEstudiantes.ItemsSource = post;
        }

        private async void btnMostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objeto = (Estudiante) e.SelectedItem;
            var codigoTem = objeto.codigo.ToString();
            int codigo = Convert.ToInt32(codigoTem);
            var edadTem = objeto.edad.ToString();
            int edad= Convert.ToInt32(edadTem);
            Navigation.PushAsync(new ActualizarEliminar(codigo,objeto.nombre.ToString(),objeto.apellido.ToString(),edad));
        }
    }
}
