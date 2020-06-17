﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entity;
using BLL;

namespace pruebabdlocal
{
    public partial class Form1 : Form
    {
        public PersonaService PersonaService;
        public Form1()
        {
            InitializeComponent();
            PersonaService = new PersonaService(ConfigConection.ConnectionString);
            DtgConsulta.DataSource = PersonaService.Consultar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            PersonaService = new PersonaService(ConfigConection.ConnectionString);
            Persona persona = new Persona();
            persona.Cedula = TxtCedula.Text;
            persona.Nombre = TxtNombre.Text;
            MessageBox.Show(PersonaService.GuardarPersona(persona));
            DtgConsulta.DataSource = null;
            DtgConsulta.DataSource = PersonaService.Consultar();
        }
    }
}
