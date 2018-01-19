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

namespace GenericStepperFocuser
{
    public partial class FormSave : Form
    {
        readonly PresetManager presetManager = new PresetManager();
        public int Position { get; set; }

        public FormSave()
        {
            InitializeComponent();

        }

        private void FormSave_Load(object sender, EventArgs e)
        {
            try
            {
                presetManager.LoadFromFile();
                comboBoxPresets.Items.AddRange(presetManager.Presets.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load presets: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormSave_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                Preset preset = presetManager.Presets.Find(p => p.Description == comboBoxPresets.Text);

                if (preset == null)
                {
                    preset = new Preset()
                    {
                        Description = comboBoxPresets.Text,
                        Position = this.Position,
                    };
                    presetManager.Presets.Add(preset);

                }
                else
                {
                    if (MessageBox.Show("Preset already defined. Overwrite?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }

                    preset.Position = this.Position;
                }
                try
                {
                    presetManager.SaveToFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot save presets: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }


        private void comboBoxPresets_TextChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = comboBoxPresets.Text != "";
        }


    }
}
