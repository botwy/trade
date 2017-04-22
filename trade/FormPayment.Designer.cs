/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 06.12.2016
 * Time: 12:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace trade
{
	partial class FormPayment
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
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Платежное поручение №";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(183, 38);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 1;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(299, 37);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(149, 20);
			this.dateTimePicker1.TabIndex = 2;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(455, 36);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(100, 20);
			this.textBox2.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(455, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 24);
			this.label2.TabIndex = 4;
			this.label2.Text = "Вид платежа";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(13, 111);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(116, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "ИНН получателя:";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(136, 113);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(100, 20);
			this.textBox3.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(243, 110);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(109, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "КПП получателя:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(377, 113);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(100, 20);
			this.textBox4.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(13, 78);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(100, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "Сумма:";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(81, 78);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(155, 20);
			this.textBox5.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(13, 148);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(100, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "Получатель:";
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(119, 145);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(416, 21);
			this.comboBox1.TabIndex = 12;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(12, 210);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 13;
			this.label7.Text = "Банк получателя:";
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(119, 210);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(416, 20);
			this.textBox6.TabIndex = 14;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 241);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(126, 23);
			this.label8.TabIndex = 15;
			this.label8.Text = "БИК банка получателя:";
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(169, 241);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(145, 20);
			this.textBox7.TabIndex = 16;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(12, 273);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(139, 23);
			this.label9.TabIndex = 17;
			this.label9.Text = "Кор сч банка получателя:";
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(169, 268);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(307, 20);
			this.textBox8.TabIndex = 18;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(14, 171);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 32);
			this.label10.TabIndex = 19;
			this.label10.Text = "Расчётный счёт получателя:";
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(120, 178);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(358, 20);
			this.textBox9.TabIndex = 20;
			// 
			// FormPayment
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(586, 353);
			this.Controls.Add(this.textBox9);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBox7);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.textBox6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "FormPayment";
			this.Text = "FormPayment";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
	}
}
