/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 07.09.2016
 * Time: 12:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace trade
{
	
	
    
    
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Product:Unit
	{
		
		
		int quantity;
		float price_buy;
		string barcode;
		Dictionary<MarkupType, float> list_markupType;
	
		public int Quantity{get{return quantity;}set{this.quantity=value;}}
		public float Price_buy{get{return price_buy;}set{this.price_buy=value;}}
	   public string Barcode{get{return barcode;}set{this.barcode=value;}}
	   public Dictionary<MarkupType,float> List_markupType {get{return this.list_markupType;}set{this.list_markupType=value;}}
		
	   public Product(string title)
			//string title, int quantity, float price_buy)
		{
			this.Id=0;
			this.Title=title;
			this.quantity=0;
		    this.price_buy=0.0f;
		    this.barcode="";
			
		 
		//	FileDataBase.InsertProduct(this);
		this.list_markupType=new Dictionary<MarkupType, float>();
			
		}
		
		public Product()
			
		{
			this.Id=0;
			this.Title="";
			this.quantity=0;
		    this.price_buy=0.0f;
		    this.barcode="";
//		    
//		    MarkupType m_type=DB.GetUnitByTitle<MarkupType>("Оптовая");
//		     MarkupType m_type_2=DB.GetUnitByTitle<MarkupType>("РозницаДисконт");
//		    Dictionary<MarkupType,float> dict=new Dictionary<MarkupType, float>();
//		   dict.Add(m_type,21f);
//		 dict.Add(m_type_2,111f);
//		 // dict.Add(m_type_2,m_type_2.Basic_percent);
//		    this.List_markupType=dict;
		    this.list_markupType=new Dictionary<MarkupType, float>();
					
		}
		
		public void AddToDB() {
			DB.InsertUnit<Product>(this);
		}
		
//public object this[string propertyName]
//  {
//    get
//    {
//      if (propertyName == "Title") return this.Title;
//      else return null;
//     
//    }
//     set
//    {
//     	if (propertyName == "Title") this.Title=value.ToString();
//     
//    }
//  }
		
		
		
		
	}
}
