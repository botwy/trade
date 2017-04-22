/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 24.11.2016
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace trade
{
	partial class FormOneMarkupType
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(25, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(159, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Наименование типа:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(25, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(330, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(25, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(132, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Базовая наценка в %:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(25, 117);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(197, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.TextChanged += new System.EventHandler(this.TextBox2TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(25, 222);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Записать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label3
			// 
			this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label3.Location = new System.Drawing.Point(25, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(367, 23);
			this.label3.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label4.Location = new System.Drawing.Point(25, 153);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(380, 23);
			this.label4.TabIndex = 6;
			// 
			// FormOneMarkupType
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 266);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "FormOneMarkupType";
			this.Text = "Тип наценки Карточка";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
	}
}
