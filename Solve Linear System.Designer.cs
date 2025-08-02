namespace Linear_Project
{
    partial class Solve_Linear_System
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
            this.panMatrix = new System.Windows.Forms.Panel();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // panMatrix
            // 
            this.panMatrix.Location = new System.Drawing.Point(12, 12);
            this.panMatrix.Name = "panMatrix";
            this.panMatrix.Size = new System.Drawing.Size(972, 544);
            this.panMatrix.TabIndex = 0;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(371, 572);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(209, 67);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // rtbResult
            // 
            this.rtbResult.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbResult.Location = new System.Drawing.Point(651, 572);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.Size = new System.Drawing.Size(100, 72);
            this.rtbResult.TabIndex = 2;
            this.rtbResult.Text = "";
            // 
            // Solve_Linear_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 651);
            this.Controls.Add(this.rtbResult);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panMatrix);
            this.Name = "Solve_Linear_System";
            this.Text = "Solve Linear System";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Solve_Linear_System_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMatrix;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.RichTextBox rtbResult;
    }
}