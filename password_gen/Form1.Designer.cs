namespace password_gen
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelHeader = new Panel();
            lblTitle = new Label();
            txtPassword = new TextBox();
            groupSettings = new GroupBox();
            numLength = new NumericUpDown();
            lblLength = new Label();
            trackLength = new TrackBar();
            groupCharTypes = new GroupBox();
            cbExcludeSimilar = new CheckBox();
            cbSymbols = new CheckBox();
            cbNumbers = new CheckBox();
            cbLowercase = new CheckBox();
            cbUppercase = new CheckBox();
            panelStrength = new Panel();
            progressStrength = new ProgressBar();
            lblStrength = new Label();
            panelButtons = new Panel();
            btnGenerate = new Button();
            btnCopy = new Button();
            btnClear = new Button();
            panelHeader.SuspendLayout();
            groupSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numLength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackLength).BeginInit();
            groupCharTypes.SuspendLayout();
            panelStrength.SuspendLayout();
            panelButtons.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(834, 40);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(271, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(244, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Password Generator";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Consolas", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtPassword.Location = new Point(212, 65);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(360, 50);
            txtPassword.TabIndex = 1;
            txtPassword.TextAlign = HorizontalAlignment.Center;
            // 
            // groupSettings
            // 
            groupSettings.Controls.Add(numLength);
            groupSettings.Controls.Add(lblLength);
            groupSettings.Controls.Add(trackLength);
            groupSettings.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupSettings.ForeColor = Color.FromArgb(52, 73, 94);
            groupSettings.Location = new Point(21, 134);
            groupSettings.Name = "groupSettings";
            groupSettings.Size = new Size(363, 219);
            groupSettings.TabIndex = 2;
            groupSettings.TabStop = false;
            groupSettings.Text = "Password Settings";
            // 
            // numLength
            // 
            numLength.BorderStyle = BorderStyle.FixedSingle;
            numLength.Location = new Point(27, 151);
            numLength.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
            numLength.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            numLength.Name = "numLength";
            numLength.Size = new Size(180, 31);
            numLength.TabIndex = 4;
            numLength.TextAlign = HorizontalAlignment.Center;
            numLength.Value = new decimal(new int[] { 12, 0, 0, 0 });
            // 
            // lblLength
            // 
            lblLength.AutoSize = true;
            lblLength.Location = new Point(15, 37);
            lblLength.Name = "lblLength";
            lblLength.Size = new Size(76, 25);
            lblLength.TabIndex = 3;
            lblLength.Text = "Length:";
            // 
            // trackLength
            // 
            trackLength.Location = new Point(15, 76);
            trackLength.Maximum = 64;
            trackLength.Minimum = 4;
            trackLength.Name = "trackLength";
            trackLength.Size = new Size(340, 69);
            trackLength.TabIndex = 3;
            trackLength.TickFrequency = 8;
            trackLength.Value = 12;
            trackLength.Scroll += trackLength_Scroll;

            txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            txtPassword.WordWrap = false;
            txtPassword.AcceptsReturn = false;
            txtPassword.AcceptsTab = false;
            // 
            // groupCharTypes
            // 
            groupCharTypes.Controls.Add(cbExcludeSimilar);
            groupCharTypes.Controls.Add(cbSymbols);
            groupCharTypes.Controls.Add(cbNumbers);
            groupCharTypes.Controls.Add(cbLowercase);
            groupCharTypes.Controls.Add(cbUppercase);
            groupCharTypes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupCharTypes.ForeColor = Color.FromArgb(52, 73, 94);
            groupCharTypes.Location = new Point(432, 134);
            groupCharTypes.Name = "groupCharTypes";
            groupCharTypes.Size = new Size(377, 219);
            groupCharTypes.TabIndex = 3;
            groupCharTypes.TabStop = false;
            groupCharTypes.Text = "Character Types";
            // 
            // cbExcludeSimilar
            // 
            cbExcludeSimilar.AutoSize = true;
            cbExcludeSimilar.Location = new Point(17, 170);
            cbExcludeSimilar.Name = "cbExcludeSimilar";
            cbExcludeSimilar.Size = new Size(270, 29);
            cbExcludeSimilar.TabIndex = 8;
            cbExcludeSimilar.Text = "Exclude Similar (0, O, l, I, 1)";
            cbExcludeSimilar.UseVisualStyleBackColor = true;
            // 
            // cbSymbols
            // 
            cbSymbols.AutoSize = true;
            cbSymbols.Location = new Point(17, 135);
            cbSymbols.Name = "cbSymbols";
            cbSymbols.Size = new Size(187, 29);
            cbSymbols.TabIndex = 7;
            cbSymbols.Text = "Symbols (!@#$...)";
            cbSymbols.UseVisualStyleBackColor = true;
            // 
            // cbNumbers
            // 
            cbNumbers.AutoSize = true;
            cbNumbers.Checked = true;
            cbNumbers.CheckState = CheckState.Checked;
            cbNumbers.Location = new Point(17, 100);
            cbNumbers.Name = "cbNumbers";
            cbNumbers.Size = new Size(161, 29);
            cbNumbers.TabIndex = 6;
            cbNumbers.Text = "Numbers (0-9)";
            cbNumbers.UseVisualStyleBackColor = true;
            // 
            // cbLowercase
            // 
            cbLowercase.AutoSize = true;
            cbLowercase.Checked = true;
            cbLowercase.CheckState = CheckState.Checked;
            cbLowercase.Location = new Point(17, 65);
            cbLowercase.Name = "cbLowercase";
            cbLowercase.Size = new Size(171, 29);
            cbLowercase.TabIndex = 5;
            cbLowercase.Text = "Lowercase (a-z)";
            cbLowercase.UseVisualStyleBackColor = true;
            // 
            // cbUppercase
            // 
            cbUppercase.AutoSize = true;
            cbUppercase.Checked = true;
            cbUppercase.CheckState = CheckState.Checked;
            cbUppercase.Location = new Point(17, 30);
            cbUppercase.Name = "cbUppercase";
            cbUppercase.Size = new Size(177, 29);
            cbUppercase.TabIndex = 4;
            cbUppercase.Text = "Uppercase (A-Z)";
            cbUppercase.UseVisualStyleBackColor = true;
            // 
            // panelStrength
            // 
            panelStrength.Controls.Add(progressStrength);
            panelStrength.Controls.Add(lblStrength);
            panelStrength.Location = new Point(21, 373);
            panelStrength.Name = "panelStrength";
            panelStrength.Size = new Size(363, 96);
            panelStrength.TabIndex = 4;
            // 
            // progressStrength
            // 
            progressStrength.Location = new Point(15, 47);
            progressStrength.Name = "progressStrength";
            progressStrength.Size = new Size(340, 34);
            progressStrength.Style = ProgressBarStyle.Continuous;
            progressStrength.TabIndex = 5;
            progressStrength.Click += progressStrength_Click;
            // 
            // lblStrength
            // 
            lblStrength.AutoSize = true;
            lblStrength.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStrength.ForeColor = Color.FromArgb(52, 73, 94);
            lblStrength.Location = new Point(15, 15);
            lblStrength.Name = "lblStrength";
            lblStrength.Size = new Size(91, 25);
            lblStrength.TabIndex = 5;
            lblStrength.Text = "Strength:";
            // 
            // panelButtons
            // 
            panelButtons.Controls.Add(btnGenerate);
            panelButtons.Controls.Add(btnCopy);
            panelButtons.Controls.Add(btnClear);
            panelButtons.Location = new Point(432, 373);
            panelButtons.Name = "panelButtons";
            panelButtons.Size = new Size(377, 55);
            panelButtons.TabIndex = 5;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(231, 76, 60);
            btnGenerate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(253, 11);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(112, 34);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnCopy
            // 
            btnCopy.BackColor = Color.FromArgb(52, 152, 219);
            btnCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCopy.ForeColor = Color.White;
            btnCopy.Location = new Point(135, 11);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(112, 34);
            btnCopy.TabIndex = 7;
            btnCopy.Text = "Copy";
            btnCopy.UseVisualStyleBackColor = false;
            btnCopy.Click += btnCopy_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(46, 204, 113);
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(17, 11);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 8;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 629);
            Controls.Add(panelButtons);
            Controls.Add(panelStrength);
            Controls.Add(groupCharTypes);
            Controls.Add(groupSettings);
            Controls.Add(txtPassword);
            Controls.Add(panelHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Password Generator";
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupSettings.ResumeLayout(false);
            groupSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numLength).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackLength).EndInit();
            groupCharTypes.ResumeLayout(false);
            groupCharTypes.PerformLayout();
            panelStrength.ResumeLayout(false);
            panelStrength.PerformLayout();
            panelButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Label lblTitle;
        private TextBox txtPassword;
        private GroupBox groupSettings;
        private Label lblLength;
        private TrackBar trackLength;
        private NumericUpDown numLength;
        private GroupBox groupCharTypes;
        private CheckBox cbExcludeSimilar;
        private CheckBox cbSymbols;
        private CheckBox cbNumbers;
        private CheckBox cbLowercase;
        private CheckBox cbUppercase;
        private Panel panelStrength;
        private ProgressBar progressStrength;
        private Label lblStrength;
        private Panel panelButtons;
        private Button btnGenerate;
        private Button btnCopy;
        private Button btnClear;
    }
}

