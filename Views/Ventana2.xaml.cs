namespace KTIGSETLLS3.Views;

public partial class Ventana2 : ContentPage
{
    public Ventana2(string pkIdent, string valIden, string nombres, string apellidos, string fecha, string correo, decimal sueldo, decimal aporte)
    {
        InitializeComponent();
        lblPkIden.Text = "IDENTIFICACIÓN SELECCIONADA: " + pkIdent;
        lblValorIden.Text = "IDENTIFICACIÓN: " + valIden;
        lblNombres.Text = "NOMBRES: " + nombres;
        lblApellidos.Text = "APELLIDOS: " + apellidos;
        lblFecha.Text = "FECHA: " + fecha;
        lblCorreo.Text = "CORREO: " + correo;
        lblSalario.Text = "SALARIO: " + sueldo.ToString();
        lblAporteIess.Text = "APORTE IESS: " + aporte.ToString();
    }

    private void btnExportar_Clicked(object sender, EventArgs e)
    {
        try
        {
            // Formamos el contenido
            string contenido = $" {lblPkIden.Text} \n {lblValorIden.Text} \n {lblNombres.Text} \n {lblApellidos.Text} " +
                $"\n {lblFecha.Text} \n {lblCorreo.Text} \n {lblSalario.Text} \n {lblAporteIess.Text}  \n---\n";

            // Ruta del archivo en almacenamiento local
            string rutaArchivo = Path.Combine(@"D:\UISRAEL\6.-OCTAVO SEMESTRE\1.-DESARROLLO MOVIL\EJERCICIOS", "contacto.txt");

            // Guardamos (append para no sobrescribir si ya hay contenido)
            File.AppendAllText(rutaArchivo, contenido);
            DisplayAlert("MENSAJE", "DATOS EXPORTADOS CORRECTAMENTE", "OK");
        }
        catch (Exception)
        {
            throw;
        }
    }
}