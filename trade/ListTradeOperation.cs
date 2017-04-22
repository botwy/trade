/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 10.09.2016
 * Time: 18:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of ListTradeOperation.
	/// </summary>
	public class ListTradeOperation
	{
		List<TradeOperation> list_to;
		
		public ListTradeOperation()
		{
			this.list_to=new List<TradeOperation>();
		}
		public TradeOperation[] GetAll() {
			TradeOperation[] arr_to = new TradeOperation[this.list_to.Count];
			
			this.list_to.CopyTo(arr_to);
			return arr_to;
		}
		
		public void Add(TradeOperation to) {
			this.list_to.Add(to);
		}
		
	}
}
