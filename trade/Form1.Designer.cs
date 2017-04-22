using System.Windows.Forms;
/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 06.09.2016
 * Time: 15:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace trade
{
	partial class Form1
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.new_row_btn = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoScroll = true;
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.58746F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.41254F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
			this.tableLayoutPanel1.Controls.Add(this.comboBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBox2, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBox3, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label1, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label5, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 108);
			this.tableLayoutPanel1.MaximumSize = new System.Drawing.Size(496, 120);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(495, 57);
			this.tableLayoutPanel1.TabIndex = 23;
			// 
			// comboBox1
			// 
			this.comboBox1.AllowDrop = true;
			this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(4, 32);
			this.comboBox1.MaximumSize = new System.Drawing.Size(228, 0);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(216, 21);
			this.comboBox1.TabIndex = 21;
			this.comboBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox1Form1_KeyUp);
			// 
			// textBox2
			// 
			this.textBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.textBox2.Location = new System.Drawing.Point(227, 32);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(68, 20);
			this.textBox2.TabIndex = 18;
			this.textBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox2_KeyUp);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(303, 32);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(86, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBox3_KeyUp);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(396, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 18);
			this.label1.TabIndex = 3;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(4, 1);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(216, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "Товар";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(303, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "Цена";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(396, 1);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(95, 18);
			this.label5.TabIndex = 7;
			this.label5.Text = "Сумма";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(227, 1);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 18);
			this.label3.TabIndex = 5;
			this.label3.Text = "Количество";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// new_row_btn
			// 
			this.new_row_btn.Location = new System.Drawing.Point(12, 78);
			this.new_row_btn.Name = "new_row_btn";
			this.new_row_btn.Size = new System.Drawing.Size(154, 24);
			this.new_row_btn.TabIndex = 3;
			this.new_row_btn.Text = "Внести в накладную";
			this.new_row_btn.UseVisualStyleBackColor = true;
			this.new_row_btn.Click += new System.EventHandler(this.New_row_btnClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(17, 170);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(491, 174);
			this.dataGridView1.TabIndex = 6;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellClick);
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellValueChanged);
			this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1RowEnter);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 381);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Провести";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(190, 5);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(109, 23);
			this.label11.TabIndex = 9;
			this.label11.Text = "Номер накладной:";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(305, 12);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(75, 23);
			this.label12.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(17, 347);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(104, 23);
			this.label6.TabIndex = 11;
			this.label6.Text = "Итого количество:";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(216, 347);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(24, 23);
			this.label13.TabIndex = 12;
			this.label13.Text = "шт.";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(246, 347);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(76, 23);
			this.label14.TabIndex = 13;
			this.label14.Text = "Итого сумма:";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(470, 347);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(38, 23);
			this.label15.TabIndex = 14;
			this.label15.Text = "руб.";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(128, 347);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(82, 23);
			this.label16.TabIndex = 15;
			this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(329, 347);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(135, 23);
			this.label17.TabIndex = 16;
			this.label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(398, 1);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(126, 20);
			this.dateTimePicker1.TabIndex = 17;
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label7.Location = new System.Drawing.Point(526, 133);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 23);
			this.label7.TabIndex = 18;
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(526, 104);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 19;
			this.label8.Text = "Остатки";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// printPreviewDialog1
			// 
			this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog1.Document = this.printDocument1;
			this.printPreviewDialog1.Enabled = true;
			this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
			this.printPreviewDialog1.Name = "printPreviewDialog1";
			this.printPreviewDialog1.Visible = false;
			// 
			// printDocument1
			// 
			this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1PrintPage);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(128, 381);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(122, 23);
			this.button1.TabIndex = 20;
			this.button1.Text = "Печать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// comboBox2
			// 
			this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(128, 27);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(396, 21);
			this.comboBox2.TabIndex = 0;
			this.comboBox2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.comboBox2Form1_KeyUp);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 27);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(109, 23);
			this.label9.TabIndex = 22;
			this.label9.Text = "Поставщик:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(526, 170);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(100, 23);
			this.label10.TabIndex = 24;
			this.label10.Text = "Остаток:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label18
			// 
			this.label18.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label18.Location = new System.Drawing.Point(543, 203);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(100, 23);
			this.label18.TabIndex = 25;
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(58, 54);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(43, 21);
			this.label19.TabIndex = 26;
			this.label19.Text = "Склад:";
			// 
			// comboBox3
			// 
			this.comboBox3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(127, 54);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(319, 21);
			this.comboBox3.TabIndex = 27;
			this.comboBox3.SelectedValueChanged += new System.EventHandler(this.comboBox3Form1_SelectedValueChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(679, 415);
			this.Controls.Add(this.comboBox3);
			this.Controls.Add(this.label19);
			this.Controls.Add(this.label18);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.label17);
			this.Controls.Add(this.label16);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.new_row_btn);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Приходная накладная";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1FormClosing);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Button button1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button new_row_btn;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		
	
	}
}
