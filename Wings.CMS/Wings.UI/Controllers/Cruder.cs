﻿using Wings.Core.Model;
using Wings.Core.Service;
using Wings.UI.Dto;
using Wings.UI.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wings.UI.Controllers
{
    /// <summary>
    /// generic crud controller for entities where there is no difference between the edit and create view
    /// </summary>
    /// <typeparam name="TEntity">the entity</typeparam>
    /// <typeparam name="TInput"> viewmodel </typeparam>
    public abstract class Cruder<TEntity, TInput> : Crudere<TEntity, TInput, TInput>
        where TInput : Input, new()
        where TEntity : DelEntity, new()
    {
        public Cruder(ICrudService<TEntity> service, IMapper<TEntity, TInput> v)
            : base(service, v, v)
        {
        }

        protected override string EditView
        {
            get { return "create"; }
        }
    }
}