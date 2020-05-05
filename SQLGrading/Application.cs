using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms;

namespace SQLGrading
{
    public partial class Application : Form
    {
        private string sqlPath = string.Empty;
        private List<string> inputList = new List<string>();

        public Application()
        {
            InitializeComponent();
            if (Properties.Settings.Default.sqlPath != string.Empty)
            {
                sqlLabel.Text = "sqlite3.exe loaded.";
                sqlPath = Properties.Settings.Default.sqlPath;
            }
            else
            {
                sqlLabel.Text = "sqlite3.exe not found.";
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Application));
            this.openInputFile = new System.Windows.Forms.OpenFileDialog();
            this.inputButton = new System.Windows.Forms.Button();
            this.openSQLPath = new System.Windows.Forms.OpenFileDialog();
            this.sqlButton = new System.Windows.Forms.Button();
            this.Compile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLabel = new System.Windows.Forms.Label();
            this.sqlLabel = new System.Windows.Forms.Label();
            this.compileLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // inputButton
            // 
            this.inputButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.inputButton.Location = new System.Drawing.Point(12, 81);
            this.inputButton.Name = "inputButton";
            this.inputButton.Size = new System.Drawing.Size(74, 40);
            this.inputButton.TabIndex = 0;
            this.inputButton.Text = "Text files";
            this.inputButton.UseVisualStyleBackColor = true;
            this.inputButton.Click += new System.EventHandler(this.getInputPath);
            // 
            // openSQLPath
            // 
            this.openSQLPath.FileName = "openSQLPath";
            // 
            // sqlButton
            // 
            this.sqlButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.sqlButton.Location = new System.Drawing.Point(12, 24);
            this.sqlButton.Name = "sqlButton";
            this.sqlButton.Size = new System.Drawing.Size(74, 38);
            this.sqlButton.TabIndex = 2;
            this.sqlButton.Text = "SQLite";
            this.sqlButton.UseVisualStyleBackColor = true;
            this.sqlButton.Click += new System.EventHandler(this.getSQLPath);
            // 
            // Compile
            // 
            this.Compile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Compile.Location = new System.Drawing.Point(12, 138);
            this.Compile.Name = "Compile";
            this.Compile.Size = new System.Drawing.Size(74, 38);
            this.Compile.TabIndex = 3;
            this.Compile.Text = "Compile";
            this.Compile.UseVisualStyleBackColor = true;
            this.Compile.Click += new System.EventHandler(this.compileAllFile);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 7;
            // 
            // txtLabel
            // 
            this.txtLabel.AutoSize = true;
            this.txtLabel.Location = new System.Drawing.Point(92, 97);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(85, 13);
            this.txtLabel.TabIndex = 4;
            this.txtLabel.Text = "No File Selected";
            this.txtLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sqlLabel
            // 
            this.sqlLabel.AutoSize = true;
            this.sqlLabel.Location = new System.Drawing.Point(92, 37);
            this.sqlLabel.Name = "sqlLabel";
            this.sqlLabel.Size = new System.Drawing.Size(89, 13);
            this.sqlLabel.TabIndex = 5;
            this.sqlLabel.Text = "No .exe Selected";
            // 
            // compileLabel
            // 
            this.compileLabel.AutoSize = true;
            this.compileLabel.Location = new System.Drawing.Point(92, 151);
            this.compileLabel.Name = "compileLabel";
            this.compileLabel.Size = new System.Drawing.Size(72, 13);
            this.compileLabel.TabIndex = 6;
            this.compileLabel.Text = "Not compiled.";
            // 
            // SaveButton
            // 
            this.SaveButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SaveButton.Location = new System.Drawing.Point(12, 194);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(74, 36);
            this.SaveButton.TabIndex = 8;
            this.SaveButton.Text = "Save settings";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.saveSetting);
            // 
            // SaveStatus
            // 
            this.SaveStatus.AutoSize = true;
            this.SaveStatus.Location = new System.Drawing.Point(92, 206);
            this.SaveStatus.Name = "SaveStatus";
            this.SaveStatus.Size = new System.Drawing.Size(0, 13);
            this.SaveStatus.TabIndex = 9;
            // 
            // Application
            // 
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.SaveStatus);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.compileLabel);
            this.Controls.Add(this.sqlLabel);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Compile);
            this.Controls.Add(this.sqlButton);
            this.Controls.Add(this.inputButton);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Application";
            this.Text = "SQL Compiler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Application_Load(object sender, EventArgs e)
        {
        }

        private void getInputPath(object sender, EventArgs e)
        {
            openInputFile.Filter = "Text files (*.txt)|*.txt";
            openInputFile.FilterIndex = 1;
            openInputFile.Multiselect = true;
            if (Properties.Settings.Default.txtFilesPath != string.Empty)
            {
                openInputFile.InitialDirectory = Properties.Settings.Default.txtFilesPath;
            }
            DialogResult result = openInputFile.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                try
                {
                    foreach (string i in openInputFile.FileNames)
                    {
                        inputList.Add(i);
                    }
                    Properties.Settings.Default.txtFilesPath = Path.GetDirectoryName(inputList[0]);
                    txtLabel.Text = "Text files loaded.";
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void getSQLPath(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (Properties.Settings.Default.sqlPath != string.Empty)
            {
                ofd.InitialDirectory = Properties.Settings.Default.sqlPath;
            }
            if (ofd.ShowDialog() == DialogResult.OK) // Test result.
            {
                try
                {
                    sqlPath = Path.GetDirectoryName(ofd.FileName);
                    Properties.Settings.Default.sqlPath = Path.GetDirectoryName(ofd.FileName);
                    sqlLabel.Text = "sqlite3.exe loaded.";
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void compileAllFile(object sender, EventArgs e)
        {
            string outputPath = Path.GetDirectoryName(inputList[0]) + "\\Result";
            // string batPath = Path.GetDirectoryName(inputList[0]) + "\\Result" + "\\compiler.bat";
            if (Directory.Exists(outputPath))
            {
                try
                {
                    DirectoryInfo di = new DirectoryInfo(outputPath);
                    di.Delete(true);
                }
                catch (Exception)
                {

                }
            }
            Directory.CreateDirectory(outputPath);
            string setPath = "path=" + sqlPath;
            Process p = new Process();
            ProcessStartInfo proc = new ProcessStartInfo
            {
                FileName = @"C:\windows\system32\cmd.exe",
                WorkingDirectory = outputPath
            };
            proc.RedirectStandardInput = true;
            proc.UseShellExecute = false;
            foreach (string i in inputList)
            {

                string dbName = i.Substring(i.LastIndexOf("\\") + 1, i.IndexOf(".") - i.LastIndexOf("\\") - 1) + ".db";
                string input = i;
                string output = outputPath + "\\" + i.Substring(i.LastIndexOf("\\") + 1, i.IndexOf(".") - i.LastIndexOf("\\") - 1) + ".txt";
                string result = "sqlite3 " + dbName + " < " + input + " > " + output;

                p.StartInfo = proc;
                p.Start();

                using (StreamWriter sw = p.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine(setPath);
                        sw.WriteLine(result);
                    }
                }
            }
            compileLabel.Text = "Compiled.";
        }

        private void saveSetting(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            SaveStatus.Text = "Saved.";
        }
    }
}
