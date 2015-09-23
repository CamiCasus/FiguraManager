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
                #region TipoTabla.Empresa
                new Tabla
                {
                    Id = (int)TipoTabla.Empresa,
                    Nombre = "Empresa",
                    Descripcion = string.Empty,
                    Estado = inactivo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "1",
                            Descripcion = "S/.",
                            Estado = activo,
                            Valor = ((int)AtributoEmpresa.MonedaId).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "7700",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = ((int)AtributoEmpresa.UITMax).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "0.01",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = ((int)AtributoEmpresa.ITF).ToString()
                        }
                    }
                },
                #endregion
                #region TipoTabla.TipoDocumentoPersona
                new Tabla
                {
                    Id = (int)TipoTabla.TipoDocumentoPersona,
                    Nombre = "Tipo de Documento",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "DNI",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "1"
                        },
                        new ItemTabla
                        {
                            Nombre = "RUC",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "2"
                        },
                    }
                },
                #endregion
                #region TipoTabla.TipoDocumentoSerie
                new Tabla
                {
                    Id = (int)TipoTabla.TipoDocumentoSerie,
                    Nombre = "Tipo Documento de Serie",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "FACTURA",
                            Descripcion = "FAC",
                            Estado = activo,
                            Valor = ((int)TipoDocumentoSerie.Factura).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "BOLETA",
                            Descripcion = "BOL",
                            Estado = activo,
                            Valor = ((int)TipoDocumentoSerie.Boleta).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "PAGO REMESA",
                            Descripcion = "PAG",
                            Estado = activo,
                            Valor = ((int)TipoDocumentoSerie.PagoRemesa).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "INGRESO",
                            Descripcion = "ING",
                            Estado = activo,
                            Valor = ((int)TipoDocumentoSerie.Ingreso).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "EGRESO",
                            Descripcion = "SAL",
                            Estado = activo,
                            Valor = ((int)TipoDocumentoSerie.Egreso).ToString()
                        },
                        new ItemTabla
                        {
                            Nombre = "DEVOLUCIÓN",
                            Descripcion = "DEV",
                            Estado = activo,
                            Valor = ((int)TipoDocumentoSerie.DevolucionRemesa).ToString()
                        }
                    }
                },
                #endregion
                #region TipoTabla.TipoRemesa
                new Tabla
                {
                    Id = (int)TipoTabla.TipoRemesa,
                    Nombre = "Tipo de Remesa",
                    Descripcion = string.Empty,
                    Estado = inactivo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "GIRO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "1"
                        },
                        new ItemTabla
                        {
                            Nombre = "TRANSFERENCIA",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "2"
                        }
                    }
                },
                #endregion
                #region TipoTabla.EntidadFinanciera
                new Tabla
                {
                    Id = (int)TipoTabla.EntidadFinanciera,
                    Nombre = "Entidad Financiera",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "BANCO AZTECA",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "01"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO CITIBANK DEL PERU",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "02"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO CONTINENTAL",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "03"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO DE CREDITO DEL PERU",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "04"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO DE LA NACION",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "05"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO DEL TRABAJO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "06"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO FALABELLA SA",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "07"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO FINANCIERO DEL PERU",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "08"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO INTERBANK",
                            Descripcion = "(BANCO INTERNACIONAL DEL PERU)",
                            Estado = activo,
                            Valor = "09"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO RIPLEY",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "10"
                        },
                        new ItemTabla
                        {
                            Nombre = "BANCO SCOTIABANK PERU SA",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "11"
                        },
                        new ItemTabla
                        {
                            Nombre = "MI BANCO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "12"
                        },
                        new ItemTabla
                        {
                            Nombre = "FINANCIERA CREDISCOTIA",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "13"
                        },
                        new ItemTabla
                        {
                            Nombre = "CAJA TRUJILLO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "14"
                        },
                        new ItemTabla
                        {
                            Nombre = "CAJA NUESTRA GENTE",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "15"
                        },
                        new ItemTabla
                        {
                            Nombre = "CAJA SULLANA",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "16"
                        },
                        new ItemTabla
                        {
                            Nombre = "COOP LEON XIII",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "17"
                        },
                        new ItemTabla
                        {
                            Nombre = "COOP NUESTRA SEÑORA DEL ROSARIO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "18"
                        },
                    }
                },
                #endregion
                #region TipoTabla.EstadoDocumento
                new Tabla
                {
                    Id = (int)TipoTabla.EstadoDocumento,
                    Nombre = "Estado de Documento",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "EMITIDO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "1"
                        },
                        new ItemTabla
                        {
                            Nombre = "PAGADO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "2"
                        },
                        new ItemTabla
                        {
                            Nombre = "DEVUELTO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "3"
                        },
                        new ItemTabla
                        {
                            Nombre = "ANULADO",
                            Descripcion = string.Empty,
                            Estado = activo,
                            Valor = "4"
                        }
                    }
                },
                #endregion
                #region TipoTabla.OperadorTelefonico
                new Tabla
                {
                    Id = (int)TipoTabla.OperadorTelefonico,
                    Nombre = "Operador Telefónico",
                    Descripcion = string.Empty,
                    Estado = activo,
                    ItemTabla = new List<ItemTabla>
                    {
                        new ItemTabla
                        {
                            Nombre = "MOVISTAR",
                            Descripcion = "‎",
                            Estado = activo,
                            Valor = "1"
                        },
                        new ItemTabla
                        {
                            Nombre = "CLARO",
                            Descripcion = "‎",
                            Estado = activo,
                            Valor = "2"
                        },
                        new ItemTabla
                        {
                            Nombre = "ENTEL",
                            Descripcion = "‎",
                            Estado = activo,
                            Valor = "3"
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
