﻿using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class InventarioService: IInventarioService
    {
        readonly IInventarioRepository repository;
        public InventarioService(IInventarioRepository repository)
        {
            this.repository = repository;
        }

        public TbPrInventario GetInventarioById(int id)
        {
            return repository.GetInventarioById(id);
        }
        public TbPrInventario GetInventarioByCodigo(string codigo)
        {
            return repository.GetInventarioByCodigo(codigo);
        }

        public IList<TbPrInventarioBodega> GetAllBodegasPorInventario(int id)
        {
            return repository.GetAllBodegasPorInventario(id);
        }

        public TbPrInventario Save(TbPrInventario domain)
        {
            return repository.Save(domain);
        }
        public TbPrInventario Update(TbPrInventario domain)
        {
            return repository.Update(domain);
        }
        public bool Delete(TbPrInventario domain)
        {
            return repository.Delete(domain);
        }
        public IList<TbPrInventario> GetAll()
        {
            return repository.GetAll();
        }
        public IList<TbPrInventario> GetAllInventario()
        {
            return repository.GetAllInventario();
        }

        public void SaveInventarioBodega(IList<TbPrInventarioBodega> domain)
        {
            repository.SaveInventarioBodega(domain);
        }

        public void CrearRelacionInventarioBodega(int idInventario, int idBodega)
        {
            repository.CrearRelacionInventarioBodega(idInventario, idBodega);
        }

        public bool EliminarInventarioBodega(int id)
        {
            return repository.EliminarInventarioBodega(id);
        }

        public bool SaveEquivalencia(TbPrEquivalencia domain)
        {
            return repository.SaveEquivalencia(domain);
        }
        public bool DeleteEquivalencia(int id)
        {
            return repository.DeleteEquivalencia(id);
        }

        public IList<TbPrEquivalencia> GetEquivalenciasPorInventario(int idInventario)
        {
            return repository.GetEquivalenciasPorInventario(idInventario);
        }

        public bool ExisteEquivalencia(TbPrEquivalencia domain)
        {
            return repository.ExisteEquivalencia(domain);
        }
    }
}
