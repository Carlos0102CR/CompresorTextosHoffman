using System;
using System.Collections.Generic;
using HuffmanLib.com.cenfotec.estructuras.huffman.arbol;
using HuffmanLib.com.cenfotec.estructuras.huffman.letra;

namespace HuffmanLib.com.cenfotec.estructuras.huffman.compresor
{
    public class Compresor
    {
        private Arbol arbol;

        public Compresor()
        {
            arbol = new Arbol();
        }

        public string comprimir(string texto)
        {
            List<Letra> diccFrecuencia;
            Dictionary<string, string> diccHuffman;
            List<string> listaCarctrs = new List<string>();
            List<int> listaFrecs = new List<int>();

            foreach (char carctr in texto)//se encarga de calcular la frecuencia de cada caracter en el texto y lo ingresa en dos listas
            {
                if (listaCarctrs.Contains(carctr + ""))
                {
                    listaFrecs[listaCarctrs.IndexOf(carctr + "")]++;
                }
                else
                {
                    listaCarctrs.Add(carctr + "");
                    listaFrecs.Add(1);
                }
            }
            diccFrecuencia = ordenarListas(listaCarctrs, listaFrecs);//ordena las listas de frecuencia en orden ascendente y devuelve una lista de Letras

            diccHuffman = arbol.generarDiccionario(diccFrecuencia);//envia al arbol la lista de frecuencias y devuelve un diccionario con los valores en bits de cada caracter



            return convertirTexto(diccHuffman, texto);
        }

        private string convertirTexto(Dictionary<string, string> diccHuffman, string texto)//convierte el texto en una serie de bits utilizando el diccionario proporcionado
        {
            string textoComp = "";
            foreach (char carctr in texto)//agrega el texto comprimido al string textoComp
            {
                textoComp += diccHuffman[carctr+""];
            }

            textoComp += "/";//divide el texto comprimido y el diccionario con /

            foreach (KeyValuePair<string,string> temp in diccHuffman)//agrega el diccionario al string textoComp
            {
                textoComp += temp.Key+":"+temp.Value+",";
            }

            return textoComp;//devuelve el texto comprimido junto con el diccionario usado para la compresion
        }

        private List<Letra> ordenarListas(List<string> listaCarctrs, List<int> listaFrecs)//ordena las listas
        {
            string caracter;
            int frecuencia;
            List<Letra> diccFrecuencia = new List<Letra>();
            List<string> listaCarOrd = new List<string>();
            List<int> listaFrecsOrd = new List<int>();

            for (int i = 0; i < listaCarctrs.Count; i++)//itera sobre las listas para ordenarlas
            {
                caracter = listaCarctrs[i];
                frecuencia = listaFrecs[i];
                if (!listaCarOrd.Contains(caracter))
                {
                    for (int j = 0; j < listaCarctrs.Count; j++)
                    {
                        if (!listaCarOrd.Contains(caracter))
                        {
                            if (frecuencia > listaFrecs[j])
                            {
                                caracter = listaCarctrs[j];
                                frecuencia = listaFrecs[j];
                            }
                        }
                    }
                    listaCarOrd.Add(caracter);
                    listaFrecsOrd.Add(frecuencia);
                }
            }
            for (int i = 0; i < listaCarctrs.Count; i++)
            {
                diccFrecuencia.Add(new Letra(listaCarOrd[i], listaFrecsOrd[i]));
            }

            return diccFrecuencia;
        }
    }
}
