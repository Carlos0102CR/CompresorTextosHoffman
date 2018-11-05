using System.Collections.Generic;
using HuffmanLib.com.cenfotec.estructuras.huffman.letra;
using HuffmanLib.com.cenfotec.estructuras.huffman.nodo;

namespace HuffmanLib.com.cenfotec.estructuras.huffman.arbol
{
    public class Arbol
    {
        public Nodo raiz { get; set; }

        public Arbol()
        {

            raiz = null;
        }

        public List<Letra> generarDiccionario(List<Letra> diccFrecuencia){
            Nodo auxIzq, raizTemp;
            raizTemp = new Nodo();
            string binario = "";
            List<Letra> diccBinario = new List<Letra>();

            foreach (Letra letraTemp in diccFrecuencia)     //Crea el Arbol
            {
                auxIzq = new Nodo(letraTemp);
                if (raiz == null) { raiz = auxIzq; }else{   //verifica si la raiz es null
                    raizTemp.derecho = raiz;
                    raizTemp.izquierdo = auxIzq;
                    raizTemp.setNodoPadre();                //hace que la letra dentro de la raiz temporal sea una suma de las letras que contienen sus hijos
                    raiz = raizTemp;                        //mueve la antigua raiz abajo de la nueva que es una suma de sus dos hijos
                }
            }

            foreach (Letra letraTemp in diccFrecuencia)     //Busca en el arbol los nuevos valores binarios de cada letra
            {

            }

            return diccBinario;
        }
    }
}

