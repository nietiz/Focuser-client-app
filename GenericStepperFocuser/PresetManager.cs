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
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace GenericStepperFocuser
{
    class PresetManager
    {

        private static readonly string pathDir = Path.Combine(
             Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
             AppDomain.CurrentDomain.FriendlyName);
        private static readonly string path = Path.Combine(pathDir, "presets.txt");


        private readonly char separator = '\t';

        readonly List<Preset> list = new List<Preset>();
        public List<Preset> Presets { get { return list; } }


        public void LoadFromFile()
        {
            list.Clear();
            if (!Directory.Exists(pathDir))
                Directory.CreateDirectory(pathDir);
            if (!File.Exists(path))
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            var lines = File.ReadLines(path);

            foreach (var line in lines)
            {
                string[] split = line.Split(separator);
                if (split.Length == 2)
                {
                    Preset preset = new Preset();
                    int position;
                    int.TryParse(split[0], out position);
                    preset.Position = position;
                    preset.Description = split[1];
                    list.Add(preset);
                }
            }

        }
        public void SaveToFile()
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in list)
            {
                s.AppendLine(item.Position.ToString() + separator + item.Description);
            }
            if (!Directory.Exists(pathDir))
                Directory.CreateDirectory(pathDir);
            File.WriteAllText(path, s.ToString());

        }
    }
}
