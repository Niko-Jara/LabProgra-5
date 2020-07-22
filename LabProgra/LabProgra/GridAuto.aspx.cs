using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaDatos;
using CapaDatos.Entidades;
using System.Data;

namespace LabProgra
{
    public partial class GridAuto : System.Web.UI.Page
    {
        GestionarBd objGestionar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargardatosAutos();
            }
        }

        //MOSTRAR MENSAJES DE ERROR O EXITO
        void mostrarMensaje(string txtMensaje, bool Tipo)
        {
            if (Tipo)
            {
                labExito.Text = txtMensaje;
                labError.Text = "";
            }
            else
            {
                labExito.Text = "";
                labError.Text = txtMensaje;
            }
        }

        //METODO CARGAR AUTOS
        void cargardatosAutos()
        {
            DataTable datosAutos = new DataTable();
            objGestionar = new GestionarBd();
            datosAutos = objGestionar.cargaAutos();

            if (datosAutos.Rows.Count > 0)
            {
                gridAutos.DataSource = datosAutos;
                gridAutos.DataBind();//VINCULA ORIGEN DE DATOS
            }
            else
            {
                datosAutos.Rows.Add(datosAutos.NewRow());
                gridAutos.DataSource = datosAutos;
                gridAutos.DataBind();
                gridAutos.Rows[0].Cells.Clear();
                gridAutos.Rows[0].Cells.Add(new TableCell());
                gridAutos.Rows[0].Cells[0].ColumnSpan = datosAutos.Columns.Count;
                gridAutos.Rows[0].Cells[0].Text = "No hay Datos Almacenados Aún.....";
                gridAutos.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        //--ROW COMAND
        protected void gridAutos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                objGestionar = new GestionarBd();
                Auto objAuto = new Auto();
                objAuto.IdCarro = Convert.ToInt32((gridAutos.FooterRow.FindControl("txtIdCarroPie") as TextBox).Text.Trim());
                objAuto.Marca = (gridAutos.FooterRow.FindControl("txtMarcaPie") as TextBox).Text.Trim();
                objAuto.Modelo = (gridAutos.FooterRow.FindControl("txtModeloPie") as TextBox).Text.Trim();
                objAuto.Pais = (gridAutos.FooterRow.FindControl("txtPaispie") as TextBox).Text.Trim();
                objAuto.Costo = Convert.ToDouble((gridAutos.FooterRow.FindControl("txtCostoPie") as TextBox).Text.Trim());
                int resultado = objGestionar.RegistrarAuto(objAuto);

                if (resultado == 1)//VALIDAMOS
                {
                    cargardatosAutos();
                    mostrarMensaje("Registro de Auto con exito", true);
                }
                else
                {
                    mostrarMensaje("Existe un error en el registro de la Auto", false);

                }
            }
        }

        //--ROW EDITING

        protected void gridAutos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridAutos.EditIndex = e.NewEditIndex;
            cargardatosAutos();
        }

        protected void gridAutos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridAutos.EditIndex = -1;
            cargardatosAutos();
        }

        //--ROW UPDATING  POR INDICE SE MODIFICA

        protected void gridAutos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objGestionar = new GestionarBd();
            Auto objAuto = new Auto();
            objAuto.IdCarro = Convert.ToInt32((gridAutos.Rows[e.RowIndex].FindControl("txtIdCarro") as TextBox).Text.Trim());
            objAuto.Marca = (gridAutos.Rows[e.RowIndex].FindControl("txtMarca") as TextBox).Text.Trim();
            objAuto.Modelo = (gridAutos.Rows[e.RowIndex].FindControl("txtModelo") as TextBox).Text.Trim();
            objAuto.Pais = (gridAutos.Rows[e.RowIndex].FindControl("txtPais") as TextBox).Text.Trim();
            objAuto.Costo = Convert.ToDouble((gridAutos.Rows[e.RowIndex].FindControl("txtCosto") as TextBox).Text.Trim());
            objAuto.IdCarro = Convert.ToInt32(gridAutos.DataKeys[e.RowIndex].Value.ToString());
            int resultado = objGestionar.ModificarAuto(objAuto);
            gridAutos.EditIndex = -1;


            if (resultado == 1)//VALIDAMOS 
            {
                cargardatosAutos();
                mostrarMensaje("Actualización de Registro de Auto con exito", true);
            }
            else
            {
                mostrarMensaje("Existe un error en el registro de la persona", false);

            }
        }

        //--ROW DELETING

        protected void gridAutos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objGestionar = new GestionarBd();
            Auto objAuto = new Auto();
            objAuto.IdCarro = Convert.ToInt32(gridAutos.DataKeys[e.RowIndex].Value.ToString());
            objGestionar.EliminarAuto(objAuto);
            gridAutos.EditIndex = -1;
            cargardatosAutos();

            mostrarMensaje("Elimino con exito", true);
        }
    }
}