using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;


namespace proyectoFinal.Vistas;

public partial class Principal : ContentPage
{
	public Principal()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new Registrar());
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        string username = usernameEntry.Text;
        string password = passwordEntry.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Por favor, ingrese nombre de usuario y contrase�a", "Aceptar");
            return;
        }
        WebClient client = new WebClient();
        var parameters = new System.Collections.Specialized.NameValueCollection();
        parameters.Add("nombre", username);
        parameters.Add("contrase�a", password);

        byte[] responseBytes = client.UploadValues("http://192.168.1.32:8080/proyecto/post.php", "POST", parameters);
        string responseBody = System.Text.Encoding.UTF8.GetString(responseBytes);

        JObject responseJson = JObject.Parse(responseBody);

        if (responseJson.ContainsKey("message"))
        {
            string message = responseJson["message"].ToString();

            if (message == "Inicio de sesi�n exitoso")
            {
                // Redirigir a la p�gina principal o realizar acciones adicionales
                await Navigation.PushAsync(new Inicio());
                // Agrega aqu� la l�gica de navegaci�n a la p�gina principal
            }
            else
            {
                // Mostrar mensaje de error
               await DisplayAlert("Error", "Credenciales incorrectas", "Aceptar");
            }
        }

    }
}