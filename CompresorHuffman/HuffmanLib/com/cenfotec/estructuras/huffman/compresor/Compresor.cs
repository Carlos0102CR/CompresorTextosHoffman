using System;
using System.Collections.Generic;
using HuffmanLib.com.cenfotec.estructuras.huffman.arbol;
using HuffmanLib.com.cenfotec.estructuras.huffman.letra;

namespace HuffmanLib.com.cenfotec.estructuras.huffman.compresor
{
    public class Compresor
    {
        public Arbol arbol;

        public Compresor()
        {
            arbol = new Arbol();
        }

        public void comprimir(string texto){
            List<Letra> diccFrecuencia = new List<Letra>();
            string[] listaLet = new string[texto.Length];
            int[] listaFrec = new int[texto.Length];
            Letra letra;
            
            foreach (char caracter in texto.ToCharArray()){
                if(listaLet.)
            }
        }
    }
}
