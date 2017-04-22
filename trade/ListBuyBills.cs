/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 09.09.2016
 * Time: 9:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of ListBuyBills.
	/// </summary>
	public class ListBuyBills
	{
		List<BuyBill> list_bb;
		public ListBuyBills()
		{
			this.list_bb=new List<BuyBill>();
		}
		
		public BuyBill[] GetAll() {
			BuyBill[] arr_bb = new BuyBill[list_bb.Count];
			
			this.list_bb.CopyTo(arr_bb);
			return arr_bb;
		}
		
		public BuyBill Get(int index) {
				return this.list_bb[index];
		}
		
		public BuyBill GetById(int id) {
			BuyBill val=null;
			foreach (BuyBill bb in this.list_bb)
				if (bb.Id==id) val=bb;
				return val;
		}
		
		public void Add(BuyBill bb) {
			this.list_bb.Add(bb);
		}
	}
}
