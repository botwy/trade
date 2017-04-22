/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 10.09.2016
 * Time: 16:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;


namespace trade
{
	/// <summary>
	/// Description of FileDataBase.
	/// </summary>
	public class FileDataBase
	{
		public FileDataBase()
		{
		}
		
		public static void InsertProduct(Product product) {
			FileStream file=new FileStream("c:\\TorgProg\\list_products.txt", FileMode.Append
, FileAccess.Write);
			 StreamWriter writer = new StreamWriter(file);
			 writer.Write(product.Title+"	"+product.Quantity+"	"+product.Price_buy+Environment.NewLine);
			 writer.Close();
		}
		
//		public static void UpdateListProducts(ListProducts list_prod) {
//			string text="";
//			FileStream file=new FileStream("c:\\TorgProg\\list_products.txt", FileMode.Truncate
//, FileAccess.Write);
//			 StreamWriter writer = new StreamWriter(file);
//			 Product[] arr_prod = list_prod.GetAll();
//			foreach (Product product in arr_prod) {
//			text +=	product.Title+"	"+product.Quantity+"	"+product.Price_buy+Environment.NewLine;
//			}
//			 writer.Write(text);
//			 writer.Close();
//		}
//		
//	public static ListProducts LoadListProduct() {
//			ListProducts list_prod=new ListProducts();
//			FileStream file=new FileStream("c:\\TorgProg\\list_products.txt", FileMode.Open
//, FileAccess.Read);
//			 StreamReader reader = new StreamReader(file);
//			 string line;
//			 while ((line=reader.ReadLine())!=null) {
//			 	string[] words=line.Split(new char[]{'\t'});
//			 	list_prod.Add(new Product(words[0],int.Parse(words[1]),float.Parse(words[2])));
////			 	foreach (string item in words) {
////			 		
////			 	}
//			 	}
//			 reader.Close();
//			 return list_prod;
//			 }
		
		public static void UpdateListBuyBills(ListBuyBills list_bb) {
			string text="";
			string text_2="";
			
			 BuyBill[] arr_bb = list_bb.GetAll();
			foreach (BuyBill bb in arr_bb) {
			 	text +=	bb.Number_instance.ToString()+'\t'
			 		+bb.Date.ToString()+'\t'
			 		+bb.Total_quantity+'\t'
			 		+bb.Total_sum+'\t'
			 		+bb.Provider.Title+Environment.NewLine;
			 	
			 	foreach (RowDocStruct row_bb in bb.List_rows) {
			 		text_2 +=bb.Number_instance.ToString()+'\t'
			 			+row_bb.product.Title+'\t'
			 			+row_bb.quantity+'\t'
			 			+row_bb.price+'\t'
			 			+row_bb.sum+Environment.NewLine;
			 	}
			}
			 
			 FileStream file=new FileStream("c:\\TorgProg\\list_buybills.txt", FileMode.Truncate
, FileAccess.Write);
			FileStream file_2=new FileStream("c:\\TorgProg\\rows_in_buybills.txt", FileMode.Truncate
, FileAccess.Write);
			 StreamWriter writer = new StreamWriter(file);
			 StreamWriter writer_2 = new StreamWriter(file_2);
			 
			 writer.Write(text);
			 writer_2.Write(text_2);
			 writer.Close();
			 writer_2.Close();
		}
	
		public static ListBuyBills LoadListBuyBills(ListUnits list_prod, ListUnits list_pa) {
			ListBuyBills list_bb=new ListBuyBills();
			//ListProducts list_prod=new ListProducts();
			List<string> text_from_ribb=new List<string>();
			FileStream file=new FileStream("c:\\TorgProg\\list_buybills.txt", FileMode.Open
, FileAccess.Read);
			FileStream file_2=new FileStream("c:\\TorgProg\\rows_in_buybills.txt", FileMode.Open
, FileAccess.Read);
			 
			StreamReader reader_2 = new StreamReader(file_2);
			string line_2;
			 while ((line_2=reader_2.ReadLine())!=null) text_from_ribb.Add(line_2);
			 reader_2.Close();
			 
			 StreamReader reader = new StreamReader(file);
			 string line;
			 
			 while ((line=reader.ReadLine())!=null) {
			 	BuyBill bb=new BuyBill();
			 
			 	
			 	string[] words=line.Split(new char[]{'\t'});
			 	bb.Number_instance=int.Parse(words[0]);
			 	BuyBill.number=bb.Number_instance;
			 	bb.Date=DateTime.Parse(words[1]);
			 	bb.Provider=(Partner)list_pa.FindByTitle(words[4]);
			 	if (text_from_ribb!=null) {
			 		Storage storage = new Storage("Основной склад");
			 	foreach (string l in text_from_ribb) 
			 		if (int.Parse(words[0])==int.Parse(l.Split('\t')[0]))
			 	{
			 		string[] w =l.Split('\t');
			 		bb.AddRow(storage,(Product)list_prod.FindByTitle(w[1]),int.Parse(w[2]),float.Parse(w[3]),float.Parse(w[4]));
			 		
			 	}
			 	}
			 	list_bb.Add(bb);
	//		 	list_bb.Add(new Product(int.Parse(words[0]),DateTime.Parse(words[1]),float.Parse(words[2],)
	//		 	                      int.Parse(words[2]),float.Parse(words[3]) ));
//			 	foreach (string item in words) {
//			 		
//			 	}
			 	}
			 reader.Close();
			 return list_bb;
			 }
		
		
			public static void UpdateListSellBills(ListSellBills list_sb) {
			string text="";
			string text_2="";
			
			 SellBill[] arr_sb = list_sb.GetAll();
			foreach (SellBill sb in arr_sb) {
			 	text +=	sb.Number_instance.ToString()
			 		+'\t'+sb.Date.ToString()
			 		+'\t'+sb.Total_quantity.ToString()
			 		+'\t'+sb.Total_sum.ToString()
			 		+'\t'+sb.Consumer.Title
			 		+'\t'+Environment.NewLine;
			 	
			 	foreach (RowDocStruct row_sb in sb.List_rows) {
			 		text_2 +=sb.Number_instance.ToString()
			 			+'\t'+row_sb.product.Title
			 			+'\t'+row_sb.quantity.ToString()
			 			+'\t'+row_sb.price.ToString()
			 			+'\t'+row_sb.sum+Environment.NewLine;
			 	}
			}
			 
			 FileStream file=new FileStream("c:\\TorgProg\\list_sellbills.txt", FileMode.Truncate
, FileAccess.Write);
			FileStream file_2=new FileStream("c:\\TorgProg\\rows_in_sellbills.txt", FileMode.Truncate
, FileAccess.Write);
			 StreamWriter writer = new StreamWriter(file);
			 StreamWriter writer_2 = new StreamWriter(file_2);
			 
			 writer.Write(text);
			 writer_2.Write(text_2);
			 writer.Close();
			 writer_2.Close();
		}
		
			public static ListSellBills LoadListSellBills(ListUnits list_prod,ListUnits list_pa) {
			ListSellBills list_sb=new ListSellBills();
			
			//ListProducts list_prod=new ListProducts();
			List<string> text_from_risb=new List<string>();
			FileStream file=new FileStream("c:\\TorgProg\\list_sellbills.txt", FileMode.Open
, FileAccess.Read);
			FileStream file_2=new FileStream("c:\\TorgProg\\rows_in_sellbills.txt", FileMode.Open
, FileAccess.Read);
			 
			StreamReader reader_2 = new StreamReader(file_2);
			string line_2;
			 while ((line_2=reader_2.ReadLine())!=null) text_from_risb.Add(line_2);
			 reader_2.Close();
			 
			 StreamReader reader = new StreamReader(file);
			 string line;
			 
			 while ((line=reader.ReadLine())!=null) {
			 	SellBill sb=new SellBill();
			    List<RowDocStruct> list_rd=new List<RowDocStruct>();
			 	
			 	string[] words=line.Split(new char[]{'\t'});
			 	sb.Number_instance=int.Parse(words[0]);
			 	SellBill.number=sb.Number_instance;
			 	sb.Date=DateTime.Parse(words[1]);
			 	sb.Consumer=(Partner)list_pa.FindByTitle(words[4]);
			 	if (text_from_risb!=null) {
			 	foreach (string l in text_from_risb) 
			 		if (int.Parse(words[0])==int.Parse(l.Split('\t')[0]))
			 	{
			 		
			 		string[] w =l.Split('\t');
			 		list_rd.Add(new RowDocStruct((Product)list_prod.FindByTitle(w[1]),int.Parse(w[2]),float.Parse(w[3]),float.Parse(w[4])));
			 	//	sb.AddRow();
			 	//	MessageBox.Show(w[1]);
			 	}
			 	}
			 	sb.List_rows=list_rd;
			 	//list_rd.Clear();
			 	list_sb.Add(sb);
	//		 	list_bb.Add(new Product(int.Parse(words[0]),DateTime.Parse(words[1]),float.Parse(words[2],)
	//		 	                      int.Parse(words[2]),float.Parse(words[3]) ));
//			 	foreach (string item in words) {
//			 		
//			 	}
			 	}
			 reader.Close();
			 return list_sb;
			 }
		
		public static void UpdateListTradeOperation(ListTradeOperation list_to) {
			string text="";
			
			TradeOperation[] arr_to=list_to.GetAll();
			foreach (TradeOperation to in arr_to) {
				text +=to.Date.ToString()
					+'\t'+to.Doc_number.ToString()
					+'\t'+to.Doc_type.ToString()
					+'\t'+to.Product.Title
					+'\t'+to.Quantity.ToString()
					+'\t'+to.Price.ToString()
					+'\t'+to.Sum.ToString()
					+'\t'+to.Price_buy.ToString()
					+'\t'+to.Profit.ToString()
					+Environment.NewLine;
			}
			FileStream file=new FileStream("c:\\TorgProg\\list_trade_operations.txt", FileMode.Truncate
, FileAccess.Write);
			 StreamWriter writer = new StreamWriter(file);
			 
			writer.Write(text);
			writer.Close();
		}
		
		public static ListTradeOperation LoadListTradeOperation(ListUnits list_prod) {
			ListTradeOperation list_to=new ListTradeOperation();
			
			ListUnits list_pa;
			FileDataBase.Load<ListUnits>("list_partners.txt",out list_pa);
			
			FileStream file=new FileStream("c:\\TorgProg\\list_trade_operations.txt", FileMode.Open
, FileAccess.Read);
			 StreamReader reader = new StreamReader(file);
			 string line;
			 while ((line=reader.ReadLine())!=null) {
			 	string[] words=line.Split(new char[]{'\t'});
			 	list_to.Add(new TradeOperation(DateTime.Parse(words[0]),
			 	                               int.Parse(words[1])
			 	                               ,words[2]
			 	                               ,0
			 	                               ,(Product)list_prod.FindByTitle(words[3])
			 	                              , int.Parse(words[4])
			 	                              , float.Parse(words[5])
			 	                               , float.Parse(words[6])
			 	                               , float.Parse(words[7])
			 	                               , float.Parse(words[8])
			 	                               ,(Partner)list_pa.FindByTitle("")
			 	                              ));
//			 	foreach (string item in words) {
//			 		
//			 	}
			 	}
			 reader.Close();
			 return list_to;
			 }
		
		public static void UpdateListQReportStruct(ListQReportStruct list_rq) {
			string text="";
			
			RowQuantityReportStruct[] arr_rq=list_rq.GetAll();
			foreach (RowQuantityReportStruct rq in arr_rq) {
				text += rq.date.ToString()
					+'\t'+rq.doc_number.ToString()
					+'\t'+rq.doc_type.ToString()
					+'\t'+rq.product.Title
					+'\t'+rq.income.ToString()
					+'\t'+rq.outgo.ToString()
					+'\t'+rq.stock_quantity.ToString()
					+'\t'+rq.price_buy.ToString()
					+Environment.NewLine;
			}
			FileStream file=new FileStream("c:\\TorgProg\\list_qreport_struct.txt", FileMode.Truncate
, FileAccess.Write);
			 StreamWriter writer = new StreamWriter(file);
			 
			writer.Write(text);
			writer.Close();
		}
		
		public static ListQReportStruct LoadListQReportStruct(ListUnits list_prod) {
			ListQReportStruct list_rq=new ListQReportStruct();
			FileStream file=new FileStream("c:\\TorgProg\\list_qreport_struct.txt", FileMode.Open
, FileAccess.Read);
			 StreamReader reader = new StreamReader(file);
			 string line;
			 while ((line=reader.ReadLine())!=null) {
			 	string[] words=line.Split(new char[]{'\t'});
			 	list_rq.Add(new RowQuantityReportStruct(DateTime.Parse(words[0]),
			 	                               int.Parse(words[1])
			 	                               ,words[2]
			 	                               ,0
			 	                               ,(Product)list_prod.FindByTitle(words[3])
			 	                              , int.Parse(words[4])
			 	                              , int.Parse(words[5])
			 	                               , int.Parse(words[6])
			 	                               , float.Parse(words[7])
			 	                              ));
//			 	foreach (string item in words) {
//			 		
//			 	}
			 	}
			 reader.Close();
			 return list_rq;
			 }
		
		public static void Update<T>(ref T list, string filename) 
			where T:class

		{
			string text="";
			
			 		if (typeof(T).Equals(typeof(ListUnits))) {
			 		
			 		switch (filename) {
			 			case "list_partners.txt":
			 					foreach (Partner pa in (list as ListUnits).GetAll()) {
			 						text += pa.Title+'\t';
			 						text += pa.Phone+'\t';
			 				text +=pa.E_mail+Environment.NewLine;
			 				}
			 				break;
			 				
			 				case "list_products.txt":
			 				foreach (Product prod in (list as ListUnits).GetAll()) {
			 				text += prod.Title+'\t';
			 				text += prod.Quantity.ToString()+'\t';
			 				text +=prod.Price_buy.ToString()+Environment.NewLine;
			 				
			 				}
			 				break;
			 		}
			 		}
			 		
			
			FileStream file=new FileStream("c:\\TorgProg\\"+filename, FileMode.Truncate
, FileAccess.Write);
			 StreamWriter writer = new StreamWriter(file);
			 writer.Write(text);
			 writer.Close();
		}
		
			public static void Load<T>(string filename, out T list) 
				where T:class, new()
			//	where T:ListUnits, new()
			//	where U:Partner, new()
				
			{
			list=new T();
			FileStream file=new FileStream("c:\\TorgProg\\"+filename, FileMode.Open
, FileAccess.Read);
			 StreamReader reader = new StreamReader(file);
			 string line;
			 if (typeof(T).Equals(typeof(ListUnits))) {
			 	//ListUnits list = new ListUnits();
			 
			 while ((line=reader.ReadLine())!=null) {
			 	string[] words=line.Split(new char[]{'\t'});
			 	//U un=new U();
			 	//un.Title=words[0];
			 switch (filename) {
			 			
			 			case "list_partners.txt":
			 			Partner pa=new Partner(words[0]);
			 			//pa.Title=words[0];
			 			pa.Phone=words[1];
			 			pa.E_mail=words[2];
			 			(list as ListUnits).Add(pa);
			 			break;
			 			
			 			case "list_products.txt":
			 			Product prod=new Product(words[0]);
			 			//prod.Title=words[0];
			 			prod.Quantity=int.Parse(words[1]);
			 			prod.Price_buy=float.Parse(words[2]);
			 			(list as ListUnits).Add(prod);
			 			break;
			 	}
			 	
//			 	foreach (string item in words) {
//			 		
//			 	}
			 	}
			 	//load_obj=(list as T);
			 }else {
			 //	load_obj=new T();
			 }
			// return (list as T);
			 reader.Close();
			
			 }
			
//			public static void Test<T>(T un) 
//				//where T:ListUnits
//				//where U:Unit, new()
//			{
//			//	U un=new U();
//				
//			if (typeof(T).Equals(typeof(ListUnits))) {
//				
//				Unit[] u = (un as ListUnits).GetAll();
//				//MessageBox.Show(un.GetType().ToString());
//				MessageBox.Show(u[0].Title);
//				//	Partner pa=(Partner)un;
//					
//			}else if (typeof(T).Equals(typeof(ListBuyBills))){
//				BuyBill[] bb= (un as ListBuyBills).GetAll();
//				MessageBox.Show(bb[0].Date.ToString());
//			}
//			
//				}
				public static void AddOneRecord<T>(ref T item, string filename) 
		//	where T:class

		{
			string text="";
			
			 		if (typeof(T).Equals(typeof(Product))) {
			 		text += (item as Product).Title+'\t';
			 				text += (item as Product).Quantity.ToString()+'\t';
			 				text +=(item as Product).Price_buy.ToString()+Environment.NewLine;	
			 	
			 		}else if (typeof(T).Equals(typeof(Partner))) {
				text += (item as Partner).Title+'\t';
				text += (item as Partner).Phone+'\t';
				text +=(item as Partner).E_mail+Environment.NewLine;
			}else if (typeof(T).Equals(typeof(BuyBill))) {
				text += (item as BuyBill).Number_instance.ToString()+'\t';
				text += (item as BuyBill).Date.ToString()+'\t';
				text +=(item as BuyBill).Total_quantity.ToString()+'\t';
				text +=(item as BuyBill).Total_sum.ToString()+'\t';
				text +=(item as BuyBill).Provider.Title+'\t';
				text +=	Environment.NewLine;
			}else if (typeof(T).Equals(typeof(SellBill))) {
				text += (item as SellBill).Number_instance.ToString()+'\t';
				text += (item as SellBill).Date.ToString()+'\t';
				text +=(item as SellBill).Total_quantity.ToString()+'\t';
				text +=(item as SellBill).Total_sum.ToString()+'\t';
				text +=(item as SellBill).Consumer.Title+'\t';
				text +=	Environment.NewLine;
			}else if (typeof(T).Equals(typeof(TradeOperation))) {
				text += (item as TradeOperation).Date.ToString()+'\t';
				text += (item as TradeOperation).Doc_number.ToString()+'\t';
				text +=(item as TradeOperation).Doc_type.ToString()+'\t';
				text +=(item as TradeOperation).Product.Title.ToString()+'\t';
				text +=(item as TradeOperation).Quantity.ToString()+'\t';
				text +=(item as TradeOperation).Price.ToString()+'\t';
				text +=(item as TradeOperation).Sum.ToString()+'\t';
				text +=(item as TradeOperation).Price_buy.ToString()+'\t';
				text +=(item as TradeOperation).Profit.ToString()+'\t';
				text +=	Environment.NewLine;
//			}else if (typeof(T).Equals(typeof(RowQuantityReportStruct))) {
//				text += (item as RowQuantityReportStruct).date.ToString()+'\t';
//				text += (item as RowQuantityReportStruct).doc_number.ToString()+'\t';
//				text +=(item as RowQuantityReportStruct).doc_type.ToString()+'\t';
//				text +=(item as RowQuantityReportStruct).product.Title.ToString()+'\t';
//				text +=(item as RowQuantityReportStruct).income.ToString()+'\t';
//				text +=(item as RowQuantityReportStruct).outgo.ToString()+'\t';
//				text +=(item as RowQuantityReportStruct).stock_quantity.ToString()+'\t';
//				text +=(item as RowQuantityReportStruct).price_buy.ToString()+'\t';
//				
//				text +=	Environment.NewLine;
			}
			 		
			
			FileStream file=new FileStream("c:\\TorgProg\\"+filename, FileMode.Append
, FileAccess.Write);
			 StreamWriter writer = new StreamWriter(file);
			 writer.Write(text);
			 writer.Close();
		}		
		

public static void AddRowsOfDoc(List<RowDocStruct> list_rd, string number_doc, string filename)
			

		{
			string text="";
			
			foreach (RowDocStruct row_d in list_rd) {
			 		text += number_doc+'\t';
			 				text += row_d.product.Title+'\t';
			 				text +=row_d.quantity.ToString();
			 				text +=row_d.price.ToString();  
			 				text +=row_d.sum.ToString(); 
			 				text +=Environment.NewLine;
			 	
			}
			 		
			
			FileStream file=new FileStream("c:\\TorgProg\\"+filename, FileMode.Append
, FileAccess.Write);
			 StreamWriter writer = new StreamWriter(file);
			 writer.Write(text);
			 writer.Close();
		}				
			
		
	}
}
