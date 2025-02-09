﻿using AutoMapper;
using Fundamentos.IS4.Loja.Domain.Models;

namespace Fundamentos.IS4.Loja.Data.Mappers
{
    internal static class PedidoMapper
    {
        internal static IMapper Mapper { get; }

        static PedidoMapper()
        {
            Mapper = new MapperConfiguration(m => m.AddProfile<PedidoMapperProfile>()).CreateMapper();
        }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Pedido ToModel(this Entities.Pedido entity)
        {
            return Mapper.Map<Pedido>(entity);
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Entities.Pedido ToEntity(this Pedido model)
        {
            return Mapper.Map<Entities.Pedido>(model);
        }

    }
}