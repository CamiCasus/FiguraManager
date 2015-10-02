using System;
using System.Collections.Generic;
using System.Data.Entity;
using DataBase.Generator.Core;
using DataBase.Generator.Modulos;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.Enums;
using Infrastructure.Data.Core.Context;

namespace DataBase.Generator
{
    public class DbContextDropCreateDatabaseAlwaysDevelopment<T> : DropCreateDatabaseAlways<T> where T : DbContextBase
    {
        private Rol _rolAdmin;

        protected override void Seed(T context)
        {
            AgregarRegistrosTabla(context);

            var roles = AgregarRegistrosRol(context);
            _rolAdmin = roles[0];

            AgregarRegistrosUsuario(context);
            AgregarRegistrosModulo(context);
        }

        private void AgregarRegistrosTabla(DbContext context)
        {
            const int activo = (int)TipoEstado.Activo;
            const int inactivo = (int)TipoEstado.Inactivo;

            var listaTablas = new List<Tabla>
            {
                #region TipoTabla.Idioma
                new Tabla
                {
                    Id = (int)TipoTabla.Idioma,
                    Nombre = "Idioma",
                    Descripcion = string.Empty,
                    Estado = inactivo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "es-PE",
                            Descripcion = "Español",
                            Estado = activo,
                            Valor = "1"
                        }
                    }
                },
                #endregion
                #region TipoTabla.TipoEstado
                new Tabla
                {
                    Id = (int)TipoTabla.TipoEstado,
                    Nombre = "Estado",
                    Descripcion = string.Empty,
                    Estado = inactivo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "INACTIVO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = ((int)TipoEstado.Inactivo).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "ACTIVO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = ((int)TipoEstado.Activo).ToString()
                        }
                    }
                },
                #endregion
                #region TipoTabla.TipoPermiso
                new Tabla
                {
                    Id = (int)TipoTabla.TipoPermiso,
                    Nombre = "Permiso",
                    Descripcion = string.Empty,
                    Estado = inactivo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "Mostrar",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = ((int)TipoPermiso.Mostrar).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "Crear",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = ((int)TipoPermiso.Crear).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "Editar",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = ((int)TipoPermiso.Editar).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "Eliminar",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = ((int)TipoPermiso.Eliminar).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "Imprimir",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = ((int)TipoPermiso.Imprimir).ToString()
                        }
                    }
                },
                #endregion
                #region TipoTabla.Moneda
                new Tabla
                {
                    Id = (int)TipoTabla.Moneda,
                    Nombre = "Moneda",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "NUEVO SOL",
                            Descripcion = "S/.",
                            Estado = activo,
                            Valor = "1"
                        },
                        new ItemTabla
                        {
                            Nombre = "DÓLAR",
                            Descripcion = "$",
                            Estado = activo,
                            Valor = "2"
                        }
                    }
                },
                #endregion
                #region TipoTabla.Tienda
                new Tabla
                {
                    Id = (int)TipoTabla.Tienda,
                    Nombre = "Tienda",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "AMIAMI",
                            Descripcion = "",
                            Estado = activo,
                            Valor = "1"
                        },
                        new ItemTabla
                        {
                            Nombre = "SOLARIS JAPAN",
                            Descripcion = "",
                            Estado = activo,
                            Valor = "2"
                        },
                        new ItemTabla
                        {
                            Nombre = "MANDARAKE",
                            Descripcion = "",
                            Estado = activo,
                            Valor = "3"
                        },
                        new ItemTabla
                        {
                            Nombre = "NIPON YASSAN",
                            Descripcion = "",
                            Estado = activo,
                            Valor = "4"
                        }
                    }
                },
                #endregion
                #region TipoTabla.Escultor
                new Tabla
                {
                    Id = (int)TipoTabla.Escultor,
                    Nombre = "Escultor",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "Good Smile",
                            Descripcion = "",
                            Estado = activo,
                            Valor = "1"
                        },
                        new ItemTabla
                        {
                            Nombre = "Alter",
                            Descripcion = "",
                            Estado = activo,
                            Valor = "2"
                        }
                    }
                },
                #endregion
                #region TipoTabla.EstadoFigura
                new Tabla
                {
                    Id = (int)TipoTabla.EstadoFigura,
                    Nombre = "EstadoFigura",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "Nuevo",
                            Descripcion = "",
                            Estado = activo,
                            Valor = "1"
                        },
                        new ItemTabla
                        {
                            Nombre = "Pre-Owned",
                            Descripcion = "",
                            Estado = activo,
                            Valor = "2"
                        }
                    }
                },
                #endregion
                #region TipoTabla.EstadoPedido
                new Tabla
                {
                    Id = (int)TipoTabla.EstadoPedido,
                    Nombre = "EstadoPedido",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "In-Stock",
                            Descripcion = "",
                            Estado = activo,
                            Valor = ((int)TipoPedido.InStock).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "Pre-Orden",
                            Descripcion = "",
                            Estado = activo,
                            Valor = ((int)TipoPedido.PreOrden).ToString()
                        }
                    }
                },
                #endregion
            };

            context.Set<Tabla>().AddRange(listaTablas);
        }

        private List<Rol> AgregarRegistrosRol(DbContext context)
        {
            var roles = new List<Rol>
            {
                new Rol {Nombre = TipoRol.Administrador.ToString(), Estado = (int)TipoEstado.Activo},
                new Rol {Nombre = TipoRol.Cajero.ToString(), Estado = (int)TipoEstado.Activo},
                new Rol {Nombre = TipoRol.Gerencial.ToString(), Estado = (int)TipoEstado.Activo}
            };

            context.Set<Rol>().AddRange(roles);
            context.SaveChanges();

            RolesStorage.Roles.Add(TipoRol.Administrador, roles[0]);
            RolesStorage.Roles.Add(TipoRol.Cajero, roles[1]);
            RolesStorage.Roles.Add(TipoRol.Gerencial, roles[2]);

            return roles;
        }

        private void AgregarRegistrosModulo(DbContext context)
        {
            var modulos = new List<IModulo>
            {
                new SeguridadModulo()
            };

            foreach (var modulo in modulos)
            {
                modulo.Registrar(context);
            }
        }

        private void AgregarRegistrosUsuario(DbContext context)
        {
            var usuario = new Usuario
            {
                UserName = "elazaro",
                Password = "Hrf2pNsy4Q6PuxOVnKYucQ==",
                Email = "ederlazaro@outlook.com",
                Estado = (int)TipoEstado.Activo,
                RolUsuarioList = new[]
                {
                    new RolUsuario {Rol = _rolAdmin, Estado = (int)TipoEstado.Activo}
                },
                UsuarioCreacion = "Admin",
                UsuarioModificacion = "Admin",
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            };

            context.Set<Usuario>().Add(usuario);

            usuario = new Usuario
            {
                UserName = "kvalverde",
                Password = "bR4EMpKQRepw7Wa/W4TFlQ==",
                Email = "txnwebmaster1@gmail.com",
                Estado = (int)TipoEstado.Activo,
                RolUsuarioList = new[]
                {
                    new RolUsuario {Rol = _rolAdmin, Estado = (int)TipoEstado.Activo}
                },
                UsuarioCreacion = "Admin",
                UsuarioModificacion = "Admin",
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = DateTime.UtcNow
            };

            context.Set<Usuario>().Add(usuario);
        }
       
    }
}
