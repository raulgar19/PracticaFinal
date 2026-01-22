using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using PracticaFinal.Helpers;
using PracticaFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PracticaFinal.Repositories
{
    #region PROCEDURES
    //    alter procedure SP_ALL_DEPARTAMENTOS
    //    as
    //	    select* from DEPT
    //    go

    //    create procedure SP_EMPLEADOS_DEPARTAMENTO
    //    (@nombre nvarchar(50))
    //    as
    //	      declare @id int
    //        select @id = DEPT_NO from DEPT where DNOMBRE = @nombre
    //        select * from EMP where DEPT_NO = @id
    //    go

    //    create procedure SP_INSERT_DEPARTAMENTO
    //    (@id int, @nombre nvarchar(50), @localidad nvarchar(50))
    //    as
    //	      insert into DEPT values(@id, @nombre, @localidad)
    //    go

    //    create procedure SP_UPDATE_EMPLEADO
    //    (@apellido nvarchar(50), @oficio nvarchar(50), @salario int)
    //    as
    //	      update EMP set APELLIDO = @apellido, OFICIO = @oficio, SALARIO = @salario where APELLIDO = @apellido
    //    go

    //    create procedure SP_DELETE_DEPARTAMENTO
    //    (@nombre nvarchar(50))
    //    as
    //	      declare @id int
    //        select @id = DEPT_NO from DEPT where DNOMBRE = @nombre
    //        delete from DEPT where DEPT_NO = @id
    //    go
    #endregion

    public class DepartamentosRepository
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public DepartamentosRepository()
        {
            IConfigurationRoot configuration = HelperConfiguration.GetConfiguration();

            this.cn = new SqlConnection(configuration.GetConnectionString("SqlLocal"));
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetDepartamentosAsync()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            List<string> departamentos = new List<string>();

            while (await this.reader.ReadAsync())
            {
                departamentos.Add(this.reader["DNOMBRE"].ToString());
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            
            return departamentos;
        }

        public async Task<List<Empleado>> GetEmpleadosDepartamentoAsync(string nombre)
        {
            string sql = "SP_EMPLEADOS_DEPARTAMENTO";
            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);

            this.com.CommandType= CommandType.StoredProcedure;
            this.com.CommandText = sql;
            this.com.Parameters.Add(pamNombre);

            await this.cn.OpenAsync();
            
            this.reader = await this.com.ExecuteReaderAsync();

            List<Empleado> empleados = new List<Empleado>();

            while(await this.reader.ReadAsync())
            {
                Empleado empleado = new Empleado();
                empleado.Apellido = this.reader["APELLIDO"].ToString();
                empleado.Oficio = this.reader["OFICIO"].ToString();
                empleado.Salario = int.Parse(this.reader["SALARIO"].ToString());

                empleados.Add(empleado);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return empleados;
        }

        public async Task<Departamento> GetDepartamentoByNombreAsync(string nombre)
        {
            string sql = "select * from DEPT where DNOMBRE = @nombre";
            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.com.Parameters.Add(pamNombre);

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();

            Departamento departamento = new Departamento();

            while (await this.reader.ReadAsync())
            {
                departamento.Id = int.Parse(this.reader["DEPT_NO"].ToString());
                departamento.Nombre = this.reader["DNOMBRE"].ToString();
                departamento.Localidad = this.reader["LOC"].ToString();
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return departamento;
        }

        public async Task<int> InsertDepartamentoAsync(int id, string nombre, string localidad)
        {
            string sql = "SP_INSERT_DEPARTAMENTO";
            SqlParameter pamId = new SqlParameter("@id", id);
            SqlParameter pamNombre = new SqlParameter("@nombre", nombre);
            SqlParameter pamLocalidad = new SqlParameter("@localidad", localidad);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            this.com.Parameters.Add(pamId);
            this.com.Parameters.Add(pamNombre);
            this.com.Parameters.Add(pamLocalidad);

            await this.cn.OpenAsync();

            int registros = await this.com.ExecuteNonQueryAsync();

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return registros;
        }

        public async Task<int> UpdateDepartamentoAsync(Empleado empleado)
        {
            string sql = "SP_UPDATE_EMPLEADO";
            SqlParameter pamApellido = new SqlParameter("@apellido", empleado.Apellido);
            SqlParameter pamOficio = new SqlParameter("@oficio", empleado.Oficio);
            SqlParameter pamSalario = new SqlParameter("@salario", empleado.Salario);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            this.com.Parameters.Add(pamApellido);
            this.com.Parameters.Add(pamOficio);
            this.com.Parameters.Add(pamSalario);

            await this.cn.OpenAsync();

            int registros = await this.com.ExecuteNonQueryAsync();

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return registros;
        }

        public async Task<int> DeleteDepartamentoAsync(string nombre)
        {
            string sql = "SP_DELETE_DEPARTAMENTO";

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            this.com.Parameters.AddWithValue("@nombre", nombre);

            await this.cn.OpenAsync();

            int registros = await this.com.ExecuteNonQueryAsync();

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

            return registros;
        }
    }
}