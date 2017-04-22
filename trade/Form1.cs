/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 06.09.2016
 * Time: 15:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
//using System.IO.Ports;

namespace trade
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		
	//	int counter;
	//	List<Label[]> list_rows;
	//	ListUnits list_prod;
	//	ListUnits list_pa;
	//	DataTable dt;
	
	//List<RowBill> list_rb;
	//ListBuyBills list_bb;
	BuyBill buy_bill;
	
	ListQReportStruct list_rq;
	
	
	
	public string curr_barcode="";
	
	//SerialPort port;
	//float total_quantity=0;
	//float total_sum=0;
		
	//	int number;
	TradeApp app;
	
		public Form1(TradeApp app, ListQReportStruct list_rq)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//this.counter=1;
			//this.list_rows=new List<Label[]>();
			
		//	this.list_prod=list_prod;
		//	this.list_pa=list_pa;
			
		//	Unit[] arr_prod=this.list_prod.GetAll();
			
			//foreach (Product prod in arr_prod) comboBox1.Items.Add(prod.Title);
			foreach (Product prod in DB.GetAll<Product>())
				comboBox1.Items.Add(prod.Title);
			
		//	Unit[] arr_pa=this.list_pa.GetAll();
		//	foreach (Partner partner in arr_pa)
		//		comboBox2.Items.Add(partner.Title);
			foreach (Partner pa in DB.GetAll<Partner>())
				comboBox2.Items.Add(pa.Title);
			
			foreach (Storage storage in DB.GetAll<Storage>())
				comboBox3.Items.Add(storage.Title);
//			comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
//            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
			//this.dt = new DataTable();
			//this.dt.Columns.Add("Товар");
			//this.dt.Columns.Add("Количество");
			//this.dt.Columns.Add("Цена");
			//this.dt.Columns.Add("Сумма");
			
			
			//this.number=1;
			//this.list_rb=new List<RowBill>();
			
			//this.list_bb=list_bb;
			this.list_rq=list_rq;
			
			this.buy_bill=new BuyBill();
			
			this.Text="Приходная накладная. Новая";
			
			this.comboBox2.Focus();
			//Поменяйте лучше TabIndex на 0 в Form1.Designer
			this.KeyPreview = true;
			
		//	port = new SerialPort("COM1");
		//	port.Open();
		//	port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
		this.app=app;
		}
		
		public Form1(BuyBill bb)
		{
			InitializeComponent();
			
			//this.dt = new DataTable();
			//this.dt.Columns.Add("Товар");
//			this.dt.Columns.Add("Количество");
//			this.dt.Columns.Add("Цена");
//			this.dt.Columns.Add("Сумма");
			
//			foreach (RowBill row_b in bb.List_rows) {
//				dt.Rows.Add(row_b.product.Title,row_b.quantity,row_b.price,row_b.sum);
//			this.total_quantity +=row_b.quantity;
//			this.total_sum +=row_b.sum;
//			}
			this.Text="Приходная накладная. Проведена";
			this.label12.Text=bb.Number_instance.ToString();
			dateTimePicker1.Value=bb.Date;
			if (bb.Provider!=null) this.comboBox2.Text=bb.Provider.Title;
			
			this.comboBox3.DropDownStyle=ComboBoxStyle.DropDown;
			if (bb.Storage!=null) this.comboBox3.Text=bb.Storage.Title;
			
			this.comboBox1.Enabled=false;
			this.comboBox2.Enabled=false;
			this.comboBox3.Enabled=false;
			this.textBox2.ReadOnly=true;
			this.textBox3.ReadOnly=true;
			this.new_row_btn.Enabled=false;
			this.button2.Enabled=false;
			this.dateTimePicker1.Enabled=false;
			dataGridView1.ReadOnly=true;
			
			this.buy_bill=bb;
			
				
//			label16.Text=this.total_quantity.ToString();
//			label17.Text=this.total_sum.ToString();
			
			label16.Text=bb.Total_quantity.ToString();
			label17.Text=bb.Total_sum.ToString();
		//	dataGridView1.DataSource=dt;
		dataGridView1.DataSource=bb.GetDataTable();
		    dataGridView1.Columns[1].Visible=false;
		    dataGridView1.Columns[0].Width=20;
		    dataGridView1.Columns[0].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
		    
		this.KeyPreview = true;
		}
		
		void FormatDataGridView() {
			this.dataGridView1.Columns[1].Visible=false;
		    this.dataGridView1.Columns[0].Width=20;
		    this.dataGridView1.Columns[0].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
		    this.dataGridView1.Columns[0].ReadOnly=true;
		    this.dataGridView1.Columns[2].ReadOnly=true;
		    this.dataGridView1.Columns[4].ReadOnly=true;
		    this.dataGridView1.Columns[5].ReadOnly=true;
		}
		
void UpdateTotalAndDataGridView() {
	dataGridView1.DataSource=this.buy_bill.GetDataTable();
			FormatDataGridView();
	label16.Text=this.buy_bill.Total_quantity.ToString();
    label17.Text=this.buy_bill.Total_sum.ToString();
    
		}	
		
		void SetBarcodeFromOtherForm(string code) {
			this.curr_barcode=code;
		}
		
		void TextBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) this.Close();
		}
		
		void TextBox2_KeyUp(object sender, KeyEventArgs e)
		{
	int int_textBox2;
	 float float_textBox3;
		if (e.KeyCode==Keys.Enter) {
	 	if (!Validator.TextBoxex<BuyBill>(textBox2,textBox3,out int_textBox2,out float_textBox3)) 
	 	{
	 		comboBox1.Focus();
	 		return;
	 	}
		
	 	textBox2.Text=(textBox2.Text=="")?"0":textBox2.Text;
			textBox3.Text=(textBox3.Text=="")?"0":textBox3.Text;
			double q,p,s;
			q=double.Parse(int_textBox2.ToString());
			p=double.Parse(float_textBox3.ToString());
			s=q*p;
			label1.Text=s.ToString();
			
			textBox3.Focus();
		
		}
		}
		
		void TextBox3_KeyUp(object sender, KeyEventArgs e)
		{
		
		int int_textBox2;
	 float float_textBox3;
		if (e.KeyCode==Keys.Enter) {
	 	if (!Validator.TextBoxex<BuyBill>(textBox2,textBox3,out int_textBox2,out float_textBox3)) 
	 	{
	 		comboBox1.Focus();
	 		return;
	 	}
		
			textBox2.Text=(textBox2.Text=="")?"0":textBox2.Text;
			textBox3.Text=(textBox3.Text=="")?"0":textBox3.Text;	
			double q,p,s;
			q=double.Parse(int_textBox2.ToString());
			p=double.Parse(float_textBox3.ToString());
			s=q*p;
			label1.Text=s.ToString();
			
			new_row_btn.PerformClick();
			comboBox1.Focus();
			label7.Text="";
		
		}
			
		}
		
//		void Button1Click(object sender, EventArgs e)
//		{
//			textBox2.Text=(textBox2.Text=="")?"0":textBox2.Text;
//			textBox3.Text=(textBox3.Text=="")?"0":textBox3.Text;
//			double q,p,s;
//			q=double.Parse(textBox2.Text);
//			p=double.Parse(textBox3.Text);
//			s=q*p;
//			label1.Text=s.ToString();
//			//label6.Text=sender.ToString();
//			//label6.Text=this.tableLayoutPanel2.RowCount.ToString();
//			//Product cur_prod=list_prod[int.Parse(textBox4.Text)];
//			//label6.Text=cur_prod.Title+" "+cur_prod.Price_buy.ToString()+" "+cur_prod.Quantity.ToString();
//		}
		
		
					
		void New_row_btnClick(object sender, EventArgs e)
		{
			
			string[] values;
			int n=4;
	int int_textBox2;
	 float float_textBox3;
		
	 	if (!Validator.TextBoxex<BuyBill>(textBox2,textBox3,out int_textBox2,out float_textBox3)) 
	 	  {return;}
		
			textBox2.Text=(textBox2.Text=="")?"0":textBox2.Text;
			textBox3.Text=(textBox3.Text=="")?"0":textBox3.Text;
			
			values=new string[n];
			values[0]=comboBox1.Text;
			values[1]=int_textBox2.ToString();
			values[2]=float_textBox3.ToString();
			values[3]=(float.Parse(values[1])*float.Parse(values[2])).ToString();

		//if (!list_prod.IsUnitByTitle(values[0])) {
			//Product new_prod = new Product(values[0]);
			//new_prod.Title=values[0];
			
			//DB
			if (!DB.IsUnitByTitle<Product>(values[0])) {
				Product new_prod = new Product(values[0]);
				
				if (Config.ask_barcode) {
					FormInputBarcode f=new FormInputBarcode(new GetDataFromOtherForm(SetBarcodeFromOtherForm));
					
					f.ShowDialog();
					new_prod.Barcode=this.curr_barcode;
				}
			//	MessageBox.Show("Записываю в базу "+new_prod.Title);
				MessageBox.Show("Штрихкод "+new_prod.Barcode);
				new_prod.AddToDB();
		
				comboBox1.Items.Add(new_prod.Title);
		
				if(this.app!=null) this.app.EventNewProductCreate(new_prod);
		
			}
			//else{MessageBox.Show("Такой товар в базе уже есть "+new_prod.Title);}
			//
			
		//	this.list_prod.Add(new_prod);
			

		//}
		//buy_bill.AddRow(((Product)list_prod.FindByTitle(values[0])),int.Parse(values[1]),float.Parse(values[2]),float.Parse(values[1])*float.Parse(values[2]));
		//string storageText=comboBox3.Text;
		//Storage bbStorage=DB.GetUnitByTitle<Storage>(storageText);
		
		if (this.buy_bill.Storage==null) {
				MessageBox.Show("Не выставлен склад. Строка не добавлена!");
				return;
			}
		
		Product prod = DB.GetUnitByTitle<Product>(values[0]);
				if (prod==null) {
				MessageBox.Show("Не определен товар. Строка не добавлена!");
				return;
			}
		
		this.buy_bill.AddRow(this.buy_bill.Storage
			                     ,prod
			                     ,int.Parse(values[1]),float.Parse(values[2])
			                     ,float.Parse(values[1])*float.Parse(values[2]));

		UpdateTotalAndDataGridView();
		if (dataGridView1.RowCount>0)
		dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];	
		textBox2.Text="0";
		textBox3.Text="0";
		this.comboBox1.Focus();
		}
		

		
		void Button2Click(object sender, EventArgs e)
		{

			
			string providerText=comboBox2.Text;
			string storageText=comboBox3.Text;
//			if (list_pa.IsUnitByTitle(provider)) {
//				this.buy_bill.Provider=(Partner)list_pa.FindByTitle(provider);
//			}
//			else {
//				Partner newPartner=new Partner(provider);
//			//	newPartner.Title=provider;
//				
//				//DB
//				newPartner.AddToDB();
//				//
//				
//				this.buy_bill.Provider=newPartner;
//				list_pa.Add(newPartner);
//			}
			if (!DB.IsUnitByTitle<Partner>(providerText)) {
				Partner newPartner=new Partner(providerText);
				newPartner.AddToDB();
			}
			//Partner bbPartner;
			//DB.GetUnitByTitle(providerText,out bbPartner);
			Partner bbPartner=DB.GetUnitByTitle<Partner>(providerText);
			if (bbPartner!=null) this.buy_bill.Provider=bbPartner;
			
			Storage bbStorage=DB.GetUnitByTitle<Storage>(storageText);
			if (bbStorage!=null) this.buy_bill.Storage=bbStorage;
		//	MessageBox.Show(this.buy_bill.Storage.Title);
			//BuyBill.number++;
			//this.buy_bill.Number_instance=BuyBill.number;
			this.buy_bill.Number_instance=DB.GetNextNumber<BuyBill>();
			dateTimePicker1.Value=DateTime.Now;
			this.buy_bill.Date=dateTimePicker1.Value;
			
			this.buy_bill.CheckOperation(this.list_rq);
    		//this.list_bb.Add(this.buy_bill);
    		this.buy_bill.AddToDB();
    		if (this.app!=null) {
    			this.app.EventAnyProductsUpdate();
    			this.app.EventChangeApp();
    		}
    		
    		
    		//FileDataBase.UpdateListProducts(list_prod);
    //	FileDataBase.Update<ListUnits>(ref this.list_prod,"list_products.txt");
    //	FileDataBase.Update<ListUnits>(ref this.list_pa,"list_partners.txt");
    	//	FileDataBase.UpdateListBuyBills(this.list_bb);
		//	FileDataBase.UpdateListQReportStruct(this.list_rq);
			
			
			  //this.Close();
			this.Text="Приходная накладная. Проведена";
			this.label12.Text=buy_bill.Number_instance.ToString();
			this.comboBox1.Enabled=false;
			this.comboBox2.Enabled=false;
			this.comboBox3.Enabled=false;
			this.textBox2.ReadOnly=true;
			this.textBox3.ReadOnly=true;
			this.new_row_btn.Enabled=false;
			this.button2.Enabled=false;
			this.dateTimePicker1.Enabled=false;
			dataGridView1.ReadOnly=true;
			label7.Text="";
		    label18.Text="";
		}
		
		void Form1FormClosing(object sender, System.ComponentModel.CancelEventArgs e)

      {
		this.buy_bill=null;
		
		}
		
		void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) {
			//	MessageBox.Show("escape");
				this.Close();
				
			}
		
		}
		

		
		void comboBox1Form1_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode==Keys.Enter) {
				textBox2.Focus();
				//Product prod=(Product)list_prod.FindByTitle(comboBox1.Text);
				Product prod=DB.GetUnitByTitle<Product>(comboBox1.Text);
				if (prod!=null) {
					textBox3.Text=prod.Price_buy.ToString();
	
	//	Storage storage=(comboBox3.Text!="")?DB.GetUnitByTitle<Storage>(comboBox3.Text):null;
		if (this.buy_bill.Storage!=null)
			label7.Text=DB.GetProdStockAtStorage(prod,this.buy_bill.Storage).ToString();
					
		//label7.Text=prod.Quantity.ToString();
				}else{textBox3.Text="0";}
			
			}
		}
		
		void comboBox2Form1_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode==Keys.Enter) {
				comboBox1.Focus();
				
			
			}
		}
		
			void FormSell_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) {
			//	MessageBox.Show("escape");
				this.Close();
				
			}
		
		}
		
void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
	if (this.dateTimePicker1.Enabled) {
		//	if (e.KeyCode == Keys.Delete) {
		if ((e.ColumnIndex==0)&&(dataGridView1[e.ColumnIndex,e.RowIndex].Value.ToString()=="x")) {
		//	int index=e.RowIndex;
		    int index=int.Parse((dataGridView1[6,e.RowIndex].Value).ToString());
		//	object obj=dataGridView1[1,e.RowIndex].Value;
			
		//	if (obj.ToString()!="") {
		//		int id=int.Parse(obj.ToString());
				this.buy_bill.List_rows.RemoveAt(index);
				this.buy_bill.UpdateTotal();
				UpdateTotalAndDataGridView();
				if (dataGridView1.RowCount==0) label18.Text="";
	//		}
				
				
			}
	}
		}
		
	void DataGridView1RowEnter(object sender, DataGridViewCellEventArgs e)
		{
	if (this.dateTimePicker1.Enabled) {
		
		object obj_prodid=dataGridView1[1,e.RowIndex].Value;	
		Product prod=(obj_prodid.ToString()!="")?DB.GetUnitById<Product>(obj_prodid.ToString()):null;
		//label18.Text=prod.Quantity.ToString();
		//Storage storage=(comboBox3.Text!="")?DB.GetUnitByTitle<Storage>(comboBox3.Text):null;
		if ((prod!=null)&&(this.buy_bill.Storage!=null))
			label18.Text=DB.GetProdStockAtStorage(prod,this.buy_bill.Storage).ToString();
		//label18.Text=prod.Quantity.ToString();
		}
	}
		
void DataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
	if (this.dateTimePicker1.Enabled) {
		
	 if (e.ColumnIndex==3) {
//			dataGridView1.ReadOnly=false;
			object obj=dataGridView1[e.ColumnIndex,e.RowIndex].Value;
			object obj_prodid=dataGridView1[1,e.RowIndex].Value;
			
			//	int index=e.RowIndex;
		    int index=int.Parse((dataGridView1[6,e.RowIndex].Value).ToString());
		
			int new_quantity;
			
			//int new_quantity=(obj.ToString()!="")?int.Parse(obj.ToString()):0;
			if (!Validator.DgvCell<BuyBill>(obj.ToString(),out new_quantity)) {
				UpdateTotalAndDataGridView();
				return;
			}
			else 
			{
			Product prod=(obj_prodid.ToString()!="")?DB.GetUnitById<Product>(obj_prodid.ToString()):null;
			
			if (prod==null) {
			MessageBox.Show("Ошибка! Не найден такой товар. Строка удалена.");
			this.buy_bill.List_rows.RemoveAt(index);
				this.buy_bill.UpdateTotal();
				UpdateTotalAndDataGridView();
			}
	
  
  RowDocStruct new_row = this.buy_bill.List_rows[index];
			
			new_row.quantity=new_quantity;
			new_row.sum=new_row.quantity*new_row.price;
			this.buy_bill.List_rows.RemoveAt(index);
			this.buy_bill.List_rows.Insert(index,new_row);
			this.buy_bill.UpdateTotal();
			
		        
		        
			UpdateTotalAndDataGridView();
			}
			
		}
	
	}
		}
		
		void comboBox3Form1_SelectedValueChanged(object sender, EventArgs e)
		{
		
		Product prod=(comboBox1.Text!="")?DB.GetUnitByTitle<Product>(comboBox1.Text):null;
		
		Storage storage=(comboBox3.Text!="")?DB.GetUnitByTitle<Storage>(comboBox3.Text):null;
		
		this.buy_bill.Storage=storage;
		
		if ((prod!=null)&&(storage!=null))
			label7.Text=DB.GetProdStockAtStorage(prod,storage).ToString();
		
		
		if (dataGridView1.RowCount>0) {
		//MessageBox.Show(dataGridView1.CurrentRow.Index);
		object obj_prodid=dataGridView1[1,dataGridView1.CurrentRow.Index].Value;
		Product dgv_prod=(obj_prodid.ToString()!="")?DB.GetUnitById<Product>(obj_prodid.ToString()):null;
		if ((dgv_prod!=null)&&(storage!=null)) 
			label18.Text=DB.GetProdStockAtStorage(dgv_prod,storage).ToString();
		
		}
		
		}
		
		
		
		
		void Button1Click(object sender, EventArgs e)
		{
			this.printPreviewDialog1.ShowDialog();
		}
		
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			string[] data;
			Graphics g = e.Graphics;

string title = "Приходная накладная №";
title += this.buy_bill.Number_instance.ToString();
title+=" от ";
title+=this.buy_bill.Date.ToString();

string total_q=this.buy_bill.Total_quantity.ToString();
string total_sum=this.buy_bill.Total_sum.ToString();
	
data = new string[3];
data[0]=title;
data[1]=total_q;
data[2]=total_sum;

DataTable dt = this.buy_bill.GetDataTable();

DrawForPrint.DrawDocWhithTable(g,data,dt);
		}
		
//		public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
//        {
//           // if (!connect) return;
//            string code = port.ReadExisting();
//          //  foreach (char data in code.ToCharArray())
//           //     Read((int)data);
//           MessageBox.Show(code);
//        }
		
	}
}
