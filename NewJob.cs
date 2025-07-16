using System;

using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RLJobCreation_Framework
{

    public partial class NewJob : Form
    {
        public NewJob()
        {
            InitializeComponent();
        }

        private void NewJob_Load(object sender, EventArgs e)
        {
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void JobLocationCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void JobLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void JobNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show("Simple App for Creating Folder\n" +
                            "Structures for RL Projects\n" +
                            "\n" +
                            "Written by Adrian Forrester\n" +
                            "\n" +
                            "adrian.forrester@robertslimbrick.com\nVersion:" + version + "\n");
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewJob));
            this.JobNo = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.JobTitle = new System.Windows.Forms.TextBox();
            this.JobLocationCombo = new System.Windows.Forms.ComboBox();
            this.AboutButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.JobNoLabel = new System.Windows.Forms.Label();
            this.JobTitleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // JobNo
            // 
            this.JobNo.Location = new System.Drawing.Point(111, 75);
            this.JobNo.Name = "JobNo";
            this.JobNo.Size = new System.Drawing.Size(121, 22);
            this.JobNo.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // JobTitle
            // 
            this.JobTitle.Location = new System.Drawing.Point(111, 116);
            this.JobTitle.Name = "JobTitle";
            this.JobTitle.Size = new System.Drawing.Size(235, 22);
            this.JobTitle.TabIndex = 2;
            // 
            // JobLocationCombo
            // 
            this.JobLocationCombo.AutoCompleteCustomSource.AddRange(new string[] {
            "Gloucester",
            "Newport"});
            this.JobLocationCombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.JobLocationCombo.FormattingEnabled = true;
            this.JobLocationCombo.Items.AddRange(new object[] {
            "Gloucester",
            "Newport"});
            this.JobLocationCombo.Location = new System.Drawing.Point(111, 32);
            this.JobLocationCombo.Name = "JobLocationCombo";
            this.JobLocationCombo.Size = new System.Drawing.Size(121, 24);
            this.JobLocationCombo.TabIndex = 3;
            // 
            // AboutButton
            // 
            this.AboutButton.Location = new System.Drawing.Point(12, 15);
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.Size = new System.Drawing.Size(75, 23);
            this.AboutButton.TabIndex = 4;
            this.AboutButton.Text = "About";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(308, 15);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(227, 15);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(75, 23);
            this.CreateButton.TabIndex = 6;
            this.CreateButton.Text = "Create Job";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(18, 35);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(87, 16);
            this.LocationLabel.TabIndex = 7;
            this.LocationLabel.Text = "Job Location:";
            // 
            // JobNoLabel
            // 
            this.JobNoLabel.AutoSize = true;
            this.JobNoLabel.Location = new System.Drawing.Point(18, 78);
            this.JobNoLabel.Name = "JobNoLabel";
            this.JobNoLabel.Size = new System.Drawing.Size(84, 16);
            this.JobNoLabel.TabIndex = 8;
            this.JobNoLabel.Text = "Job Number:";
            // 
            // JobTitleLabel
            // 
            this.JobTitleLabel.AutoSize = true;
            this.JobTitleLabel.Location = new System.Drawing.Point(18, 119);
            this.JobTitleLabel.Name = "JobTitleLabel";
            this.JobTitleLabel.Size = new System.Drawing.Size(62, 16);
            this.JobTitleLabel.TabIndex = 9;
            this.JobTitleLabel.Text = "Job Title:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.CreateButton);
            this.panel1.Controls.Add(this.AboutButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 186);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 50);
            this.panel1.TabIndex = 10;
            // 
            // NewJob
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(395, 236);
            this.Controls.Add(this.JobTitleLabel);
            this.Controls.Add(this.JobNoLabel);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.JobLocationCombo);
            this.Controls.Add(this.JobTitle);
            this.Controls.Add(this.JobNo);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewJob";
            this.Text = "RL Job Directory Creation Tool";
            this.Load += new System.EventHandler(this.NewJob_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox JobNo;
        private ContextMenuStrip contextMenuStrip1;
        private IContainer components;
        private TextBox JobTitle;



        private ComboBox JobLocationCombo;
        private Button AboutButton;
        private new Button CancelButton;
        private Button CreateButton;


        private Label LocationLabel;
        private Label JobNoLabel;
        private Label JobTitleLabel;

        private void CreateButton_Click(object sender, EventArgs e)
        {
            string DriveId = "";
            string RootPath = "";
            string JobName = "";
            string CurrJobNo = JobNo.Text;
            string CompletePath = "";
            string SelectedDrive = JobLocationCombo.SelectedItem?.ToString();


            if (JobLocationCombo.SelectedItem != null)
            {
                if (SelectedDrive == "Gloucester")
                {
#if DEBUG
                    DriveId = "C";
#else
                    DriveId = "X";
#endif
                }
                else if (SelectedDrive == "Newport")
                {
#if DEBUG
                    DriveId = "C";
#else
                    DriveId = "Y";
#endif
                }
                // Pending Changes
                //  else if (SelectedDrive == "London"){
                //      DriveId = "A";
                //  }
            }
            else
            {
                MessageBox.Show("No Job Location Set");
                return;
            }

            int JobNoLen = CurrJobNo.Length;
            if (JobNoLen > 0 && JobNoLen <= 4)
            {
                RootPath = CurrJobNo.Substring(0, 2);
                RootPath = RootPath + "--";
            }
            else if (JobNoLen >= 5)
            {
                RootPath = CurrJobNo.Substring(0, 3);
                RootPath = RootPath + "00";
            }
            else
            {
                MessageBox.Show("Job Number Empty");
                return;
            }

            if (JobTitle.Text.Length > 0)
            {
                string CleanJobName = Regex.Replace(JobTitle.Text, $"[{Regex.Escape(new string(Path.GetInvalidFileNameChars()))}]", "_");
                JobName = JobNo.Text + " - " + CleanJobName;
            }
            else
            {
                MessageBox.Show("Job Title Is Empty");
                return;
            }
            CompletePath = DriveId + ":\\" + RootPath + "\\" + JobName;
            DialogResult result = MessageBox.Show("Confirm Job Path Below:\n" + CompletePath,
                "Confirm Job Creation",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                string ProjectPath = DriveId + ":\\" + RootPath + "\\";
                string WildJobNo = CurrJobNo + "*";
                if (Directory.Exists(ProjectPath))
                {
                    bool DirectoryExists = Directory.GetDirectories(ProjectPath, WildJobNo).Length > 0;
                    if (DirectoryExists)
                    {
                        MessageBox.Show("Job Number Already Exists on System - Please Check Inputs");
                        return;
                    }
                }

                CreatingForm creatingForm = new CreatingForm(CompletePath, JobNo.Text, DriveId, RootPath);
                creatingForm.Show();

            }

            if (result == DialogResult.Cancel)
            {
                MessageBox.Show("Aborting Creation");
            }
        }

        private Panel panel1;
    }
}
