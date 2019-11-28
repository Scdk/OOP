namespace waListaEncadeada
{
	partial class Form1
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.tbLista = new System.Windows.Forms.TextBox();
			this.btInsere = new System.Windows.Forms.Button();
			this.btMaior = new System.Windows.Forms.Button();
			this.btRemove = new System.Windows.Forms.Button();
			this.btImprime = new System.Windows.Forms.Button();
			this.btMenor = new System.Windows.Forms.Button();
			this.tbInsere = new System.Windows.Forms.TextBox();
			this.tbMenor = new System.Windows.Forms.TextBox();
			this.tbMaior = new System.Windows.Forms.TextBox();
			this.tbRemove = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
			this.label1.Location = new System.Drawing.Point(72, 41);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Lista:";
			// 
			// tbLista
			// 
			this.tbLista.Location = new System.Drawing.Point(142, 47);
			this.tbLista.Name = "tbLista";
			this.tbLista.ReadOnly = true;
			this.tbLista.Size = new System.Drawing.Size(333, 20);
			this.tbLista.TabIndex = 1;
			this.tbLista.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btInsere
			// 
			this.btInsere.Location = new System.Drawing.Point(142, 132);
			this.btInsere.Name = "btInsere";
			this.btInsere.Size = new System.Drawing.Size(75, 23);
			this.btInsere.TabIndex = 2;
			this.btInsere.Text = "INSERE";
			this.btInsere.UseVisualStyleBackColor = true;
			this.btInsere.Click += new System.EventHandler(this.btInsere_Click);
			// 
			// btMaior
			// 
			this.btMaior.Location = new System.Drawing.Point(142, 238);
			this.btMaior.Name = "btMaior";
			this.btMaior.Size = new System.Drawing.Size(75, 23);
			this.btMaior.TabIndex = 3;
			this.btMaior.Text = "MAIOR";
			this.btMaior.UseVisualStyleBackColor = true;
			this.btMaior.Click += new System.EventHandler(this.btMaior_Click);
			// 
			// btRemove
			// 
			this.btRemove.Location = new System.Drawing.Point(142, 187);
			this.btRemove.Name = "btRemove";
			this.btRemove.Size = new System.Drawing.Size(75, 23);
			this.btRemove.TabIndex = 4;
			this.btRemove.Text = "REMOVE";
			this.btRemove.UseVisualStyleBackColor = true;
			this.btRemove.Click += new System.EventHandler(this.btRemove_Click);
			// 
			// btImprime
			// 
			this.btImprime.Location = new System.Drawing.Point(142, 337);
			this.btImprime.Name = "btImprime";
			this.btImprime.Size = new System.Drawing.Size(75, 23);
			this.btImprime.TabIndex = 5;
			this.btImprime.Text = "IMPRIME";
			this.btImprime.UseVisualStyleBackColor = true;
			this.btImprime.Click += new System.EventHandler(this.btImprime_Click);
			// 
			// btMenor
			// 
			this.btMenor.Location = new System.Drawing.Point(142, 288);
			this.btMenor.Name = "btMenor";
			this.btMenor.Size = new System.Drawing.Size(75, 23);
			this.btMenor.TabIndex = 6;
			this.btMenor.Text = "MENOR";
			this.btMenor.UseVisualStyleBackColor = true;
			this.btMenor.Click += new System.EventHandler(this.btMenor_Click);
			// 
			// tbInsere
			// 
			this.tbInsere.Location = new System.Drawing.Point(223, 134);
			this.tbInsere.Name = "tbInsere";
			this.tbInsere.Size = new System.Drawing.Size(154, 20);
			this.tbInsere.TabIndex = 7;
			this.tbInsere.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInsere_KeyPress);
			// 
			// tbMenor
			// 
			this.tbMenor.Location = new System.Drawing.Point(223, 290);
			this.tbMenor.Name = "tbMenor";
			this.tbMenor.ReadOnly = true;
			this.tbMenor.Size = new System.Drawing.Size(154, 20);
			this.tbMenor.TabIndex = 8;
			this.tbMenor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMenor_KeyPress);
			// 
			// tbMaior
			// 
			this.tbMaior.Location = new System.Drawing.Point(223, 240);
			this.tbMaior.Name = "tbMaior";
			this.tbMaior.ReadOnly = true;
			this.tbMaior.Size = new System.Drawing.Size(154, 20);
			this.tbMaior.TabIndex = 9;
			this.tbMaior.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbMaior_KeyPress);
			// 
			// tbRemove
			// 
			this.tbRemove.Location = new System.Drawing.Point(224, 189);
			this.tbRemove.Name = "tbRemove";
			this.tbRemove.Size = new System.Drawing.Size(153, 20);
			this.tbRemove.TabIndex = 11;
			this.tbRemove.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbRemove_KeyPress);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(577, 386);
			this.Controls.Add(this.tbRemove);
			this.Controls.Add(this.tbMaior);
			this.Controls.Add(this.tbMenor);
			this.Controls.Add(this.tbInsere);
			this.Controls.Add(this.btMenor);
			this.Controls.Add(this.btImprime);
			this.Controls.Add(this.btRemove);
			this.Controls.Add(this.btMaior);
			this.Controls.Add(this.btInsere);
			this.Controls.Add(this.tbLista);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Lista Encadeada";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbLista;
		private System.Windows.Forms.Button btInsere;
		private System.Windows.Forms.Button btMaior;
		private System.Windows.Forms.Button btRemove;
		private System.Windows.Forms.Button btImprime;
		private System.Windows.Forms.Button btMenor;
		private System.Windows.Forms.TextBox tbInsere;
		private System.Windows.Forms.TextBox tbMenor;
		private System.Windows.Forms.TextBox tbMaior;
		private System.Windows.Forms.TextBox tbRemove;
	}
}

