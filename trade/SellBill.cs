/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 09.09.2016
 * Time: 16:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of SellBill.
	/// </summary>
	public class SellBill:DocWithTable
	{
		public static int number=0;
			
//		List<RowDocStruct> list_rows;
		int id;
//		float total_sum=0;
		int number_instance=0;
		DateTime date;
	    Partner consumer;
	    Storage storage;
	    
		public SellBill():base()
		{
		//	number++;
		//	this.list_rows=new List<RowDocStruct>();
		this.Check_available_item=true;
		}
		
//		public void AddRow(Product prod, int quantity,float price_sell,float sum) {
//			this.list_rows.Add(new RowDocStruct(prod, quantity, price_sell, sum));
//		}
//		public List<RowDocStruct> List_rows {set {this.list_rows=value;}get{return this.list_rows;}}
//		public float Total_sum {set {this.total_sum=value;}get{return this.total_sum;}}
	     public int Id {set {this.id=value;}get{return this.id;}}   
		public int Number_instance {set {this.number_instance=value;}get{return this.number_instance;}}
	    public DateTime Date {set {this.date=value;}get{return this.date;}}
	    public Partner Consumer {set {this.consumer=value;}get{return this.consumer;}}
	     public Storage Storage {set {this.storage=value;}get{return this.storage;}}
	    
	     public void DecreaseStock() {
			foreach (RowDocStruct row_d in this.List_rows) {
				//row_d.product.Quantity -=row_d.quantity;
				//DB
				if (this.storage!=null)
				DB.DecreaseProdStock(row_d,this.storage);
				//
			}
		}
	     
	    public void CheckOperation(ListTradeOperation list_to, ListQReportStruct list_rq) {
	    	DecreaseStock();
	    //	foreach (RowDocStruct row_d in this.List_rows) {
	    			    	
//	    		list_to.Add(new TradeOperation(this.date,this.Number_instance,"sellbill",
//	    		                               row_d.product,row_d.quantity,row_d.price,row_d.sum));
	    		
//	    		list_rq.Add(new RowQuantityReportStruct(this.date
//	    		                                        ,this.Number_instance
//	    		                                        ,"sellbill"
//	    		                                        ,row_d.product
//	    		                                        ,0
//	    		                                       ,row_d.quantity
//	    		                                      ,row_d.product.Quantity
//	    		                                     ,row_d.product.Price_buy));
	    		
	    	
	//    	}
	    }
	    
	    public void AddToDB() {
		this.Id = DB.InsertDoc<SellBill>(this);
			
			foreach (RowDocStruct row_d in this.List_rows) {
	    		DB.InsertTradeOperation(new TradeOperation(this.date
	    		                                           ,this.Number_instance
	    		                                           ,"sellbill"
	    		                                           ,this.Id
	    		                               ,row_d.product
	    		                              ,row_d.quantity
	    		                              ,row_d.price
	    		                              ,row_d.sum
	    		                             ,this.Consumer
	    		                            ,this.Storage)
	    		                           );
			
			DB.InsertQuantityReport(new RowQuantityReportStruct(this.date
	    		                                        ,this.Number_instance
	    		                                        ,"sellbill"
	    		                                        ,this.Id
	    		                                        ,row_d.product
	    		                                        ,0
	    		                                       ,row_d.quantity
	    		                                       ,DB.GetProdStockAtStorage(row_d.product,this.Storage)
	    		                                     ,row_d.product.Price_buy
	    		                                     ,this.Storage)
	    		                                    );
			                                
			}
		}
	    
	}
}
