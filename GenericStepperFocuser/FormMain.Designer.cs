namespace GenericStepperFocuser
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.buttonSetup = new System.Windows.Forms.Button();
            this.buttonT1 = new System.Windows.Forms.Button();
            this.panelBasicControls = new System.Windows.Forms.Panel();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonOutFast = new System.Windows.Forms.Button();
            this.buttonOutSlow = new System.Windows.Forms.Button();
            this.buttonInSlow = new System.Windows.Forms.Button();
            this.buttonInFast = new System.Windows.Forms.Button();
            this.buttonDummy = new System.Windows.Forms.Button();
            this.panelTemperature = new System.Windows.Forms.Panel();
            this.checkBoxTemperature = new System.Windows.Forms.CheckBox();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerPosition = new System.Windows.Forms.Timer(this.components);
            this.buttonZero = new System.Windows.Forms.Button();
            this.timerTemperature = new System.Windows.Forms.Timer(this.components);
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonT2 = new System.Windows.Forms.Button();
            this.panelBasicControls.SuspendLayout();
            this.panelTemperature.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 84;
            this.label1.Text = "Position:";
            // 
            // labelPosition
            // 
            this.labelPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelPosition.Location = new System.Drawing.Point(59, 7);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(86, 17);
            this.labelPosition.TabIndex = 84;
            this.labelPosition.Text = "--";
            this.labelPosition.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonSetup
            // 
            this.buttonSetup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSetup.ForeColor = System.Drawing.Color.Red;
            this.buttonSetup.Location = new System.Drawing.Point(3, 200);
            this.buttonSetup.Name = "buttonSetup";
            this.buttonSetup.Size = new System.Drawing.Size(69, 25);
            this.buttonSetup.TabIndex = 10;
            this.buttonSetup.Text = "Setup";
            this.buttonSetup.UseVisualStyleBackColor = false;
            this.buttonSetup.Click += new System.EventHandler(this.buttonSetup_Click);
            // 
            // buttonT1
            // 
            this.buttonT1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonT1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonT1.ForeColor = System.Drawing.Color.Red;
            this.buttonT1.Location = new System.Drawing.Point(75, 169);
            this.buttonT1.Name = "buttonT1";
            this.buttonT1.Size = new System.Drawing.Size(33, 25);
            this.buttonT1.TabIndex = 9;
            this.buttonT1.Text = "T1";
            this.buttonT1.UseVisualStyleBackColor = false;
            this.buttonT1.Click += new System.EventHandler(this.buttonT1_Click);
            // 
            // panelBasicControls
            // 
            this.panelBasicControls.Controls.Add(this.buttonLoad);
            this.panelBasicControls.Controls.Add(this.buttonSave);
            this.panelBasicControls.Controls.Add(this.label5);
            this.panelBasicControls.Controls.Add(this.label3);
            this.panelBasicControls.Controls.Add(this.buttonOutFast);
            this.panelBasicControls.Controls.Add(this.buttonOutSlow);
            this.panelBasicControls.Controls.Add(this.buttonInSlow);
            this.panelBasicControls.Controls.Add(this.buttonInFast);
            this.panelBasicControls.Controls.Add(this.buttonDummy);
            this.panelBasicControls.Location = new System.Drawing.Point(4, 29);
            this.panelBasicControls.Name = "panelBasicControls";
            this.panelBasicControls.Size = new System.Drawing.Size(138, 86);
            this.panelBasicControls.TabIndex = 86;
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.ForeColor = System.Drawing.Color.Red;
            this.buttonLoad.Location = new System.Drawing.Point(6, 56);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(56, 22);
            this.buttonLoad.TabIndex = 5;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.ForeColor = System.Drawing.Color.Red;
            this.buttonSave.Location = new System.Drawing.Point(77, 56);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(56, 22);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(75, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Extra-focal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "Intra-focal";
            // 
            // buttonOutFast
            // 
            this.buttonOutFast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonOutFast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOutFast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOutFast.ForeColor = System.Drawing.Color.Red;
            this.buttonOutFast.Location = new System.Drawing.Point(108, 20);
            this.buttonOutFast.Name = "buttonOutFast";
            this.buttonOutFast.Size = new System.Drawing.Size(30, 25);
            this.buttonOutFast.TabIndex = 4;
            this.buttonOutFast.Text = ">>";
            this.buttonOutFast.UseVisualStyleBackColor = false;
            this.buttonOutFast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonOutFast_MouseDown);
            this.buttonOutFast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonOutFast_MouseUp);
            // 
            // buttonOutSlow
            // 
            this.buttonOutSlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonOutSlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOutSlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOutSlow.ForeColor = System.Drawing.Color.Red;
            this.buttonOutSlow.Location = new System.Drawing.Point(72, 20);
            this.buttonOutSlow.Name = "buttonOutSlow";
            this.buttonOutSlow.Size = new System.Drawing.Size(30, 25);
            this.buttonOutSlow.TabIndex = 3;
            this.buttonOutSlow.Text = ">";
            this.buttonOutSlow.UseVisualStyleBackColor = false;
            this.buttonOutSlow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonOutSlow_MouseDown);
            this.buttonOutSlow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonOutSlow_MouseUp);
            // 
            // buttonInSlow
            // 
            this.buttonInSlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonInSlow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInSlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInSlow.ForeColor = System.Drawing.Color.Red;
            this.buttonInSlow.Location = new System.Drawing.Point(36, 20);
            this.buttonInSlow.Name = "buttonInSlow";
            this.buttonInSlow.Size = new System.Drawing.Size(30, 25);
            this.buttonInSlow.TabIndex = 2;
            this.buttonInSlow.Text = "<";
            this.buttonInSlow.UseVisualStyleBackColor = false;
            this.buttonInSlow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonInSlow_MouseDown);
            this.buttonInSlow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonInSlow_MouseUp);
            // 
            // buttonInFast
            // 
            this.buttonInFast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonInFast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInFast.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonInFast.ForeColor = System.Drawing.Color.Red;
            this.buttonInFast.Location = new System.Drawing.Point(0, 20);
            this.buttonInFast.Name = "buttonInFast";
            this.buttonInFast.Size = new System.Drawing.Size(30, 25);
            this.buttonInFast.TabIndex = 1;
            this.buttonInFast.Text = "<<";
            this.buttonInFast.UseVisualStyleBackColor = false;
            this.buttonInFast.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonInFast_MouseDown);
            this.buttonInFast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.buttonInFast_MouseUp);
            // 
            // buttonDummy
            // 
            this.buttonDummy.Location = new System.Drawing.Point(51, 21);
            this.buttonDummy.Name = "buttonDummy";
            this.buttonDummy.Size = new System.Drawing.Size(13, 15);
            this.buttonDummy.TabIndex = 0;
            this.buttonDummy.TabStop = false;
            this.buttonDummy.Text = "dummy";
            this.buttonDummy.UseVisualStyleBackColor = true;
            // 
            // panelTemperature
            // 
            this.panelTemperature.Controls.Add(this.checkBoxTemperature);
            this.panelTemperature.Controls.Add(this.labelTemperature);
            this.panelTemperature.Controls.Add(this.label2);
            this.panelTemperature.Location = new System.Drawing.Point(3, 120);
            this.panelTemperature.Name = "panelTemperature";
            this.panelTemperature.Size = new System.Drawing.Size(142, 43);
            this.panelTemperature.TabIndex = 88;
            // 
            // checkBoxTemperature
            // 
            this.checkBoxTemperature.AutoSize = true;
            this.checkBoxTemperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.checkBoxTemperature.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxTemperature.Location = new System.Drawing.Point(10, 24);
            this.checkBoxTemperature.Name = "checkBoxTemperature";
            this.checkBoxTemperature.Size = new System.Drawing.Size(122, 17);
            this.checkBoxTemperature.TabIndex = 7;
            this.checkBoxTemperature.Text = "Temp. compensation";
            this.checkBoxTemperature.UseVisualStyleBackColor = false;
            this.checkBoxTemperature.CheckedChanged += new System.EventHandler(this.checkBoxTemperature_CheckedChanged);
            // 
            // labelTemperature
            // 
            this.labelTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemperature.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelTemperature.Location = new System.Drawing.Point(85, 0);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(56, 24);
            this.labelTemperature.TabIndex = 87;
            this.labelTemperature.Text = "--";
            this.labelTemperature.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 86;
            this.label2.Text = "Temperature (°C):";
            // 
            // timerPosition
            // 
            this.timerPosition.Interval = 500;
            this.timerPosition.Tick += new System.EventHandler(this.timerPosition_Tick);
            // 
            // buttonZero
            // 
            this.buttonZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonZero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonZero.ForeColor = System.Drawing.Color.Red;
            this.buttonZero.Location = new System.Drawing.Point(3, 169);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(69, 25);
            this.buttonZero.TabIndex = 8;
            this.buttonZero.Text = "Find Zero";
            this.buttonZero.UseVisualStyleBackColor = false;
            this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
            // 
            // timerTemperature
            // 
            this.timerTemperature.Interval = 5000;
            this.timerTemperature.Tick += new System.EventHandler(this.timerTemperature_Tick);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnect.ForeColor = System.Drawing.Color.Red;
            this.buttonConnect.Location = new System.Drawing.Point(75, 200);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(69, 25);
            this.buttonConnect.TabIndex = 11;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonT2
            // 
            this.buttonT2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonT2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonT2.ForeColor = System.Drawing.Color.Red;
            this.buttonT2.Location = new System.Drawing.Point(111, 169);
            this.buttonT2.Name = "buttonT2";
            this.buttonT2.Size = new System.Drawing.Size(33, 25);
            this.buttonT2.TabIndex = 9;
            this.buttonT2.Text = "T2";
            this.buttonT2.UseVisualStyleBackColor = false;
            this.buttonT2.Click += new System.EventHandler(this.buttonT2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(146, 228);
            this.Controls.Add(this.panelTemperature);
            this.Controls.Add(this.panelBasicControls);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.buttonZero);
            this.Controls.Add(this.buttonSetup);
            this.Controls.Add(this.buttonT2);
            this.Controls.Add(this.buttonT1);
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "GSFocuser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelBasicControls.ResumeLayout(false);
            this.panelBasicControls.PerformLayout();
            this.panelTemperature.ResumeLayout(false);
            this.panelTemperature.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Button buttonSetup;
        private System.Windows.Forms.Button buttonT1;
        private System.Windows.Forms.Panel panelBasicControls;
        private System.Windows.Forms.Button buttonOutFast;
        private System.Windows.Forms.Button buttonOutSlow;
        private System.Windows.Forms.Button buttonInSlow;
        private System.Windows.Forms.Button buttonInFast;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDummy;
        private System.Windows.Forms.Panel panelTemperature;
        private System.Windows.Forms.CheckBox checkBoxTemperature;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerPosition;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.Timer timerTemperature;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonT2;
    }
}

