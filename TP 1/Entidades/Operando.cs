using System;

namespace Entidades
{
    public class Operando
    {
        private double numero;

        #region Constructores

        public Operando() : this(0)
        {            
        }

        public Operando(double numero) : this(numero.ToString())
        {
            
        }

        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }

        #endregion

        #region Propiedades

        public string Numero 
        {
            set
            {
                this.numero = ValidarOperando(value);
            } 
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Recibe un numero decimal y lo convierte a binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(double numero)
        {
            string retorno = "Valor Invalido";
            int numParseado = (int)numero;
            int residuo = 0;

            if (numParseado == 0)
            {
                retorno = "0";
            }
            else if (numParseado > 0)
            {
                retorno = "";

                while (numParseado > 1)
                {
                    residuo = numParseado % 2;
                    retorno = residuo.ToString() + retorno;
                    numParseado = numParseado / 2;
                }

                retorno = numParseado.ToString() + retorno;
            }

            return retorno;
        }

        /// <summary>
        /// Recibe un numero en formato cadena, verifica que sea un numero valido y lo convierte en binario.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        public static string DecimalBinario(string numero)
        {
            string retorno = "Valor Invalido";

            if (double.TryParse(numero, out double numParseado))
            {
                retorno = DecimalBinario(numParseado);
            }

            return retorno;
        }

        /// <summary>
        /// Recibe un numero binario en formato string, valida que no tenga errores y lo convierte a decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        public static string BinarioDecimal(string binario)
        {
            string retorno = "Valor Invalido";
            char[] arrayBinario;
            int acumulador = 0;

            if (EsBinario(binario))
            {
                arrayBinario = binario.ToCharArray();
                Array.Reverse(arrayBinario);

                for (int i = 0; i < arrayBinario.Length; i++)
                {
                    if (arrayBinario[i] == '1')
                    {
                        acumulador = acumulador + (int)Math.Pow(2, i);
                    }
                }

                retorno = acumulador.ToString();
            }

            return retorno;
        }

        /// <summary>
        /// Retorna true si la cadena recibida es un numero binario. Caso contrario, retorna false.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns></returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = true;

            for (int i = 0; i < binario.Length; i++)
            {
                if (binario[i] != '0' && binario[i] != '1')
                {
                    retorno = false;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Valida que la cadena recibida sea un numero valido y lo devuelve como double. Caso contrario retorna 0.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        public static double ValidarOperando(string strNumero)
        {
            if (!double.TryParse(strNumero, out double retorno))
            {
                return 0;
            }

            return retorno;
        }

        #endregion

        #region Sobrecargas

        /// <summary>
        /// Realiza el calculo de dos valores de la clase Operando y lo devuelve como Double
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator +(Operando num1, Operando num2)
        {
            return num1.numero + num2.numero;
        }

        /// <summary>
        /// Realiza el calculo de dos valores de la clase Operando y lo devuelve como Double
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator -(Operando num1, Operando num2)
        {
            return num1.numero - num2.numero;
        }

        /// <summary>
        /// Realiza el calculo de dos valores de la clase Operando y lo devuelve como Double
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator *(Operando num1, Operando num2)
        {
            return num1.numero * num2.numero;
        }

        /// <summary>
        /// Realiza el calculo de dos valores de la clase Operando y lo devuelve como Double
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        public static double operator /(Operando num1, Operando num2)
        {
            if(num2.numero == 0)
            {
                return double.MinValue;
            }

            return num1.numero / num2.numero;
        }

        #endregion
    }
}
