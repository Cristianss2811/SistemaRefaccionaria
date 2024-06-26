﻿using SistemaRefaccionaria.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        IBodegaRepositorio Bodega { get; }

        ICategoriaRepositorio Categoria { get; }

        IMarcaRepositorio Marca { get; }

        IProductoRepositorio Producto { get; }

        IPuestoRepositorio Puesto { get; }

        IDepartamentoRepositorio Departamento { get; }

        IEmpleadoRepositorio Empleado { get; }

        Task Guardar();
    }
}
