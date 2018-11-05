using System;
using HuffmanLib.com.cenfotec.estructuras.huffman.letra;

namespace HuffmanLib.com.cenfotec.estructuras.huffman.nodo
{
    public class Nodo
    {
        public Letra letra { get; set; }
        public Nodo derecho { get; set; }
        public Nodo izquierdo { get; set; }

        public Nodo()
        {
            derecho = null;
            izquierdo = null;
            letra = null;
        }
        public Nodo(Letra letra){
            this.letra = letra;
            derecho = null;
            izquierdo = null;
        }
        public void setNodoPadre(){
            this.letra = new Letra(izquierdo.letra.letras + derecho.letra.letras, izquierdo.letra.frecuencia + derecho.letra.frecuencia);
        }

    }
}
