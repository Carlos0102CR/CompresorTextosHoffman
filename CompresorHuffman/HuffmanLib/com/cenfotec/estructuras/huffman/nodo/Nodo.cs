using System;
using System.Collections.Generic;
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

        public List<Letra> setCodigoHuff(string binario,List<Letra> binarios)   //agrega el valor binario a la letra de este nodo y envia a sus hijos los suyos
        {
            this.letra.binario = binario;
            if (esHoja(this)) {
                binarios.Add(this.letra);
                return binarios;
            }else{

                if (derecho != null)
                {
                    List<Letra> caminoDer = new List<Letra>();
                    caminoDer.AddRange(binarios);

                    binarios = derecho.setCodigoHuff(binario + "1", caminoDer);

                }
                if (izquierdo != null)
                {
                    List<Letra> caminoIzq = new List<Letra>();
                    caminoIzq.AddRange(binarios);

                    binarios = izquierdo.setCodigoHuff(binario + "0", caminoIzq);
                }
                    return binarios;
            }
        }


        private bool esHoja(Nodo nodo)
        {
            if(nodo.izquierdo == null && nodo.derecho == null){
                return true;
            }else{
                return false;
            }
        }

    }
}
