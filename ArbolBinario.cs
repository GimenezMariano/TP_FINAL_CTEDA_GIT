using System;
using tp1;

namespace tp2
{
	public class ArbolBinario<T>
	{
		
		private T dato;
		private ArbolBinario<T> hijoIzquierdo;
		private ArbolBinario<T> hijoDerecho;
	
		
		public ArbolBinario(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public ArbolBinario<T> getHijoIzquierdo() {
			return this.hijoIzquierdo;
		}
	
		public ArbolBinario<T> getHijoDerecho() {
			return this.hijoDerecho;
		}
	
		public void agregarHijoIzquierdo(ArbolBinario<T> hijo) {
			this.hijoIzquierdo=hijo;
		}
	
		public void agregarHijoDerecho(ArbolBinario<T> hijo) {
			this.hijoDerecho=hijo;
		}
	
		public void eliminarHijoIzquierdo() {
			this.hijoIzquierdo=null;
		}
	
		public void eliminarHijoDerecho() {
			this.hijoDerecho=null;
		}
	
		public bool esHoja() {
			return this.hijoIzquierdo==null && this.hijoDerecho==null;
		}
		
		public void inorden() 
        {
            //hijo izquierdo recursivamente

            if (this.hijoIzquierdo != null)
            {
                this.hijoIzquierdo.inorden();
            }
            //raiz (dato)

            Console.Write(dato + " ");

            //hijo derecho recursivamente

            if (this.hijoDerecho != null)
            {
                this.hijoDerecho.inorden();
            }
        }
		
		public void preorden() 
		{
            //raiz (dato)

            Console.Write(dato + " ");

            //hijo izquierdo recursivamente

            if (this.hijoIzquierdo != null)
            {
                this.hijoIzquierdo.preorden();
            }

            //hijo derecho recursivamente

            if (this.hijoDerecho != null)
            {
                this.hijoDerecho.preorden();
            }
        }
		
		public void postorden() 
		{
            //hijo izquierdo recursivamente

            if (this.hijoIzquierdo != null)
            {
                this.hijoIzquierdo.postorden();
            }

            //hijo derecho recursivamente

            if (this.hijoDerecho != null)
            {
                this.hijoDerecho.postorden();
            }
            //imprimir raiz (dato)

            Console.Write(dato + " ");
        }
		
		public void recorridoPorNiveles() 
		{
            Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
            ArbolBinario<T> aux;
            c.encolar(this);

            while (!c.esVacia())
            {
                aux = c.desencolar();
                Console.Write(aux.dato + " ");
                if (aux.hijoIzquierdo != null)
                {
                    c.encolar(aux.hijoIzquierdo);
                }
                if (aux.hijoDerecho != null)
                {
                    c.encolar(aux.hijoDerecho);
                }
            }
        }
	
		public int contarHojas() 
		{
            int cont = 0;
            List<int> cantidad = new List<int>();
            Cola<ArbolBinario<T>> c = new Cola<ArbolBinario<T>>();
            ArbolBinario<T> aux;
            c.encolar(this);

            while (!c.esVacia())
            {
                aux = c.desencolar();
                if (aux.esHoja())
                {
                    cont += 1;
                }
                if (aux.hijoIzquierdo != null)
                {
                    c.encolar(aux.hijoIzquierdo);
                }

                if (aux.hijoDerecho != null)
                {
                    c.encolar(aux.hijoDerecho);
                }

            }

            return cont;
        }
		
		public void recorridoEntreNiveles(int n,int m) {
		}
	}
}
