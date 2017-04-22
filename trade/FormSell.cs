/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 07.09.2016
 * Time: 17:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
//using System.IO.Ports;
using trade.Barcode;

namespace trade
{

	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class FormSell : Form
	{
		
	//	int counter;
	//	List<Label[]> list_rows;
	//	ListUnits list_prod, list_pa;
	TradeApp app;
	
		ListTradeOperation list_to;
		ListQReportStruct list_rq;
		
	//	DataTable dt;
	//    List<RowDocStruct> list_rb;
	//    ListSellBills list_sb;
	    SellBill sell_bill;
	    
	//    SerialPort port;
	    COMBarcodeScaner scaner;
	    
	//float total_quantity=0;
	//float total_sum=0;
	
		public FormSell(TradeApp app, ListTradeOperation list_to, ListQReportStruct list_rq)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		//	this.counter=1;
		//	this.list_rows=new List<Label[]>();
			
//			this.list_prod=list_prod;
//			this.list_pa=list_pa;
//		    Unit[] arr_prod=this.list_prod.GetAll();
//			foreach (Product prod in arr_prod) comboBox1.Items.Add(prod.Title);
//			
//			foreach (Partner pa in this.list_pa.GetAll()) comboBox2.Items.Add(pa.Title);
		foreach (Product prod in DB.GetAll<Product>())
				comboBox1.Items.Add(prod.Title);
			
	
			foreach (Partner pa in DB.GetAll<Partner>())
				comboBox2.Items.Add(pa.Title);
		
		foreach (Storage storage in DB.GetAll<Storage>())
				comboBox3.Items.Add(storage.Title);
		
			this.list_to=list_to;
			this.list_rq=list_rq;
//			this.dt = new DataTable();
//			this.dt.Columns.Add("Товар");
//			this.dt.Columns.Add("Количество");
//			this.dt.Columns.Add("Цена");
//			this.dt.Columns.Add("Сумма");
//			
//			this.list_rb=new List<RowDocStruct>();
			
			//this.list_sb=list_sb;
			this.sell_bill=new SellBill();
			this.Text="Расходная накладная. Новая";
			//this.comboBox2.Focus();
			//Поменяйте лучше TabIndex на 0 в FormSell.Designer
			this.KeyPreview = true;
			
			scaner=new COMBarcodeScaner(Config.barcode_port);
			scaner.Connect();
			scaner.GetBarcode += new BarcodeHandler(com_scaner_ReceiveBarcode);
//		    port = new SerialPort("COM1");
//		    if (!port.IsOpen) port.Open();
//			port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
		
		this.app=app;
		}
		
		
		public FormSell(SellBill sb)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
//			this.dt = new DataTable();
//			this.dt.Columns.Add("Товар");
//			this.dt.Columns.Add("Количество");
//			this.dt.Columns.Add("Цена");
//			this.dt.Columns.Add("Сумма");
//			
//			foreach (RowDocStruct row_b in sb.List_rows) {
//				dt.Rows.Add(row_b.product.Title,row_b.quantity,row_b.price,row_b.sum);
//			this.total_quantity +=row_b.quantity;
//			this.total_sum +=row_b.sum;
//			}
			this.Text="Расходная накладная. Проведена";
			this.label12.Text=sb.Number_instance.ToString();
			dateTimePicker1.Value=sb.Date;
			if (sb.Consumer!=null) this.comboBox2.Text=sb.Consumer.Title;
			
			this.comboBox3.DropDownStyle=ComboBoxStyle.DropDown;
			if (sb.Storage!=null) this.comboBox3.Text=sb.Storage.Title;
			
			this.comboBox1.Enabled=false;
			this.comboBox2.Enabled=false;
			this.comboBox3.Enabled=false;
			this.textBox2.ReadOnly=true;
			this.textBox3.ReadOnly=true;
			this.new_row_btn.Enabled=false;
			this.button2.Enabled=false;
			this.dateTimePicker1.Enabled=false;
			dataGridView1.ReadOnly=true;
			
				
			label17.Text=sb.Total_quantity.ToString();
			label18.Text=sb.Total_sum.ToString();
			
			dataGridView1.DataSource=sb.GetDataTable();
			FormatDataGridView();
//			dataGridView1.Columns[1].Visible=false;
//		    dataGridView1.Columns[0].Width=20;
//		    dataGridView1.Columns[0].DefaultCellStyle.Alignment=DataGridViewContentAlignment.MiddleCenter;
		    
			this.KeyPreview = true;
			
			this.sell_bill=sb;
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
	dataGridView1.DataSource=sell_bill.GetDataTable();
			FormatDataGridView();
	label17.Text=this.sell_bill.Total_quantity.ToString();
    label18.Text=this.sell_bill.Total_sum.ToString();
    
		}	
		
//void SetText(string text)
//{
//  // InvokeRequired required compares the thread ID of the
//  // calling thread to the thread ID of the creating thread.
//  // If these threads are different, it returns true.
//  if (this.comboBox1.InvokeRequired)
//  { 
//    SetTextCallback d = new SetTextCallback(SetText);
//    this.Invoke(d, new object[] { text });
//  }
//  else
//  {
//    this.comboBox1.Text = text;
//  }
//}

//void SetDataTable()
//{
//  // InvokeRequired required compares the thread ID of the
//  // calling thread to the thread ID of the creating thread.
//  // If these threads are different, it returns true.
//  if (this.dataGridView1.InvokeRequired)
//  { 
//    SetDataTableCallback d = new SetDataTableCallback(SetDataTable);
//    this.Invoke(d, new object[] {});
//  }
//  else
//  {
////  	label17.Text=this.sell_bill.Total_quantity.ToString();
////    label18.Text=this.sell_bill.Total_sum.ToString();
////    this.dataGridView1.DataSource = dt;
////    FormaDataGridView();
//UpdateTotalAndDataGridView();
//    if (dataGridView1.RowCount>0)
//   dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
//  }
//}
//		

		
		void TextBox2_KeyUp(object sender, KeyEventArgs e)
		{
	int int_textBox2;
	 float float_textBox3;
	 
	 
	 
		if (e.KeyCode==Keys.Enter) {
			
	 	if (!Validator.TextBoxex<SellBill>(textBox2,textBox3,out int_textBox2,out float_textBox3)) 
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
			label6.Text="";
	 	 
		}
		}
		
		void TextBox3_KeyUp(object sender, KeyEventArgs e)
		{
			
	int int_textBox2;
	 float float_textBox3;
	 
		if (e.KeyCode==Keys.Enter) {
			// if (!ValidateTextBoxex(out int_textBox2, out float_textBox3)) return;	
			if (!Validator.TextBoxex<SellBill>(textBox2,textBox3,out int_textBox2,out float_textBox3)) 
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
		
//		void TextBox2TextChanged(object sender, EventArgs e)
//		{
//			
//		}
//		
//		void TextBox3TextChanged(object sender, EventArgs e)
//		{
//			
//		}
//		
//		
//		
//		void ToolStripMenuItem1Click(object sender, EventArgs e)
//		{
//			//Close();
//		}
//		
//		void ToolStripMenuItem2Click(object sender, EventArgs e)
//		{
//			
//		}
//		
//		void ToolStripMenuItem3Click(object sender, EventArgs e)
//		{
//			Close();
//		}
		
		
	
		
			
		void New_row_btnClick(object sender, EventArgs e)
		{
			
			string[] values;
			int n=4;
			
			int int_textBox2;
	        float float_textBox3;
	 
         // if (!ValidateTextBoxex(out int_textBox2, out float_textBox3)) return;	
			
         if (!Validator.TextBoxex<SellBill>(textBox2,textBox3,out int_textBox2,out float_textBox3)) return;
		
             //int num_rows=this.tableLayoutPanel2.RowCount;
			
			//if (this.counter>num_rows) this.tableLayoutPanel2.RowCount++;
			textBox2.Text=(textBox2.Text=="")?"0":textBox2.Text;
			textBox3.Text=(textBox3.Text=="")?"0":textBox3.Text;
			
			values=new string[n];
			values[0]=comboBox1.Text;
			values[1]=int_textBox2.ToString();
			values[2]=float_textBox3.ToString();
			values[3]=(float.Parse(values[1])*float.Parse(values[2])).ToString();
		//	System.Windows.Forms.Label[] arr_label=new System.Windows.Forms.Label[n];
			
			
			
			
			
//			Product[] arr_prod=this.list_prod.GetAll();
//			bool old=false;
//			bool have_stock=true;
//			foreach (Product cur_prod in arr_prod) {
//				if (values[0]==cur_prod.Title) {
//					//cur_prod.Price_buy=float.Parse(values[2]);
//					if(cur_prod.Quantity>=int.Parse(values[1])) {
//				//	cur_prod.Quantity -= int.Parse(values[1]);
//					
//					this.list_rb.Add(new RowDocStruct(cur_prod,int.Parse(values[1]),float.Parse(values[2]),float.Parse(values[1])*float.Parse(values[2])));
//					this.total_quantity +=int.Parse(values[1]);
//			this.total_sum +=float.Parse(values[1])*float.Parse(values[2]);
//			label17.Text=this.total_quantity.ToString();
//			label18.Text=this.total_sum.ToString();
//			
//			dt.Rows.Add(values[0],values[1],values[2],values[3]);
//					
//					have_stock=true;
//					}else have_stock=false;
//					old=true;
//				}
//			}
			
//		if (!list_prod.IsUnitByTitle(values[0])) {
//		MessageBox.Show("Такой товар не найден");
//		    
//		}else{
//			if(!sell_bill.AddRow(((Product)list_prod.FindByTitle(values[0])),int.Parse(values[1]),float.Parse(values[2]),float.Parse(values[1])*float.Parse(values[2]))) {
//			MessageBox.Show("Нет в наличии такого количества");	
//			}
//			
//		}
		if (this.sell_bill.Storage==null) {
				MessageBox.Show("Не выставлен склад. Строка не добавлена!");
				return;
			}
		
		
		
		
			//DB
			if (!DB.IsUnitByTitle<Product>(values[0])) {
				MessageBox.Show("Такой товар не найден");
			}else{
				Product prod = DB.GetUnitByTitle<Product>(values[0]);
				if (prod==null) {
				MessageBox.Show("Не определен товар. Строка не добавлена!");
				return;
			}
				
				if(!sell_bill.AddRow(this.sell_bill.Storage
				                     ,prod
				                     ,int.Parse(values[1])
				                     ,float.Parse(values[2])
				                     ,float.Parse(values[1])*float.Parse(values[2]))) {
			                 MessageBox.Show("Нет в наличии такого количества");	
				}
			}
			//else{MessageBox.Show("Такой товар в базе уже есть "+new_prod.Title);}
			//
			
//			if (!old) {
//				MessageBox.Show("Такой товар не найден");
//				
//			}else{
//				if(!have_stock) {
//					MessageBox.Show("Нет в наличии такого количества");
//				}else{
//			//	for (int i=0; i<n; i++) {
//				//arr_label[i]=new System.Windows.Forms.Label();
//				//this.tableLayoutPanel2.Controls.Add(arr_label[i],i,this.counter);
//				//arr_label[i].Text=values[i];
//				//	}
//					
//			}
//		    
//			//this.list_rows.Add(arr_label);
//			//this.counter++;
//			}
			UpdateTotalAndDataGridView();
		
			if(dataGridView1.RowCount>0) 
				dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
		
		textBox2.Text="0";
		textBox3.Text="0";
		this.comboBox1.Focus();
		}
		
//		void TableLayoutPanel2Paint(object sender, PaintEventArgs e)
//		{
//			
//		}
		
		void Button2Click(object sender, EventArgs e)
		{
//			SellBill sellbill=new SellBill();
//			sellbill.List_rows=this.list_rb;
		//	this.sell_bill.Number_instance=SellBill.number;
		    dateTimePicker1.Value=DateTime.Now;
			this.sell_bill.Date=dateTimePicker1.Value;
			
			if (this.sell_bill.Storage==null) {
				MessageBox.Show("Не выставлен склад. Накладная не проведена!");
				return;
			}

				
//			bool have_stock=true;
//			string prod_title_no="";
//			foreach (RowDocStruct row_b in sellbill.List_rows) {
//				//dt_2.Rows.Add(buybill.Number_instance,row_b.product.Title,row_b.quantity,row_b.price,row_b.sum);
//				if (row_b.product.Quantity>=row_b.quantity) {
//				sellbill.Total_sum +=row_b.sum;
//				row_b.product.Quantity -= row_b.quantity;
//				
//			
//				}else{
//					have_stock=false;
//					prod_title_no=row_b.product.Title;
//				}
//			}
			
			string[] check_all=this.sell_bill.CheckAvailableAll(this.sell_bill.Storage);
			if ((int.Parse(check_all[0])==0)) {
				MessageBox.Show("Нет в наличии такого количества товара "+check_all[1]);
				//sell_bill=null;
			}
//			if (!have_stock) {
//				MessageBox.Show("Нет в наличии такого количества товара "+prod_title_no);	
//				sell_bill=null;
//			}
			else{
		//	this.sell_bill.DecreaseStock();
			//SellBill.number++;
			//this.sell_bill.Number_instance=SellBill.number;
			this.sell_bill.Number_instance=DB.GetNextNumber<SellBill>();
			this.sell_bill.Date=dateTimePicker1.Value;
			
			string consumerText=comboBox2.Text;
		if (!DB.IsUnitByTitle<Partner>(consumerText)) {
				Partner newPartner=new Partner(consumerText);
				newPartner.AddToDB();
			}
			//Partner bbPartner;
			//DB.GetUnitByTitle(providerText,out bbPartner);
			Partner sbPartner=DB.GetUnitByTitle<Partner>(consumerText);
			if (sbPartner!=null) this.sell_bill.Consumer=sbPartner;	
			
			
			
//			if (this.list_pa.IsUnitByTitle(consumer)) {
//				
//				this.sell_bill.Consumer=(Partner)this.list_pa.FindByTitle(consumer);
//				
//			}
//			else {
//				Partner newPartner=new Partner(consumer);
//				//newPartner.Title=consumer;
//				
//				//DB
//				newPartner.AddToDB();
//				//DB
//				
//				this.sell_bill.Consumer=newPartner;
//				list_pa.Add(newPartner);
//			}
			
			this.sell_bill.CheckOperation(this.list_to,this.list_rq);
			//this.list_sb.Add(sell_bill);
			this.sell_bill.AddToDB();
			if (this.app!=null) {
				this.app.EventAnyProductsUpdate();
    			this.app.EventChangeApp();
    		}
			      //dataGridView2.DataSource=dt_2;
			      //FileDataBase.UpdateListProducts(this.list_prod);
			//FileDataBase.Update<ListUnits>(ref list_prod,"list_products.txt");
			//FileDataBase.Update<ListUnits>(ref list_pa, "list_partners.txt");
//			FileDataBase.UpdateListSellBills(this.list_sb);
//			FileDataBase.UpdateListTradeOperation(this.list_to);
//			FileDataBase.UpdateListQReportStruct(this.list_rq);
			//this.Close();
			this.Text="Расходная накладная. Проведена";
			this.label12.Text=sell_bill.Number_instance.ToString();
			
			this.comboBox1.Enabled=false;
			this.comboBox2.Enabled=false;
			this.comboBox3.Enabled=false;
			this.textBox2.ReadOnly=true;
			this.textBox3.ReadOnly=true;
			this.new_row_btn.Enabled=false;
			this.button2.Enabled=false;
			this.dateTimePicker1.Enabled=false;
			dataGridView1.ReadOnly=true;
			label6.Text="";
		    label19.Text="";
			}
		}
		
		
		
		void comboBox1FormSell_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode==Keys.Enter) {
				
				float markup;
				markup=Config.markup;
				Partner pa=DB.GetUnitByTitle<Partner>(comboBox2.Text);
				//markup=pa.Markup_type.Basic_percent;
				if (pa!=null)
					if (pa.Markup_type!=null)
						markup=pa.Markup_type.Basic_percent;
						
				
				textBox2.Focus();
				//Product prod=(Product)list_prod.FindByTitle(comboBox1.Text);
				Product prod=DB.GetUnitByTitle<Product>(comboBox1.Text);
				if (prod!=null) {
				
					textBox3.Text=(Math.Round(prod.Price_buy*((markup+100)/100),0)).ToString();
					
					foreach (KeyValuePair<MarkupType,float> keyValue in prod.List_markupType)
						if (keyValue.Key.Id==pa.Markup_type.Id)
							textBox3.Text=(keyValue.Value).ToString();
					
					
					//label6.Text=prod.Quantity.ToString();
					if (this.sell_bill.Storage!=null)
			label6.Text=DB.GetProdStockAtStorage(prod,this.sell_bill.Storage).ToString();
				}else{textBox3.Text="0";}
			
			}
		}
		
		void comboBox2FormSell_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode==Keys.Enter) {
				comboBox3.Focus();
				
			
			}
		}
		
void comboBox2FormSell_FocusLeave(object sender, EventArgs e) {
			if (this.sell_bill!=null) {
			List<RowDocStruct> row_d=new List<RowDocStruct>();
			float markup;
				markup=Config.markup;
				Partner pa=DB.GetUnitByTitle<Partner>(comboBox2.Text);
				//markup=pa.Markup_type.Basic_percent;
				if (pa!=null)
					if (pa.Markup_type!=null)
						markup=pa.Markup_type.Basic_percent;
			foreach (RowDocStruct rd in this.sell_bill.List_rows) {
					float new_price=float.Parse((Math.Round(rd.product.Price_buy*((markup+100)/100),0)).ToString());
					row_d.Add(new RowDocStruct(
					rd.product
					,rd.quantity
					,new_price
					,rd.quantity*new_price
				)
					         );
				
			}
				this.sell_bill.List_rows=row_d;
				UpdateTotalAndDataGridView();
			}
		}
		
void comboBox3Form1_SelectedValueChanged(object sender, EventArgs e)
		{
		
		Product prod=(comboBox1.Text!="")?DB.GetUnitByTitle<Product>(comboBox1.Text):null;
		
		Storage storage=(comboBox3.Text!="")?DB.GetUnitByTitle<Storage>(comboBox3.Text):null;
		
		this.sell_bill.Storage=storage;
		
		if ((prod!=null)&&(storage!=null))
			label6.Text=DB.GetProdStockAtStorage(prod,storage).ToString();
		
		
		if (dataGridView1.RowCount>0) {
		//MessageBox.Show(dataGridView1.CurrentRow.Index);
		object obj_prodid=dataGridView1[1,dataGridView1.CurrentRow.Index].Value;
		Product dgv_prod=(obj_prodid.ToString()!="")?DB.GetUnitById<Product>(obj_prodid.ToString()):null;
		if ((dgv_prod!=null)&&(storage!=null)) 
			label19.Text=DB.GetProdStockAtStorage(dgv_prod,storage).ToString();
		
		}
		
		//comboBox1.Focus();
		
		}

void comboBox3FormSell_KeyUp(object sender, KeyEventArgs e) {
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
		

//		void DataGridView1_KeyUp(object sender, KeyEventArgs e)
//		{
void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
	if (this.dateTimePicker1.Enabled) {
		//	if (e.KeyCode == Keys.Delete) {
		if ((e.ColumnIndex==0)&&(dataGridView1[e.ColumnIndex,e.RowIndex].Value.ToString()=="x")) {
			
		//	object obj=dataGridView1[1,e.RowIndex].Value;
		//	int index=e.RowIndex;
		int index=int.Parse((dataGridView1[6,e.RowIndex].Value).ToString());
			
		//if (obj.ToString()!="") {
			//	int id=int.Parse(obj.ToString());
				this.sell_bill.List_rows.RemoveAt(index);
				this.sell_bill.UpdateTotal();
				UpdateTotalAndDataGridView();
				if (dataGridView1.RowCount==0) label19.Text="";
			//}
				
				
		}
	
		//else {dataGridView1.ReadOnly=true;}
	}
		}

void DataGridView1RowEnter(object sender, DataGridViewCellEventArgs e)
		{
	if (this.dateTimePicker1.Enabled) {
		
		object obj_prodid=dataGridView1[1,e.RowIndex].Value;	
		Product prod=(obj_prodid.ToString()!="")?DB.GetUnitById<Product>(obj_prodid.ToString()):null;
		//label19.Text=prod.Quantity.ToString();
		if ((prod!=null)&&(this.sell_bill.Storage!=null))
			label19.Text=DB.GetProdStockAtStorage(prod,this.sell_bill.Storage).ToString();
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
			if (!Validator.DgvCell<SellBill>(obj.ToString(),out new_quantity)) {
				UpdateTotalAndDataGridView();
				return;
			}
			else 
			{
			Product prod=(obj_prodid.ToString()!="")?DB.GetUnitById<Product>(obj_prodid.ToString()):null;
		
			if (prod==null) {
			MessageBox.Show("Ошибка! Не найден такой товар. Строка удалена.");
			this.sell_bill.List_rows.RemoveAt(index);
				this.sell_bill.UpdateTotal();
				UpdateTotalAndDataGridView();
			}
	int old_quantity = this.sell_bill.List_rows[index].quantity;	
	int to_add_quant=new_quantity-old_quantity;
  //MessageBox.Show(obj.ToString());
  int ask_quantity=to_add_quant;
  foreach(RowDocStruct rd in this.sell_bill.List_rows.FindAll(x=>x.product.Id==prod.Id))
			ask_quantity +=rd.quantity;
  
  int curr_stock=DB.GetProdStockAtStorage(prod,this.sell_bill.Storage);
  //if (prod.Quantity<ask_quantity) {
  if (curr_stock<ask_quantity) {
  	MessageBox.Show("Корректировка! Товара "+prod.Title+" в наличии "+curr_stock+" шт. Требуемое кол. "+ask_quantity+" шт.");
  	new_quantity +=(curr_stock-ask_quantity);
  }
  
  RowDocStruct new_row = this.sell_bill.List_rows[index];
			
			new_row.quantity=new_quantity;
			new_row.sum=new_row.quantity*new_row.price;
			this.sell_bill.List_rows.RemoveAt(index);
			this.sell_bill.List_rows.Insert(index,new_row);
			this.sell_bill.UpdateTotal();
			
		        
		        
			UpdateTotalAndDataGridView();
			}
			
		}
	
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

string title = "Товарный чек №";
title += this.sell_bill.Number_instance.ToString();
title+=" от ";
title+=this.sell_bill.Date.ToString();

string total_q=this.sell_bill.Total_quantity.ToString();
string total_sum=this.sell_bill.Total_sum.ToString();
	
data = new string[3];
data[0]=title;
data[1]=total_q;
data[2]=total_sum;

DataTable dt = this.sell_bill.GetDataTable();

DrawForPrint.DrawDocWhithTable(g,data,dt);
		
}
		
void PrintPreviewDialog1Load(object sender, EventArgs e)
		{
			
		}
		
//		public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
//        {
//           // if (!connect) return;
//           string text="";
//            string text2="";
//           string code;
//           code = port.ReadExisting();
//        //   byte[] buffer = new byte[2];
//         //  port.Read(buffer,0,buffer.Length);
//         //  while ((code = port.ReadExisting())!=null)
//         //  	  text +=code;
//           foreach (char data in code.ToCharArray())
//           //     Read((int)data);
//         //  for (int i=0; i<buffer.Length; i++)
//         //  	text2=System.Text.Encoding.Unicode.GetString(buffer);
//           	MessageBox.Show(data.ToString());
//        }
		
public void com_scaner_ReceiveBarcode(string code) {
	if (this.InvokeRequired) {
		ReadBarcode d=new ReadBarcode(com_scaner_ReceiveBarcode);
		this.Invoke(d,code);
	}else{
	//MessageBox.Show(barcode);
	//SetText(barcode);
	
			if (this.sell_bill.Storage==null) {
				MessageBox.Show("Не выставлен склад. Строка не добавлена!");
				comboBox3.Focus();
				return;
			}
	
	Product prod=DB.GetUnitByBarcode<Product>(code);
	if (prod!=null) {
	int quantity=1;
	float price=(float)Math.Round(prod.Price_buy*Config.markup,0);
	float sum=price*quantity;
	if (!this.sell_bill.AddRow(this.sell_bill.Storage
	                           ,prod
	                           ,quantity
	                           ,price
	                           ,sum))
		MessageBox.Show("Не могу добавить такое количество ("+quantity+" шт.) товара "+prod.Title+". Недостаточно наличия.");
	//dataGridView1.DataSource=this.sell_bill.GetDataTable();
	//SetDataTable(this.sell_bill.GetDataTable());
	UpdateTotalAndDataGridView();
    if (dataGridView1.RowCount>0)
   dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.RowCount-1].Cells[0];
	}else{MessageBox.Show("Такой товар не найден");}
	}
}
		
		
void FormSellFormClosing(object sender, System.ComponentModel.CancelEventArgs e)

    {
		this.sell_bill=null;
		
		if (scaner!=null) {
			scaner.GetBarcode -= new BarcodeHandler(com_scaner_ReceiveBarcode);
			scaner.Disconnect();
			scaner=null;
		}
		
	}
	
		
	}
}
