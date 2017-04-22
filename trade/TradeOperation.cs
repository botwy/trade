/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 10.09.2016
 * Time: 18:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trade
{
	/// <summary>
	/// Description of TradeOperation.
	/// </summary>
	public class TradeOperation
	{
		DateTime date;
		int doc_number;
		string doc_type;
		int doc_id;
		Product product;
		int quantity;
		float price;
		float sum;
		float price_buy; 
		float profit;
		Partner partner;
		Storage storage;
		
		public TradeOperation() {
			
		}
		
		public TradeOperation(DateTime date,int doc_number, string doc_type,
		   int doc_id,Product product,int quantity,float price, float sum, Partner partner)
		{
			this.date=date;
			this.doc_number=doc_number;
			this.doc_type=doc_type;
			this.doc_id=doc_id;
			this.product=product;
			this.quantity=quantity;
			this.price=price;
			this.sum=sum;
			this.price_buy=product.Price_buy;
			this.profit=(this.price-this.price_buy)*this.quantity;
			this.partner=partner;
		}
		
		public TradeOperation(DateTime date,int doc_number, string doc_type,
		   int doc_id,Product product,int quantity,float price, float sum
		   , Partner partner, Storage storage)
		{
			this.date=date;
			this.doc_number=doc_number;
			this.doc_type=doc_type;
			this.doc_id=doc_id;
			this.product=product;
			this.quantity=quantity;
			this.price=price;
			this.sum=sum;
			this.price_buy=product.Price_buy;
			this.profit=(this.price-this.price_buy)*this.quantity;
			this.partner=partner;
			this.storage=storage;
		}
		
		public TradeOperation(DateTime date,int doc_number, string doc_type, int doc_id,
		   Product product,int quantity,float price, float sum, float price_buy, float profit, Partner partner)
		{
			this.date=date;
			this.doc_number=doc_number;
			this.doc_type=doc_type;
			this.doc_id=doc_id;
			this.product=product;
			this.quantity=quantity;
			this.price=price;
			this.sum=sum;
			this.price_buy=price_buy;
			this.profit=profit;
			this.partner=partner;
		}
		
   public DateTime Date {set {this.date=value;}get{return this.date;}}
     public int Doc_number {set {this.doc_number=value;}get{return this.doc_number;}}
       public string Doc_type {set {this.doc_type=value;}get{return this.doc_type;}}
        public int Doc_id {set {this.doc_id=value;}get{return this.doc_id;}}
     public Product Product {set {this.product=value;}get{return this.product;}}
	  public int Quantity {set {this.quantity=value;}get{return this.quantity;}}
	   public float Price {set {this.price=value;}get{return this.price;}}
	    public float Sum {set {this.sum=value;}get{return this.sum;}}
	    public float Price_buy {set {this.price_buy=value;}get{return this.price_buy;}}
	    public float Profit {set {this.profit=value;}get{return this.profit;}}
	     public Partner Partner {set {this.partner=value;}get{return this.partner;}}
	     public Storage Storage {set{this.storage=value;}get{return this.storage;}}
	}
}
