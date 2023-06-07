
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Respuesta;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.EntityFrameworkCore;
using Datos.ModelosDBSIAC.Entities;
using Datos.ModelosDBSIAC.DTO;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Negocio
{
    public class PerfilNegocio
    {
        public AppSIACDbContext ctx = new AppSIACDbContext();

        public TipoAccion Respuesta { get; set; }


        public async Task<TipoAccion> Get(int? id, int pageSize, int pageNumber)
        {
            try
            {
                List<CatSede> lista = new List<CatSede>();


                if (pageSize == 0)
                    throw new Exception("El parámetro pageSize debe ser mayor a cero");

                var resultados = await ctx.Perfils.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"Perfil"}, @Id = { null }, @PageSize = {pageSize}, @PageNumber = {pageNumber}").ToListAsync();



                //foreach (var perfil in resultados)
                //{
                    
                    
                //    perfil.PerfilVista = await this.GetPerfilVista(perfil.Id);


                //}




                    Respuesta = TipoAccion.Positiva(resultados);
            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }


        public async Task<TipoAccion> Insertar(PerfilDTO entidad)
        {
            try
            {
                var parametroId = new SqlParameter("@idRespuesta", SqlDbType.Int);
                parametroId.Direction = ParameterDirection.Output;

                var parametroExito = new SqlParameter("@exito", SqlDbType.Int);
                parametroExito.Direction = ParameterDirection.Output;

                var parametroMensaje = new SqlParameter("@mensaje", SqlDbType.NVarChar, -1);
                parametroMensaje.Direction = ParameterDirection.Output;


                await ctx.Database.ExecuteSqlInterpolatedAsync($@"EXEC sp_Perfil_Actualiza
                                    @TipoActualiza = {"I"},
                                    @Entidad = {JsonSerializer.Serialize(entidad)}, 
                                    @idRespuesta = {parametroId} OUTPUT, @exito = {parametroExito} OUTPUT,  @mensaje = {parametroMensaje} OUTPUT");


                Respuesta = new TipoAccion();
                Respuesta.id = (int)parametroId.Value;
                Respuesta.Exito = (int)parametroExito.Value == 1 ? true : false;
                Respuesta.Mensaje = (string)parametroMensaje.Value;


            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;

        }


        public async Task<TipoAccion> GetPerfilVista(int idPerfil)
        {
            try
            {
                List<CatSede> lista = new List<CatSede>();


                var resultados = await ctx.Perfils.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"PerfilVista"}, @Id = {idPerfil}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();
                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }

        public async Task<TipoAccion> PerfilVistaTipoAcceso(int idPerfilVista)
        {
            try
            {
                List<CatSede> lista = new List<CatSede>();


                var resultados = await ctx.Perfils.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"PerfilVistaTipoAcceso"}, @Id = {idPerfilVista}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();
                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }

        public async Task<TipoAccion> PerfilCampus(int idPerfil)
        {
            try
            {
                List<CatSede> lista = new List<CatSede>();


                var resultados = await ctx.Perfils.FromSqlInterpolated($@"EXEC sp_Perfil_Select @TipoConsulta = {"PerfilCampus"}, @Id = {idPerfil}, @PageSize = {null}, @PageNumber = {null}").ToListAsync();
                Respuesta = TipoAccion.Positiva(resultados);

            }
            catch (Exception ex)
            {
                Respuesta = TipoAccion.Negativa(ex.Message);
            }

            return Respuesta;
        }



    }
}
