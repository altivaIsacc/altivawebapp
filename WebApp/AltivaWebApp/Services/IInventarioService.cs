using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IInventarioService
    {
        IList<ListarInventarioViewModel> GetListarInventario(int valor, int tipo, bool estado, int bodega, bool clave);
        TbPrInventarioBodega UpdateIBodega(TbPrInventarioBodega domain);
        IList<TbPrInventario> GetAllByCoincidence(string word);
        IList<TbPrInventario> GetInventarioFacturable();
        TbPrInventario GetInventarioById(int id);
        TbPrInventarioBodega GetInventarioBodegaById(int id);
        IList<TbPrImagenInventario> GetInventarioImagenById(int id);
        TbPrInventario GetInventarioByCodigo(string codigo);
        long? ExisteInventarioCodigo(string codigo);
        TbPrInventario Save(TbPrInventario domain);
        TbPrInventario Update(TbPrInventario domain);
        bool Delete(TbPrInventario domain);
        IList<TbPrInventario> GetAll();
        IList<TbPrInventario> GetAllInventario();
        void SaveInventarioBodega(IList<TbPrInventarioBodega> domain);
        void SaveImagenInventario(IList<TbPrImagenInventario> domain);
        IList<TbPrInventarioBodega> GetAllBodegasPorInventario(int id);
        bool EliminarInventarioBodega(int id);
        bool SaveEquivalencia(TbPrEquivalencia domain);
        bool DeleteEquivalencia(int id);
        IList<TbPrEquivalencia> GetEquivalenciasPorInventario(int idInventario);
        bool ExisteEquivalencia(TbPrEquivalencia domain);
        void SaveCaracteristicaInventario(TbPrInventarioCaracteristica domain);
        IList<TbPrInventarioCaracteristica> GetInventarioCaracteristicaById(int id);
        bool DeleteCaracteristica(int id);
        bool DeleteImagen(int id);
        void CrearRelacionInventarioBodega(int idInventario, int idBodega);
        bool ExisteCaracteristica(long idInventario, string caracteristica);

    }
}
