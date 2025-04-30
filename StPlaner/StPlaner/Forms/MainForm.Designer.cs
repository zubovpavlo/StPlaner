namespace StPlaner.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPersonalSchedule;
        private System.Windows.Forms.DataGridView dgvCourses;
        private System.Windows.Forms.GroupBox groupBoxCourses;
        private System.Windows.Forms.GroupBox groupBoxSchedule;
        private System.Windows.Forms.Button btnAddCourse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCourseFilter;
        private System.Windows.Forms.Label lblCourseFilter;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnDeleteAccount;

        /// <summary>
        /// Releases all resources used by the component.
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

        /// <summary>
        /// Initializes the form components.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPersonalSchedule = new System.Windows.Forms.DataGridView();
            this.dgvCourses = new System.Windows.Forms.DataGridView();
            this.groupBoxCourses = new System.Windows.Forms.GroupBox();
            this.groupBoxSchedule = new System.Windows.Forms.GroupBox();
            this.btnAddCourse = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCourseFilter = new System.Windows.Forms.TextBox();
            this.lblCourseFilter = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnDeleteAccount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalSchedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).BeginInit();
            this.groupBoxCourses.SuspendLayout();
            this.groupBoxSchedule.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPersonalSchedule
            // 
            this.dgvPersonalSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPersonalSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPersonalSchedule.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPersonalSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonalSchedule.Location = new System.Drawing.Point(6, 19);
            this.dgvPersonalSchedule.Name = "dgvPersonalSchedule";
            this.dgvPersonalSchedule.Size = new System.Drawing.Size(1071, 200);
            this.dgvPersonalSchedule.TabIndex = 2;
            // 
            // dgvCourses
            // 
            this.dgvCourses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCourses.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCourses.Location = new System.Drawing.Point(6, 19);
            this.dgvCourses.Name = "dgvCourses";
            this.dgvCourses.Size = new System.Drawing.Size(1071, 150);
            this.dgvCourses.TabIndex = 3;
            this.dgvCourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellContentClick);
            this.dgvCourses.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellMouseEnter);
            this.dgvCourses.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCourses_CellMouseLeave);
            this.dgvCourses.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvCourses_CellPainting);
            // 
            // groupBoxCourses
            // 
            this.groupBoxCourses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCourses.Controls.Add(this.dgvCourses);
            this.groupBoxCourses.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxCourses.Location = new System.Drawing.Point(12, 67);
            this.groupBoxCourses.Name = "groupBoxCourses";
            this.groupBoxCourses.Size = new System.Drawing.Size(1083, 175);
            this.groupBoxCourses.TabIndex = 5;
            this.groupBoxCourses.TabStop = false;
            this.groupBoxCourses.Text = "Courses";
            // 
            // groupBoxSchedule
            // 
            this.groupBoxSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSchedule.Controls.Add(this.dgvPersonalSchedule);
            this.groupBoxSchedule.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxSchedule.Location = new System.Drawing.Point(12, 248);
            this.groupBoxSchedule.Name = "groupBoxSchedule";
            this.groupBoxSchedule.Size = new System.Drawing.Size(1083, 225);
            this.groupBoxSchedule.TabIndex = 6;
            this.groupBoxSchedule.TabStop = false;
            this.groupBoxSchedule.Text = "Study Schedule";
            // 
            // btnAddCourse
            // 
            this.btnAddCourse.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddCourse.FlatAppearance.BorderSize = 0;
            this.btnAddCourse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCourse.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddCourse.ForeColor = System.Drawing.Color.White;
            this.btnAddCourse.Location = new System.Drawing.Point(12, 12);
            this.btnAddCourse.Name = "btnAddCourse";
            this.btnAddCourse.Size = new System.Drawing.Size(100, 30);
            this.btnAddCourse.TabIndex = 0;
            this.btnAddCourse.Text = "Add Course";
            this.btnAddCourse.UseVisualStyleBackColor = false;
            this.btnAddCourse.Click += new System.EventHandler(this.btnAddCourse_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SeaGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(120, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCourseFilter
            // 
            this.txtCourseFilter.Font = new System.Drawing.Font("Arial", 10F);
            this.txtCourseFilter.Location = new System.Drawing.Point(685, 16);
            this.txtCourseFilter.Name = "txtCourseFilter";
            this.txtCourseFilter.Size = new System.Drawing.Size(182, 23);
            this.txtCourseFilter.TabIndex = 4;
            this.txtCourseFilter.TextChanged += new System.EventHandler(this.txtCourseFilter_TextChanged);
            // 
            // lblCourseFilter
            // 
            this.lblCourseFilter.AutoSize = true;
            this.lblCourseFilter.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lblCourseFilter.Location = new System.Drawing.Point(568, 19);
            this.lblCourseFilter.Name = "lblCourseFilter";
            this.lblCourseFilter.Size = new System.Drawing.Size(99, 16);
            this.lblCourseFilter.TabIndex = 7;
            this.lblCourseFilter.Text = "Course Filter";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.Firebrick;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1020, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 30);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnDeleteAccount
            // 
            this.btnDeleteAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAccount.BackColor = System.Drawing.Color.Crimson;
            this.btnDeleteAccount.FlatAppearance.BorderSize = 0;
            this.btnDeleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAccount.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteAccount.ForeColor = System.Drawing.Color.White;
            this.btnDeleteAccount.Location = new System.Drawing.Point(923, 12);
            this.btnDeleteAccount.Name = "btnDeleteAccount";
            this.btnDeleteAccount.Size = new System.Drawing.Size(90, 30);
            this.btnDeleteAccount.TabIndex = 9;
            this.btnDeleteAccount.Text = "Delete acc";
            this.btnDeleteAccount.UseVisualStyleBackColor = false;
            this.btnDeleteAccount.Click += new System.EventHandler(this.btnDeleteAccount_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1107, 485);
            this.Controls.Add(this.btnDeleteAccount);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblCourseFilter);
            this.Controls.Add(this.groupBoxSchedule);
            this.Controls.Add(this.groupBoxCourses);
            this.Controls.Add(this.txtCourseFilter);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnAddCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StPlaner";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonalSchedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCourses)).EndInit();
            this.groupBoxCourses.ResumeLayout(false);
            this.groupBoxSchedule.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
