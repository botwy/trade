/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 22.10.2016
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace trade
{
	partial class FormOneProduct
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
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(37, 30);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(258, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Наименование товара:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(37, 57);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(514, 20);
			this.textBox1.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(37, 92);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Цена закупки:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(37, 150);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Остаток:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(37, 127);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(238, 20);
			this.textBox2.TabIndex = 5;
			this.textBox2.TextChanged += new System.EventHandler(this.TextBox2TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(17, 513);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(120, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Записать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label6.Location = new System.Drawing.Point(130, 92);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(400, 23);
			this.label6.TabIndex = 8;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(17, 213);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 9;
			this.label7.Text = "Штрихкод:";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(10, 239);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(265, 20);
			this.textBox3.TabIndex = 10;
			this.textBox3.TextChanged += new System.EventHandler(this.TextBox3TextChanged);
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label9.Location = new System.Drawing.Point(101, 213);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(429, 23);
			this.label9.TabIndex = 12;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(37, 165);
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(120, 20);
			this.textBox4.TabIndex = 13;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(17, 334);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(315, 150);
			this.dataGridView1.TabIndex = 14;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellClick);
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellValueChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(17, 307);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(140, 21);
			this.comboBox1.TabIndex = 15;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(172, 307);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(80, 20);
			this.textBox5.TabIndex = 16;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(258, 285);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(74, 45);
			this.button2.TabIndex = 17;
			this.button2.Text = "Внести тип наценки";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(17, 286);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(140, 18);
			this.label4.TabIndex = 18;
			this.label4.Text = "Тип наценки";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(172, 285);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(80, 16);
			this.label5.TabIndex = 19;
			this.label5.Text = "Фиксир. цена";
			// 
			// FormOneProduct
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(574, 560);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "FormOneProduct";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
	}
}
