using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IInventarioService
    {
        TbPrInventario GetInventarioById(int id);
        TbPrInventario GetInventarioByCodigo(string codigo);
        TbPrInventario Save(TbPrInventario domain);
        TbPrInventario Update(TbPrInventario domain);
        bool Delete(TbPrInventario domain);
        IList<TbPrInventario> GetAll();
        IList<TbPrInventario> GetAllInventario();
        void SaveInventarioBodega(IList<TbPrInventarioBodega> domain);
        IList<TbPrInventarioBodega> GetAllBodegasPorInventario(int id);
        bool EliminarInventarioBodega(int id);
        bool SaveEquivalencia(TbPrEquivalencia domain);
        bool DeleteEquivalencia(int id);
        IList<TbPrEquivalencia> GetEquivalenciasPorInventario(int idInventario);
        bool ExisteEquivalencia(TbPrEquivalencia domain);
        void CrearRelacionInventarioBodega(int idInventario, int idBodega);
    }
}
