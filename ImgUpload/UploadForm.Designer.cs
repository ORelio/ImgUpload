namespace ImgUpload
{
    partial class UploadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadForm));
            this.button_select = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.settingResize = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_copy = new System.Windows.Forms.Button();
            this.box_result = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.option_image_with_fullsize_link = new System.Windows.Forms.RadioButton();
            this.option_forumcode = new System.Windows.Forms.RadioButton();
            this.option_directlink = new System.Windows.Forms.RadioButton();
            this.button_close = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_choosefile = new System.Windows.Forms.Button();
            this.textBox_file = new System.Windows.Forms.TextBox();
            this.button_advanced_mode = new System.Windows.Forms.Button();
            this.button_simple_cancelclose = new System.Windows.Forms.Button();
            this.button_simple_send = new System.Windows.Forms.Button();
            this.text_advanced_mode = new System.Windows.Forms.Label();
            this.providerChange = new System.Windows.Forms.HScrollBar();
            this.providerGoWebsite = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(58, 349);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(116, 23);
            this.button_select.TabIndex = 9;
            this.button_select.Text = "Send_Picture";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.settingResize);
            this.groupBox1.Location = new System.Drawing.Point(10, 172);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 53);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resize_Picture";
            // 
            // settingResize
            // 
            this.settingResize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.settingResize.FormattingEnabled = true;
            this.settingResize.Location = new System.Drawing.Point(14, 19);
            this.settingResize.Name = "settingResize";
            this.settingResize.Size = new System.Drawing.Size(306, 21);
            this.settingResize.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_copy);
            this.groupBox2.Controls.Add(this.box_result);
            this.groupBox2.Location = new System.Drawing.Point(10, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 49);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // btn_copier
            // 
            this.btn_copy.Location = new System.Drawing.Point(277, 18);
            this.btn_copy.Name = "btn_copier";
            this.btn_copy.Size = new System.Drawing.Size(46, 23);
            this.btn_copy.TabIndex = 1;
            this.btn_copy.Text = "Copy";
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copier_Click);
            // 
            // box_resultat
            // 
            this.box_result.Location = new System.Drawing.Point(6, 19);
            this.box_result.Name = "box_resultat";
            this.box_result.Size = new System.Drawing.Size(264, 20);
            this.box_result.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.option_image_with_fullsize_link);
            this.groupBox3.Controls.Add(this.option_forumcode);
            this.groupBox3.Controls.Add(this.option_directlink);
            this.groupBox3.Location = new System.Drawing.Point(10, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 53);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output_Format";
            // 
            // option_imagecliquable
            // 
            this.option_image_with_fullsize_link.AutoSize = true;
            this.option_image_with_fullsize_link.Location = new System.Drawing.Point(170, 20);
            this.option_image_with_fullsize_link.Name = "option_imagecliquable";
            this.option_image_with_fullsize_link.Size = new System.Drawing.Size(160, 17);
            this.option_image_with_fullsize_link.TabIndex = 2;
            this.option_image_with_fullsize_link.TabStop = true;
            this.option_image_with_fullsize_link.Text = "Forum_Code_And_Fullsize_Link";
            this.option_image_with_fullsize_link.UseVisualStyleBackColor = true;
            // 
            // option_codeforum
            // 
            this.option_forumcode.AutoSize = true;
            this.option_forumcode.Location = new System.Drawing.Point(87, 20);
            this.option_forumcode.Name = "option_codeforum";
            this.option_forumcode.Size = new System.Drawing.Size(79, 17);
            this.option_forumcode.TabIndex = 1;
            this.option_forumcode.TabStop = true;
            this.option_forumcode.Text = "Forum_Code";
            this.option_forumcode.UseVisualStyleBackColor = true;
            // 
            // option_liendirect
            // 
            this.option_directlink.AutoSize = true;
            this.option_directlink.Location = new System.Drawing.Point(9, 20);
            this.option_directlink.Name = "option_liendirect";
            this.option_directlink.Size = new System.Drawing.Size(74, 17);
            this.option_directlink.TabIndex = 0;
            this.option_directlink.TabStop = true;
            this.option_directlink.Text = "Direct_Link";
            this.option_directlink.UseVisualStyleBackColor = true;
            // 
            // button_close
            // 
            this.button_close.Location = new System.Drawing.Point(180, 349);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(111, 23);
            this.button_close.TabIndex = 10;
            this.button_close.Text = "Cancel_Close";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.button_close_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_choosefile);
            this.groupBox4.Controls.Add(this.textBox_file);
            this.groupBox4.Location = new System.Drawing.Point(10, 113);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(333, 53);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Choose_Picture";
            // 
            // button_choosefile
            // 
            this.button_choosefile.Location = new System.Drawing.Point(240, 18);
            this.button_choosefile.Name = "button_choosefile";
            this.button_choosefile.Size = new System.Drawing.Size(80, 23);
            this.button_choosefile.TabIndex = 1;
            this.button_choosefile.Text = "Browse";
            this.button_choosefile.UseVisualStyleBackColor = true;
            this.button_choosefile.Click += new System.EventHandler(this.button_choosefile_Click);
            // 
            // textBox_file
            // 
            this.textBox_file.Location = new System.Drawing.Point(9, 20);
            this.textBox_file.Name = "textBox_file";
            this.textBox_file.Size = new System.Drawing.Size(227, 20);
            this.textBox_file.TabIndex = 0;
            // 
            // button_modeavance
            // 
            this.button_advanced_mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_advanced_mode.Location = new System.Drawing.Point(320, 81);
            this.button_advanced_mode.Name = "button_modeavance";
            this.button_advanced_mode.Size = new System.Drawing.Size(23, 23);
            this.button_advanced_mode.TabIndex = 4;
            this.button_advanced_mode.Text = "˅";
            this.button_advanced_mode.UseVisualStyleBackColor = true;
            this.button_advanced_mode.Click += new System.EventHandler(this.button_advanced_mode_Click);
            // 
            // button_simple_annulerfermer
            // 
            this.button_simple_cancelclose.Location = new System.Drawing.Point(239, 81);
            this.button_simple_cancelclose.Name = "button_simple_annulerfermer";
            this.button_simple_cancelclose.Size = new System.Drawing.Size(75, 23);
            this.button_simple_cancelclose.TabIndex = 3;
            this.button_simple_cancelclose.Text = "Cancel/Cl.";
            this.button_simple_cancelclose.UseVisualStyleBackColor = true;
            this.button_simple_cancelclose.Click += new System.EventHandler(this.button_close_Click);
            // 
            // button_simple_envoyer
            // 
            this.button_simple_send.Location = new System.Drawing.Point(118, 81);
            this.button_simple_send.Name = "button_simple_envoyer";
            this.button_simple_send.Size = new System.Drawing.Size(115, 23);
            this.button_simple_send.TabIndex = 2;
            this.button_simple_send.Text = "Send_Picture";
            this.button_simple_send.UseVisualStyleBackColor = true;
            this.button_simple_send.Click += new System.EventHandler(this.button_choosefile_Click);
            // 
            // texte_modeavance
            // 
            this.text_advanced_mode.AutoSize = true;
            this.text_advanced_mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_advanced_mode.Location = new System.Drawing.Point(12, 87);
            this.text_advanced_mode.Name = "texte_modeavance";
            this.text_advanced_mode.Size = new System.Drawing.Size(265, 13);
            this.text_advanced_mode.TabIndex = 10;
            this.text_advanced_mode.Text = "Send_Picture_With_Custom_Settings";
            // 
            // providerChange
            // 
            this.providerChange.LargeChange = 1;
            this.providerChange.Location = new System.Drawing.Point(317, 1);
            this.providerChange.Maximum = 1;
            this.providerChange.Name = "providerChange";
            this.providerChange.Size = new System.Drawing.Size(36, 18);
            this.providerChange.TabIndex = 0;
            this.providerChange.Value = 1;
            this.providerChange.Scroll += new System.Windows.Forms.ScrollEventHandler(this.providerChange_Scroll);
            // 
            // providerGoWebsite
            // 
            this.providerGoWebsite.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.providerGoWebsite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.providerGoWebsite.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.providerGoWebsite.Location = new System.Drawing.Point(316, 21);
            this.providerGoWebsite.Name = "providerGoWebsite";
            this.providerGoWebsite.Size = new System.Drawing.Size(40, 23);
            this.providerGoWebsite.TabIndex = 1;
            this.providerGoWebsite.Text = "Info";
            this.providerGoWebsite.UseVisualStyleBackColor = true;
            this.providerGoWebsite.Click += new System.EventHandler(this.providerGoWebsite_Click);
            // 
            // UploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(355, 382);
            this.Controls.Add(this.providerGoWebsite);
            this.Controls.Add(this.providerChange);
            this.Controls.Add(this.text_advanced_mode);
            this.Controls.Add(this.button_simple_send);
            this.Controls.Add(this.button_simple_cancelclose);
            this.Controls.Add(this.button_advanced_mode);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button_close);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_select);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UploadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImgUpload";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.TextBox box_result;
        private System.Windows.Forms.ComboBox settingResize;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton option_image_with_fullsize_link;
        private System.Windows.Forms.RadioButton option_forumcode;
        private System.Windows.Forms.RadioButton option_directlink;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_choosefile;
        private System.Windows.Forms.TextBox textBox_file;
        private System.Windows.Forms.Button button_advanced_mode;
        private System.Windows.Forms.Button button_simple_cancelclose;
        private System.Windows.Forms.Button button_simple_send;
        private System.Windows.Forms.Label text_advanced_mode;
        private System.Windows.Forms.HScrollBar providerChange;
        private System.Windows.Forms.Button providerGoWebsite;
    }
}