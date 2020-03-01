using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Desafio_02_Criptografia_JC
{
    public class CesarCypher : ICrypt, IDecrypt
    {
        private int TrocaCasas { get; } = 3;

        public string Crypt(string texto)
        {
            if (texto == null)
            {
                throw new ArgumentNullException(nameof(texto));
            }

            if (texto.Trim() == "")
            {
                return texto;
            }

            string textoMinusculo = texto.ToLower();
            string textoCifrado = "";
            int codChar;
            int codChar_a = Convert.ToInt32('a');
            int codChar_z = Convert.ToInt32('z');

            foreach (var item in textoMinusculo)
            {
                int unicodItem = Convert.ToInt32(item);

                if (Char.IsWhiteSpace(item) || Char.IsNumber(item))
                {
                    textoCifrado += item;
                }
                else if (unicodItem >= codChar_a && unicodItem <= codChar_z)
                {
                    codChar = (Convert.ToInt32(item) - codChar_a + TrocaCasas) % 26;
                    textoCifrado += Convert.ToChar(codChar + codChar_a);
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(texto), $"Caracter '{item}' não foi reconhecido.");
                }
            }

            return textoCifrado;
        }

        public string Decrypt(string texto)
        {
            if (texto == null)
            {
                throw new ArgumentNullException(nameof(texto));
            }

            if (texto.Trim() == "")
            {
                return texto;
            }

            string textoMinusculo = texto.ToLower();
            string textoDecifrado = "";
            int codChar;
            int codChar_a = Convert.ToInt32('a');
            int codChar_z = Convert.ToInt32('z');

            foreach (var item in textoMinusculo)
            {
                int unicodItem = Convert.ToInt32(item);

                if (Char.IsWhiteSpace(item) || Char.IsNumber(item))
                {
                    textoDecifrado += item;
                }
                else if (unicodItem >= codChar_a && unicodItem <= codChar_z)
                {
                    codChar = (Convert.ToInt32(item) - codChar_a - TrocaCasas) % 26;
                    if (codChar >= 0)
                    {
                        textoDecifrado += Convert.ToChar(codChar + codChar_a);
                    }
                    else
                    {
                        textoDecifrado += Convert.ToChar(codChar + codChar_z + 1);
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(texto), $"Caracter '{item}' não foi reconhecido.");
                }
            }
            return textoDecifrado;
        }
    }
}
