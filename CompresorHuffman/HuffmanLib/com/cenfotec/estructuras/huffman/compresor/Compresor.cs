using System.Linq;
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
            List<Letra> listaFrecuencia;
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
            listaFrecuencia = ordenarListas(listaCarctrs, listaFrecs);//ordena las listas de frecuencia en orden ascendente y devuelve una lista de Letras

            diccHuffman = arbol.generarDiccionario(listaFrecuencia);//envia al arbol la lista de frecuencias y devuelve un diccionario con los valores en bits de cada caracter



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

        private List<Letra> ordenarListas(List<string> listaCarctrs, List<int> listaFrecs)//retorna una secuencia ordenada
        {
            List<Letra> listaFrecOrd = new List<Letra>();
            var diccionario = new Dictionary<string, int>();

            for (int i = 0; i < listaCarctrs.Count; i++) diccionario.Add(listaCarctrs[i], listaFrecs[i]);//itera sobre las listas para ordenarlas
           
            var diccFrecuencias = from par in diccionario
                        orderby par.Value ascending
                        select par;

            foreach(var temp in diccFrecuencias)listaFrecOrd.Add(new Letra(temp.Key,temp.Value));

            return listaFrecOrd;
        }
    }
}
