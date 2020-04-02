using System;

namespace Codenation.Challenge
{
    /// <summary>
    /// Classe CesarCypher para a criptografar e descriptografar mensagens usando a Cifra de C�sar:
    /// </summary>
    public class CesarCypher : ICrypt, IDecrypt
    {
        /// <summary>
        /// Quantidade de letras que deve ser trocada para cifrar ou decifrar um texto
        /// </summary>
        private int TrocaCasas { get; } = 3;

        /// <summary>
        /// M�todo para cifra um texto usando a Cifra de C�sar.
        /// <exception cref="System.ArgumentNullException">Lan�ado quando o param <see cref="texto"/> � null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Lan�ado quando o param <see cref="texto"/> cont�m algum caracter especial ou letra acentuada como �, �, �, etc.</exception>
        /// </summary>
        /// <param name="texto">Texto para ser cifrado</param>
        /// <returns>Retorna o <see cref="texto"/> cifrado.</returns>
        public string Crypt(string texto)
        {
            if (texto is null)
            {
                throw new ArgumentNullException(nameof(texto));
            }

            if (texto.Length == 0)
            {
                return String.Empty;
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
                    throw new ArgumentOutOfRangeException(nameof(texto), $"Caracter '{item}' n�o foi reconhecido.");
                }
            }

            return textoCifrado;
        }

        /// <summary>
        /// M�todo para decifrar um texto usando a Cifra de C�sar.
        /// </summary>
        /// <exception cref="System.ArgumentNullException">Lan�ado quando o param <see cref="texto"/> � null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Lan�ado quando o param <see cref="texto"/> cont�m algum caracter especial ou letra acentuada como �, �, �, etc.</exception>
        /// <param name="texto">Texto para ser decifrado</param>
        /// <returns>Retorna o <see cref="texto"/> decifrado.</returns>
        public string Decrypt(string texto)
        {
            if (texto is null)
            {
                throw new ArgumentNullException(nameof(texto));
            }

            if (texto.Length == 0)
            {
                return String.Empty;
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
                    throw new ArgumentOutOfRangeException(nameof(texto), $"Caracter '{item}' n�o foi reconhecido.");
                }
            }
            return textoDecifrado;
        }
    }
}
