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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculadora23BM_Ucan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            
                Button button = (Button)sender;
                string value = (string)button.Content;
                
                if (IsNumber(value))
                {
                    HadleNumber(value);
                }
                else if (IsOperador(value))
                {
                    HandleOperador(value);
                }
                if (EsResultado(value))
                {
                    Resultado(Screen.Text);    
                }
            
           
        }

        //metodos auxiliares
        private bool IsNumber(string num)
        {
            return double.TryParse(num, out _)|| num == ".";
        }
        private bool IsOperador(string posibleOperador)
        {
            if (posibleOperador == "+" || posibleOperador == "-" || posibleOperador == "x" || posibleOperador == "÷")
            {
                return true;
            }
            return false;
        }
        public bool EsResultado (string posible)
        {

            return posible == "=";
        }
        private void HadleNumber(string value)
        {

            if (Screen.Text == "0")
            {
                Screen.Clear();
                Screen.Text= value;
            }
            else
            {
                Screen.Text += value;
            }
            
        }

        private void HandleOperador(string value)
        {
            if (!string.IsNullOrEmpty(Screen.Text))
            {
                if (IsNumber(Screen.Text))
                {
                    Screen.Text += value;
                }
                else if(ContainsDuplicateOperator(Screen.Text+value))
                {
                    MessageBox.Show("No se pueden agregar más de dos operadores consecutivos.");
                }
                else
                {
                    Screen.Text += value;
                }
            }
            
        } 
        
        // VALIDACION SW NO AGREGAAR MAS DE DOS OPERADORES contains in c#
        public bool ContainsDuplicateOperator(string num)
        {
            string operado = "+-x÷";

            for (int i = 0; i < num.Length; i++)
            {
                if (operado.Contains(num[i].ToString()))
                {
                    return true;
                }
            }

            return false;
        }
        public void Resultado (string resultado)
        {
            string[] operadores = { "+", "-", "x", "÷" };
            foreach (string operador in operadores)
            {
                if (resultado.Contains(operador))
                {
                    string[] Suma = resultado.Split(operador);
                        string valor1 = Suma[0];
                        string valor2 = Suma[1];
                    if (valor2 != "")
                    {
                        double val1 = double.Parse(valor1), val2 = double.Parse(valor2), resulta;
                        switch (operador)
                        {
                            case "+":
                                resulta = val1 + val2;
                                Screen.Text = resulta.ToString();
                                break;
                            case "-":
                                resulta = val1 - val2;
                                Screen.Text = resulta.ToString();
                                break;
                            case "x":
                                resulta = val1 * val2;
                                Screen.Text = resulta.ToString();
                                break;
                            case "÷":
                                resulta = val1 / val2;
                                Screen.Text = resulta.ToString();
                                break;
                            default:
                                MessageBox.Show("Ingrese una operacion valida");
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese dos valores para poder realizar la operacion");
                    }
                }
            }
            
        }
        

    }
}
