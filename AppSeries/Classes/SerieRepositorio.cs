using System.Collections.Generic;
using AppSeries.Interfaces;

namespace AppSeries
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private static SerieRepositorio instance;
        private List<Serie> listaSerie = new List<Serie>();
        private SerieRepositorio(){}
        public static SerieRepositorio GetInstance(){
            if(instance == null) instance = new SerieRepositorio();
            return instance;
        }
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}