/*
 * Created by SharpDevelop.
 * User: denis
 * Date: 08.09.2016
 * Time: 16:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using System;
using System.Data;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of BuyBill.
	/// </summary>
	/// 
	
	
	public class BuyBill:DocWithTable
	{
		public static int number=0;
		//public string date;
		//DataTable dt;
		
		int id;
		//List<RowBill> list_rows;
		
		//float total_sum=0;
		int number_instance=0;
		DateTime date;
		Partner provider;
		Storage storage;
	//	bool check_available_item;
		
	public BuyBill():base()
		{
		//number++;
			//this.dt=dt_bb_content;
		//	this.list_rows=new List<RowBill>();
		//this.check_available_item=false;
		this.Check_available_item=false;
		this.Id=0;
		
		}
		
//		public void AddRow(Product prod, int quantity,float price_buy,float sum) {
//			this.list_rows.Add(new RowBill(prod, quantity, price_buy, sum));
//		}
//		public List<RowBill> List_rows {set {this.list_rows=value;}get{return this.list_rows;}}
//		public float Total_sum {set {this.total_sum=value;}get{return this.total_sum;}}
	  public int Id {set {this.id=value;}get{return this.id;}}   
	public int Number_instance {set {this.number_instance=value;}get{return this.number_instance;}}
	    public DateTime Date {set {this.date=value;}get{return this.date;}}
	   public Partner Provider{set {this.provider=value;}get{return this.provider;}}
	    public Storage Storage {set {this.storage=value;}get{return this.storage;}}

	   public void IncreaseStock() {
			foreach (RowDocStruct row_d in this.List_rows) {
				//row_d.product.Quantity +=row_d.quantity;
				//DB
				if (this.storage!=null)
				DB.IncreaseProdStock(row_d,this.storage);
				//
				
			}
		}


	    public void CheckOperation(ListQReportStruct list_rq) {
	//    	UpdatePriceBuy();
	    	IncreaseStock();
//--------------------------------------------------------
//Обновление товаров в т. ч. и закупочных цен. А также можно сделать обновление штрих-кодов и наименования товара.
//Обновление цен у типов наценки товара. Делаем такими же как у поставщика, если у поставщика задан хоть один тип
foreach (RowDocStruct row_d in List_rows) {
	row_d.product.Price_buy=row_d.price;
   if (this.provider!=null)
   	if (this.provider.List_markupTypeToProd.Count>0) {
   	float new_fix_price;
   	Dictionary<MarkupType,float> new_listMarkupFixPrice=new Dictionary<MarkupType, float>();
   	foreach (KeyValuePair<MarkupType,float> keyValue in this.provider.List_markupTypeToProd) {
   		new_fix_price=float.Parse(Math.Round(row_d.product.Price_buy*((keyValue.Value+100)/100),0).ToString());
   		
   		List<MarkupTypePercentCorrection> list_mtype_correct=this.provider.List_mtypeCorrect.FindAll(x=>x.Markup_type.Id==keyValue.Key.Id);
   		foreach (MarkupTypePercentCorrection mtype_corr in list_mtype_correct)
   				  new_fix_price=mtype_corr.CalculatePrice(row_d.product.Price_buy, new_fix_price);
  //   				if (mtype_corr.Percent>0)
//   				  new_fix_price=mtype_corr.Fix_price;
//   		             else
//   				  new_fix_price=float.Parse(Math.Round(row_d.product.Price_buy*((mtype_corr.Percent+100)/100),0).ToString());
   List<RoundPriceCorrection> list_round_correct=this.provider.List_roundCorrect.FindAll(x=>x.Markup_type.Id==keyValue.Key.Id);
   		foreach (RoundPriceCorrection round_corr in list_round_correct)
   		      new_fix_price=round_corr.CalculatePrice(new_fix_price);				
   		
   		new_listMarkupFixPrice.Add(keyValue.Key,new_fix_price);
   		}
   		      // row_d.product.List_markupType=this.provider.List_markupTypeToProd;
   		      row_d.product.List_markupType=new_listMarkupFixPrice;
   }
   		       DB.UpdateUnit<Product>(row_d.product);
	    }
	    
//----------------------------------------------------------
//	    	foreach (RowDocStruct row_d in this.List_rows) {
//	       		
//	    		list_rq.Add(new RowQuantityReportStruct(this.date
//	    		                                        ,this.Number_instance
//	    		                                        ,"buybill"
//	    		                                        ,row_d.product
//	    		                                        ,row_d.quantity
//	    		                                       ,0
//	    		                                      ,row_d.product.Quantity
//	    		                                     ,row_d.product.Price_buy));
//	    	}
	    }
	   
	   public void AddToDB() {
			this.Id=DB.InsertDoc<BuyBill>(this);
			
		foreach (RowDocStruct row_d in this.List_rows) {	
			DB.InsertQuantityReport(new RowQuantityReportStruct(this.date
	    		                                        ,this.Number_instance
	    		                                        ,"buybill"
	    		                                        ,this.Id
	    		                                        ,row_d.product
	    		                                        ,row_d.quantity
	    		                                       ,0
	    		                                     // ,row_d.product.Quantity
	    		                                     ,DB.GetProdStockAtStorage(row_d.product,this.Storage)
	    		                                     ,row_d.product.Price_buy
	    		                                     ,this.Storage)
	    		                                    );
		
			}
		}
	    
	}
	
}
