using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gsantillanS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Veterinarios : ContentPage
    {
        private String url = "http://192.168.17.26/pawpal/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Veterinario> post;
        public Veterinarios()
        {
            InitializeComponent();
            ObtenerDatos();
        }
        public async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(url);
            List<Veterinario> listaPost = JsonConvert.DeserializeObject<List<Veterinario>>(contenido);
            post = new ObservableCollection<Veterinario>(listaPost);

            listaVeterinarios.ItemsSource = post;
        }
    }
}