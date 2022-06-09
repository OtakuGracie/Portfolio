namespace PokemonHGSSMoveEditor
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.moveComboBx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.powerMaskTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.accuracyMaskTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ppMaskTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.typeComboBx = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.effectMaskTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.effectChanceMaskTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.categoryComboBx = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.classComboBx = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.targetComboBx = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.priorityMaskTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.flag1MaskTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.flag2MaskTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.flag3MaskTxtBx = new System.Windows.Forms.MaskedTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.contestComboBx = new System.Windows.Forms.ComboBox();
            this.resetButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsPatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMoveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // moveComboBx
            // 
            this.moveComboBx.FormattingEnabled = true;
            this.moveComboBx.Location = new System.Drawing.Point(305, 52);
            this.moveComboBx.MaxDropDownItems = 10;
            this.moveComboBx.MaxLength = 20;
            this.moveComboBx.Name = "moveComboBx";
            this.moveComboBx.Size = new System.Drawing.Size(121, 21);
            this.moveComboBx.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Move:";
            // 
            // powerMaskTxtBx
            // 
            this.powerMaskTxtBx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.powerMaskTxtBx.HidePromptOnLeave = true;
            this.powerMaskTxtBx.Location = new System.Drawing.Point(87, 144);
            this.powerMaskTxtBx.Mask = "900";
            this.powerMaskTxtBx.Name = "powerMaskTxtBx";
            this.powerMaskTxtBx.PromptChar = ' ';
            this.powerMaskTxtBx.Size = new System.Drawing.Size(100, 20);
            this.powerMaskTxtBx.TabIndex = 1;
            this.powerMaskTxtBx.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Power:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Accuracy:";
            // 
            // accuracyMaskTxtBx
            // 
            this.accuracyMaskTxtBx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.accuracyMaskTxtBx.HidePromptOnLeave = true;
            this.accuracyMaskTxtBx.Location = new System.Drawing.Point(207, 144);
            this.accuracyMaskTxtBx.Mask = "%900";
            this.accuracyMaskTxtBx.Name = "accuracyMaskTxtBx";
            this.accuracyMaskTxtBx.PromptChar = ' ';
            this.accuracyMaskTxtBx.Size = new System.Drawing.Size(100, 20);
            this.accuracyMaskTxtBx.TabIndex = 2;
            this.accuracyMaskTxtBx.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(323, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "PP:";
            // 
            // ppMaskTxtBx
            // 
            this.ppMaskTxtBx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.ppMaskTxtBx.HidePromptOnLeave = true;
            this.ppMaskTxtBx.Location = new System.Drawing.Point(326, 144);
            this.ppMaskTxtBx.Mask = "90";
            this.ppMaskTxtBx.Name = "ppMaskTxtBx";
            this.ppMaskTxtBx.PromptChar = ' ';
            this.ppMaskTxtBx.Size = new System.Drawing.Size(100, 20);
            this.ppMaskTxtBx.TabIndex = 3;
            this.ppMaskTxtBx.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // typeComboBx
            // 
            this.typeComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBx.FormattingEnabled = true;
            this.typeComboBx.Location = new System.Drawing.Point(450, 144);
            this.typeComboBx.Name = "typeComboBx";
            this.typeComboBx.Size = new System.Drawing.Size(100, 21);
            this.typeComboBx.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(450, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Type:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Effect:";
            // 
            // effectMaskTxtBx
            // 
            this.effectMaskTxtBx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.effectMaskTxtBx.HidePromptOnLeave = true;
            this.effectMaskTxtBx.Location = new System.Drawing.Point(84, 224);
            this.effectMaskTxtBx.Mask = "900";
            this.effectMaskTxtBx.Name = "effectMaskTxtBx";
            this.effectMaskTxtBx.PromptChar = ' ';
            this.effectMaskTxtBx.Size = new System.Drawing.Size(100, 20);
            this.effectMaskTxtBx.TabIndex = 6;
            this.effectMaskTxtBx.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(207, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Effect Chance:";
            // 
            // effectChanceMaskTxtBx
            // 
            this.effectChanceMaskTxtBx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.effectChanceMaskTxtBx.HidePromptOnLeave = true;
            this.effectChanceMaskTxtBx.Location = new System.Drawing.Point(207, 224);
            this.effectChanceMaskTxtBx.Mask = "%900";
            this.effectChanceMaskTxtBx.Name = "effectChanceMaskTxtBx";
            this.effectChanceMaskTxtBx.PromptChar = ' ';
            this.effectChanceMaskTxtBx.Size = new System.Drawing.Size(100, 20);
            this.effectChanceMaskTxtBx.TabIndex = 7;
            this.effectChanceMaskTxtBx.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(569, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Category:";
            // 
            // categoryComboBx
            // 
            this.categoryComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBx.FormattingEnabled = true;
            this.categoryComboBx.Location = new System.Drawing.Point(569, 144);
            this.categoryComboBx.MaxDropDownItems = 3;
            this.categoryComboBx.Name = "categoryComboBx";
            this.categoryComboBx.Size = new System.Drawing.Size(100, 21);
            this.categoryComboBx.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(84, 306);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Class:";
            // 
            // classComboBx
            // 
            this.classComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBx.FormattingEnabled = true;
            this.classComboBx.Location = new System.Drawing.Point(84, 339);
            this.classComboBx.MaxDropDownItems = 2;
            this.classComboBx.Name = "classComboBx";
            this.classComboBx.Size = new System.Drawing.Size(100, 21);
            this.classComboBx.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(326, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Target:";
            // 
            // targetComboBx
            // 
            this.targetComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.targetComboBx.FormattingEnabled = true;
            this.targetComboBx.Location = new System.Drawing.Point(326, 225);
            this.targetComboBx.MaxDropDownItems = 9;
            this.targetComboBx.Name = "targetComboBx";
            this.targetComboBx.Size = new System.Drawing.Size(100, 21);
            this.targetComboBx.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(450, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Priority:";
            // 
            // priorityMaskTxtBx
            // 
            this.priorityMaskTxtBx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.priorityMaskTxtBx.HidePromptOnLeave = true;
            this.priorityMaskTxtBx.Location = new System.Drawing.Point(450, 224);
            this.priorityMaskTxtBx.Mask = "#9";
            this.priorityMaskTxtBx.Name = "priorityMaskTxtBx";
            this.priorityMaskTxtBx.PromptChar = ' ';
            this.priorityMaskTxtBx.Size = new System.Drawing.Size(100, 20);
            this.priorityMaskTxtBx.TabIndex = 9;
            this.priorityMaskTxtBx.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(207, 306);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Flag1:";
            // 
            // flag1MaskTxtBx
            // 
            this.flag1MaskTxtBx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.flag1MaskTxtBx.HidePromptOnLeave = true;
            this.flag1MaskTxtBx.Location = new System.Drawing.Point(207, 338);
            this.flag1MaskTxtBx.Mask = "900";
            this.flag1MaskTxtBx.Name = "flag1MaskTxtBx";
            this.flag1MaskTxtBx.PromptChar = ' ';
            this.flag1MaskTxtBx.Size = new System.Drawing.Size(100, 20);
            this.flag1MaskTxtBx.TabIndex = 12;
            this.flag1MaskTxtBx.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(326, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Flag2:";
            // 
            // flag2MaskTxtBx
            // 
            this.flag2MaskTxtBx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.flag2MaskTxtBx.HidePromptOnLeave = true;
            this.flag2MaskTxtBx.Location = new System.Drawing.Point(326, 338);
            this.flag2MaskTxtBx.Mask = "900";
            this.flag2MaskTxtBx.Name = "flag2MaskTxtBx";
            this.flag2MaskTxtBx.PromptChar = ' ';
            this.flag2MaskTxtBx.Size = new System.Drawing.Size(100, 20);
            this.flag2MaskTxtBx.TabIndex = 13;
            this.flag2MaskTxtBx.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(450, 306);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Flag3:";
            // 
            // flag3MaskTxtBx
            // 
            this.flag3MaskTxtBx.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.flag3MaskTxtBx.HidePromptOnLeave = true;
            this.flag3MaskTxtBx.Location = new System.Drawing.Point(450, 338);
            this.flag3MaskTxtBx.Mask = "900";
            this.flag3MaskTxtBx.Name = "flag3MaskTxtBx";
            this.flag3MaskTxtBx.PromptChar = ' ';
            this.flag3MaskTxtBx.Size = new System.Drawing.Size(100, 20);
            this.flag3MaskTxtBx.TabIndex = 14;
            this.flag3MaskTxtBx.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(569, 191);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Contest condition:";
            // 
            // contestComboBx
            // 
            this.contestComboBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.contestComboBx.FormattingEnabled = true;
            this.contestComboBx.Location = new System.Drawing.Point(569, 224);
            this.contestComboBx.MaxDropDownItems = 3;
            this.contestComboBx.Name = "contestComboBx";
            this.contestComboBx.Size = new System.Drawing.Size(100, 21);
            this.contestComboBx.TabIndex = 10;
            // 
            // resetButton
            // 
            this.resetButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.resetButton.Location = new System.Drawing.Point(324, 423);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 15;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(734, 24);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveAsFileToolStripMenuItem,
            this.saveAsPatchToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveAsFileToolStripMenuItem
            // 
            this.saveAsFileToolStripMenuItem.Name = "saveAsFileToolStripMenuItem";
            this.saveAsFileToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveAsFileToolStripMenuItem.Text = "Save as file";
            this.saveAsFileToolStripMenuItem.Click += new System.EventHandler(this.saveAsFileToolStripMenuItem_Click);
            // 
            // saveAsPatchToolStripMenuItem
            // 
            this.saveAsPatchToolStripMenuItem.Name = "saveAsPatchToolStripMenuItem";
            this.saveAsPatchToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveAsPatchToolStripMenuItem.Text = "Save as patch";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTypeToolStripMenuItem,
            this.newMoveToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // newTypeToolStripMenuItem
            // 
            this.newTypeToolStripMenuItem.Name = "newTypeToolStripMenuItem";
            this.newTypeToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.newTypeToolStripMenuItem.Text = "New Type";
            this.newTypeToolStripMenuItem.Click += new System.EventHandler(this.newTypeToolStripMenuItem_Click);
            // 
            // newMoveToolStripMenuItem
            // 
            this.newMoveToolStripMenuItem.Name = "newMoveToolStripMenuItem";
            this.newMoveToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.newMoveToolStripMenuItem.Text = "New Move";
            this.newMoveToolStripMenuItem.Click += new System.EventHandler(this.newMoveToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.resetButton;
            this.ClientSize = new System.Drawing.Size(734, 506);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.contestComboBx);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.flag3MaskTxtBx);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.flag2MaskTxtBx);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.flag1MaskTxtBx);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.priorityMaskTxtBx);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.targetComboBx);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.classComboBx);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.categoryComboBx);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.effectChanceMaskTxtBx);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.effectMaskTxtBx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.typeComboBx);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ppMaskTxtBx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.accuracyMaskTxtBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.powerMaskTxtBx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moveComboBx);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mainForm";
            this.Text = "Pokemon HGSS Move Editor";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox moveComboBx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox powerMaskTxtBx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox accuracyMaskTxtBx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox ppMaskTxtBx;
        private System.Windows.Forms.ComboBox typeComboBx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox effectMaskTxtBx;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox effectChanceMaskTxtBx;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox categoryComboBx;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox classComboBx;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox targetComboBx;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox priorityMaskTxtBx;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox flag1MaskTxtBx;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox flag2MaskTxtBx;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox flag3MaskTxtBx;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox contestComboBx;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsPatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMoveToolStripMenuItem;
    }
}

