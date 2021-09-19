using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Utiliza la funcion Operar para realizar el calculo de los valores ingresados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string registro;

            this.ValidarCampos();

            this.lblResultado.Text = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text).ToString();

            registro = $"{this.txtNumero1.Text} {this.cmbOperador.Text} {this.txtNumero2.Text} = {this.lblResultado.Text}";
            this.lstOperaciones.Items.Add(registro);

            this.btnConvertirABinario.Enabled = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado;

            resultado = MessageBox.Show("¿Confirma que quiere salir?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                Dispose();
            }
        }

        /// <summary>
        /// Convierte el resultado en decimal a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            string registro;
            string aux;

            aux = this.lblResultado.Text; 
            this.lblResultado.Text = Operando.DecimalBinario(this.lblResultado.Text);

            this.btnConvertirABinario.Enabled = false;
            this.btnConvertirADecimal.Enabled = true;

            registro = $"{aux} en Binario es: {this.lblResultado.Text}";
            this.lstOperaciones.Items.Add(registro);
        }

        /// <summary>
        /// Convierte el resultado en binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string registro;
            string aux;

            aux = this.lblResultado.Text;
            this.lblResultado.Text = Operando.BinarioDecimal(this.lblResultado.Text);
        
            this.btnConvertirABinario.Enabled = true;
            this.btnConvertirADecimal.Enabled = false;

            registro = $"{aux} en Decimal es: {this.lblResultado.Text}";
            this.lstOperaciones.Items.Add(registro);
        }

        /// <summary>
        /// Limpia todos los campos de la calculadora menos el historial.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedIndex = 0;
            this.lblResultado.Text = "0";
        }

        /// <summary>
        /// Realiza el calculo de los dos valores ingresados y devuelve el resultado.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string num1, string num2, string operador)
        {
            Operando op1 = new Operando(num1);
            Operando op2 = new Operando(num2);
            char operando = char.Parse(operador);

            return Calculadora.Operar(op1, op2, operando);
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult resultado;

            resultado = MessageBox.Show("¿Confirma que quiere salir?", "Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Corrige los campos de texto en caso de que no se ingresen numeros, para que no queden en el historial.
        /// Corrige el combobox en caso de que no se ingrese signo.
        /// </summary>
        private void ValidarCampos()
        {
            if (!this.txtNumero1.Text.All(char.IsDigit))
            {
                this.txtNumero1.Text = "0";
            }

            if (!this.txtNumero2.Text.All(char.IsDigit))
            {
                this.txtNumero2.Text = "0";
            }

            if(this.cmbOperador.SelectedIndex == 0)
            {
                this.cmbOperador.SelectedIndex = 1;
            }
        }
    }
}
