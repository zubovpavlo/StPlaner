
namespace StPlaner.Forms
{
    partial class CourseForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblCourseName;
        private System.Windows.Forms.TextBox txtCourseName;
        private System.Windows.Forms.Label lblECTS;
        private System.Windows.Forms.NumericUpDown numECTS;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label lblStatus;

        private void InitializeComponent()
        {
            this.lblCourseName = new System.Windows.Forms.Label();
            this.txtCourseName = new System.Windows.Forms.TextBox();
            this.lblECTS = new System.Windows.Forms.Label();
            this.numECTS = new System.Windows.Forms.NumericUpDown();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numECTS)).BeginInit();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCourseName
            // 
            this.lblCourseName.AutoSize = true;
            this.lblCourseName.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblCourseName.Location = new System.Drawing.Point(12, 15);
            this.lblCourseName.Name = "lblCourseName";
            this.lblCourseName.Size = new System.Drawing.Size(105, 16);
            this.lblCourseName.TabIndex = 0;
            this.lblCourseName.Text = "Course Name:";
            // 
            // txtCourseName
            // 
            this.txtCourseName.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCourseName.Location = new System.Drawing.Point(180, 12);
            this.txtCourseName.Name = "txtCourseName";
            this.txtCourseName.Size = new System.Drawing.Size(226, 23);
            this.txtCourseName.TabIndex = 1;
            // 
            // lblECTS
            // 
            this.lblECTS.AutoSize = true;
            this.lblECTS.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblECTS.Location = new System.Drawing.Point(12, 41);
            this.lblECTS.Name = "lblECTS";
            this.lblECTS.Size = new System.Drawing.Size(47, 16);
            this.lblECTS.TabIndex = 2;
            this.lblECTS.Text = "ECTS:";
            // 
            // numECTS
            // 
            this.numECTS.Font = new System.Drawing.Font("Arial", 10F);
            this.numECTS.Location = new System.Drawing.Point(180, 39);
            this.numECTS.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numECTS.Name = "numECTS";
            this.numECTS.Size = new System.Drawing.Size(226, 23);
            this.numECTS.TabIndex = 3;
            this.numECTS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numECTS.ValueChanged += new System.EventHandler(this.numECTS_ValueChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblStartDate.Location = new System.Drawing.Point(12, 67);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(80, 16);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "Start Date:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Arial", 10F);
            this.dtpStartDate.Location = new System.Drawing.Point(180, 67);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(226, 23);
            this.dtpStartDate.TabIndex = 5;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblEndDate.Location = new System.Drawing.Point(12, 93);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(74, 16);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "End Date:";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Font = new System.Drawing.Font("Arial", 10F);
            this.dtpEndDate.Location = new System.Drawing.Point(180, 94);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(226, 23);
            this.dtpEndDate.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(15, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(391, 35);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelHeader.Controls.Add(this.lblCourseName);
            this.panelHeader.Controls.Add(this.lblProgress);
            this.panelHeader.Controls.Add(this.txtCourseName);
            this.panelHeader.Controls.Add(this.btnSave);
            this.panelHeader.Controls.Add(this.dtpEndDate);
            this.panelHeader.Controls.Add(this.lblECTS);
            this.panelHeader.Controls.Add(this.lblEndDate);
            this.panelHeader.Controls.Add(this.numECTS);
            this.panelHeader.Controls.Add(this.dtpStartDate);
            this.panelHeader.Controls.Add(this.lblStartDate);
            this.panelHeader.Controls.Add(this.cbStatus);
            this.panelHeader.Controls.Add(this.lblStatus);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(418, 192);
            this.panelHeader.TabIndex = 10;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblProgress.Location = new System.Drawing.Point(12, 120);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(75, 16);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "Progress:";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Arial", 10F);
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Povinné (A)",
            "Povinně volitelné (B)",
            "Volitelné (C)"});
            this.cbStatus.Location = new System.Drawing.Point(180, 120);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(226, 24);
            this.cbStatus.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(12, 123);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(55, 16);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Status:";
            // 
            // CourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 192);
            this.Controls.Add(this.panelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CourseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Course";
            ((System.ComponentModel.ISupportInitialize)(this.numECTS)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
