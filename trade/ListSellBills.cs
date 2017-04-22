/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 09.09.2016
 * Time: 16:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of ListSellBills.
	/// </summary>
	public class ListSellBills
	{
		List<SellBill> list_sb;
		
		public ListSellBills()
		{
			this.list_sb=new List<SellBill>();
		}
		
		
		public SellBill[] GetAll() {
			SellBill[] arr_sb = new SellBill[list_sb.Count];
			
			this.list_sb.CopyTo(arr_sb);
			return arr_sb;
		}
		
		public SellBill Get(int index) {
			return this.list_sb[index];
		}
		
		public void Add(SellBill sb) {
			this.list_sb.Add(sb);
		}
		
	}
}
