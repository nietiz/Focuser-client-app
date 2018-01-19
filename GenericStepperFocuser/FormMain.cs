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
using System.Diagnostics;
using ASCOM.Utilities;
using ASCOM.DriverAccess;
using System.IO;
using System.Globalization;

namespace GenericStepperFocuser
{
    public partial class FormMain : Form
    {



        // --- Variables to hold the current device configuration ---

        // behaviour at connection
        private bool findZero;
        private bool restoreLastPosition;
        // motor settings
        private int fullStepsRev;
        private int microStepsStep;
        private int speedFastRpm;
        private int speedSlowRpm;
        // temperature management
        private bool temperatureCompensation;
        private decimal temperatureCoefficient; // mm/°C
        private double tempT1 = 0;
        private double tempT2 = 0;
        private int positionT1 = 0;
        private int positionT2 = 0;
        // controls which do something only if driver is connected
        private List<Control> commandControls = new List<Control>();



        ASCOM.DriverAccess.Focuser driver;

        public FormMain(ASCOM.DriverAccess.Focuser driver)
        {
            InitializeComponent();

            this.driver = driver;


            // controls which enabled state depend on connection
            commandControls.Add(buttonInFast);
            commandControls.Add(buttonInSlow);
            commandControls.Add(buttonOutSlow);
            commandControls.Add(buttonOutFast);
            commandControls.Add(buttonLoad);
            commandControls.Add(buttonSave);
            commandControls.Add(checkBoxTemperature);
            commandControls.Add(buttonZero);
            commandControls.Add(buttonT1);
            commandControls.Add(buttonT2);

            SetControlsState(false);
            ReadProfile();

        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            DoConnection();
            buttonDummy.Focus();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (driver != null)
                CloseConnection();
        }


        private void buttonInFast_MouseDown(object sender, MouseEventArgs e)
        {
            if (driver == null)
                return;
            try
            {
                SetSpeedFast();
                driver.Move(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }
        private void buttonInFast_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDummy.Focus();
            if (driver == null)
                return;
            try
            {
                if (!driver.Connected)
                    return;
                driver.Halt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }
        private void buttonInSlow_MouseDown(object sender, MouseEventArgs e)
        {
            if (driver == null)
                return;
            try
            {
                SetSpeedSlow();
                driver.Move(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }
        private void buttonInSlow_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDummy.Focus();
            if (driver == null)
                return;
            try
            {
                if (!driver.Connected)
                    return;
                driver.Halt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }
        private void buttonOutSlow_MouseDown(object sender, MouseEventArgs e)
        {
            if (driver == null)
                return;
            try
            {
                SetSpeedSlow();
                driver.Move(driver.MaxStep);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }
        private void buttonOutSlow_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDummy.Focus();
            if (driver == null)
                return;
            try
            {
                if (!driver.Connected)
                    return;
                if (driver.Position == driver.MaxStep)
                    return;
                driver.Halt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }
        private void buttonOutFast_MouseDown(object sender, MouseEventArgs e)
        {
            if (driver == null)
                return;
            try
            {
                if (driver.Position == driver.MaxStep)
                    return;
                SetSpeedFast();
                driver.Move(driver.MaxStep);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }
        private void buttonOutFast_MouseUp(object sender, MouseEventArgs e)
        {
            buttonDummy.Focus();
            if (driver == null)
                return;
            try
            {
                driver.Halt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            buttonDummy.Focus();
            if (driver == null)
                return;
            try
            {
                using (FormPresets f = new FormPresets())
                {
                    DialogResult result = f.ShowDialog(this);
                    if (result == DialogResult.OK)
                    {
                        SetSpeedFast();
                        driver.Move(f.TargetPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            buttonDummy.Focus();
            if (driver == null)
                return;
            try
            {
                using (FormSave f = new FormSave())
                {
                    f.Position = driver.Position;
                    f.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }


        private void buttonZero_Click(object sender, EventArgs e)
        {
            buttonDummy.Focus();
            if (driver == null)
                return;
            FindZero();
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            buttonDummy.Focus();
            if (driver == null)
                return;
            try
            {
                driver.SetupDialog();
                ReadProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        private void buttonConnect_Click(object sender, EventArgs e)
        {
            buttonDummy.Focus();
            if (driver == null)
            {
                DoConnection();
            }
            else
            {
                if (driver.Connected)
                    CloseConnection();
                else
                    DoConnection();
            }
        }

        private void buttonT1_Click(object sender, EventArgs e)
        {
            buttonDummy.Focus();
            tempT1 = driver.Temperature;
            positionT1 = driver.Position;
            string message = string.Format(
                "The starting point for the calculation of the temperature coefficient has been acquired. " +
                Environment.NewLine +
                "Position1={0} steps, t1={1} °C" + Environment.NewLine +
                "Wait until a convenient delta T (1> °C) and then press the T2 button",
                positionT1, tempT1);

            MessageBox.Show(this, message);
        }
        private void buttonT2_Click(object sender, EventArgs e)
        {
            decimal calculatedTempCoeff = 0;
            buttonDummy.Focus();
            tempT2 = driver.Temperature;
            positionT2 = driver.Position;
            decimal deltaT = (decimal)(tempT2 - tempT1);
            decimal deltaPosSteps = positionT2 - positionT1;
            decimal deltaPosMm = deltaPosSteps * (decimal)driver.StepSize / 1000m;
            if (deltaPosSteps == 0 || Math.Abs(deltaT) < decimal.MinValue)
                calculatedTempCoeff = 0;
            else
                calculatedTempCoeff = deltaPosMm / deltaT;
            string message = string.Format("The ending point for the calculation of the temperature coefficient has been acquired. " +
                Environment.NewLine +
                "Data are: " + Environment.NewLine +
                "Position1={0} steps, t1={1} °C" + Environment.NewLine +
                "Position2={2} steps, t2={3} °C" + Environment.NewLine +
                "The resulting temperature coefficient is {4} mm/°C",
                positionT1, tempT1, positionT2, tempT2, calculatedTempCoeff);
            // ask user confirmation
            DialogResult result = MessageBox.Show(this, message, "", MessageBoxButtons.OKCancel);
            if (result == System.Windows.Forms.DialogResult.OK)
                temperatureCoefficient = calculatedTempCoeff;
        }


        private void SetSpeedSlow()
        {
            try
            {
                string s = driver.CommandString("S\n", true);
                Debug.WriteLine(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }
        private void SetSpeedFast()
        {
            try
            {
                string s = driver.CommandString("F\n", true);
                Debug.WriteLine(s);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }

        private void timerPosition_Tick(object sender, EventArgs e)
        {
            try
            {
                labelPosition.Text = driver.Position.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }
        }


        private void timerTemperature_Tick(object sender, EventArgs e)
        {
            try
            {
                double t = driver.Temperature;
                //Debug.WriteLine(t);
                labelTemperature.Text = t.ToString("0.0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                CloseConnection();
            }

        }


        /// <summary>
        /// Find zero position.
        /// Move toward intra-focal position until limt switch is pressed.
        /// </summary>
        /// <returns>true if operation has completed, false if user pressed tha Cancel button</returns>
        private bool FindZero()
        {
            timerPosition.Enabled = false;
            DialogResult result;
            using (FormFindZero f = new FormFindZero(driver))
            {
                result = f.ShowDialog(this);
            }
            timerPosition.Enabled = true;
            return result != DialogResult.Cancel;
        }


        /// <summary>
        /// OPEN CONNECTION
        /// </summary>
        private void DoConnection()
        {
            try
            {
                // connection request
                driver.Connected = true;

                // OK, enable controls
                SetControlsState(true);

                // change connection button text
                buttonConnect.Text = "Close";

                // set advanced motor settings
                Debug.Assert(fullStepsRev == 100 || fullStepsRev == 200 || fullStepsRev == 400);
                driver.CommandString("r" + fullStepsRev.ToString() + "\n", true);
                Debug.Assert(microStepsStep == 1 || microStepsStep == 2 || microStepsStep == 4 || microStepsStep == 8 || microStepsStep == 16 || microStepsStep == 32);
                driver.CommandString("u" + microStepsStep.ToString() + "\n", true);
                //Debug.Assert(speedFastRpm);
                driver.CommandString("f" + speedFastRpm.ToString() + "\n", true);
                driver.CommandString("s" + speedSlowRpm.ToString() + "\n", true);


                if (findZero)
                {
                    // find zero and if requested restore last position
                    if (FindZero())
                    {
                        // find zero completed (not cancelled by the user)
                        if (restoreLastPosition)
                            driver.Move(Properties.Settings.Default.LastPosition);
                    }
                }
                else
                {
                    // force the focuser to the last position (assume that it hasn't been moved manually)
                    string response = driver.CommandString("A" + Properties.Settings.Default.LastPosition.ToString() + "\n", true);
                    if (response != "OK")
                        MessageBox.Show("Cannot force last position", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // enable position feedback
                timerPosition.Enabled = true;

                // check if the temperature probe is connected and working
                if (driver.TempCompAvailable)
                {
                    // OK, enable temperature feedback
                    timerTemperature.Enabled = true;
                }
                else
                {
                    // disconnected or not working: disable temperature feedback
                    timerTemperature.Enabled = false;
                    labelTemperature.Text = "--";
                    checkBoxTemperature.Visible = false;
                    buttonT1.Visible = false;
                    buttonT2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// CLOSE CONNECTION
        /// </summary>
        private void CloseConnection()
        {
            try
            {
                if (driver != null)
                {
                    if (driver.Connected)
                    {
                        // store last position in settings
                        int position;
                        if (int.TryParse(labelPosition.Text, out position))
                        {
                            Properties.Settings.Default.LastPosition = position; //driver.Position;
                            Properties.Settings.Default.Save();
                        }

                        // disable temperature compensation, if enabled
                        try
                        {
                            if (driver.TempComp)
                                driver.TempComp = false;
                        }
                        catch (Exception)
                        {
                        }
                        try
                        {
                            driver.Connected = false;
                        }
                        catch (Exception)
                        {
                        }

                        // disable position feedback
                        timerPosition.Enabled = false;
                        // disable temperature feedback
                        timerTemperature.Enabled = false;

                        SetControlsState(false);
                        buttonConnect.Text = "Connect";
                        labelPosition.Text = "--";
                        labelTemperature.Text = "--";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, "Closing connection failed: " + ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Read the device configuration from the ASCOM Profile store
        /// </summary>
        private void ReadProfile()
        {
            const string findZeroProfileName = "Find zero at connection";
            const string restorePositionProfileName = "Restore last position";
            const string tempCompensationProfileName = "Temperature compensation";
            const string tempCoefficientProfileName = "Temperature coefficient";
            const string fullStepsRevProfileName = "Fullsteps-revolution";
            const string microStepsStepProfileName = "Microsteps-step";
            const string speedFastRpsProfileName = "Speed Fast  RPS";
            const string speedSlowRpsProfileName = "Speed Slow RPS";
            const string alwaysOnTopProfileName = "Always on top";
            const string alwaysOnTopDefault = "false";

            using (Profile profile = new Profile())
            {
                profile.DeviceType = "Focuser";
                this.TopMost = Convert.ToBoolean(profile.GetValue(Program.FocuserID, alwaysOnTopProfileName, string.Empty, alwaysOnTopDefault));
                findZero = Convert.ToBoolean(profile.GetValue(Program.FocuserID, findZeroProfileName, string.Empty, "true"));
                restoreLastPosition = Convert.ToBoolean(profile.GetValue(Program.FocuserID, restorePositionProfileName, string.Empty, "false"));
                temperatureCompensation = Convert.ToBoolean(profile.GetValue(Program.FocuserID, tempCompensationProfileName, string.Empty, "false"));
                temperatureCoefficient = Convert.ToDecimal(profile.GetValue(Program.FocuserID, tempCoefficientProfileName, string.Empty, "0.0"), CultureInfo.InvariantCulture);
                fullStepsRev = Convert.ToInt32(profile.GetValue(Program.FocuserID, fullStepsRevProfileName, string.Empty, "200"));
                microStepsStep = Convert.ToInt32(profile.GetValue(Program.FocuserID, microStepsStepProfileName, string.Empty, "32"));

                decimal speedFastRps = Convert.ToDecimal(profile.GetValue(Program.FocuserID, speedFastRpsProfileName, string.Empty, "5.0"), CultureInfo.InvariantCulture);
                decimal speedSlowRps = Convert.ToDecimal(profile.GetValue(Program.FocuserID, speedSlowRpsProfileName, string.Empty, "0.1"), CultureInfo.InvariantCulture);

                speedFastRpm = (int)(speedFastRps * 60);
                speedSlowRpm = (int)(speedSlowRps * 60);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enabled">new state of the controls</param>
        /// <param name="checkBoxTempToo">if true then apply the new state also to the checkBoxTemperature, otherwise leave it in its previous state</param>
        private void SetControlsState(bool enabled, bool checkBoxTempToo = true)
        {
            foreach (var item in commandControls)
            {
                if (item != checkBoxTemperature || checkBoxTempToo)
                {
                    item.ForeColor = enabled ? Color.Red : Color.Gray;
                    item.Enabled = enabled;
                }
            }
        }

        private void checkBoxTemperature_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTemperature.Checked)
            {
                SetControlsState(false, false);
                driver.TempComp = true;
            }
            else
            {
                SetControlsState(true);
                driver.TempComp = false;
            }
        }



    }
}
