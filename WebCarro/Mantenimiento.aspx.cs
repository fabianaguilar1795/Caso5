using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseDatos;
using System.Data;
using BaseDatos.Entidades;



namespace WebCarro
{
    public partial class Mantenimiento : System.Web.UI.Page
    {
        GestionBD objGestion;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cargarCarros();
            }
        }

        void mostrarMensaje(string txtMensaje, bool Tipo)
        {
            if (Tipo)
            {
                lblExito.Text = txtMensaje;
                lblError.Text = "";
            }
            else
            {
                lblExito.Text = "";
                lblError.Text = txtMensaje;
            }
        }

        void cargarCarros()
        {
            DataTable carros = new DataTable();
            objGestion = new GestionBD();
            carros = objGestion.cargarCarros();

            if (carros.Rows.Count > 0)
            {
                gridCarro.DataSource = carros;
                gridCarro.DataBind();
            }
            else
            {
                carros.Rows.Add(carros.NewRow());
                gridCarro.DataSource = carros;
                gridCarro.DataBind();
                gridCarro.Rows[0].Cells.Clear();
                gridCarro.Rows[0].Cells.Add(new TableCell());
                gridCarro.Rows[0].Cells[0].ColumnSpan = carros.Columns.Count;
                gridCarro.Rows[0].Cells[0].Text = "No hay datos que mostrar...";
                gridCarro.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void gridCarro_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("AddNew"))
            {
                objGestion = new GestionBD();
                Carro obj = new Carro();
                obj.MARCA = (gridCarro.FooterRow.FindControl("txtMarcaPie") as TextBox).Text.Trim();
                obj.MODELO = (gridCarro.FooterRow.FindControl("txtModeloPie") as TextBox).Text.Trim();
                obj.PAIS = (gridCarro.FooterRow.FindControl("txtPaisPie") as TextBox).Text.Trim();
                obj.COSTO = decimal.Parse((gridCarro.FooterRow.FindControl("txtCostoPie") as TextBox).Text.Trim());
                int resultado = objGestion.registrarCarro(obj);

                if (resultado == 1)
                {
                    cargarCarros();
                    mostrarMensaje("Registro con exito", true);
                }
                else
                {
                    mostrarMensaje("Existe un error en el registro del carro", false);

                }
            }
        }

        protected void gridCarro_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridCarro.EditIndex = e.NewEditIndex;
            cargarCarros();
        }

        protected void gridCarro_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridCarro.EditIndex = -1;
            cargarCarros();
        }

        protected void gridCarro_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            objGestion = new GestionBD();
            Carro objPersona = new Carro();
            objPersona.MARCA = (gridCarro.Rows[e.RowIndex].FindControl("txtMarca") as TextBox).Text.Trim();
            objPersona.MODELO = (gridCarro.Rows[e.RowIndex].FindControl("txtModelo") as TextBox).Text.Trim();
            objPersona.PAIS = (gridCarro.Rows[e.RowIndex].FindControl("txtPais") as TextBox).Text.Trim();
            objPersona.COSTO = decimal.Parse((gridCarro.Rows[e.RowIndex].FindControl("txtCosto") as TextBox).Text.Trim());
            objPersona.IDCARRO = Convert.ToInt32(gridCarro.DataKeys[e.RowIndex].Value.ToString());
            int resultado = objGestion.actualizarCarro(objPersona);
            gridCarro.EditIndex = -1;

            if (resultado == 1)
            {
                cargarCarros();
                mostrarMensaje("Actualización con exito", true);
            }
            else
            {
                mostrarMensaje("Existe un error en el registro del carro", false);
            }
        }

        protected void gridCarro_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            objGestion = new GestionBD();
            Carro obj = new Carro();
            obj.IDCARRO = Convert.ToInt32(gridCarro.DataKeys[e.RowIndex].Value.ToString());
            objGestion.eliminarCarro(obj);
            gridCarro.EditIndex = -1;
            cargarCarros();

            mostrarMensaje("Se elimino con exito", true);
        }
    }
}
