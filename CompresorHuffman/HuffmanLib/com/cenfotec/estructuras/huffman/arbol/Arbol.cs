using System.Collections.Generic;
using HuffmanLib.com.cenfotec.estructuras.huffman.letra;
using HuffmanLib.com.cenfotec.estructuras.huffman.nodo;

namespace HuffmanLib.com.cenfotec.estructuras.huffman.arbol
{
    public class Arbol
    {
        private Nodo raiz { get; set; }

        public Arbol()
        {

            raiz = null;
        }

        public Dictionary<string, string> generarDiccionario(List<Letra> diccFrecuencia)
        {
            Nodo auxIzq, raizTemp;
            raizTemp = new Nodo();
            bool fin = false;
            Dictionary<string,string> diccHuffman = new Dictionary<string,string>();

            foreach (Letra letraTemp in diccFrecuencia)         //Crea el Arbol
            {
                auxIzq = new Nodo(letraTemp);
                if (raiz == null) { raiz = auxIzq; }            //verifica si la raiz es null
                else
                {       
                    raizTemp.derecho = raiz;
                    raizTemp.izquierdo = auxIzq;
                    raizTemp.setPrimoIzq(raizTemp.izquierdo);
                    raizTemp.setNodoPadre();                    //hace que la letra dentro de la raiz temporal sea una suma de las letras que contienen sus hijos
                    raiz = raizTemp;                            //mueve la antigua raiz abajo de la nueva que es una suma de sus dos hijos
                }
            }

            if (raiz != null)
            {
                raizTemp = raiz.getUltimoDerecho();             //Pide la hoja derecha del nodo actual o en su defecto el mismo
                while (!fin)
                {
                    diccHuffman.Add(raizTemp.letra.letras,raizTemp.letra.binario);            //Annade la Letra con su valor binario a la lista diccHuffman
                    if (raizTemp.primoIzq != null)
                    {
                        raizTemp = raizTemp.primoIzq;
                    }
                    else
                    {
                        fin = true;
                    }
                }
            }

            return diccHuffman;
        }
    }
}

