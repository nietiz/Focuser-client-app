// --------------------------------------------------------------------------------
//
// Author:		(NT) Tiziano Niero, tiziano.niero@gmail.com, www.tizianoniero.it
//
// This work is licensed under the Creative Commons Attribution-NonCommercial-ShareAlike 4.0 
// International License. 
// To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/4.0/ 
// or send a letter to Creative Commons, PO Box 1866, Mountain View, CA 94042, USA.
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// 26-aug-2014	NT	1.0.0	Initial edit
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ASCOM.DriverAccess;
using System.Diagnostics;

namespace GenericStepperFocuser
{
    public partial class FormFindZero : Form
    {
        private readonly Focuser driver;

        public FormFindZero(Focuser driver)
        {
            InitializeComponent();
            this.driver = driver;

        }

        private void FormFindZero_Load(object sender, EventArgs e)
        {
            string s = driver.CommandString("Z\n", true);
            Debug.WriteLine(s);
            if (s == "OK")
                timer1.Enabled = true;
            else
                Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!driver.IsMoving)
            {
                timer1.Enabled = false;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            driver.Halt();
            Close();
        }
    }
}
