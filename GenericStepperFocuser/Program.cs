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
using System.Linq;
using System.Windows.Forms;
using System.IO;
using ASCOM.DriverAccess;

namespace GenericStepperFocuser
{
    static class Program
    {
        private static readonly string focuserID = "ASCOM.GenericStepper.Focuser";
        public static string FocuserID { get { return focuserID; } }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ASCOM.DriverAccess.Focuser driver;
            try
            {
                driver = new Focuser(focuserID);
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to create an instance of the dll: " + focuserID, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Application.Run(new FormMain(driver));
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error: " + ex.Message);
            }
        }

    }
}
