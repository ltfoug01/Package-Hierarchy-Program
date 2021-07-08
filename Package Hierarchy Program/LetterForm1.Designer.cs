namespace Package_Hierarchy_Program
{
    partial class LetterForm1
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
            this.components = new System.ComponentModel.Container();
            this.originLbl = new System.Windows.Forms.Label();
            this.destLbl = new System.Windows.Forms.Label();
            this.originAddCbo = new System.Windows.Forms.ComboBox();
            this.destAddCbo = new System.Windows.Forms.ComboBox();
            this.fixedCostTxt = new System.Windows.Forms.TextBox();
            this.costLbl = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // originLbl
            // 
            this.originLbl.AutoSize = true;
            this.originLbl.Location = new System.Drawing.Point(45, 9);
            this.originLbl.Name = "originLbl";
            this.originLbl.Size = new System.Drawing.Size(78, 13);
            this.originLbl.TabIndex = 1;
            this.originLbl.Text = "Origin Address:";
            // 
            // destLbl
            // 
            this.destLbl.AutoSize = true;
            this.destLbl.Location = new System.Drawing.Point(19, 36);
            this.destLbl.Name = "destLbl";
            this.destLbl.Size = new System.Drawing.Size(104, 13);
            this.destLbl.TabIndex = 2;
            this.destLbl.Text = "Destination Address:";
            // 
            // originAddCbo
            // 
            this.originAddCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.originAddCbo.FormattingEnabled = true;
            this.originAddCbo.Location = new System.Drawing.Point(129, 6);
            this.originAddCbo.Name = "originAddCbo";
            this.originAddCbo.Size = new System.Drawing.Size(129, 21);
            this.originAddCbo.TabIndex = 3;
            this.originAddCbo.Validating += new System.ComponentModel.CancelEventHandler(this.addressCbo_Validating);
            this.originAddCbo.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // destAddCbo
            // 
            this.destAddCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.destAddCbo.FormattingEnabled = true;
            this.destAddCbo.Location = new System.Drawing.Point(129, 33);
            this.destAddCbo.Name = "destAddCbo";
            this.destAddCbo.Size = new System.Drawing.Size(129, 21);
            this.destAddCbo.TabIndex = 5;
            this.destAddCbo.Validating += new System.ComponentModel.CancelEventHandler(this.addressCbo_Validating);
            // 
            // fixedCostTxt
            // 
            this.fixedCostTxt.Location = new System.Drawing.Point(129, 60);
            this.fixedCostTxt.Name = "fixedCostTxt";
            this.fixedCostTxt.Size = new System.Drawing.Size(129, 20);
            this.fixedCostTxt.TabIndex = 6;
            this.fixedCostTxt.Validating += new System.ComponentModel.CancelEventHandler(this.fixedCostTxt_Validating);
            this.fixedCostTxt.Validated += new System.EventHandler(this.AllFields_Validated);
            // 
            // costLbl
            // 
            this.costLbl.AutoSize = true;
            this.costLbl.Location = new System.Drawing.Point(64, 63);
            this.costLbl.Name = "costLbl";
            this.costLbl.Size = new System.Drawing.Size(59, 13);
            this.costLbl.TabIndex = 7;
            this.costLbl.Text = "Fixed Cost:";
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(48, 102);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 8;
            this.okBtn.Text = "OK";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(129, 102);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 9;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cancelBtn_MouseDown);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // LetterForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 146);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.costLbl);
            this.Controls.Add(this.fixedCostTxt);
            this.Controls.Add(this.destAddCbo);
            this.Controls.Add(this.originAddCbo);
            this.Controls.Add(this.destLbl);
            this.Controls.Add(this.originLbl);
            this.Name = "LetterForm1";
            this.Text = "Letter";
            this.Load += new System.EventHandler(this.LetterForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label originLbl;
        private System.Windows.Forms.Label destLbl;
        private System.Windows.Forms.ComboBox originAddCbo;
        private System.Windows.Forms.ComboBox destAddCbo;
        private System.Windows.Forms.TextBox fixedCostTxt;
        private System.Windows.Forms.Label costLbl;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}