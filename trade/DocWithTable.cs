/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 10.09.2016
 * Time: 10:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace trade
{
	/// <summary>
	/// Description of DocWithTable.
	/// </summary>
	public class DocWithTable
	{
		List<RowDocStruct> list_rows;
		float total_sum=0;
		int total_quantity=0;
		bool check_available_item=true;
		
		public List<RowDocStruct> List_rows {
			set {
				this.list_rows=value;
				UpdateTotal();
			    }
			get{return this.list_rows;}}
		public float Total_sum {set {this.total_sum=value;}get{return this.total_sum;}}
	    public int Total_quantity {set {this.total_quantity=value;}get{return this.total_quantity;}}
	    public bool Check_available_item {set {this.check_available_item=value;}get{return this.check_available_item;}}
		
	    public DocWithTable()
		{
			this.list_rows=new List<RowDocStruct>();
		}
	    
	    public void UpdateTotal() {
	    	this.total_sum=0;
		        this.total_quantity=0;
				foreach (RowDocStruct row_d in list_rows) {
		        this.total_sum +=row_d.sum;	
				this.total_quantity +=row_d.quantity;
				    }
	    }
		
		public bool AddRow(Storage storage,Product prod, int quantity,float price, float sum) {
	    	int query_quantity=quantity;
	    	foreach (RowDocStruct rd in this.list_rows.FindAll(x=>x.product.Id==prod.Id))
	    		query_quantity += rd.quantity;
	    	int stock_quantity=DB.GetProdStockAtStorage(prod,storage);
	    	if ((this.Check_available_item)&&(stock_quantity<query_quantity)) {
				
				return false;
			}else{
	    		if (this.list_rows.Exists(x=>x.product.Id==prod.Id)) {
	    		  int index = this.list_rows.FindIndex(x=>x.product.Id==prod.Id);	
	    		  RowDocStruct row=this.list_rows[index];
	    		  
	    		   row.quantity +=quantity;
	    		   row.sum=row.quantity*row.price;
	    		   this.list_rows.RemoveAt(index);
	    		   this.list_rows.Insert(index,row);
	    		//   this.list_rows[index]=row;
	    		    }else{
			this.list_rows.Add(new RowDocStruct(prod, quantity, price, sum));
	    		    }
			    
	    		UpdateTotal();
			
		        return true;
			}
		}
		
		public DataTable GetDataTable() {
			DataTable dt=new DataTable();
			dt.Columns.Add("X");        //0
			dt.Columns.Add("Id товара"); //1
			dt.Columns.Add("Товар");       //2
			dt.Columns.Add("Количество");  //3
			dt.Columns.Add("Цена");        //4
			dt.Columns.Add("Сумма");       //5
			dt.Columns.Add("Индекс");     //6
			
			//foreach (RowDocStruct row_d in this.list_rows) {
			for (int i=0; i<this.list_rows.Count; i++) {
				RowDocStruct row_d=this.list_rows[i];
				dt.Rows.Add("x",row_d.product.Id,row_d.product.Title,row_d.quantity,row_d.price,row_d.sum,i.ToString());
			
			}
			return dt;
		}
		
		public string[] CheckAvailableAll(Storage storage) {
			string have_stock="1",prod_title_no="";
//			foreach (RowDocStruct row_d in list_rows) {
//				
//			}
			foreach (RowDocStruct row_d in list_rows) {
				int q=0;
				foreach (RowDocStruct founded in list_rows.FindAll(x=>x.product.Id==row_d.product.Id))
					q+=founded.quantity;
				
				int stock_quantity=DB.GetProdStockAtStorage(row_d.product,storage);
			//	if (!DB.CheckProdStock(row_d.product, q)) {
			if(stock_quantity<q) {
					have_stock="0";
					prod_title_no=row_d.product.Title;
				}
				
//				if (row_d.product.Quantity<row_d.quantity) {
//					have_stock="0";
//					prod_title_no=row_d.product.Title;
//				}
				
			}
			return new string[2]{have_stock, prod_title_no};
		}
		
		
		
		
		
		public void UpdatePriceBuy() {
			foreach (RowDocStruct row_d in list_rows) {
				//row_d.product.Price_buy = row_d.price;
				//DB
				DB.UpdateProdPriceBuy(row_d);
				//
			}
		}
		
		
	}
}
