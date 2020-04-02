using System;
using Xunit;

namespace Codenation.Challenge
{
    public class CesarCypherTest
    {
        [Fact]
        public void CryptTextoComNumerosEspacos()
        {
            string textoEntrada = "The1 Quick2 Brow3 Fox4 Jumps5 Over6 The7 Lazy8 Dog9 0";
            string textoEsperado = "wkh1 txlfn2 eurz3 ira4 mxpsv5 ryhu6 wkh7 odcb8 grj9 0";

            var cesarCypher = new CesarCypher();
            string textoCifrado = cesarCypher.Crypt(textoEntrada);

            Assert.Equal(textoCifrado, textoEsperado);
        }

        [Fact]
        public void CryptTextoVazio()
        {
            string textoEntrada = "";
            string textoEsperado = "";
            var cesarCypher = new CesarCypher();
            string textoCifrado = cesarCypher.Crypt(textoEntrada);

            Assert.Equal(textoCifrado, textoEsperado);
        }

        [Fact]
        public void CryptTextoComAcento()
        {
            string textoEntrada = "Chão";
            var cesarCypher = new CesarCypher();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => cesarCypher.Crypt(textoEntrada)
              );
        }

        [Fact]
        public void CryptArgumentoNull()
        {
            string textoEntrada = null;
            var cesarCypher = new CesarCypher();

            Assert.Throws<ArgumentNullException>(
                () => cesarCypher.Crypt(textoEntrada)
              );
        }

        [Fact]
        public void DecryptTextoComNumerosEspacos()
        {
            string textoEntrada = "aWkh1 Txlfn2 Eurz3 Ira4 Mxpsv5 Ryhu6 Wkh7 Odcb8 Grj9 0";
            string textoEsperado = "xthe1 quick2 brow3 fox4 jumps5 over6 the7 lazy8 dog9 0";

            var cesarCypher = new CesarCypher();
            string textoDecifrado = cesarCypher.Decrypt(textoEntrada);

            Assert.Equal(textoDecifrado, textoEsperado);
        }

        [Fact]
        public void DecryptTextoVazio()
        {
            string textoEntrada = "";
            string textoEsperado = "";
            var cesarCypher = new CesarCypher();
            string textoDecifrado = cesarCypher.Decrypt(textoEntrada);

            Assert.Equal(textoDecifrado, textoEsperado);
        }

        [Fact]
        public void DecryptTextoComAcento()
        {
            string textoEntrada = "Chão";
            var cesarCypher = new CesarCypher();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => cesarCypher.Decrypt(textoEntrada)
              );
        }

        [Fact]
        public void DecryptArgumentoNull()
        {
            string textoEntrada = null;
            var cesarCypher = new CesarCypher();

            var excecao = Assert.Throws<ArgumentNullException>(
                () => cesarCypher.Decrypt(textoEntrada)
              );
        }
    }

}

