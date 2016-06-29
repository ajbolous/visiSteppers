namespace visiSteppers
{
    partial class StepperGui
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.txtTag = new System.Windows.Forms.Label();
            this.lblTestPos = new System.Windows.Forms.Label();
            this.lblLevelPos = new System.Windows.Forms.Label();
            this.lblAbsPos = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.stepsCounter = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.numDelay = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numSpeed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numStep = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.grpSettings = new System.Windows.Forms.GroupBox();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).BeginInit();
            this.grpSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(5, 4);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(15, 14);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.SystemColors.Control;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.ForeColor = System.Drawing.Color.Black;
            this.btnUp.Location = new System.Drawing.Point(61, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(31, 23);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "/\\";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.SystemColors.Control;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.ForeColor = System.Drawing.Color.Black;
            this.btnDown.Location = new System.Drawing.Point(98, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(31, 23);
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "V";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // txtTag
            // 
            this.txtTag.AutoSize = true;
            this.txtTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTag.ForeColor = System.Drawing.Color.DarkRed;
            this.txtTag.Location = new System.Drawing.Point(26, 2);
            this.txtTag.Name = "txtTag";
            this.txtTag.Size = new System.Drawing.Size(25, 25);
            this.txtTag.TabIndex = 17;
            this.txtTag.Text = "5";
            // 
            // lblTestPos
            // 
            this.lblTestPos.AutoSize = true;
            this.lblTestPos.Location = new System.Drawing.Point(9, 139);
            this.lblTestPos.Name = "lblTestPos";
            this.lblTestPos.Size = new System.Drawing.Size(53, 13);
            this.lblTestPos.TabIndex = 21;
            this.lblTestPos.Text = "Test[mm]:";
            // 
            // lblLevelPos
            // 
            this.lblLevelPos.AutoSize = true;
            this.lblLevelPos.Location = new System.Drawing.Point(9, 126);
            this.lblLevelPos.Name = "lblLevelPos";
            this.lblLevelPos.Size = new System.Drawing.Size(72, 13);
            this.lblLevelPos.TabIndex = 20;
            this.lblLevelPos.Text = "Leveling[mm]:";
            // 
            // lblAbsPos
            // 
            this.lblAbsPos.AutoSize = true;
            this.lblAbsPos.Location = new System.Drawing.Point(9, 113);
            this.lblAbsPos.Name = "lblAbsPos";
            this.lblAbsPos.Size = new System.Drawing.Size(73, 13);
            this.lblAbsPos.TabIndex = 19;
            this.lblAbsPos.Text = "Absolute[mm]:";
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.AutoSize = true;
            this.lblCurrentPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPosition.ForeColor = System.Drawing.Color.SeaGreen;
            this.lblCurrentPosition.Location = new System.Drawing.Point(9, 152);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(102, 16);
            this.lblCurrentPosition.TabIndex = 23;
            this.lblCurrentPosition.Text = "Position [mm]";
            // 
            // stepsCounter
            // 
            this.stepsCounter.AutoSize = true;
            this.stepsCounter.BackColor = System.Drawing.Color.Transparent;
            this.stepsCounter.Location = new System.Drawing.Point(10, 101);
            this.stepsCounter.Name = "stepsCounter";
            this.stepsCounter.Size = new System.Drawing.Size(45, 13);
            this.stepsCounter.TabIndex = 24;
            this.stepsCounter.Text = "Steps[s]";
            this.stepsCounter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.stepsCounter.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 94);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(121, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 25;
            // 
            // numDelay
            // 
            this.numDelay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numDelay.Location = new System.Drawing.Point(63, 45);
            this.numDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numDelay.Name = "numDelay";
            this.numDelay.Size = new System.Drawing.Size(57, 16);
            this.numDelay.TabIndex = 31;
            this.numDelay.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numDelay.ValueChanged += new System.EventHandler(this.numDelay_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Delay[ms]";
            // 
            // numSpeed
            // 
            this.numSpeed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numSpeed.DecimalPlaces = 2;
            this.numSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSpeed.Location = new System.Drawing.Point(63, 27);
            this.numSpeed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new System.Drawing.Size(57, 16);
            this.numSpeed.TabIndex = 29;
            this.numSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numSpeed.ValueChanged += new System.EventHandler(this.numSpeed_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Speed";
            // 
            // numStep
            // 
            this.numStep.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numStep.Location = new System.Drawing.Point(65, 10);
            this.numStep.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numStep.Name = "numStep";
            this.numStep.Size = new System.Drawing.Size(55, 16);
            this.numStep.TabIndex = 27;
            this.numStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStep.ValueChanged += new System.EventHandler(this.numDuration_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Step[mm]";
            // 
            // grpSettings
            // 
            this.grpSettings.Controls.Add(this.numStep);
            this.grpSettings.Controls.Add(this.numDelay);
            this.grpSettings.Controls.Add(this.label4);
            this.grpSettings.Controls.Add(this.numSpeed);
            this.grpSettings.Controls.Add(this.label3);
            this.grpSettings.Controls.Add(this.label1);
            this.grpSettings.Location = new System.Drawing.Point(4, 27);
            this.grpSettings.Name = "grpSettings";
            this.grpSettings.Size = new System.Drawing.Size(125, 61);
            this.grpSettings.TabIndex = 32;
            this.grpSettings.TabStop = false;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(9, 168);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(34, 13);
            this.lblTotal.TabIndex = 33;
            this.lblTotal.Text = "Total:";
            // 
            // StepperGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.grpSettings);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.stepsCounter);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.lblCurrentPosition);
            this.Controls.Add(this.txtTag);
            this.Controls.Add(this.lblAbsPos);
            this.Controls.Add(this.lblLevelPos);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.lblTestPos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StepperGui";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(131, 185);
            this.Load += new System.EventHandler(this.StepperGui_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStep)).EndInit();
            this.grpSettings.ResumeLayout(false);
            this.grpSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label txtTag;
        private System.Windows.Forms.Label lblTestPos;
        private System.Windows.Forms.Label lblLevelPos;
        private System.Windows.Forms.Label lblAbsPos;
        private System.Windows.Forms.Label lblCurrentPosition;
        private System.Windows.Forms.Label stepsCounter;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NumericUpDown numDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpSettings;
        private System.Windows.Forms.Label lblTotal;
    }
}
