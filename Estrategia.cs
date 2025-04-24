
using System;
using System.Collections.Generic;
using System.Text;
using tp1;
using tp2;

namespace tpfinal
{

	class Estrategia
	{

		public string Consulta1(ArbolBinario<DecisionData> arbol)
		{
            if (arbol == null) 
			{
                return "Árbol vacío.";
            }
            string predicciones = "";
            List<string> resultado= new List<string>();
            ObtenerPredicciones(arbol,resultado);
            for (var i = 0; i < resultado.Count; i++)
            {
                predicciones +=  resultado[i] + "\n";
            }
            return predicciones;
        }

        // Funcion para obener las predicciones
		private void ObtenerPredicciones(ArbolBinario<DecisionData> arbol , List<string> resultado)
		{
			
			if (arbol == null)
            {
                return;
            }

            if (arbol.esHoja())
			{
                // El nodo hoja contiene las predicciones 

                resultado.Add(arbol.getDatoRaiz().ToString());	
			}
			else
			{
				// Seguir recorriendo los nodos hijos

				ObtenerPredicciones(arbol.getHijoIzquierdo(),resultado);
                ObtenerPredicciones(arbol.getHijoDerecho(), resultado);
                
            }
            
        }

        public String Consulta2(ArbolBinario<DecisionData> arbol)
		{

            if (arbol == null)
            {
                return "Árbol vacío.";
            }
            string camino_predicciones = "";
            List<string> camino = new List<string>();
            caminoPredicciones(arbol, camino);
            for (var i = 0; i < camino.Count; i++)
            {
                camino_predicciones += camino[i] + "\n";
            }
            return camino_predicciones;

        }

        // Funcion para obtener el camino completo hasta las predicciones
        public void caminoPredicciones(ArbolBinario<DecisionData> arbol, List<string> camino)
        {

            if (arbol == null)
            {
                return;
            }

            camino.Add(arbol.getDatoRaiz().ToString());

            if (arbol.esHoja())
            {
                // E nodo hoja contiene las predicciones 
                camino.Add(arbol.getDatoRaiz().ToString());
            }
            else
            {
                // Seguir recorriendo los nodos hijos
                ObtenerPredicciones(arbol.getHijoIzquierdo(), camino);
                camino.Add(arbol.getDatoRaiz().ToString());
                ObtenerPredicciones(arbol.getHijoDerecho(), camino);
                camino.Add(arbol.getDatoRaiz().ToString());
            }

        }

		public String Consulta3(ArbolBinario<DecisionData> arbol)
		{
            List<string> resultado = ObtenerNivel(arbol);
            string niveles = "";
            if (arbol == null)
            {
                return "Árbol vacío.";
            }
            for (int i = 0; i < resultado.Count(); i++)
            {
                niveles += resultado[i] + "\n";
            }
            return niveles;
        }

        //Funcion para obtener una lista con los strings separados por niveles
        public List<string> ObtenerNivel( ArbolBinario<DecisionData>arbol)
        {
            // Creo una lista para almacenar los string
            List<string> resultado = new List<string>();

            // Creo una cola que almacena el nodo y el numero de nivel
            Cola<(ArbolBinario<DecisionData> nodo, int nivel)> cola = new Cola<(ArbolBinario<DecisionData>, int)>();
            cola.encolar((arbol, 0));
            int nivelActual = -1;
            string lineaNivel = "";
            while (cola.cantidadElementos() > 0)
            {
                // Desencolo el nodo actual y el numero de nivel
                var (nodo, nivel) = cola.desencolar();
                if (nivel != nivelActual)
                {
                    if (nivelActual != -1)
                    {
                        // Si nivel actual es distinto a -1 agrego el nivel actual y el valor de la linea del nivel
                        resultado.Add("Nivel "+ nivelActual + lineaNivel);
                    }
                    nivelActual = nivel;
                    lineaNivel = "";
                }
                lineaNivel += nodo.getDatoRaiz().ToString() + ", ";
                if (nodo.getHijoIzquierdo() != null)
                {
                    cola.encolar((nodo.getHijoIzquierdo(), nivel + 1));
                }
                if (nodo.getHijoDerecho() != null)
                {
                    cola.encolar((nodo.getHijoDerecho(), nivel + 1));
                }
            }
            // Agrego la última línea       
            
            resultado.Add("Nivel " + nivelActual + lineaNivel);
            return resultado;
        }

		public ArbolBinario<DecisionData> CrearArbol(Clasificador clasificador)
		{

            if (clasificador == null)
            {
                return null;
            }
            if (clasificador.crearHoja())
            {
                // Crear un nodo hoja con los datos obtenidos del clasificador           

                return new ArbolBinario<DecisionData>(new DecisionData(clasificador.obtenerDatoHoja()));
            }

            // Crear un nodo de decisión con la pregunta obtenida del clasificador   
			    
            ArbolBinario<DecisionData> arbol = new ArbolBinario<DecisionData>(new DecisionData(clasificador.obtenerPregunta()));

            // Construir recursivamente las ramas izquierda y derecha 
			      
            arbol.agregarHijoIzquierdo(CrearArbol(clasificador.obtenerClasificadorIzquierdo()));
            arbol.agregarHijoDerecho(CrearArbol(clasificador.obtenerClasificadorDerecho()));

            return arbol;

        }
    }
}