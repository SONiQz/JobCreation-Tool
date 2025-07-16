using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace RLJobCreation_Framework
{
    public partial class CreatingForm : Form
    {
        private string CompletePath;
        private string JobNo;
        private string DriveID;
        private string RootPath;

        public CreatingForm(string completePath, string jobNo, string driveID, string rootPath)
        {
            InitializeComponent();

            // Assign parameters to class-level variables
            this.CompletePath = completePath;
            this.JobNo = jobNo;
            this.DriveID = driveID;
            this.RootPath = rootPath;

            this.Load += new EventHandler(CreateForm_Load);
        }

        private void CreateForm_Load(object sender, EventArgs e)
        {

            string StaticPath = CompletePath + "\\" + JobNo + " - ";

            List<string> pathList = PathList.DirectoriesToCreate();

            string ProjectPath = DriveID + ":\\" + RootPath + "\\";

            foreach (string DirectoryPath in pathList)
            {
                try
                {
                    // Check if the directory already exists
                    if (Directory.Exists(StaticPath + DirectoryPath))
                    {
                        CreatingBox.AppendText($"Directory '{StaticPath + DirectoryPath}' already exists.\r\n");
                    }
                    else
                    {
                        // Try to create the directory if it does not exist
                        DirectoryInfo directoryInfo = Directory.CreateDirectory(StaticPath + DirectoryPath);
                        DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

                        FileSystemAccessRule accessRule = new FileSystemAccessRule(
                            "Domain Users",
                            FileSystemRights.Read |
                            FileSystemRights.Write |
                            FileSystemRights.ExecuteFile,          // Read, Write, and Execute permissions
                            InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, // Apply to subfolders and files
                            PropagationFlags.None,                 // Propagation flags
                            AccessControlType.Allow
                         );

                        directorySecurity.AddAccessRule(accessRule);
                        directoryInfo.SetAccessControl(directorySecurity);


                        // Check again if the directory exists after creation
                        if (Directory.Exists(StaticPath + DirectoryPath))
                        {
                            CreatingBox.AppendText($"Directory '{StaticPath + DirectoryPath}' created successfully.\r\n");
                        }
                        else
                        {
                            CreatingBox.AppendText($"Failed to create directory: {DirectoryPath}\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Catch any errors and display them in the text box
                    CreatingBox.AppendText($"Error creating directory '{DirectoryPath}': {ex.Message}\r\n");
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreatingForm));
            this.CreatingBox = new System.Windows.Forms.TextBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.CreatePanel = new System.Windows.Forms.Panel();
            this.CreatePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CreatingBox
            // 
            this.CreatingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CreatingBox.Location = new System.Drawing.Point(0, 0);
            this.CreatingBox.Multiline = true;
            this.CreatingBox.Name = "CreatingBox";
            this.CreatingBox.ReadOnly = true;
            this.CreatingBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CreatingBox.Size = new System.Drawing.Size(840, 266);
            this.CreatingBox.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.Location = new System.Drawing.Point(753, 15);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CreatePanel
            // 
            this.CreatePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CreatePanel.Controls.Add(this.CloseButton);
            this.CreatePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CreatePanel.Location = new System.Drawing.Point(0, 266);
            this.CreatePanel.Name = "CreatePanel";
            this.CreatePanel.Size = new System.Drawing.Size(840, 50);
            this.CreatePanel.TabIndex = 2;
            // 
            // CreatingForm
            // 
            this.ClientSize = new System.Drawing.Size(840, 316);
            this.Controls.Add(this.CreatingBox);
            this.Controls.Add(this.CreatePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreatingForm";
            this.Text = "Creating Folders";
            this.CreatePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private TextBox CreatingBox;
        private Button CloseButton;
        private Panel CreatePanel;
    }
}

