//using PassKit;

//using PassKit;
using System.Globalization;

namespace KTIGSETLLS3.Views;

public partial class Ventana1 : ContentPage
{
    public Ventana1()
    {
        InitializeComponent();
    }

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (pkIden.SelectedIndex == -1)
            {
                this.lblInfo.Text = "SELECCIONE UNA IDENTIFICACIÓN";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text))
            {
                this.lblInfo.Text = "INGRESE LA IDENTIFICACIÓN";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                this.lblInfo.Text = "INGRESE LOS NOMBRES";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtApellidos.Text))
            {
                this.lblInfo.Text = "INGRESE LOS APELLIDOS";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                this.lblInfo.Text = "INGRESE EL CORREO";
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSueldo.Text))
            {
                this.lblInfo.Text = "INGRESE EL SUELDO";
                return;
            }

            //CALCULO APORTE AL IESS - Nota: Al afiliado le corresponde entregar un aporte al IESS del 9,45% de su sueldo o salario
            // Capturamos el texto del Entry
            string texto = txtSueldo.Text.Trim();

            // Reemplazamos coma por punto para garantizar formato correcto
            texto = texto.Replace(",", ".");

            // Intentamos convertir el texto a decimal usando InvariantCulture
            if (decimal.TryParse(texto, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal sueldo))
            {
                // Calculamos el aporte (9.45% del sueldo)
                decimal aporte = Math.Round((sueldo * 9.45m) / 100, 2); // Redondeamos a 2 decimales

                string pkIdenti = pkIden.Items[pkIden.SelectedIndex].ToString();
                string valIden = txtIdentificacion.Text;
                string nombres = txtNombres.Text;
                string apellidos = txtApellidos.Text;
                string fec = dpFec.Date.ToString();
                string correo = txtCorreo.Text;

                Navigation.PushAsync(new Views.Ventana2(pkIdenti, valIden, nombres,apellidos, fec, correo, sueldo, aporte));
            }
            else
            {
                // Si el usuario ingresó mal el valor
                DisplayAlert("Error", "Ingrese un sueldo válido (ej: 987.73).", "OK");
                return;
            }
        }
        catch (Exception)
        {
            throw;
        }
    }

    private void txtSueldo_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            // Intentamos convertir el nuevo valor a número decimal (double)
            if (!string.IsNullOrWhiteSpace(e.NewTextValue) && !double.TryParse(e.NewTextValue, out _))
            {
                this.lblInfo.Text = "❌ Solo se permiten números válidos (enteros o decimales).";
                this.txtSueldo.Text = e.OldTextValue; // Revertir al valor anterior
            }
        }
        catch (Exception)
        {

            throw;
        }
    }
}