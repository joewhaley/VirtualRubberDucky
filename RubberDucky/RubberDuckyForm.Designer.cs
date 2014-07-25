namespace RubberDucky
{
    partial class RubberDuckyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RubberDuckyForm));
            this.inputSimulatorButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.classLabel = new System.Windows.Forms.Label();
            this.titleValueLabel = new System.Windows.Forms.Label();
            this.classValueLabel = new System.Windows.Forms.Label();
            this.openScriptButton = new System.Windows.Forms.Button();
            this.scriptFileNameLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.useDirectInputCheckBox = new System.Windows.Forms.CheckBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.delayTextBox = new System.Windows.Forms.TextBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.typingDelayLabel = new System.Windows.Forms.Label();
            this.typingDelayTextBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.crossPictureBox = new System.Windows.Forms.PictureBox();
            this.snarfDataButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.stealthCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // inputSimulatorButton
            // 
            this.inputSimulatorButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.inputSimulatorButton.Location = new System.Drawing.Point(207, 215);
            this.inputSimulatorButton.Name = "inputSimulatorButton";
            this.inputSimulatorButton.Size = new System.Drawing.Size(85, 23);
            this.inputSimulatorButton.TabIndex = 1;
            this.inputSimulatorButton.Text = "GO";
            this.inputSimulatorButton.UseVisualStyleBackColor = true;
            this.inputSimulatorButton.Click += new System.EventHandler(this.inputSimulator_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(12, 40);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(38, 13);
            this.titleLabel.TabIndex = 8;
            this.titleLabel.Text = "Name:";
            // 
            // classLabel
            // 
            this.classLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.classLabel.AutoSize = true;
            this.classLabel.Location = new System.Drawing.Point(16, 19);
            this.classLabel.Name = "classLabel";
            this.classLabel.Size = new System.Drawing.Size(34, 13);
            this.classLabel.TabIndex = 9;
            this.classLabel.Text = "Type:";
            // 
            // titleValueLabel
            // 
            this.titleValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.titleValueLabel.AutoSize = true;
            this.titleValueLabel.Location = new System.Drawing.Point(48, 40);
            this.titleValueLabel.MaximumSize = new System.Drawing.Size(210, 13);
            this.titleValueLabel.Name = "titleValueLabel";
            this.titleValueLabel.Size = new System.Drawing.Size(74, 13);
            this.titleValueLabel.TabIndex = 10;
            this.titleValueLabel.Text = "<window title>";
            // 
            // classValueLabel
            // 
            this.classValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.classValueLabel.AutoSize = true;
            this.classValueLabel.Location = new System.Drawing.Point(48, 19);
            this.classValueLabel.MaximumSize = new System.Drawing.Size(210, 13);
            this.classValueLabel.Name = "classValueLabel";
            this.classValueLabel.Size = new System.Drawing.Size(82, 13);
            this.classValueLabel.TabIndex = 11;
            this.classValueLabel.Text = "<window class>";
            // 
            // openScriptButton
            // 
            this.openScriptButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.openScriptButton.Location = new System.Drawing.Point(16, 71);
            this.openScriptButton.Name = "openScriptButton";
            this.openScriptButton.Size = new System.Drawing.Size(104, 23);
            this.openScriptButton.TabIndex = 16;
            this.openScriptButton.Text = "Choose payload...";
            this.openScriptButton.UseVisualStyleBackColor = true;
            this.openScriptButton.Click += new System.EventHandler(this.openScriptButton_Click);
            // 
            // scriptFileNameLabel
            // 
            this.scriptFileNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.scriptFileNameLabel.AutoSize = true;
            this.scriptFileNameLabel.Location = new System.Drawing.Point(126, 76);
            this.scriptFileNameLabel.Name = "scriptFileNameLabel";
            this.scriptFileNameLabel.Size = new System.Drawing.Size(58, 13);
            this.scriptFileNameLabel.TabIndex = 17;
            this.scriptFileNameLabel.Text = "<filename>";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "DuckyScript Files (.duck)|*.duck|Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            // 
            // useDirectInputCheckBox
            // 
            this.useDirectInputCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.useDirectInputCheckBox.AutoSize = true;
            this.useDirectInputCheckBox.Location = new System.Drawing.Point(15, 104);
            this.useDirectInputCheckBox.Name = "useDirectInputCheckBox";
            this.useDirectInputCheckBox.Size = new System.Drawing.Size(126, 17);
            this.useDirectInputCheckBox.TabIndex = 19;
            this.useDirectInputCheckBox.Text = "Use DirectInput Keys";
            this.useDirectInputCheckBox.UseVisualStyleBackColor = true;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Location = new System.Drawing.Point(13, 271);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(279, 135);
            this.outputTextBox.TabIndex = 20;
            // 
            // delayTextBox
            // 
            this.delayTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.delayTextBox.Location = new System.Drawing.Point(15, 153);
            this.delayTextBox.MaxLength = 5;
            this.delayTextBox.Name = "delayTextBox";
            this.delayTextBox.Size = new System.Drawing.Size(50, 20);
            this.delayTextBox.TabIndex = 21;
            this.delayTextBox.Text = "0";
            this.delayTextBox.WordWrap = false;
            // 
            // delayLabel
            // 
            this.delayLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(71, 156);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(93, 13);
            this.delayLabel.TabIndex = 22;
            this.delayLabel.Text = "Default Delay (ms)";
            // 
            // typingDelayLabel
            // 
            this.typingDelayLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.typingDelayLabel.AutoSize = true;
            this.typingDelayLabel.Location = new System.Drawing.Point(71, 182);
            this.typingDelayLabel.Name = "typingDelayLabel";
            this.typingDelayLabel.Size = new System.Drawing.Size(91, 13);
            this.typingDelayLabel.TabIndex = 24;
            this.typingDelayLabel.Text = "Typing Delay (ms)";
            // 
            // typingDelayTextBox
            // 
            this.typingDelayTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.typingDelayTextBox.Location = new System.Drawing.Point(15, 179);
            this.typingDelayTextBox.MaxLength = 5;
            this.typingDelayTextBox.Name = "typingDelayTextBox";
            this.typingDelayTextBox.Size = new System.Drawing.Size(50, 20);
            this.typingDelayTextBox.TabIndex = 23;
            this.typingDelayTextBox.Text = "0";
            this.typingDelayTextBox.WordWrap = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::RubberDucky.Properties.Resources.USBRubberDucky;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(192, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 81);
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // crossPictureBox
            // 
            this.crossPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.crossPictureBox.Image = global::RubberDucky.Properties.Resources.cross;
            this.crossPictureBox.Location = new System.Drawing.Point(259, 19);
            this.crossPictureBox.Name = "crossPictureBox";
            this.crossPictureBox.Size = new System.Drawing.Size(33, 34);
            this.crossPictureBox.TabIndex = 3;
            this.crossPictureBox.TabStop = false;
            this.crossPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.crossPictureBox_MouseDown);
            // 
            // snarfDataButton
            // 
            this.snarfDataButton.Location = new System.Drawing.Point(15, 215);
            this.snarfDataButton.Name = "snarfDataButton";
            this.snarfDataButton.Size = new System.Drawing.Size(75, 23);
            this.snarfDataButton.TabIndex = 27;
            this.snarfDataButton.Text = "Snarf Data";
            this.snarfDataButton.UseVisualStyleBackColor = true;
            this.snarfDataButton.Click += new System.EventHandler(this.snarfButtonClicked);
            // 
            // stealthCheckBox
            // 
            this.stealthCheckBox.AutoSize = true;
            this.stealthCheckBox.Location = new System.Drawing.Point(15, 128);
            this.stealthCheckBox.Name = "stealthCheckBox";
            this.stealthCheckBox.Size = new System.Drawing.Size(89, 17);
            this.stealthCheckBox.TabIndex = 28;
            this.stealthCheckBox.Text = "Stealth Mode";
            this.stealthCheckBox.UseVisualStyleBackColor = true;
            // 
            // RubberDuckyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 418);
            this.Controls.Add(this.stealthCheckBox);
            this.Controls.Add(this.snarfDataButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.typingDelayLabel);
            this.Controls.Add(this.typingDelayTextBox);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.delayTextBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.useDirectInputCheckBox);
            this.Controls.Add(this.scriptFileNameLabel);
            this.Controls.Add(this.openScriptButton);
            this.Controls.Add(this.classValueLabel);
            this.Controls.Add(this.titleValueLabel);
            this.Controls.Add(this.classLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.crossPictureBox);
            this.Controls.Add(this.inputSimulatorButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RubberDuckyForm";
            this.Text = "RubberDucky";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button inputSimulatorButton;
        private System.Windows.Forms.PictureBox crossPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label classLabel;
        private System.Windows.Forms.Label titleValueLabel;
        private System.Windows.Forms.Label classValueLabel;
        private System.Windows.Forms.Button openScriptButton;
        private System.Windows.Forms.Label scriptFileNameLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox useDirectInputCheckBox;
        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.TextBox delayTextBox;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.Label typingDelayLabel;
        private System.Windows.Forms.TextBox typingDelayTextBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button snarfDataButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.CheckBox stealthCheckBox;
    }
}

