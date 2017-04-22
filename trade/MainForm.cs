/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 06.09.2016
 * Time: 9:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.IO;
using System.Data.Common;

namespace trade
{

	
	
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		
		public ListUnits list_prods;
		public ListTradeOperation list_to;
		public ListQReportStruct list_rq;
		public ListBuyBills list_bb;
		public ListSellBills list_sb;
		public ListUnits list_pa;
		//public List<Unit> list_prods, list_pa;
		TradeApp app;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			//this.list_prods=new ListProducts();
			//this.list_prods=FileDataBase.LoadListProduct();
			this.app = new TradeApp();
			
			Config.dbServer="sqlite";
			Config.barcode_port="COM3";
			Config.ask_barcode=true;
		//	Config.dbServer="txtfile_database";
		
			
//			FileDataBase.Load<ListUnits>("list_products.txt", out this.list_prods);
//			
//			FileDataBase.Load<ListUnits>("list_partners.txt", out this.list_pa);
//			
//			this.list_bb=FileDataBase.LoadListBuyBills(this.list_prods,this.list_pa);
//		
//			this.list_sb=FileDataBase.LoadListSellBills(this.list_prods,this.list_pa);
//		
//			this.list_to=FileDataBase.LoadListTradeOperation(this.list_prods);
//			this.list_rq = FileDataBase.LoadListQReportStruct(this.list_prods);
		
		
			//FileDataBase.Test<ListUnits>(list_prods);
			//FileDataBase.Test<ListBuyBills>(list_bb);
		//	SQLiteDataBase.Execute("DROP TABLE product");
			
			SQLiteDataBase.CreateTable("product");
			SQLiteDataBase.CreateTable("partner");
			
//			SQLiteDataBase.Execute("DROP TABLE buybill");
//			SQLiteDataBase.Execute("DROP TABLE rows_in_buybill");
//			SQLiteDataBase.Execute("DROP TABLE sellbill");
//			SQLiteDataBase.Execute("DROP TABLE rows_in_sellbill");
			
			SQLiteDataBase.CreateTable("buybill");
			SQLiteDataBase.CreateTable("rows_in_buybill");
			SQLiteDataBase.CreateTable("sellbill");
			SQLiteDataBase.CreateTable("rows_in_sellbill");
			
//			SQLiteDataBase.Execute("DROP TABLE trade_operation");
//			SQLiteDataBase.Execute("DROP TABLE quantity_report");
		
			SQLiteDataBase.CreateTable("trade_operation");
			SQLiteDataBase.CreateTable("quantity_report");
			
			SQLiteDataBase.CreateTable("storage");
			SQLiteDataBase.CreateTable("prodqty_storage");
			SQLiteDataBase.CreateTable("markup_type");
			SQLiteDataBase.CreateTable("prod_markup");
			SQLiteDataBase.CreateTable("partner_markuptoprod");
			SQLiteDataBase.CreateTable("partner_markup_correct");
			SQLiteDataBase.CreateTable("partner_round_correct");
			
//			SQLiteDataBase.Execute("ALTER TABLE prod_markup RENAME TO old_prod_markup;");
//				SQLiteDataBase.Execute("CREATE TABLE IF NOT EXISTS prod_markup (" +
//		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
//		    	                ", prod_id INTEGER" +
//		    	                  ", markup_type_id INTEGER" +
//		    	                  ", fix_price REAL);");
//			SQLiteDataBase.Execute("INSERT INTO prod_markup (prod_id,markup_type_id,fix_price) SELECT prod_id,markup_type_id,percent FROM old_prod_markup;");
		//	SQLiteDataBase.Execute("ALTER TABLE sellbill ADD COLUMN storage_id INTEGER");
			//SQLiteDataBase.ShowAllRows("product");
		//	SQLiteDataBase.ShowAllRows("rows_in_sellbill");
		}
		
		
		
		
		void ToolStripMenuItem1Click(object sender, EventArgs e)
		{
			//Close();
		}
		
		void ToolStripMenuItem2Click(object sender, EventArgs e)
		{
			
		}
		
		void ToolStripMenuItem3Click(object sender, EventArgs e)
		{
			Close();
		}
		
		void MainFormFormClosing(object sender, System.ComponentModel.CancelEventArgs e)

      {

         if(MessageBox.Show("Вы уверены, что хотите завершить работу программы?","Выход", MessageBoxButtons.YesNo)!= DialogResult.Yes)

            e.Cancel = true;

         else

            e.Cancel = false;

      }
		
		
		
		void ToolStripMenuItem9Click(object sender, EventArgs e)
		{
			Form1 secondForm = new Form1(this.app, this.list_rq);
			//secondForm.Show(this);
			secondForm.MdiParent=this;
			secondForm.Show();
		}
		
		void ToolStripMenuItem8Click(object sender, EventArgs e)
		{
			FormProducts prodForm=new FormProducts(this.app,this.list_prods);
			//prodForm.ShowDialog(this);
			prodForm.MdiParent=this;
			prodForm.Show();
		}
		
		void ToolStripMenuItem10Click(object sender, EventArgs e)
		{
			FormSell sellForm=new FormSell(this.app,this.list_to
			                              ,this.list_rq);
			//sellForm.ShowDialog(this);
			sellForm.MdiParent=this;
			sellForm.Show();
		}
		
		
		
		
		
		void ToolStripMenuItem11Click(object sender, EventArgs e)
		{
			FormRegisterBuyBill registerBbForm=new FormRegisterBuyBill(this.app);
			registerBbForm.MdiParent=this;
			registerBbForm.Show();
		}
		
		void ToolStripMenuItem12Click(object sender, EventArgs e)
		{
			FormRegisterSellBill registerSbForm=new FormRegisterSellBill(this.app);
			registerSbForm.MdiParent=this;
			registerSbForm.Show();
			                      
		}
		
//		void Button1Click(object sender, EventArgs e)
//		{
//			DataTable dt=new DataTable();
//					dt.Columns.Add("html");
//			
////			dt.Columns.Add("Дата");
////			dt.Columns.Add("Номер документа");
////			dt.Columns.Add("Тип документа");
////			
////			dt.Columns.Add("Товар");
////			dt.Columns.Add("Приход-колич");
////			dt.Columns.Add("Расход-колич");
////			dt.Columns.Add("Остаток");
////			dt.Columns.Add("Цена закупки");
////			dt.Columns.Add("Дата");
////			dt.Columns.Add("Тип документа");
////			dt.Columns.Add("Номер документа");
////			dt.Columns.Add("Товар");
////			dt.Columns.Add("Количество");
////			dt.Columns.Add("Цена");
////			dt.Columns.Add("Сумма");
////			dt.Columns.Add("Прибыль");
////			
////			TradeOperation[] arr_to=list_to.GetAll();
////			foreach (TradeOperation to in arr_to) {
////			dt.Rows.Add(to.Date,to.Type_doc,to.Number_doc,
////				            to.Product.Title,to.Quantity,to.Price,to.Sum,to.Profit);
////			}
////			RowQuantityReportStruct[] arr_rq=this.list_rq.GetAll();
////			foreach (RowQuantityReportStruct rq in arr_rq)
////				dt.Rows.Add(rq.date
////				            ,rq.number_doc
////				            ,rq.type_doc
////				            ,rq.product.Title
////				            ,rq.income
////				            ,rq.outgo
////				            ,rq.stock_quantity
////				            ,rq.price_buy);
////			
////			dataGridView1.DataSource=dt;
//			
////			IPHostEntry host=Dns.GetHostEntry("www.russkayasumka.ru");
////			
////			label1.Text = host.HostName;
////			
////			foreach (IPAddress ip in host.AddressList)
////				dt.Rows.Add(ip.ToString());
////					CredentialCache cc= new CredentialCache();
////					cc.Add (
////						 new System.Uri("http://1.rsumka.z8.ru/sinhron_2.php?type=catalog&mode=checkauth"),
////    "Basic", 
////    new System.Net.NetworkCredential("admin", "159753")
////					);
//					HttpWebRequest req=(HttpWebRequest)WebRequest.Create("http://1.rsumka.z8.ru/sinhron_2.php?type=catalog&mode=checkauth");
//					string username = "admin";
//                    string password = "159753";
//                    String encoded = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(username + ":" + password));
//
//                    req.Headers.Add("Authorization", "Basic " + encoded);
//					
////					//req.Credentials = new NetworkCredential("admin", "159753");
////					req.Credentials = cc;
////					req.PreAuthenticate = true;
//					
//					HttpWebResponse res=(HttpWebResponse)req.GetResponse();
//            
//					Stream stream=res.GetResponseStream();
//					StreamReader reader=new StreamReader(stream);
//					string line;
//					while ((line=reader.ReadLine())!=null)
//						dt.Rows.Add(line);
////					WebHeaderCollection headers=res.Headers;
////					for (int i=0; i<headers.Count; i++)
////						dt.Rows.Add(headers.GetKey(i)+" "+headers[i]);
//			dataGridView1.DataSource=dt;
//		}
		
		void ToolStripMenuItem14Click(object sender, EventArgs e)
		{
			FormReportTrade reportTrade=new FormReportTrade(this.list_to);
			reportTrade.MdiParent=this;
			reportTrade.Show();
		}
		
		void ToolStripMenuItem13Click(object sender, EventArgs e)
		{
			FormReportStock reportStock= new FormReportStock(this.list_rq);
			reportStock.MdiParent=this;
			reportStock.Show();
		}
		
//		void Button2Click(object sender, EventArgs e)
//		{
//			DataTable dt=new DataTable();
//					dt.Columns.Add("Наименование контрагента");
//			
////			dt.Columns.Add("Дата");
////			dt.Columns.Add("Номер документа");
////			dt.Columns.Add("Тип документа");
//					Unit[] arr_pa=list_pa.GetAll();
//					foreach (Partner partner in arr_pa) {
//						dt.Rows.Add(partner.Title);
//					}
//					dataGridView1.DataSource=dt;
//		}
//		
//		void Button3Click(object sender, EventArgs e)
//		{
//			DataTable dt=new DataTable();
//			
//	dt.Columns.Add("id");
//			dt.Columns.Add("sellbill_id");
//			dt.Columns.Add("product_id");
//			
//			dt.Columns.Add("quantity");
//			dt.Columns.Add("price");
//			dt.Columns.Add("sum");
//		
//
//
//			
//			
////			dt.Columns.Add("Дата");
////			dt.Columns.Add("Номер документа");
////			dt.Columns.Add("Тип документа");
////			
////			dt.Columns.Add("Товар");
////			dt.Columns.Add("Приход-колич");
////			dt.Columns.Add("Расход-колич");
////			dt.Columns.Add("Остаток");
////			dt.Columns.Add("Цена закупки");
//			
//			
////			dt.Columns.Add("Дата");
////			dt.Columns.Add("Тип документа");
////			dt.Columns.Add("Номер документа");
////			dt.Columns.Add("Товар");
////			dt.Columns.Add("Количество");
////			dt.Columns.Add("Цена");
////			dt.Columns.Add("Сумма");
////			dt.Columns.Add("Прибыль");
//			
//			//TradeOperation[] arr_to=list_to.GetAll();
//			//foreach (TradeOperation to in arr_to) {
////			dt.Rows.Add(to.Date,to.Type_doc,to.Number_doc,
////				            to.Product.Title,to.Quantity,to.Price,to.Sum,to.Profit);
////			}
//		//	RowQuantityReportStruct[] arr_rq=this.list_rq.GetAll();
//		//	foreach (RowQuantityReportStruct rq in arr_rq)
//		foreach (DbDataRecord rec in SQLiteDataBase.GetAllRows("rows_in_sellbill")) {
//	dt.Rows.Add(rec["id"].ToString()
//		         	,rec["sellbill_id"].ToString()
//		         	,DB.GetUnitById<Product>(rec["product_id"].ToString()).Title
//,rec["quantity"].ToString()
//,rec["price"].ToString()
//,rec["sum"].ToString()
//		        );
//		         }
////		foreach (RowQuantityReportStruct rq in DB.GetAll<RowQuantityReportStruct>())
////				dt.Rows.Add(rq.date
////				            ,rq.doc_number
////				            ,rq.doc_type
////				            ,rq.product.Title
////				            ,rq.income
////				            ,rq.outgo
////				            ,rq.stock_quantity
////				            ,rq.price_buy);
//			
//			dataGridView1.DataSource=dt;
//		}
		
		void ToolStripMenuItemPartnerClick(object sender, EventArgs e)
		{
			FormPartners form= new FormPartners(this.app);
			//form.ShowDialog(this);
            form.MdiParent=this;			
			form.Show();
		}
		
		void StorageToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormStorages f= new FormStorages(this.app);
		
            f.MdiParent=this;			
			f.Show();
		}
		
		void NewStorageToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormOneStorage f= new FormOneStorage(this.app);
		
            f.MdiParent=this;			
			f.Show();
		}
		
		void TestToolStripMenuItemClick(object sender, EventArgs e)
		{
			Test f= new Test();
		
            f.MdiParent=this;			
			f.Show();
		}
		
		void TypeMarkupToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormMarkupTypes f= new FormMarkupTypes(this.app);
		
            f.MdiParent=this;			
			f.Show();
		}
		
		void NewMarkupTypeToolStripMenuItemClick(object sender, EventArgs e)
		{
			FormOneMarkupType f= new FormOneMarkupType(this.app);
		
            f.MdiParent=this;			
			f.Show();
		}
	}
}
