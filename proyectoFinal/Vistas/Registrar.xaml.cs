using System.Net;

namespace proyectoFinal.Vistas;

public partial class Registrar : ContentPage
{
	public Registrar()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
		try
		{
            WebClient cliente = new WebClient();
            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);
            parametros.Add("contrasenia", txtContrasenia.Text);
            cliente.UploadValues("http://192.168.1.32:8080/proyecto/post.php", "POST", parametros);
            Navigation.PushAsync(new Principal());
        }
		catch (Exception ex)
		{

			throw;
		}
    }
}