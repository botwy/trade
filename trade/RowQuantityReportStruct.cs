/*
 * Created by SharpDevelop.
 * User: Владелец
 * Date: 19.09.2016
 * Time: 11:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trade
{
	/// <summary>
	/// Description of RowQuantityReportStruct.
	/// </summary>
	public struct RowQuantityReportStruct
	{
		public int id;
		public DateTime date;
		
		public int doc_number;
		public string doc_type;
		public int doc_id;
		public Product product;
		public int income;
		public int outgo;
		public int stock_quantity;
		
		public float price_buy;
        public Storage storage;		
		
		public RowQuantityReportStruct(DateTime date, int doc_number, 
		string doc_type, int doc_id, Product prod, 
		int income, int outgo, int stock_quantity, float price_buy) {
			this.id=0;
        	this.date=date;
			this.doc_number=doc_number;
			this.doc_type=doc_type;
			this.doc_id=doc_id;
			this.product=prod;
			this.income=income;
			this.outgo=outgo;
			this.stock_quantity=stock_quantity;
			this.price_buy=price_buy;
			this.storage=null;
			
		
				
			}
		public RowQuantityReportStruct(DateTime date, int doc_number, 
		string doc_type, int doc_id, Product prod, 
		int income, int outgo, int stock_quantity, float price_buy
	,Storage storage) {
        	this.id=0;
			this.date=date;
			this.doc_number=doc_number;
			this.doc_type=doc_type;
			this.doc_id=doc_id;
			this.product=prod;
			this.income=income;
			this.outgo=outgo;
			this.stock_quantity=stock_quantity;
			this.price_buy=price_buy;
			this.storage=storage;
			
		
				
			}
		
	}
}
