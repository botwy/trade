/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 08.09.2016
 * Time: 16:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trade
{
	/// <summary>
	/// Description of RowBill.
	/// </summary>
	public struct RowDocStruct 
		//: IEquatable<RowBill>
	{
		    public Product product;
			public int quantity;
			public float price;
			public float sum;
			
			public RowDocStruct(Product prod, int quantity,float price,float sum) {
			this.product=prod;
			this.quantity=quantity;
			this.price=price;
			this.sum=sum;	
				
			}
	}
}
