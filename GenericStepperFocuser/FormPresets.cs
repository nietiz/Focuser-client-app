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
using System.IO;

namespace GenericStepperFocuser
{
    public partial class FormPresets : Form
    {
        private enum ColumnIndex
        {
            Position,
            Description
        }


        readonly DataTable dataTable = new DataTable();
        readonly PresetManager presetManager = new PresetManager();

        public int TargetPosition { get; private set; }

        public FormPresets()
        {
            InitializeComponent();
        }

        private void FormPresets_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FormPresets_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        private void SaveData()
        {
            try
            {

                presetManager.SaveToFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot save presets: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int index = dataGridViewPresets.CurrentRow.Index;
            TargetPosition = presetManager.Presets[index].Position;
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int index = dataGridViewPresets.CurrentRow.Index;
            presetManager.Presets.RemoveAt(index);
            dataGridViewPresets.Rows.RemoveAt(index);
        }
        //private void dataGridViewPresets_DoubleClick(object sender, EventArgs e)
        //{
        //    buttonOK.PerformClick();
        //}

        private void dataGridViewPresets_SelectionChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = buttonDelete.Enabled = dataGridViewPresets.Rows.Count > 0;
        }

        void FillData()
        {
            try
            {
                presetManager.LoadFromFile();

                foreach (var preset in presetManager.Presets)
                {
                    string[] row = { preset.Position.ToString(), preset.Description };
                    dataGridViewPresets.Rows.Add(row);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Cannot load presets: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Preset preset = new Preset()
            {
                Position = 0,
                Description = "new preset"
            };
            presetManager.Presets.Add(preset);
            string[] row = 
            {
                preset.Position.ToString(), 
                preset.Description
            };
            int index = dataGridViewPresets.Rows.Add(row);
            dataGridViewPresets.Rows[index].Cells[1].Selected = true;
            dataGridViewPresets.BeginEdit(true);
        }

        private void dataGridViewPresets_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string s = (e.FormattedValue as string).Trim();
            switch ((ColumnIndex)e.ColumnIndex)
            {
                case ColumnIndex.Position:
                    int position;
                    if (!int.TryParse(s, out position))
                    {
                        MessageBox.Show("Invalid number");
                        e.Cancel = true;
                    }
                    break;
                case ColumnIndex.Description:
                    if (s == "")
                    {
                        MessageBox.Show("Please provide some description");
                        e.Cancel = true;

                    }
                    else
                    {
                        Preset preset = presetManager.Presets.Find(p => p.Description == s);
                        if (preset != null && presetManager.Presets.IndexOf(preset) != e.RowIndex)
                        {
                            MessageBox.Show("This description is use by another preset, please change it");
                            e.Cancel = true;
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void dataGridViewPresets_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            switch ((ColumnIndex)e.ColumnIndex)
            {
                case ColumnIndex.Position:
                    presetManager.Presets[e.RowIndex].Position = int.Parse(dataGridViewPresets.CurrentCell.Value as string);
                    break;
                case ColumnIndex.Description:
                    presetManager.Presets[e.RowIndex].Description = dataGridViewPresets.CurrentCell.Value as string;
                    break;
                default:
                    break;
            }


        }

    }
}
