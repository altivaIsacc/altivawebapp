﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class RequisicionService : IRequisicionService
    {
        private readonly IRequisicionRepository repository;

        public RequisicionService(IRequisicionRepository repository)
        {
            this.repository = repository;
        }

        public IList<TbPrRequisicion> GetAllWithDetails()
        {
            return repository.GetAllWithDetails();
        }
        public bool DeleteRD(IList<TbPrRequisicionDetalle> domain)
        {
            return repository.DeleteRD(domain);
        }

        public IList<TbPrRequisicionDetalle> GetAllRDByRequisicionId(int id)
        {
            return repository.GetAllRDByRequisicionId(id);
        }

        public TbPrRequisicion GetReqById(int id)
        {
            return repository.GetReqById(id);
        }

        public TbPrRequisicion Save(TbPrRequisicion domain)
        {
            return repository.Save(domain);
        }

        public void SaveRD(IList<TbPrRequisicionDetalle> domain)
        {
            repository.SaveRD(domain);
        }

        public TbPrRequisicion Update(TbPrRequisicion domain)
        {
            return repository.Update(domain);
        }

        public void UpdateRD(IList<TbPrRequisicionDetalle> domain)
        {
            repository.UpdateRD(domain);
        }

        public IList<TbPrRequisicionDetalle> GetAllReqDetalleById(IList<int> domain)
        {
            return repository.GetAllReqDetalleById(domain);
        }
    }
}
