﻿using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IInventarioRepository
    {
        TbPrInventario GetInventarioById(int id);
        TbPrInventario GetInventarioByCodigo(string codigo);
        IList<TbPrImagenInventario> GetInventarioImagenByCodigo(int id);
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
        IList<TbPrInventarioCaracteristica> GetInventarioCaracteristicaByCodigo(int id);
        bool DeleteCaracteristica(int id);
        bool DeleteImagen(int id);
    }
}
