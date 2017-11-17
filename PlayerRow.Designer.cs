namespace BabyMonitor {
    partial class PlayerRow {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if ( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.txtOverrideName = new System.Windows.Forms.TextBox();
            this.txtHandicap = new System.Windows.Forms.TextBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.AutoSize = true;
            this.lblPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(11, 12);
            this.lblPlayerName.MaximumSize = new System.Drawing.Size(250, 0);
            this.lblPlayerName.MinimumSize = new System.Drawing.Size(250, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(250, 20);
            this.lblPlayerName.TabIndex = 0;
            // 
            // txtOverrideName
            // 
            this.txtOverrideName.Location = new System.Drawing.Point(267, 15);
            this.txtOverrideName.Name = "txtOverrideName";
            this.txtOverrideName.Size = new System.Drawing.Size(250, 20);
            this.txtOverrideName.TabIndex = 1;
            // 
            // txtHandicap
            // 
            this.txtHandicap.Location = new System.Drawing.Point(523, 15);
            this.txtHandicap.Name = "txtHandicap";
            this.txtHandicap.Size = new System.Drawing.Size(50, 20);
            this.txtHandicap.TabIndex = 2;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Location = new System.Drawing.Point(603, 21);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 3;
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // PlayerRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtHandicap);
            this.Controls.Add(this.txtOverrideName);
            this.Controls.Add(this.lblPlayerName);
            this.Name = "PlayerRow";
            this.Size = new System.Drawing.Size(632, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerName;
        private System.Windows.Forms.TextBox txtOverrideName;
        private System.Windows.Forms.TextBox txtHandicap;
        private System.Windows.Forms.CheckBox chkActive;
    }
}
