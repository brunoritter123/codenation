using Desafio_02_Criptografia_JC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Desafio_02_Criptografia_JC_Teste
{
    [TestClass]
    public class CesarCypherTest    
    {
        [TestMethod]
        public void CryptTextoComNumerosEspacos()
        {
            string textoEntrada = "The1 Quick2 Brow3 Fox4 Jumps5 Over6 The7 Lazy8 Dog9 0";
            string textoEsperado = "wkh1 txlfn2 eurz3 ira4 mxpsv5 ryhu6 wkh7 odcb8 grj9 0";

            var cesarCypher = new CesarCypher();
            string textoCifrado = cesarCypher.Crypt(textoEntrada);

            Assert.AreEqual(textoCifrado, textoEsperado);
        }

        public void CryptTextoVazio()
        {
            string textoEntrada = "  ";
            string textoEsperado = "";
            var cesarCypher = new CesarCypher();
            string textoCifrado = cesarCypher.Crypt(textoEntrada);

            Assert.Equals(textoCifrado, textoEsperado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CryptTextoComAcento()
        {
            string textoEntrada = "Chão";
            var cesarCypher = new CesarCypher();
            cesarCypher.Crypt(textoEntrada);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CryptArgumentoNull()
        {
            string textoEntrada = null;
            var cesarCypher = new CesarCypher();
            cesarCypher.Crypt(textoEntrada);
        }

        [TestMethod]
        public void DecryptTextoComNumerosEspacos()
        {
            string textoEntrada = "aWkh1 Txlfn2 Eurz3 Ira4 Mxpsv5 Ryhu6 Wkh7 Odcb8 Grj9 0";
            string textoEsperado= "xthe1 quick2 brow3 fox4 jumps5 over6 the7 lazy8 dog9 0";

            var cesarCypher = new CesarCypher();
            string textoDecifrado = cesarCypher.Decrypt(textoEntrada);

            Assert.AreEqual(textoDecifrado, textoEsperado);
        }

        public void DecryptTextoVazio()
        {
            string textoEntrada = "   ";
            string textoEsperado = "";
            var cesarCypher = new CesarCypher();
            string textoDecifrado = cesarCypher.Decrypt(textoEntrada);

            Assert.Equals(textoDecifrado, textoEsperado);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DecryptTextoComAcento()
        {
            string textoEntrada = "Chão";
            var cesarCypher = new CesarCypher();
            cesarCypher.Decrypt(textoEntrada);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DecryptArgumentoNull()
        {
            string textoEntrada = null;
            var cesarCypher = new CesarCypher();
            cesarCypher.Decrypt(textoEntrada);
        }
    }
}
