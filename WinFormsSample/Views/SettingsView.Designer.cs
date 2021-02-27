
namespace WinFormsSample.Views
{
    partial class SettingsView
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPermanentState = new System.Windows.Forms.TextBox();
            this.lblPermanentState = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(60, 47);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(38, 15);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "label1";
            // 
            // txtPermanentState
            // 
            this.txtPermanentState.Location = new System.Drawing.Point(16, 121);
            this.txtPermanentState.Name = "txtPermanentState";
            this.txtPermanentState.Size = new System.Drawing.Size(100, 23);
            this.txtPermanentState.TabIndex = 1;
            // 
            // lblPermanentState
            // 
            this.lblPermanentState.AutoSize = true;
            this.lblPermanentState.Location = new System.Drawing.Point(16, 100);
            this.lblPermanentState.Name = "lblPermanentState";
            this.lblPermanentState.Size = new System.Drawing.Size(97, 15);
            this.lblPermanentState.TabIndex = 2;
            this.lblPermanentState.Text = "Permanent State:";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPermanentState);
            this.Controls.Add(this.txtPermanentState);
            this.Controls.Add(this.lblTitle);
            this.Name = "SettingsView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtPermanentState;
        private System.Windows.Forms.Label lblPermanentState;
    }
}
