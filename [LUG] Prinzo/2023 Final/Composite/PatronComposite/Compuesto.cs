﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PatronComposite
{
    class Compuesto<T> : IComponente<T>
    {
        readonly List<IComponente<T>> elementos;
        public T Nombre { get; set; }
        public Compuesto(T pNombre)
        {
            Nombre = pNombre;
            elementos = new List<IComponente<T>>();
        }

        public void Adiciona(IComponente<T> pElemento) => elementos.Add(pElemento);

        public IComponente<T> Borra(T pElemento)
        {
            IComponente<T> elemento = this.Busca(pElemento);
            if (elemento != null)
            {
                (this as Compuesto<T>).elementos.Remove(elemento);
            }
            return this;
        }

        public IComponente<T> Busca(T pElemento)
        {
            if (Nombre.Equals(pElemento)) { return this; }
            IComponente<T> encontrado = null;
            foreach (IComponente<T> elemento in elementos)
            {
                encontrado = elemento.Busca(pElemento);
                if (encontrado != null) { break; }
            }
            return encontrado;
        }

        public string Muestra(int pProfundidad)
        {
            StringBuilder infoElemento = new StringBuilder(new String('-', pProfundidad));
            infoElemento.Append("Compuesto: " + Nombre + " elementos: " + elementos.Count + "\r\n");

            foreach (IComponente<T> elemento in elementos)
            {
                infoElemento.Append(elemento.Muestra(pProfundidad + 1));
            }

            return infoElemento.ToString();
        }
    }

}
