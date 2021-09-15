using System;
using System.Collections.Generic;
using Cadastro.Series.Interfaces;

namespace Cadastro.Series
{
    public class SeriesRepositorio : Cadastro.Series.Interfaces.InterfaceRepositorio<Series>
    {
        private System.Collections.Generic.List<Series> listaSerie = new System.Collections.Generic.List<Series>();
    
        public void Atualizar(int id, Series objeto) {
            listaSerie[id] = objeto;
        }

        public void Excluir(int id) {
            listaSerie[id].Exclui();
        }

        public void Inserir(Series objeto) {
            listaSerie.Add(objeto);
        }

        public System.Collections.Generic.List<Series> Lista() {
            return listaSerie;
        }

        public int ProximoId() {
            return listaSerie.Count;
        }

        public Series RetornaPorId(int id) {
            return listaSerie[id];
        }
    }
}