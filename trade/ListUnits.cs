/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 29.09.2016
 * Time: 13:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of ListUnits.
	/// </summary>
	public class ListUnits
	{
		List<Unit> list_u;
		
			public ListUnits()
		{
			this.list_u=new List<Unit>();
		}
		
		public Unit[] GetAll() {
			Unit[] arr_u = new Unit [list_u.Count];
			
			this.list_u.CopyTo(arr_u);
			return arr_u;
		}
		
		public void Add(Unit u) {
			this.list_u.Add(u);
		}
		
		public bool IsUnitByTitle(string title) {
			foreach (Unit cur_u in this.list_u) {
				if(title==cur_u.Title) return true;
			}
			return false;
		}
		
		public Unit FindByTitle(string title) {
			foreach (Unit cur_u in this.list_u) {
				if(title==cur_u.Title) return cur_u;
			}
			return null;
		}
		
	}
}
