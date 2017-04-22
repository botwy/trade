/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 07.09.2016
 * Time: 14:32
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
	public class ListProducts
	{
		List<Product> list_prod;
		public ListProducts()
		{
			this.list_prod=new List<Product>();
		}
		
		public Product[] GetAll() {
			Product[] arr_prod = new Product[list_prod.Count];
			
			this.list_prod.CopyTo(arr_prod);
			return arr_prod;
		}
		
		public void Add(Product prod) {
			this.list_prod.Add(prod);
		}
		
		public bool IsProductByTitle(string title) {
			foreach (Product cur_prod in this.list_prod) {
				if(title==cur_prod.Title) return true;
			}
			return false;
		}
		
		public Product FindByTitle(string title) {
			foreach (Product cur_prod in this.list_prod) {
				if(title==cur_prod.Title) return cur_prod;
			}
			return null;
		}
	}
}
