using System;
using System.Collections.Generic;

namespace HuffmanLib.com.cenfotec.estructuras.huffman.letra
{
    public class Letra
    {
        public string letras { get; set; }
        public int frecuencia { get; set; }
        public string binario { get; set; }

        public Letra()
        {
            letras = "";
        }

        public Letra(string letras, int frecuencia ){
            this.letras = letras;
            this.frecuencia = frecuencia;
            this.binario = "";
        }

        public Letra(string letras, string binario)
        {
            this.letras = letras;
            this.binario = binario;
        }
    }
}
