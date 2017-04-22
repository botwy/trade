/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 04.10.2016
 * Time: 17:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.Data.Common;
using System.Collections.Generic;
using System.IO;

namespace trade
{
	/// <summary>
	/// Description of DB.
	/// </summary>
	public class DB
	{
		
		
public static int InsertUnit<T>(T un) {
			int id_unit=0;
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(Product))) {
//				SQLiteDataBase.Execute("INSERT INTO 'product' ('id', 'title', 'quantity', 'price_buy') VALUES (" +
//			      "null,'"
//			      +(un as Product).Title.ToString()+"', '"
//                 +(un as Product).Quantity.ToString()+"', '"
//                 +(un as Product).Price_buy.ToString()+"');");
string[] arr_col=new string[]{"title","quantity","price_buy","barcode"};
string[] arr_val=new string[]{
                                (un as Product).Title.ToString()
                                 ,(un as Product).Quantity.ToString()
                                   ,(un as Product).Price_buy.ToString()
                                   ,(un as Product).Barcode.ToString()
                                 };
                  
id_unit=SQLiteDataBase.AddOneRecord(arr_col,arr_val,"product");

foreach (KeyValuePair<MarkupType,float> keyValue in (un as Product).List_markupType) {
	
string[] arr_col_2=new string[]{"prod_id","markup_type_id","fix_price"};
string[] arr_val_2=new string[]{
		                         id_unit.ToString()
                                 ,keyValue.Key.Id.ToString()
                                   ,keyValue.Value.ToString()
                                 };
	SQLiteDataBase.AddOneRecord(arr_col_2,arr_val_2,"prod_markup");
}
	   
				} 
				else if (typeof(T).Equals(typeof(Partner))) {
					
					
//					MessageBox.Show(un.ToString());
//					SQLiteDataBase.Execute("INSERT INTO 'partner' ('id', 'title', 'phone', 'e_mail') VALUES (" +
//			      "null,'"
//			      +(un as Partner).Title.ToString()+"', '"
//                 +(un as Partner).Phone.ToString()+"', '"
//                 +(un as Partner).E_mail.ToString()+"');");
string[] arr_col=new string[]{"title","phone","e_mail"};
string[] arr_val=new string[]{
                                (un as Partner).Title.ToString()
                                 ,(un as Partner).Phone.ToString()
                                   ,(un as Partner).E_mail.ToString()};
                  
id_unit=SQLiteDataBase.AddOneRecord(arr_col,arr_val,"partner");

 
foreach (KeyValuePair<MarkupType,float> keyValue in (un as Partner).List_markupTypeToProd) 
             {
string[] arr_col_2=new string[]{"partner_id","markup_type_id","percent"};
string[] arr_val_2=new string[]{
		                         id_unit.ToString()
                                 ,keyValue.Key.Id.ToString()
                                   ,keyValue.Value.ToString()
                                 };
	SQLiteDataBase.AddOneRecord(arr_col_2,arr_val_2,"partner_markuptoprod");
				
				}
				}
				else if (typeof(T).Equals(typeof(Storage))) {
					
					
string[] arr_col=new string[]{"title"};
string[] arr_val=new string[]{(un as Storage).Title.ToString()
                                 };
                  
id_unit=SQLiteDataBase.AddOneRecord(arr_col,arr_val,"storage");
				}
				else if (typeof(T).Equals(typeof(MarkupType))) {
					
					
string[] arr_col=new string[]{"title","basic_percent"};
string[] arr_val=new string[]{(un as MarkupType).Title.ToString()
		,(un as MarkupType).Basic_percent.ToString() };
                  
id_unit=SQLiteDataBase.AddOneRecord(arr_col,arr_val,"markup_type");
				}
			} else if (Config.dbServer=="txtfile_database") {
				if (typeof(T).Equals(typeof(Product))) {
					Product prod = (un as Product);
					FileDataBase.AddOneRecord<Product>(ref prod,"list_products.txt");
								
				}else if (typeof(T).Equals(typeof(Partner))) {
					Partner pa = (un as Partner);
					FileDataBase.AddOneRecord<Partner>(ref pa,"list_partners.txt");
								
				}
			}
			return id_unit;
		}
		
		
		
public static int InsertDoc<T>(T doc) {
		int id_doc=0;	
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(BuyBill))) {
int new_number=SQLiteDataBase.GetMaxValueOfColumn("number","buybill");

string[] arr_col=new string[]{"number","date","total_quantity"
						,"total_sum","storage_id","provider_id"};
string[] arr_val=new string[]{
                                (doc as BuyBill).Number_instance.ToString()
                                 ,(doc as BuyBill).Date.ToString()
                                   ,(doc as BuyBill).Total_quantity.ToString()
						,(doc as BuyBill).Total_sum.ToString()
                                	,(doc as BuyBill).Storage.Id.ToString()
						,(doc as BuyBill).Provider.Id.ToString()};
					
					

                  
id_doc=SQLiteDataBase.AddOneRecord(arr_col,arr_val,"buybill");
string[,] rows=new string[(doc as BuyBill).List_rows.Count+1,5];
rows[0,0]="buybill_id";
rows[0,1]="product_id";
rows[0,2]="quantity";
rows[0,3]="price";
rows[0,4]="sum";
int i=1;
foreach (RowDocStruct row_d in (doc as BuyBill).List_rows) {
	
	        rows[i,0]=id_doc.ToString();
			rows[i,1]=row_d.product.Id.ToString();
			rows[i,2]=row_d.quantity.ToString();
			rows[i,3]=row_d.price.ToString();
			rows[i,4]=row_d.sum.ToString();
	i++;
}
SQLiteDataBase.AddManyRecords(rows,"rows_in_buybill");
				} else if (typeof(T).Equals(typeof(SellBill))) {
int new_number=SQLiteDataBase.GetMaxValueOfColumn("number","sellbill");

string[] arr_col=new string[]{"number","date","total_quantity"
						,"total_sum","storage_id","consumer_id"};
string[] arr_val=new string[]{
                                (doc as SellBill).Number_instance.ToString()
                                 ,(doc as SellBill).Date.ToString()
                                   ,(doc as SellBill).Total_quantity.ToString()
						,(doc as SellBill).Total_sum.ToString()
                                	,(doc as SellBill).Storage.Id.ToString()
						,(doc as SellBill).Consumer.Id.ToString()};
					
					

                  
id_doc=SQLiteDataBase.AddOneRecord(arr_col,arr_val,"sellbill");
string[,] rows=new string[(doc as SellBill).List_rows.Count+1,5];
rows[0,0]="sellbill_id";
rows[0,1]="product_id";
rows[0,2]="quantity";
rows[0,3]="price";
rows[0,4]="sum";
int i=1;
foreach (RowDocStruct row_d in (doc as SellBill).List_rows) {
	
	        rows[i,0]=id_doc.ToString();
			rows[i,1]=row_d.product.Id.ToString();
			rows[i,2]=row_d.quantity.ToString();
			rows[i,3]=row_d.price.ToString();
			rows[i,4]=row_d.sum.ToString();
	i++;
}
SQLiteDataBase.AddManyRecords(rows,"rows_in_sellbill");
				} 
//				else if (typeof(T).Equals(typeof(SellBill))) {
//					
//					
//
//string[] arr_col=new string[]{"id","title","phone","e_mail"};
//string[] arr_val=new string[]{"null"
//                                ,(un as Partner).Title.ToString()
//                                 ,(un as Partner).Phone.ToString()
//                                   ,(un as Partner).E_mail.ToString()};
//                  
//SQLiteDataBase.AddOneRecord(arr_col,arr_val,"partner");
//				}
		} 
				else if (Config.dbServer=="txtfile_database") {
				if (typeof(T).Equals(typeof(BuyBill))) {
					BuyBill bb = (doc as BuyBill);
					FileDataBase.AddOneRecord<BuyBill>(ref bb,"list_buybills.txt");
					FileDataBase.AddRowsOfDoc((doc as BuyBill).List_rows,(doc as BuyBill).Number_instance.ToString(),"rows_in_buybills.txt");
//								
				}
//					else if (typeof(T).Equals(typeof(Partner))) {
//					Partner pa = (un as Partner);
//					FileDataBase.AddOneRecord<Partner>(ref pa,"list_partners.txt");
//								
//				}
       }
		return id_doc;
		}
		
		
public static void IncreaseProdStock(RowDocStruct row_d, Storage storage) {
			if (Config.dbServer=="sqlite") {
			//DbDataRecord rec =	SQLiteDataBase.GetRecordByTitle(row_d.product.Title, "product");
			string[] columns=new string[]{"prod_id","storage_id"};
			string[] values=new string[]{row_d.product.Id.ToString()
					,storage.Id.ToString()};
			List<DbDataRecord> list_rec = SQLiteDataBase.GetAllRowsByColsValues(columns,values,"prodqty_storage");
			if (list_rec.Count>0) {
				DbDataRecord rec=list_rec[0];
			
			if (rec!=null) {
				int new_quantity=int.Parse(rec["quantity"].ToString())+row_d.quantity;
				SQLiteDataBase.UpdateRecordById(new string[1]{"quantity"}
				                                  , new string[1]{new_quantity.ToString()}
				                                  ,rec["id"].ToString()
				                                  ,"prodqty_storage"
				);
//				SQLiteDataBase.UpdateRecordByTitle(new string[1]{"quantity"}
//				                                   , new string[1]{new_quantity.ToString()}
//				                                  ,row_d.product.Title
//				                                 ,"product");
			//row_d.product.Quantity +=row_d.quantity;
			   }
			}
			else {
				SQLiteDataBase.AddOneRecord(new string[]{"prod_id","storage_id","quantity"}
				                            , new string[]{row_d.product.Id.ToString()
				                            		,storage.Id.ToString()
				                            	,row_d.quantity.ToString()
				                            }
				                                 
				                            ,"prodqty_storage"
				);
			}
			}else if (Config.dbServer=="txtfile_database") {
				row_d.product.Quantity +=row_d.quantity;
			}
		}
		
		
			
		
public static void DecreaseProdStock(RowDocStruct row_d, Storage storage) {
			if (Config.dbServer=="sqlite") {
			//DbDataRecord rec =	SQLiteDataBase.GetRecordByTitle(row_d.product.Title, "product");
			string[] columns=new string[]{"prod_id","storage_id"};
			string[] values=new string[]{row_d.product.Id.ToString()
					,storage.Id.ToString()};
			List<DbDataRecord> list_rec = SQLiteDataBase.GetAllRowsByColsValues(columns,values,"prodqty_storage");
			if (list_rec.Count>0) {
				DbDataRecord rec=list_rec[0];
			if (rec!=null) {
				int new_quantity=int.Parse(rec["quantity"].ToString())-row_d.quantity;
				SQLiteDataBase.UpdateRecordById(new string[1]{"quantity"}
				                                  , new string[1]{new_quantity.ToString()}
				                                  ,rec["id"].ToString()
				                                  ,"prodqty_storage"
				);
//				SQLiteDataBase.UpdateRecordByTitle(new string[1]{"quantity"}
//				                                   , new string[1]{new_quantity.ToString()}
//				                                  ,row_d.product.Title
//				                                 ,"product");
			//   row_d.product.Quantity -=row_d.quantity;
			  }
			}
			}else if (Config.dbServer=="txtfile_database") {
				row_d.product.Quantity -=row_d.quantity;
			}
		}
		
	public static int GetProdStockAtStorage(Product prod, Storage storage) {
			int qty=0;
			if (Config.dbServer=="sqlite") {
			//DbDataRecord rec =	SQLiteDataBase.GetRecordByTitle(row_d.product.Title, "product");
			string[] columns=new string[]{"prod_id","storage_id"};
			string[] values=new string[]{prod.Id.ToString()
					,storage.Id.ToString()};
			List<DbDataRecord> list_rec = SQLiteDataBase.GetAllRowsByColsValues(columns,values,"prodqty_storage");
			if (list_rec.Count>0) {
				DbDataRecord rec=list_rec[0];
			if (rec!=null) 
				qty=int.Parse(rec["quantity"].ToString());
				
				}
			}
			return qty;
		}
		
		public static List<RowQuantityReportStruct> GetAllRowQRepByStorage(Storage storage) {
			List<RowQuantityReportStruct> list = new List<RowQuantityReportStruct>();
			if (Config.dbServer=="sqlite") {
			//DbDataRecord rec =	SQLiteDataBase.GetRecordByTitle(row_d.product.Title, "product");
			string[] columns=new string[]{"storage_id"};
			string[] values=new string[]{storage.Id.ToString()};
			List<DbDataRecord> list_rec = SQLiteDataBase.GetAllRowsByColsValues(columns,values,"quantity_report");
			
			foreach (DbDataRecord record in list_rec) {
				RowQuantityReportStruct instance = new RowQuantityReportStruct();
					instance.date=DateTime.Parse(record["date"].ToString());
					instance.doc_number=int.Parse(record["doc_number"].ToString());
					instance.doc_type=record["doc_type"].ToString();
					instance.doc_id=int.Parse(record["doc_id"].ToString());
					instance.product=DB.GetUnitById<Product>(record["prod_id"].ToString());
					instance.income=int.Parse(record["income"].ToString());
					instance.outgo=int.Parse(record["outgo"].ToString());
					instance.stock_quantity=int.Parse(record["stock_quantity"].ToString());
					instance.price_buy=float.Parse(record["price_buy"].ToString());
					instance.storage=DB.GetUnitById<Storage>(record["storage_id"].ToString());
					instance.id=int.Parse(record["id"].ToString());
					list.Add(instance);
			}
		
			}
			return list;
		}
		
			public static List<TradeOperation> GetAllTradeOperationByStorage(Storage storage) {
			List<TradeOperation> list = new List<TradeOperation>();
			if (Config.dbServer=="sqlite") {
			//DbDataRecord rec =	SQLiteDataBase.GetRecordByTitle(row_d.product.Title, "product");
			string[] columns=new string[]{"storage_id"};
			string[] values=new string[]{storage.Id.ToString()};
			List<DbDataRecord> list_rec = SQLiteDataBase.GetAllRowsByColsValues(columns,values,"trade_operation");
			
			foreach (DbDataRecord record in list_rec) {
					TradeOperation instance = new TradeOperation();
					instance.Date=DateTime.Parse(record["date"].ToString());
					instance.Doc_number=int.Parse(record["doc_number"].ToString());
					instance.Doc_type=record["doc_type"].ToString();
					instance.Doc_id=int.Parse(record["doc_id"].ToString());
					instance.Product=DB.GetUnitById<Product>(record["prod_id"].ToString());
					instance.Quantity=int.Parse(record["quantity"].ToString());
					instance.Price=float.Parse(record["price"].ToString());
					instance.Sum=float.Parse(record["sum"].ToString());
					instance.Price_buy=float.Parse(record["price_buy"].ToString());
					instance.Profit=float.Parse(record["profit"].ToString());
					instance.Partner=GetUnitById<Partner>(record["partner_id"].ToString());
					instance.Storage=DB.GetUnitById<Storage>(record["storage_id"].ToString());
					list.Add(instance);
			}
		
			}
			return list;
		}
		
		
		public static void UpdateProdPriceBuy(RowDocStruct row_d) {
			if (Config.dbServer=="sqlite") {
			
				SQLiteDataBase.UpdateRecordByTitle(new string[1]{"price_buy"}
				                                   , new string[1]{row_d.price.ToString()}
				                                  ,row_d.product.Title
				                                 ,"product");
			  row_d.product.Price_buy = row_d.price;
			}else if (Config.dbServer=="txtfile_database") {
			 row_d.product.Price_buy = row_d.price;	
			}
		}
		
public static void UpdateUnit<T>(T un) 
		//where T:class, new()
		{
		   
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(Product))) {
				int id = (un as Product).Id;
				
				string[] columns=new string[] {"title"
						,"quantity"
						,"price_buy"
						,"barcode"
					
				};
				
				string[] values=new string[] {(un as Product).Title
						,(un as Product).Quantity.ToString()
						,(un as Product).Price_buy.ToString()
						,(un as Product).Barcode.ToString()
					
				};
				
				SQLiteDataBase.UpdateRecordById(columns,values,id.ToString(),"product");
	//-------------------------------------------------------
	
				SQLiteDataBase.DeleteAllRowsByColsValues(new string[]{"prod_id"}
				                                         ,new string[]{id.ToString()}
				                                         ,"prod_markup");
foreach (KeyValuePair<MarkupType,float> keyValue in (un as Product).List_markupType) {
List<DbDataRecord> list_rec_prodMType_exist = SQLiteDataBase.GetAllRowsByColsValues(new string[]{"prod_id","markup_type_id"}
					                                      ,new string[]{id.ToString(),keyValue.Key.Id.ToString()}
					                                      ,"prod_markup");
					if (list_rec_prodMType_exist.Count>0) continue;
string[] arr_col_2=new string[]{"prod_id","markup_type_id","fix_price"};
string[] arr_val_2=new string[]{
		                         id.ToString()
                                 ,keyValue.Key.Id.ToString()
                                   ,keyValue.Value.ToString()
                                 };
	SQLiteDataBase.AddOneRecord(arr_col_2,arr_val_2,"prod_markup");
			
				}
//-------------------------------------------------------------					
		}
else if (typeof(T).Equals(typeof(Partner))) {
				int id = (un as Partner).Id;
				
				string[] columns;
				string[] values;
				if ((un as Partner).Markup_type!=null) {
					
				columns=new string[] {"title"
						,"phone"
						,"e_mail"
						,"markup_type_id"
					
				};
					
				values=new string[] {(un as Partner).Title
						,(un as Partner).Phone.ToString()
						,(un as Partner).E_mail.ToString()
						,(un as Partner).Markup_type.Id.ToString()
					
				};
				}
				else {
					columns=new string[] {"title"
						,"phone"
						,"e_mail"
					
					
				};
					
				values=new string[] {(un as Partner).Title
						,(un as Partner).Phone.ToString()
						,(un as Partner).E_mail.ToString()
						
					
				};
				}
					
				
				SQLiteDataBase.UpdateRecordById(columns,values,id.ToString(),"partner");

//-----------------------------------------------------------
//update partner_markuptoprod
    SQLiteDataBase.DeleteAllRowsByColsValues(new string[]{"partner_id"}
				                                         ,new string[]{id.ToString()}
				                                         ,"partner_markuptoprod");
foreach (KeyValuePair<MarkupType,float> keyValue in (un as Partner).List_markupTypeToProd) 
                  {
List<DbDataRecord> list_rec_MType_exist = SQLiteDataBase.GetAllRowsByColsValues(new string[]{"partner_id","markup_type_id"}
					                                      ,new string[]{id.ToString(),keyValue.Key.Id.ToString()}
					                                      ,"partner_markuptoprod");
					if (list_rec_MType_exist.Count>0) continue;
string[] arr_col_2=new string[]{"partner_id","markup_type_id","percent"};
string[] arr_val_2=new string[]{
		                         id.ToString()
                                 ,keyValue.Key.Id.ToString()
                                   ,keyValue.Value.ToString()
                                 };
	SQLiteDataBase.AddOneRecord(arr_col_2,arr_val_2,"partner_markuptoprod");
				
				}
//-------------------------------------------------------------------				
	//-----------------------------------------------------------
//update partner_markup_correct
    SQLiteDataBase.DeleteAllRowsByColsValues(new string[]{"partner_id"}
				                                         ,new string[]{id.ToString()}
				                                         ,"partner_markup_correct");
foreach (MarkupTypePercentCorrection mtype_correct in (un as Partner).List_mtypeCorrect) 
                  {

string[] arr_col_2=new string[]{"partner_id","markup_type_id"
			,"begin_number","end_number","percent","fix_price"};
string[] arr_val_2=new string[]{
		                         id.ToString()
                                 , mtype_correct.Markup_type.Id.ToString()
                                   ,mtype_correct.Begin_number.ToString()
		                         	,mtype_correct.End_number.ToString()
		                         	,mtype_correct.Percent.ToString()
		                         	,mtype_correct.Fix_price.ToString()
                                 };
	SQLiteDataBase.AddOneRecord(arr_col_2,arr_val_2,"partner_markup_correct");
				
				}
//-------------------------------------------------------------------	
//update partner_round_correct
    SQLiteDataBase.DeleteAllRowsByColsValues(new string[]{"partner_id"}
				                                         ,new string[]{id.ToString()}
				                                         ,"partner_round_correct");
foreach (RoundPriceCorrection round_correct in (un as Partner).List_roundCorrect) 
                  {

string[] arr_col_2=new string[]{"partner_id","markup_type_id"
			,"begin_number","end_number","round_result"};
string[] arr_val_2=new string[]{
		                         id.ToString()
                                 , round_correct.Markup_type.Id.ToString()
                                   ,round_correct.Begin_number.ToString()
		                         	,round_correct.End_number.ToString()
		                         	,round_correct.Round_result.ToString()
                                 };
	SQLiteDataBase.AddOneRecord(arr_col_2,arr_val_2,"partner_round_correct");
				
				}
//-------------------------------------------------------------------			
		}
else if (typeof(T).Equals(typeof(Storage))) {
				int id = (un as Storage).Id;
				
				string[] columns=new string[] {"title"
						};
				
				string[] values=new string[] {(un as Storage).Title
						};
				
				SQLiteDataBase.UpdateRecordById(columns,values,id.ToString(),"storage");
				} 
else if (typeof(T).Equals(typeof(MarkupType))) {
				int id = (un as MarkupType).Id;
				
				string[] columns=new string[] {"title","basic_percent"
						};
				
				string[] values=new string[] {(un as MarkupType).Title
						,(un as MarkupType).Basic_percent.ToString()
						};
				
				SQLiteDataBase.UpdateRecordById(columns,values
				                                ,id.ToString()
				                                ,"markup_type");
				} 			

		}
}
		
		public static bool CheckProdStock(Product prod, int order_quantity) {
			bool val=false;
			if (Config.dbServer=="sqlite") {
				DbDataRecord rec =	SQLiteDataBase.GetRecordById(prod.Id.ToString(), "product");
			if (rec!=null) {
				int curr_quantity=int.Parse(rec["quantity"].ToString());
				if (curr_quantity>=order_quantity) val=true;
			   }
			}else if (Config.dbServer=="txtfile_database") {
				if (prod.Quantity>=order_quantity) val=true;
			}
			return val;
		}		
		
		
		
public static bool IsUnitByTitle<T>(string title) {
			bool val=false;
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(Product))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordByTitle(title, "product");
				if (rec!=null) val=true;
				}
				else if (typeof(T).Equals(typeof(Partner))) {
					DbDataRecord rec=SQLiteDataBase.GetRecordByTitle(title, "partner");
				if (rec!=null) val=true;
				}
				}else if (Config.dbServer=="txtfile_database") {
				if (typeof(T).Equals(typeof(Product))) {
					ListUnits list_prod;
					FileDataBase.Load<ListUnits>("list_products.txt", out list_prod);
					if (list_prod.IsUnitByTitle(title)) val=true;
				//удалить объект list_prod
				} else if (typeof(T).Equals(typeof(Partner))) {
					ListUnits list_pa;
					FileDataBase.Load<ListUnits>("list_partners.txt", out list_pa);
					if (list_pa.IsUnitByTitle(title)) val=true;
				//удалить объект list_pa
				}
				
				}
			return val;
		}
		
		
public static T GetUnitByTitle<T>(string title) 
		where T:class, new()
		{
		   T un=new T();
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(Product))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordByTitle(title, "product");
				if (rec!=null) {
					//Product prod=new Product(rec[1].ToString());
					(un as Product).Title=rec[1].ToString();
					(un as Product).Quantity=int.Parse(rec[2].ToString());
					(un as Product).Price_buy=float.Parse(rec[3].ToString());
					(un as Product).Id=int.Parse(rec[0].ToString());
					(un as Product).Barcode=rec["barcode"].ToString();
					
				List<DbDataRecord> list_rec=SQLiteDataBase.GetAllRowsByColsValues(new string[]{"prod_id"}
					                                      ,new string[]{rec["id"].ToString()}
					                                      ,"prod_markup"
					                                     );
					foreach (DbDataRecord rec_mtype in list_rec) {
						MarkupType m_type = DB.GetUnitById<MarkupType>(rec_mtype["markup_type_id"].ToString());
						float fix_price=float.Parse(rec_mtype["fix_price"].ToString());
						(un as Product).List_markupType.Add(m_type,fix_price);
					}	
				}else{un=null;}
				}
				else if (typeof(T).Equals(typeof(Partner))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordByTitle(title, "partner");
				if (rec!=null) {
					//Partner pa=new Partner(rec[1].ToString());
					(un as Partner).Title=rec[1].ToString();
					(un as Partner).Phone=rec[2].ToString();
					(un as Partner).E_mail=rec[3].ToString();
					(un as Partner).Id=int.Parse(rec[0].ToString());
				(un as Partner).Markup_type=DB.GetUnitById<MarkupType>(rec["markup_type_id"].ToString());
				
				List<DbDataRecord> list_rec=SQLiteDataBase.GetAllRowsByColsValues(new string[]{"partner_id"}
					                                      ,new string[]{rec["id"].ToString()}
					                                      ,"partner_markuptoprod"
					                                     );
					foreach (DbDataRecord rec_mtype in list_rec) {
						MarkupType m_type = DB.GetUnitById<MarkupType>(rec_mtype["markup_type_id"].ToString());
						float percent=float.Parse(rec_mtype["percent"].ToString());
						(un as Partner).List_markupTypeToProd.Add(m_type,percent);
					}
				
				list_rec=SQLiteDataBase.GetAllRowsByColsValues(new string[]{"partner_id"}
					                                      ,new string[]{rec["id"].ToString()}
					                                      ,"partner_markup_correct"
					                                     );
					foreach (DbDataRecord rec_mcor in list_rec) {
						MarkupType m_type = DB.GetUnitById<MarkupType>(rec_mcor["markup_type_id"].ToString());
						float begin_number=float.Parse(rec_mcor["begin_number"].ToString());
						float end_number=float.Parse(rec_mcor["end_number"].ToString());
						float percent=float.Parse(rec_mcor["percent"].ToString());
						float fix_price=float.Parse(rec_mcor["fix_price"].ToString());
						(un as Partner).List_mtypeCorrect.Add(new MarkupTypePercentCorrection(m_type
						                                          ,begin_number
                                                                  ,end_number
                                                                  ,percent  
                                                                  ,fix_price
                                                                 )
						);
					}
					
					list_rec=SQLiteDataBase.GetAllRowsByColsValues(new string[]{"partner_id"}
					                                      ,new string[]{rec["id"].ToString()}
					                                      ,"partner_round_correct"
					                                     );
					foreach (DbDataRecord rec_rcor in list_rec) {
						MarkupType m_type = DB.GetUnitById<MarkupType>(rec_rcor["markup_type_id"].ToString());
						float begin_number=float.Parse(rec_rcor["begin_number"].ToString());
						float end_number=float.Parse(rec_rcor["end_number"].ToString());
						float round_result=float.Parse(rec_rcor["round_result"].ToString());
						
						(un as Partner).List_roundCorrect.Add(new RoundPriceCorrection(m_type
						                                          ,begin_number
                                                                  ,end_number
                                                                  ,round_result
                                                                 )
						);
					}
				}else{un=null;}
				}
		   	else if (typeof(T).Equals(typeof(Storage))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordByTitle(title, "storage");
				if (rec!=null) {
					//Partner pa=new Partner(rec[1].ToString());
					(un as Storage).Title=rec["title"].ToString();
					(un as Storage).Id=int.Parse(rec["id"].ToString());
				}else{un=null;}
				}
		   	else if (typeof(T).Equals(typeof(MarkupType))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordByTitle(title, "markup_type");
				if (rec!=null) {
					//Partner pa=new Partner(rec[1].ToString());
					(un as MarkupType).Title=rec["title"].ToString();
					(un as MarkupType).Id=int.Parse(rec["id"].ToString());
					(un as MarkupType).Basic_percent=float.Parse(rec["basic_percent"].ToString());
				}else{un=null;}
				}
				} else if (Config.dbServer=="txtfile_database") {
				if (typeof(T).Equals(typeof(Product))) {
					ListUnits list_prod;
					FileDataBase.Load<ListUnits>("list_products.txt", out list_prod);
					Product prod = (Product)list_prod.FindByTitle(title);
					(un as Product).Title=prod.Title;
					(un as Product).Quantity=prod.Quantity;
					(un as Product).Price_buy=prod.Price_buy;
					(un as Product).Id=prod.Id;
					
				//удалить объект list_prod
				//удалить объект prod
				} else if (typeof(T).Equals(typeof(Partner))) {
					ListUnits list_pa;
					FileDataBase.Load<ListUnits>("list_partners.txt", out list_pa);
					Partner pa = (Partner)list_pa.FindByTitle(title);
					(un as Partner).Title=pa.Title;
					(un as Partner).Phone=pa.Phone;
					(un as Partner).E_mail=pa.E_mail;
					(un as Partner).Id=pa.Id;
					
				//удалить объект list_pa
				//удалить объект pa
				}
		   	
		   	
				}
			return un;
		}
		
//public static T TestGetUnitById<T>(string id,string table,string property,string column) 
//		where T:class, new()
//		{	
// T un=new T();
// DbDataRecord rec=SQLiteDataBase.GetRecordById(id, table);
//				if (rec!=null) {
// 	(un as T)[property]=rec[column].ToString();
// }
// return un;
//}
		
public static T GetUnitById<T>(string id) 
		where T:class, new()
		{
		   T un=new T();
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(Product))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordById(id, "product");
				if (rec!=null) {
					//Product prod=new Product(rec[1].ToString());
					(un as Product).Title=rec["title"].ToString();
					(un as Product).Quantity=int.Parse(rec["quantity"].ToString());
					(un as Product).Price_buy=float.Parse(rec["price_buy"].ToString());
					(un as Product).Id=int.Parse(rec["id"].ToString());
					(un as Product).Barcode=rec["barcode"].ToString();
					
					List<DbDataRecord> list_rec=SQLiteDataBase.GetAllRowsByColsValues(new string[]{"prod_id"}
					                                      ,new string[]{rec["id"].ToString()}
					                                      ,"prod_markup"
					                                     );
					foreach (DbDataRecord rec_mtype in list_rec) {
						MarkupType m_type = DB.GetUnitById<MarkupType>(rec_mtype["markup_type_id"].ToString());
						float fix_price=float.Parse(rec_mtype["fix_price"].ToString());
						(un as Product).List_markupType.Add(m_type,fix_price);
					}
					
					
						
				}else{un=null;}
				}
				else if (typeof(T).Equals(typeof(Partner))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordById(id, "partner");
				if (rec!=null) {
					//Partner pa=new Partner(rec[1].ToString());
					(un as Partner).Title=rec[1].ToString();
					(un as Partner).Phone=rec[2].ToString();
					(un as Partner).E_mail=rec[3].ToString();
					(un as Partner).Id=int.Parse(rec[0].ToString());
					(un as Partner).Markup_type=DB.GetUnitById<MarkupType>(rec["markup_type_id"].ToString());
				
					List<DbDataRecord> list_rec=SQLiteDataBase.GetAllRowsByColsValues(new string[]{"partner_id"}
					                                      ,new string[]{rec["id"].ToString()}
					                                      ,"partner_markuptoprod"
					                                     );
					foreach (DbDataRecord rec_mtype in list_rec) {
						MarkupType m_type = DB.GetUnitById<MarkupType>(rec_mtype["markup_type_id"].ToString());
						float percent=float.Parse(rec_mtype["percent"].ToString());
						(un as Partner).List_markupTypeToProd.Add(m_type,percent);
					}
					
					list_rec=SQLiteDataBase.GetAllRowsByColsValues(new string[]{"partner_id"}
					                                      ,new string[]{rec["id"].ToString()}
					                                      ,"partner_markup_correct"
					                                     );
					foreach (DbDataRecord rec_mcor in list_rec) {
						MarkupType m_type = DB.GetUnitById<MarkupType>(rec_mcor["markup_type_id"].ToString());
						float begin_number=float.Parse(rec_mcor["begin_number"].ToString());
						float end_number=float.Parse(rec_mcor["end_number"].ToString());
						float percent=float.Parse(rec_mcor["percent"].ToString());
						float fix_price=float.Parse(rec_mcor["fix_price"].ToString());
						(un as Partner).List_mtypeCorrect.Add(new MarkupTypePercentCorrection(m_type
						                                          ,begin_number
                                                                  ,end_number
                                                                  ,percent  
                                                                  ,fix_price
                                                                 )
						);
					}
					
					list_rec=SQLiteDataBase.GetAllRowsByColsValues(new string[]{"partner_id"}
					                                      ,new string[]{rec["id"].ToString()}
					                                      ,"partner_round_correct"
					                                     );
					foreach (DbDataRecord rec_rcor in list_rec) {
						MarkupType m_type = DB.GetUnitById<MarkupType>(rec_rcor["markup_type_id"].ToString());
						float begin_number=float.Parse(rec_rcor["begin_number"].ToString());
						float end_number=float.Parse(rec_rcor["end_number"].ToString());
						float round_result=float.Parse(rec_rcor["round_result"].ToString());
						
						(un as Partner).List_roundCorrect.Add(new RoundPriceCorrection(m_type
						                                          ,begin_number
                                                                  ,end_number
                                                                  ,round_result
                                                                 )
						);
					}
				}else{un=null;}
				}
		   	else if (typeof(T).Equals(typeof(Storage))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordById(id, "storage");
				if (rec!=null) {
					//Partner pa=new Partner(rec[1].ToString());
					(un as Storage).Title=rec["title"].ToString();
					(un as Storage).Id=int.Parse(rec["id"].ToString());
				}else{un=null;}
				}
		   		else if (typeof(T).Equals(typeof(MarkupType))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordById(id, "markup_type");
				if (rec!=null) {
					//Partner pa=new Partner(rec[1].ToString());
					(un as MarkupType).Title=rec["title"].ToString();
					(un as MarkupType).Id=int.Parse(rec["id"].ToString());
					(un as MarkupType).Basic_percent=float.Parse(rec["basic_percent"].ToString());
				}else{un=null;}
				}
		} 
//		   else if (Config.dbServer=="txtfile_database") {
//				if (typeof(T).Equals(typeof(Product))) {
//					ListUnits list_prod;
//					FileDataBase.Load<ListUnits>("list_products.txt", out list_prod);
//					Product prod = (Product)list_prod.FindByTitle(title);
//					(un as Product).Title=prod.Title;
//					(un as Product).Quantity=prod.Quantity;
//					(un as Product).Price_buy=prod.Price_buy;
//					(un as Product).Id=prod.Id;
//					
//				//удалить объект list_prod
//				//удалить объект prod
//				} else if (typeof(T).Equals(typeof(Partner))) {
//					ListUnits list_pa;
//					FileDataBase.Load<ListUnits>("list_partners.txt", out list_pa);
//					Partner pa = (Partner)list_pa.FindByTitle(title);
//					(un as Partner).Title=pa.Title;
//					(un as Partner).Phone=pa.Phone;
//					(un as Partner).E_mail=pa.E_mail;
//					(un as Partner).Id=pa.Id;
//					
//				//удалить объект list_pa
//				//удалить объект pa
//				}
//		   	
//		   	
//				}
			return un;
		}		
public static T GetDocById<T>(string id) 
		where T:class, new()
		{
		   T item=new T();
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(BuyBill))) {
				DbDataRecord record=SQLiteDataBase.GetRecordById(id, "buybill");
				if (record!=null) {
					//Product prod=new Product(rec[1].ToString());
					(item as BuyBill).Id=int.Parse(record["id"].ToString());
					(item as BuyBill).Number_instance=int.Parse(record["number"].ToString());
					(item as BuyBill).Date=DateTime.Parse(record["date"].ToString());
					(item as BuyBill).Total_quantity=int.Parse(record["total_quantity"].ToString());
					(item as BuyBill).Total_sum=float.Parse(record["total_sum"].ToString());
					
					
					string prov_id=record["provider_id"].ToString();
					(item as BuyBill).Provider=DB.GetUnitById<Partner>(prov_id);
					
					string storage_id=record["storage_id"].ToString();
					(item as BuyBill).Storage=DB.GetUnitById<Storage>(storage_id);
					
				  List<RowDocStruct> list_rd = new List<RowDocStruct>();
				  foreach (DbDataRecord rec_row in SQLiteDataBase.GetAllRowsByColsValues(new string[]{"buybill_id"}
				                                                                         ,new string[]{(item as BuyBill).Id.ToString()}
				                                                                         ,"rows_in_buybill")) {
					         	
					         	list_rd.Add(new RowDocStruct(
					         		DB.GetUnitById<Product>(rec_row["product_id"].ToString())
					         		,int.Parse(rec_row["quantity"].ToString())
					         		,float.Parse(rec_row["price"].ToString())
					         		,float.Parse(rec_row["sum"].ToString())
					         	)
					         	);
					         }
				  (item as BuyBill).List_rows=list_rd;
				}else{item=null;}
				}
				else if (typeof(T).Equals(typeof(SellBill))) {
				DbDataRecord record=SQLiteDataBase.GetRecordById(id, "sellbill");
				if (record!=null) {
					(item as SellBill).Id=int.Parse(record["id"].ToString());
					(item as SellBill).Number_instance=int.Parse(record["number"].ToString());
					(item as SellBill).Date=DateTime.Parse(record["date"].ToString());
					(item as SellBill).Total_quantity=int.Parse(record["total_quantity"].ToString());
					(item as SellBill).Total_sum=float.Parse(record["total_sum"].ToString());
					
					string consum_id=record["consumer_id"].ToString();
					(item as SellBill).Consumer=DB.GetUnitById<Partner>(consum_id);
				
					string storage_id=record["storage_id"].ToString();
					(item as SellBill).Storage=DB.GetUnitById<Storage>(storage_id);
					
				List<RowDocStruct> list_rd = new List<RowDocStruct>();
				foreach (DbDataRecord rec_row in SQLiteDataBase.GetAllRowsByColsValues(new string[]{"sellbill_id"}
				                                                                       ,new string[]{(item as SellBill).Id.ToString()}
				                                                                       ,"rows_in_sellbill")) {
						//MessageBox.Show(DB.GetUnitById<Product>(rec_row["product_id"].ToString()).Title);
					          list_rd.Add(new RowDocStruct(
					         		DB.GetUnitById<Product>(rec_row["product_id"].ToString())
					         		,int.Parse(rec_row["quantity"].ToString())
					         		,float.Parse(rec_row["price"].ToString())
					         		,float.Parse(rec_row["sum"].ToString())
					         	)
					         	);
					         }
				(item as SellBill).List_rows=list_rd;
				}else{item=null;}
				}
				} 
//		   else if (Config.dbServer=="txtfile_database") {
//				if (typeof(T).Equals(typeof(Product))) {
//					ListUnits list_prod;
//					FileDataBase.Load<ListUnits>("list_products.txt", out list_prod);
//					Product prod = (Product)list_prod.FindByTitle(title);
//					(un as Product).Title=prod.Title;
//					(un as Product).Quantity=prod.Quantity;
//					(un as Product).Price_buy=prod.Price_buy;
//					(un as Product).Id=prod.Id;
//					
//				//удалить объект list_prod
//				//удалить объект prod
//				} else if (typeof(T).Equals(typeof(Partner))) {
//					ListUnits list_pa;
//					FileDataBase.Load<ListUnits>("list_partners.txt", out list_pa);
//					Partner pa = (Partner)list_pa.FindByTitle(title);
//					(un as Partner).Title=pa.Title;
//					(un as Partner).Phone=pa.Phone;
//					(un as Partner).E_mail=pa.E_mail;
//					(un as Partner).Id=pa.Id;
//					
//				//удалить объект list_pa
//				//удалить объект pa
//				}
//		   	
//		   	
//				}
			return item;
		}	
	
	
public static T GetUnitByBarcode<T>(string barcode) 
		where T:class, new()
		{
		   T un=new T();
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(Product))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordByBarcode(barcode, "product");
				if (rec!=null) {
					//Product prod=new Product(rec[1].ToString());
					(un as Product).Title=rec[1].ToString();
					(un as Product).Quantity=int.Parse(rec[2].ToString());
					(un as Product).Price_buy=float.Parse(rec[3].ToString());
					(un as Product).Id=int.Parse(rec[0].ToString());
					(un as Product).Barcode=rec["barcode"].ToString();
					
					List<DbDataRecord> list_rec=SQLiteDataBase.GetAllRowsByColsValues(new string[]{"prod_id"}
					                                      ,new string[]{rec["id"].ToString()}
					                                      ,"prod_markup"
					                                     );
					foreach (DbDataRecord rec_mtype in list_rec) {
						MarkupType m_type = DB.GetUnitById<MarkupType>(rec_mtype["markup_type_id"].ToString());
						float fix_price=float.Parse(rec_mtype["fix_price"].ToString());
						(un as Product).List_markupType.Add(m_type,fix_price);
					}	
				}else{un=null;}
				}
				else if (typeof(T).Equals(typeof(Partner))) {
				DbDataRecord rec=SQLiteDataBase.GetRecordByBarcode(barcode, "partner");
				if (rec!=null) {
					//Partner pa=new Partner(rec[1].ToString());
					(un as Partner).Title=rec[1].ToString();
					(un as Partner).Phone=rec[2].ToString();
					(un as Partner).E_mail=rec[3].ToString();
					(un as Partner).Id=int.Parse(rec[0].ToString());
				}else{un=null;}
				}
				} 
//		   else if (Config.dbServer=="txtfile_database") {
//				if (typeof(T).Equals(typeof(Product))) {
//					ListUnits list_prod;
//					FileDataBase.Load<ListUnits>("list_products.txt", out list_prod);
//					Product prod = (Product)list_prod.FindByTitle(title);
//					(un as Product).Title=prod.Title;
//					(un as Product).Quantity=prod.Quantity;
//					(un as Product).Price_buy=prod.Price_buy;
//					(un as Product).Id=prod.Id;
//					
//				//удалить объект list_prod
//				//удалить объект prod
//				} else if (typeof(T).Equals(typeof(Partner))) {
//					ListUnits list_pa;
//					FileDataBase.Load<ListUnits>("list_partners.txt", out list_pa);
//					Partner pa = (Partner)list_pa.FindByTitle(title);
//					(un as Partner).Title=pa.Title;
//					(un as Partner).Phone=pa.Phone;
//					(un as Partner).E_mail=pa.E_mail;
//					(un as Partner).Id=pa.Id;
//					
//				//удалить объект list_pa
//				//удалить объект pa
//				}
//		   	
//		   	
//				}
			return un;
		}		
		
public static List<T> GetAll<T>() {
			List<T> list = new List<T>();
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(Product))) {
					
				List<DbDataRecord>	list_rec=SQLiteDataBase.GetAllRows("product");
				foreach (DbDataRecord record in list_rec) {
					Product prod = new Product(record[1].ToString());
					prod.Quantity=int.Parse(record[2].ToString());
					prod.Price_buy=float.Parse(record[3].ToString());
					prod.Barcode=record["barcode"].ToString();
					prod.Id=int.Parse(record["id"].ToString());
					(list as List<Product>).Add(prod);
				}
				}
				else if (typeof(T).Equals(typeof(Partner))) {
					List<DbDataRecord>	list_rec=SQLiteDataBase.GetAllRows("partner");
					foreach (DbDataRecord record in list_rec) {
					Partner pa = new Partner(record[1].ToString());
					pa.Phone=record[2].ToString();
					pa.E_mail=record[3].ToString();
					pa.Id=int.Parse(record["id"].ToString());
					(list as List<Partner>).Add(pa);
				}
				}
				else if (typeof(T).Equals(typeof(Storage))) {
					List<DbDataRecord>	list_rec=SQLiteDataBase.GetAllRows("storage");
					foreach (DbDataRecord record in list_rec) {
					Storage item = new Storage(record["title"].ToString());
					item.Id=int.Parse(record["id"].ToString());
					(list as List<Storage>).Add(item);
				}
				}
				else if (typeof(T).Equals(typeof(MarkupType))) {
					List<DbDataRecord>	list_rec=SQLiteDataBase.GetAllRows("markup_type");
					foreach (DbDataRecord record in list_rec) {
					MarkupType item = new MarkupType(record["title"].ToString());
					item.Id=int.Parse(record["id"].ToString());
					item.Basic_percent=float.Parse(record["basic_percent"].ToString());
					(list as List<MarkupType>).Add(item);
				}
				}
				else if (typeof(T).Equals(typeof(BuyBill))) {
					List<DbDataRecord>	list_rec=SQLiteDataBase.GetAllRows("buybill");
					foreach (DbDataRecord record in list_rec) {
					BuyBill bb = new BuyBill();
					bb.Id=int.Parse(record["id"].ToString());
					bb.Number_instance=int.Parse(record["number"].ToString());
					bb.Date=DateTime.Parse(record["date"].ToString());
					bb.Total_quantity=int.Parse(record["total_quantity"].ToString());
					bb.Total_sum=float.Parse(record["total_sum"].ToString());
					
					string prov_id=record["provider_id"].ToString();
					bb.Provider=DB.GetUnitById<Partner>(prov_id);
					
					string storage_id=record["storage_id"].ToString();
					bb.Storage=DB.GetUnitById<Storage>(storage_id);
//					List<RowDocStruct> list_rd = new List<RowDocStruct>();
//					foreach (DbDataRecord rec_row in SQLiteDataBase.GetAllRowsByColValue("buybill_id",bb.Id.ToString(),"rows_in_buybill")) {
//					         	
//					         	list_rd.Add(new RowDocStruct(
//					         		DB.GetUnitById<Product>(rec_row["product_id"].ToString())
//					         		,int.Parse(rec_row["quantity"].ToString())
//					         		,float.Parse(rec_row["price"].ToString())
//					         		,float.Parse(rec_row["sum"].ToString())
//					         	)
//					         	);
//					         }
//					   bb.List_rows=list_rd;      
					(list as List<BuyBill>).Add(bb);
				}
				}else if (typeof(T).Equals(typeof(SellBill))) {
					List<DbDataRecord>	list_rec=SQLiteDataBase.GetAllRows("sellbill");
					foreach (DbDataRecord record in list_rec) {
					SellBill sb = new SellBill();
					sb.Id=int.Parse(record["id"].ToString());
					sb.Number_instance=int.Parse(record["number"].ToString());
					sb.Date=DateTime.Parse(record["date"].ToString());
					sb.Total_quantity=int.Parse(record["total_quantity"].ToString());
					sb.Total_sum=float.Parse(record["total_sum"].ToString());
					
					string consum_id=record["consumer_id"].ToString();
					sb.Consumer=DB.GetUnitById<Partner>(consum_id);
					
					string storage_id=record["storage_id"].ToString();
					sb.Storage=DB.GetUnitById<Storage>(storage_id);
//					List<RowDocStruct> list_rd = new List<RowDocStruct>();
//					foreach (DbDataRecord rec_row in SQLiteDataBase.GetAllRowsByColValue("sellbill_id",sb.Id.ToString(),"rows_in_sellbill")) {
//						//MessageBox.Show(DB.GetUnitById<Product>(rec_row["product_id"].ToString()).Title);
//					          list_rd.Add(new RowDocStruct(
//					         		DB.GetUnitById<Product>(rec_row["product_id"].ToString())
//					         		,int.Parse(rec_row["quantity"].ToString())
//					         		,float.Parse(rec_row["price"].ToString())
//					         		,float.Parse(rec_row["sum"].ToString())
//					         	)
//					         	);
//					         }
//					    sb.List_rows=list_rd;     
					(list as List<SellBill>).Add(sb);
					}
				}else if (typeof(T).Equals(typeof(TradeOperation))) {
					List<DbDataRecord>	list_rec=SQLiteDataBase.GetAllRows("trade_operation");
					foreach (DbDataRecord record in list_rec) {
					TradeOperation instance = new TradeOperation();
					instance.Date=DateTime.Parse(record["date"].ToString());
					instance.Doc_number=int.Parse(record["doc_number"].ToString());
					instance.Doc_type=record["doc_type"].ToString();
					instance.Doc_id=int.Parse(record["doc_id"].ToString());
					instance.Product=DB.GetUnitById<Product>(record["prod_id"].ToString());
					instance.Quantity=int.Parse(record["quantity"].ToString());
					instance.Price=float.Parse(record["price"].ToString());
					instance.Sum=float.Parse(record["sum"].ToString());
					instance.Price_buy=float.Parse(record["price_buy"].ToString());
					instance.Profit=float.Parse(record["profit"].ToString());
					instance.Partner=GetUnitById<Partner>(record["partner_id"].ToString());
					instance.Storage=DB.GetUnitById<Storage>(record["storage_id"].ToString());
					(list as List<TradeOperation>).Add(instance);
				}
			
			
			}else if (typeof(T).Equals(typeof(RowQuantityReportStruct))) {
					List<DbDataRecord>	list_rec=SQLiteDataBase.GetAllRows("quantity_report");
					foreach (DbDataRecord record in list_rec) {
					RowQuantityReportStruct instance = new RowQuantityReportStruct();
					instance.date=DateTime.Parse(record["date"].ToString());
					instance.doc_number=int.Parse(record["doc_number"].ToString());
					instance.doc_type=record["doc_type"].ToString();
					instance.doc_id=int.Parse(record["doc_id"].ToString());
					instance.product=DB.GetUnitById<Product>(record["prod_id"].ToString());
					instance.income=int.Parse(record["income"].ToString());
					instance.outgo=int.Parse(record["outgo"].ToString());
					instance.stock_quantity=int.Parse(record["stock_quantity"].ToString());
					instance.price_buy=float.Parse(record["price_buy"].ToString());
					instance.storage=DB.GetUnitById<Storage>(record["storage_id"].ToString());
					instance.id=int.Parse(record["id"].ToString());
					(list as List<RowQuantityReportStruct>).Add(instance);
				}
			
			  }
			
			}else if (Config.dbServer=="txtfile_database") {
				if (typeof(T).Equals(typeof(Product))) {
					ListUnits list_prods;
				FileDataBase.Load<ListUnits>("list_products.txt", out list_prods);
				foreach (Product prod in list_prods.GetAll()) (list as List<Product>).Add(prod);
				}else if (typeof(T).Equals(typeof(Partner))) {
					ListUnits list_pa;
				FileDataBase.Load<ListUnits>("list_partners.txt", out list_pa);
				foreach (Partner pa in list_pa.GetAll()) (list as List<Partner>).Add(pa);
				}else if (typeof(T).Equals(typeof(BuyBill))) {
					ListUnits list_pa;
					FileDataBase.Load<ListUnits>("list_partners.txt", out list_pa);
					
					ListUnits list_prods;
				FileDataBase.Load<ListUnits>("list_products.txt", out list_prods);
					
				ListBuyBills list_bb=FileDataBase.LoadListBuyBills(list_prods,list_pa);
				foreach (BuyBill bb in list_bb.GetAll()) (list as List<BuyBill>).Add(bb);
				}
			}
					
					
			return list;
		}
		
		

public static int GetNextNumber<T>() {
			int val=0;
			if (Config.dbServer=="sqlite") {
				if (typeof(T).Equals(typeof(BuyBill))) {
					val=SQLiteDataBase.GetMaxValueOfColumn("number","buybill");
					val++;
				}else if (typeof(T).Equals(typeof(SellBill))) {
					val=SQLiteDataBase.GetMaxValueOfColumn("number","sellbill");
					val++;
				}
			}else if (Config.dbServer=="txtfile_database") {
				if (typeof(T).Equals(typeof(BuyBill))) {
				val=BuyBill.number;
				val++;
				}
			}
			return val;
		}
		
public static void InsertTradeOperation(TradeOperation to) {
	if (Config.dbServer=="sqlite") {
	string[] columns = new string[]{"date"
			,"doc_number"	
			,"doc_type"
			,"doc_id"
			,"prod_id"
			,"quantity"
			,"price"
			,"sum"
			,"price_buy"
			,"profit"
	,"partner_id"
,"storage_id"				
       };
	string[] values = new string[]{to.Date.ToString()
				,to.Doc_number.ToString()
				,to.Doc_type.ToString()
			,to.Doc_id.ToString()
			,to.Product.Id.ToString()
			,to.Quantity.ToString()
			,to.Price.ToString()
			,to.Sum.ToString()
			,to.Price_buy.ToString()
			,to.Profit.ToString()
	,to.Partner.Id.ToString()
				,to.Storage.Id.ToString()
       };
	SQLiteDataBase.AddOneRecord(columns,values,"trade_operation");
	}else if (Config.dbServer=="txtfile_database") {
		FileDataBase.AddOneRecord<TradeOperation>(ref to,"list_trade_operations.txt");
	}
	
}

public static void InsertQuantityReport(RowQuantityReportStruct inst) {
	if (Config.dbServer=="sqlite") {
	string[] columns = new string[]{"date"
			,"doc_number"	
			,"doc_type"
			,"doc_id"
			,"prod_id"
			,"income"
			,"outgo"
			,"stock_quantity"
			,"price_buy"
			,"storage_id"
       };
	string[] values = new string[]{inst.date.ToString()
				,inst.doc_number.ToString()
				,inst.doc_type.ToString()
			,inst.doc_id.ToString()
			,inst.product.Id.ToString()
			,inst.income.ToString()
			,inst.outgo.ToString()
			,inst.stock_quantity.ToString()
			,inst.price_buy.ToString()
			,inst.storage.Id.ToString()
       };
	SQLiteDataBase.AddOneRecord(columns,values,"quantity_report");
	}else if (Config.dbServer=="txtfile_database") {
	//	FileDataBase.AddOneRecord<RowQuantityReportStruct>(ref inst,"list_qreport_struct.txt");
	}
	
}
		
	}
}
