﻿namespace Triangles.Views.Windows.MainWindow
{
    partial class MainWindow
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainMenu = new MenuStrip();
            menuItemFile = new ToolStripMenuItem();
            menuItemLoad = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            menuItemClose = new ToolStripMenuItem();
            оПрограммеToolStripMenuItem = new ToolStripMenuItem();
            тЗToolStripMenuItem = new ToolStripMenuItem();
            panelMessage = new Panel();
            lblMessage = new Label();
            pictureBoxMain = new PictureBox();
            mainMenu.SuspendLayout();
            panelMessage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).BeginInit();
            SuspendLayout();
            // 
            // mainMenu
            // 
            mainMenu.ImageScalingSize = new Size(24, 24);
            mainMenu.Items.AddRange(new ToolStripItem[] { menuItemFile, оПрограммеToolStripMenuItem });
            mainMenu.Location = new Point(0, 0);
            mainMenu.Name = "mainMenu";
            mainMenu.Size = new Size(800, 33);
            mainMenu.TabIndex = 1;
            mainMenu.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            menuItemFile.DropDownItems.AddRange(new ToolStripItem[] { menuItemLoad, toolStripMenuItem1, menuItemClose });
            menuItemFile.Name = "menuItemFile";
            menuItemFile.Size = new Size(69, 29);
            menuItemFile.Text = "Файл";
            // 
            // menuItemLoad
            // 
            menuItemLoad.Name = "menuItemLoad";
            menuItemLoad.Size = new Size(194, 34);
            menuItemLoad.Text = "Загрузить";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(191, 6);
            // 
            // menuItemClose
            // 
            menuItemClose.Name = "menuItemClose";
            menuItemClose.Size = new Size(194, 34);
            menuItemClose.Text = "Закрыть";
            // 
            // оПрограммеToolStripMenuItem
            // 
            оПрограммеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { тЗToolStripMenuItem });
            оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            оПрограммеToolStripMenuItem.Size = new Size(141, 29);
            оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // тЗToolStripMenuItem
            // 
            тЗToolStripMenuItem.Name = "тЗToolStripMenuItem";
            тЗToolStripMenuItem.Size = new Size(270, 34);
            тЗToolStripMenuItem.Text = "ТЗ";
            // 
            // panelMessage
            // 
            panelMessage.AutoSize = true;
            panelMessage.Controls.Add(lblMessage);
            panelMessage.Dock = DockStyle.Top;
            panelMessage.Location = new Point(0, 33);
            panelMessage.Margin = new Padding(10);
            panelMessage.Name = "panelMessage";
            panelMessage.Size = new Size(800, 32);
            panelMessage.TabIndex = 3;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblMessage.ForeColor = SystemColors.HotTrack;
            lblMessage.Location = new Point(12, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(83, 32);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "label1";
            // 
            // pictureBoxMain
            // 
            pictureBoxMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBoxMain.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxMain.Location = new Point(12, 78);
            pictureBoxMain.Name = "pictureBoxMain";
            pictureBoxMain.Size = new Size(776, 360);
            pictureBoxMain.TabIndex = 4;
            pictureBoxMain.TabStop = false;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBoxMain);
            Controls.Add(panelMessage);
            Controls.Add(mainMenu);
            Name = "MainWindow";
            Text = "MainWindow";
            mainMenu.ResumeLayout(false);
            mainMenu.PerformLayout();
            panelMessage.ResumeLayout(false);
            panelMessage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem menuItemFile;
        private ToolStripMenuItem menuItemLoad;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem menuItemClose;
        private ToolStripMenuItem оПрограммеToolStripMenuItem;
        private ToolStripMenuItem тЗToolStripMenuItem;
        private Panel panelMessage;
        private Label lblMessage;
        private PictureBox pictureBoxMain;
    }
}