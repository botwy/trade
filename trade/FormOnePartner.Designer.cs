/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 22.10.2016
 * Time: 16:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace trade
{
	partial class FormOnePartner
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label16 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label17 = new System.Windows.Forms.Label();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.button3 = new System.Windows.Forms.Button();
			this.comboBox3 = new System.Windows.Forms.ComboBox();
			this.label15 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.dataGridView3 = new System.Windows.Forms.DataGridView();
			this.button4 = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.comboBox4 = new System.Windows.Forms.ComboBox();
			this.label18 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			this.tabPage3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(51, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(174, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Наименование контрагента:";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(51, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "Номер телефона:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(51, 170);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(190, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Электронная почта (e-mail):";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(51, 67);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(399, 20);
			this.textBox1.TabIndex = 3;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(51, 131);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(359, 20);
			this.textBox2.TabIndex = 4;
			this.textBox2.TextChanged += new System.EventHandler(this.TextBox2TextChanged);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(51, 196);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(313, 20);
			this.textBox3.TabIndex = 5;
			this.textBox3.TextChanged += new System.EventHandler(this.TextBox3TextChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(25, 584);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(107, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "Записать";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label4
			// 
			this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label4.Location = new System.Drawing.Point(210, 31);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(306, 23);
			this.label4.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label5.Location = new System.Drawing.Point(155, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(339, 23);
			this.label5.TabIndex = 8;
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label6.Location = new System.Drawing.Point(197, 170);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(319, 23);
			this.label6.TabIndex = 9;
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(47, 219);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 19);
			this.label7.TabIndex = 10;
			this.label7.Text = "Тип наценки:";
			// 
			// comboBox1
			// 
			this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(51, 241);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(200, 21);
			this.comboBox1.TabIndex = 11;
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(6, 117);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(301, 106);
			this.dataGridView1.TabIndex = 12;
			this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellClick);
			this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1CellValueChanged);
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(3, 90);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(133, 21);
			this.comboBox2.TabIndex = 13;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(142, 90);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(72, 20);
			this.textBox4.TabIndex = 14;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(232, 64);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 46);
			this.button2.TabIndex = 15;
			this.button2.Text = "Внести тип наценки";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(22, 54);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(100, 23);
			this.label8.TabIndex = 16;
			this.label8.Text = "Тип наценки";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(140, 54);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 31);
			this.label9.TabIndex = 17;
			this.label9.Text = "% наценки на этот тип";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label10
			// 
			this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label10.Location = new System.Drawing.Point(25, 265);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(554, 23);
			this.label10.TabIndex = 18;
			this.label10.Text = "Для поставщиков (установка цен на товары в приходной накладной):";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(25, 291);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(578, 287);
			this.tabControl1.TabIndex = 19;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label16);
			this.tabPage1.Controls.Add(this.comboBox2);
			this.tabPage1.Controls.Add(this.label8);
			this.tabPage1.Controls.Add(this.dataGridView1);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.label9);
			this.tabPage1.Controls.Add(this.textBox4);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(570, 261);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Типы наценки и наценка";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label16
			// 
			this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label16.Location = new System.Drawing.Point(6, 3);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(537, 51);
			this.label16.TabIndex = 18;
			this.label16.Text = "% для типов наценки для установки фиксированых цен для типов наценки на товары";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label17);
			this.tabPage2.Controls.Add(this.dataGridView2);
			this.tabPage2.Controls.Add(this.button3);
			this.tabPage2.Controls.Add(this.comboBox3);
			this.tabPage2.Controls.Add(this.label15);
			this.tabPage2.Controls.Add(this.textBox5);
			this.tabPage2.Controls.Add(this.textBox6);
			this.tabPage2.Controls.Add(this.label14);
			this.tabPage2.Controls.Add(this.textBox7);
			this.tabPage2.Controls.Add(this.textBox8);
			this.tabPage2.Controls.Add(this.label13);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(570, 261);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Корректировки наценок";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label17
			// 
			this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label17.Location = new System.Drawing.Point(9, 3);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(558, 74);
			this.label17.TabIndex = 12;
			this.label17.Text = "Корректировка наценки, при её попадании в определенный интервал. Если для данного" +
			" интервала установлена фиксированая цена, то % наценки не действует.";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dataGridView2
			// 
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Location = new System.Drawing.Point(9, 147);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.Size = new System.Drawing.Size(541, 105);
			this.dataGridView2.TabIndex = 0;
			this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView2CellClick);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(446, 87);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(104, 54);
			this.button3.TabIndex = 11;
			this.button3.Text = "Внести способ корректировки цены";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// comboBox3
			// 
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Location = new System.Drawing.Point(10, 120);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new System.Drawing.Size(139, 21);
			this.comboBox3.TabIndex = 1;
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(369, 70);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(71, 45);
			this.label15.TabIndex = 10;
			this.label15.Text = "или фиксир цена";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(156, 120);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(66, 20);
			this.textBox5.TabIndex = 2;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(228, 120);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(62, 20);
			this.textBox6.TabIndex = 3;
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(307, 70);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(54, 42);
			this.label14.TabIndex = 9;
			this.label14.Text = "то наценка в %";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(296, 120);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(65, 20);
			this.textBox7.TabIndex = 4;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(369, 121);
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(71, 20);
			this.textBox8.TabIndex = 5;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(228, 81);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(62, 33);
			this.label13.TabIndex = 8;
			this.label13.Text = "но до этой цены";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(23, 94);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(100, 23);
			this.label11.TabIndex = 6;
			this.label11.Text = "Тип наценки";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(156, 77);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(66, 40);
			this.label12.TabIndex = 7;
			this.label12.Text = "Если цена закупки от этой цены";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.dataGridView3);
			this.tabPage3.Controls.Add(this.button4);
			this.tabPage3.Controls.Add(this.label22);
			this.tabPage3.Controls.Add(this.label21);
			this.tabPage3.Controls.Add(this.label20);
			this.tabPage3.Controls.Add(this.label19);
			this.tabPage3.Controls.Add(this.textBox11);
			this.tabPage3.Controls.Add(this.textBox10);
			this.tabPage3.Controls.Add(this.textBox9);
			this.tabPage3.Controls.Add(this.comboBox4);
			this.tabPage3.Controls.Add(this.label18);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(570, 261);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Округление цен";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// dataGridView3
			// 
			this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView3.Location = new System.Drawing.Point(18, 133);
			this.dataGridView3.Name = "dataGridView3";
			this.dataGridView3.Size = new System.Drawing.Size(481, 104);
			this.dataGridView3.TabIndex = 10;
			this.dataGridView3.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView3CellClick);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(410, 70);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(89, 42);
			this.button4.TabIndex = 9;
			this.button4.Text = "внести способ округления";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// label22
			// 
			this.label22.Location = new System.Drawing.Point(314, 59);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(100, 23);
			this.label22.TabIndex = 8;
			this.label22.Text = "округлление";
			// 
			// label21
			// 
			this.label21.Location = new System.Drawing.Point(235, 59);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(60, 23);
			this.label21.TabIndex = 7;
			this.label21.Text = "до";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(158, 60);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(54, 23);
			this.label20.TabIndex = 6;
			this.label20.Text = "от";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(22, 60);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(100, 23);
			this.label19.TabIndex = 5;
			this.label19.Text = "Тип наценки";
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(314, 92);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(67, 20);
			this.textBox11.TabIndex = 4;
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(235, 92);
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(60, 20);
			this.textBox10.TabIndex = 3;
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(158, 92);
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(64, 20);
			this.textBox9.TabIndex = 2;
			// 
			// comboBox4
			// 
			this.comboBox4.FormattingEnabled = true;
			this.comboBox4.Location = new System.Drawing.Point(18, 92);
			this.comboBox4.Name = "comboBox4";
			this.comboBox4.Size = new System.Drawing.Size(121, 21);
			this.comboBox4.TabIndex = 1;
			// 
			// label18
			// 
			this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label18.Location = new System.Drawing.Point(52, 7);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(413, 52);
			this.label18.TabIndex = 0;
			this.label18.Text = "Округление (сдвиг) цен при попадании её в определенный интервал";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// FormOnePartner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(615, 619);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FormOnePartner";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox comboBox4;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.DataGridView dataGridView3;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.ComboBox comboBox3;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
