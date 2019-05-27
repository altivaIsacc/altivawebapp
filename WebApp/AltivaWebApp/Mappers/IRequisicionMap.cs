﻿using AltivaWebApp.Domains;
using AltivaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IRequisicionMap
    {
        TbPrRequisicion Create(RequisicionViewModel viewModel);
        TbPrRequisicion Update(RequisicionViewModel viewModel);
        void SaveRD(RequisicionViewModel viewModel);
        void UpdateRD(IList<RequisicionDetalleViewModel> viewModel);
        RequisicionViewModel DomainToViewModel(TbPrRequisicion domain);
    }
}
