using System;
using HuffmanLib.com.cenfotec.estructuras.huffman.letra;

namespace HuffmanLib.com.cenfotec.estructuras.huffman.nodo
{
    public class Nodo
    {
        public Letra letra { get; set; }
        public Nodo primoIzq { get; set; }
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

        public void setCodigoHuff(string binario)
        {
            this.letra.binario = binario;
            if (derecho!=null){
                derecho.setCodigoHuff(binario+"1");
            }
            if(izquierdo!=null){
                izquierdo.setCodigoHuff(binario + "0");
            }
        }

        public Nodo getUltimoDerecho(){
            if(derecho!=null){
                return derecho.getUltimoDerecho();
            }
            return this;
        }

        public void setPrimoIzq(Nodo primoIzq){
            Nodo hijoDer = this;
            if(derecho!=null){
                derecho.setPrimoIzq(primoIzq);
            }else if(primoIzq != null)
            {
                this.primoIzq.setPrimoIzq(primoIzq);
            }else{
                this.primoIzq = primoIzq;
            }
        }

    }
}
