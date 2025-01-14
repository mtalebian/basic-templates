﻿
namespace WinFormsApp1
{
    partial class SrourceFileControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SrourceFileControl));
            this.txtCode = new System.Windows.Forms.TextBox();
            this.bCopyIfNew = new System.Windows.Forms.Button();
            this.bOpen = new System.Windows.Forms.Button();
            this.bEntity = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.bCopy = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCode.Location = new System.Drawing.Point(0, 90);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCode.Size = new System.Drawing.Size(974, 586);
            this.txtCode.TabIndex = 11;
            this.txtCode.WordWrap = false;
            // 
            // bCopyIfNew
            // 
            this.bCopyIfNew.Location = new System.Drawing.Point(304, 34);
            this.bCopyIfNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bCopyIfNew.Name = "bCopyIfNew";
            this.bCopyIfNew.Size = new System.Drawing.Size(142, 45);
            this.bCopyIfNew.TabIndex = 8;
            this.bCopyIfNew.Text = "Create If New";
            this.bCopyIfNew.UseVisualStyleBackColor = true;
            this.bCopyIfNew.Click += new System.EventHandler(this.bCreateIfNew_Click);
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(154, 34);
            this.bOpen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(86, 45);
            this.bOpen.TabIndex = 9;
            this.bOpen.Text = "Open";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // bEntity
            // 
            this.bEntity.Location = new System.Drawing.Point(9, 34);
            this.bEntity.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bEntity.Name = "bEntity";
            this.bEntity.Size = new System.Drawing.Size(86, 45);
            this.bEntity.TabIndex = 10;
            this.bEntity.Text = "Browse";
            this.bEntity.UseVisualStyleBackColor = true;
            this.bEntity.Click += new System.EventHandler(this.bEntity_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFolder.Location = new System.Drawing.Point(0, 0);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(974, 27);
            this.txtFolder.TabIndex = 7;
            // 
            // bCopy
            // 
            this.bCopy.Image = ((System.Drawing.Image)(resources.GetObject("bCopy.Image")));
            this.bCopy.Location = new System.Drawing.Point(101, 34);
            this.bCopy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(46, 45);
            this.bCopy.TabIndex = 9;
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFolder);
            this.panel1.Controls.Add(this.bEntity);
            this.panel1.Controls.Add(this.bCopyIfNew);
            this.panel1.Controls.Add(this.bOpen);
            this.panel1.Controls.Add(this.bCopy);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(974, 90);
            this.panel1.TabIndex = 12;
            // 
            // SrourceFileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SrourceFileControl";
            this.Size = new System.Drawing.Size(974, 676);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button bCopyIfNew;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bEntity;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.Panel panel1;
    }
}
