namespace Utdl.View {
    partial class FultraTrail {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
            this.btnLesCourses = new System.Windows.Forms.Button();
            this.btnUneCourse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLesCourses
            // 
            this.btnLesCourses.Location = new System.Drawing.Point(76, 8);
            this.btnLesCourses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLesCourses.Name = "btnLesCourses";
            this.btnLesCourses.Size = new System.Drawing.Size(136, 27);
            this.btnLesCourses.TabIndex = 0;
            this.btnLesCourses.Text = "LesCourses";
            this.btnLesCourses.UseVisualStyleBackColor = true;
            // 
            // btnUneCourse
            // 
            this.btnUneCourse.Location = new System.Drawing.Point(76, 47);
            this.btnUneCourse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUneCourse.Name = "btnUneCourse";
            this.btnUneCourse.Size = new System.Drawing.Size(136, 27);
            this.btnUneCourse.TabIndex = 1;
            this.btnUneCourse.Text = "Une Course";
            this.btnUneCourse.UseVisualStyleBackColor = true;
            // 
            // FultraTrail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 82);
            this.Controls.Add(this.btnUneCourse);
            this.Controls.Add(this.btnLesCourses);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FultraTrail";
            this.Text = "Ultra Trail des lapins";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLesCourses; 
        private System.Windows.Forms.Button btnUneCourse;
    }
}

