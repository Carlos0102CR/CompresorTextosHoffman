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

        public string comprimir(string texto){
            List<Letra> diccFrecuencia;
            List<Letra> diccHuffman;
            List<string> listaCarctrs = new List<string>();
            List<int> listaFrecs = new List<int>();

            foreach (char carctr in texto)
            {
                if (listaCarctrs.Contains(carctr+""))
                {
                    listaFrecs[listaCarctrs.IndexOf(carctr + "")]++;
                }
                else
                {
                    listaCarctrs.Add(carctr + "");
                    listaFrecs.Add(1);
                }
            }
            diccFrecuencia = ordenarListas(listaCarctrs, listaFrecs);

            diccHuffman = arbol.generarDiccionario(diccFrecuencia);



            return convertirTexto(diccHuffman,texto);
        }

        private string convertirTexto(List<Letra> diccHuffman, string texto)
        {
            throw new NotImplementedException();
        }

        private List<Letra> ordenarListas(List<string> listaCarctrs, List<int> listaFrecs)
        {
            string caracter;
            int frecuencia;
            List<Letra> diccFrecuencia = new List<Letra>();
            List<string> listaCarOrd = new List<string>();
            List<int> listaFrecsOrd = new List<int>();

            for (int i = 0; i < listaCarctrs.Count;i++)
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
