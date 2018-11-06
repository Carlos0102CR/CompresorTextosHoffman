using System.Collections.Generic;
using HuffmanLib.com.cenfotec.estructuras.huffman.letra;
using HuffmanLib.com.cenfotec.estructuras.huffman.nodo;
using System.Linq;

namespace HuffmanLib.com.cenfotec.estructuras.huffman.arbol
{
    public class Arbol
    {
        private List<Nodo> nodos = new List<Nodo>();
        private Nodo raiz { get; set; }
        List<Letra> frecuencias;

        public Arbol()
        {
            raiz = null;
        }

        public void setFrecuencias(List<Letra> listaFrecuencias)
        {
            frecuencias = listaFrecuencias;
            construir();
        }
        private void construir()
        {

            foreach (Letra letra in frecuencias)
            {
                nodos.Add(new Nodo(letra));
            }

            while (nodos.Count > 1)
            {
                List<Nodo> nodosOrdenados = nodos.OrderBy(nodo => nodo.letra.frecuencia).ToList<Nodo>();

                if (nodosOrdenados.Count >= 2)
                {
                    // toma primero 2 nodos
                    List<Nodo> par = nodosOrdenados.Take(2).ToList<Nodo>();

                    // Crea un padre de los nodos tomada sumando sus letras y frecuencias
                    Nodo parent = new Nodo()
                    {
                        letra = new Letra(par[0].letra.letras + par[1].letra.letras, par[0].letra.frecuencia + par[1].letra.frecuencia),
                        izquierdo = par[0],
                        derecho = par[1]
                    };

                    nodos.Remove(par[0]);
                    nodos.Remove(par[1]);
                    nodos.Add(parent);
                }

                this.raiz = nodos.FirstOrDefault();

            }
        }

        public Dictionary<string, string> generarDiccionario()
        {
            List<Letra> test = new List<Letra>();
            List<Letra> lista =  raiz.setCodigoHuff("", test);
            Dictionary<string, string> diccHuffman = new Dictionary<string, string>();

            foreach (Letra letra in lista) diccHuffman.Add(letra.letras, letra.binario);

            return diccHuffman;
        }
    }
}

