namespace SQLGrading
{
    partial class Application
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

        private System.Windows.Forms.OpenFileDialog openInputFile;
        private System.Windows.Forms.Button inputButton;
        private System.Windows.Forms.OpenFileDialog openSQLPath;
        private System.Windows.Forms.Button sqlButton;
        private System.Windows.Forms.Button Compile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtLabel;
        private System.Windows.Forms.Label sqlLabel;
        private System.Windows.Forms.Label compileLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label SaveStatus;
    }
}

