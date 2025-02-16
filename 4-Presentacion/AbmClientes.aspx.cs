﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AbmClientes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //primer acceso a la pagina
            Session["Cliente"] = null;
            this.DesActivoBotones();
            this.LimpioControles();
            TxtNumero.Enabled = true;
            TxtNumero.ReadOnly = false;
        }
    }

    private void DesActivoBotones()
    {
        BtnAlta.Enabled = false;
        BtnBaja.Enabled = false;
        BtnModificar.Enabled = false;
    }

    private void LimpioControles()
    {
        TxtNumero.Text = "";
        TxtNombre.Text = "";
        TxtDireccion.Text = "";
        TxtUsuario.Text = "";
        TxtPassword.Text = "";
        LblError.Text = "";

        TxtNumero.Enabled = false;
        TxtNumero.ReadOnly = true;

        LbTelefonos.Items.Clear();
        LbTelefonos.SelectedIndex = -1;

    }

    private List<EntidadesCompartidas.Telefono> CargoListaTels()
    {
        List<EntidadesCompartidas.Telefono> _lista = new List<EntidadesCompartidas.Telefono>();

        foreach (ListItem unLugar in LbTelefonos.Items)
            _lista.Add(new EntidadesCompartidas.Telefono(unLugar.Text.Trim()));

        return _lista;
    }

    protected void BtnBusco_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Cliente _unCliente = null;
            _unCliente = Logica.FabricaLogica.GetLogicaCliente().Buscar(Convert.ToInt32(TxtNumero.Text));
            this.LimpioControles();


            if (_unCliente == null)
            {
                BtnAlta.Enabled = true;
            }
            else
            {
                BtnModificar.Enabled = true;
                BtnBaja.Enabled = true;
                Session["Cliente"] = _unCliente;
                TxtNumero.Text = _unCliente.NumCli.ToString();
                TxtNombre.Text = _unCliente.NomCli;
                TxtDireccion.Text = _unCliente.DirCli;
                TxtUsuario.Text = _unCliente.UsuCli;
                TxtPassword.Text = _unCliente.PassCli;
                LbTelefonos.DataSource = _unCliente.ListaTelefonos;
                LbTelefonos.DataTextField = "UnTelefono";
                LbTelefonos.DataBind();
                LbTelefonos.SelectedIndex = -1;

            }
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Cliente _unCliente = null;
            _unCliente = new EntidadesCompartidas.Cliente(0, TxtNombre.Text.Trim(), TxtDireccion.Text.Trim(), TxtUsuario.Text.Trim(), TxtPassword.Text.Trim(), CargoListaTels());
            Logica.FabricaLogica.GetLogicaCliente().Alta(_unCliente);
            this.DesActivoBotones();
            this.LimpioControles();
            TxtNumero.Enabled = true;
            TxtNumero.ReadOnly = false;

            LblError.Text = "Alta con Exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Cliente _unCliente = (EntidadesCompartidas.Cliente)Session["Cliente"];
            Logica.FabricaLogica.GetLogicaCliente().Baja(_unCliente);
            this.DesActivoBotones();
            this.LimpioControles();
            TxtNumero.Enabled = true;
            TxtNumero.ReadOnly = false;

            LblError.Text = "Baja con Exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            EntidadesCompartidas.Cliente _unCliente = (EntidadesCompartidas.Cliente)Session["Cliente"];
            _unCliente.NomCli = TxtNombre.Text.Trim();
            _unCliente.DirCli = TxtDireccion.Text.Trim();
            _unCliente.UsuCli = TxtUsuario.Text.Trim();
            _unCliente.PassCli = TxtPassword.Text.Trim();
            _unCliente.ListaTelefonos = CargoListaTels();
            Logica.FabricaLogica.GetLogicaCliente().Modificar(_unCliente);
            this.DesActivoBotones();
            this.LimpioControles();
            TxtNumero.Enabled = true;
            TxtNumero.ReadOnly = false;

            LblError.Text = "Modificacion con Exito";
        }
        catch (Exception ex)
        {
            LblError.Text = ex.Message;
        }
    }

    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
        //primer acceso a la pagina
        Session["Cliente"] = null;
        this.DesActivoBotones();
        this.LimpioControles();
        TxtNumero.Enabled = true;
        TxtNumero.ReadOnly = false;
    }

    protected void BtnBorrarTel_Click(object sender, EventArgs e)
    {
        //determino si hay una linea de la lista seleccionada
        if (LbTelefonos.SelectedIndex >= 0)
        {
            LbTelefonos.Items.RemoveAt(LbTelefonos.SelectedIndex);
            LblError.Text = "Eliminacion del Telefono de la Lista con Exito";
        }
        else
            LblError.Text = "Debe Seleccionar un telefono de la lista para eliminar";

    }

    protected void BtnAgregarTel_Click(object sender, EventArgs e)
    {
        //verifico q se haya ingresado algo en la caja de texto de telefono
        if (TxtTelefono.Text.Trim().Length > 0)
        {
            LbTelefonos.Items.Add(TxtTelefono.Text.Trim());
            TxtTelefono.Text = "";
            LblError.Text = "Se agrego Correctamente el Telefono a la Lista";
        }
        else
            LblError.Text = "No Hay nada ingresado - No se agrega Telefono a la lista";

    }
}