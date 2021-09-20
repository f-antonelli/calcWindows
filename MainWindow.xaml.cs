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

namespace calculadoraWindows
{
	public partial class MainWindow : Window
	{
		double valor1 = 0;
		double valor2 = 0;
		Operacion operador = Operacion.NoDefinida;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void AddNumero(string numero) 
		{
			if (txtResultado.Text == "0" && txtResultado.Text != null)
				txtResultado.Text = numero;
			else
				txtResultado.Text += numero;
		}

		private double RealizarOperacion()
		{
			double resultado = 0;
			switch (operador)
			{
				case Operacion.Suma:
					resultado = valor1 + valor2;
					break;
				case Operacion.Resta:
					resultado = valor1 - valor2;
					break;
				case Operacion.Division:
					if (valor2 == 0)
					{
						MessageBox.Show("No se puede dividir entre 0");
						resultado = 0;
					}
					else
					resultado = valor1 / valor2;
					break;
				case Operacion.Multiplicacion:
					resultado = valor1 * valor2;
					break;
				case Operacion.Modulo:
					resultado = valor1 % valor2;
					break;
			}
			return resultado;
		}
		private void btnCero_Click(object sender, RoutedEventArgs e)
		{
			if (txtResultado.Text == "0")
				return;
			else
				txtResultado.Text += "0";
		} 

		private void btnUno_Click(object sender, RoutedEventArgs e) => AddNumero("1");
		private void btnDos_Click(object sender, RoutedEventArgs e) => AddNumero("2");
		private void btnTres_Click(object sender, RoutedEventArgs e) => AddNumero("3");
		private void btnCuatro_Click(object sender, RoutedEventArgs e) => AddNumero("4");
		private void btnCinco_Click(object sender, RoutedEventArgs e) => AddNumero("5");
		private void btnSeis_Click(object sender, RoutedEventArgs e) => AddNumero("6");
		private void btnSiete_Click(object sender, RoutedEventArgs e) => AddNumero("7");
		private void btnOcho_Click(object sender, RoutedEventArgs e) => AddNumero("8");
		private void btnNueve_Click(object sender, RoutedEventArgs e) => AddNumero("9");

		private void ObtenerValor() //para no tener codigo repetido en las operaciones
		{
			valor1 = Convert.ToDouble(txtResultado.Text); //porque es string
			txtResultado.Text = "0";
		}
		private void btnSuma_Click(object sender, RoutedEventArgs e)
		{
			operador = Operacion.Suma;
			ObtenerValor();
		}

		private void btnResta_Click(object sender, RoutedEventArgs e)
		{
			operador = Operacion.Resta;
			ObtenerValor();
		}

		private void btnResultado_Click(object sender, RoutedEventArgs e)
		{
			if (valor2 == 0)
			{ 
				valor2 = Convert.ToDouble(txtResultado.Text);
				double resultado = RealizarOperacion();
				valor1 = 0;
				valor2 = 0;
				txtResultado.Text = Convert.ToString(resultado);
			}

		}

		private void btnMultiplicacion_Click(object sender, RoutedEventArgs e)
		{
			operador = Operacion.Multiplicacion;
			ObtenerValor();
		}

		private void btnDivision_Click(object sender, RoutedEventArgs e)
		{
			operador = Operacion.Division;
			ObtenerValor();
		}

		private void btnBorrar_Click(object sender, RoutedEventArgs e)
		{
			if (txtResultado.Text.Length > 1) //El texto vuelve a 0
			{
				string rdo = txtResultado.Text;
				rdo = rdo.Substring(0,rdo.Length - 1); //corto el ultimo numero
				txtResultado.Text = rdo;
				
				if (rdo.Length == 1 && rdo.Contains("-"))
					txtResultado.Text = "0";

			}
			else
				txtResultado.Text = "0";
		}

		private void btnReset_Click(object sender, RoutedEventArgs e)
		{
			txtResultado.Text = "0";
		}

		private void btnComa_Click(object sender, RoutedEventArgs e)
		{
			if (txtResultado.Text.Contains(","))
				return;
			else
			txtResultado.Text += ",";
		}

	}
}
