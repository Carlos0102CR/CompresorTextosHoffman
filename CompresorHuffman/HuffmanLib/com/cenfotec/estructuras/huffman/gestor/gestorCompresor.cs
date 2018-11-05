using System;
using HuffmanLib.com.cenfotec.estructuras.huffman.compresor;

namespace HuffmanLib.com.cenfotec.estructuras.huffman.gestor
{
    public class gestorCompresor
    {
        private Compresor comp; 

        public gestorCompresor()
        {
            comp = new Compresor();
        }

        public string comprimir(string texto){
            return comp.comprimir(texto);
        }
    }
}
