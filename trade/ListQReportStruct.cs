/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 24.09.2016
 * Time: 16:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of ListQReportStruct.
	/// </summary>
	public class ListQReportStruct
	{
		List<RowQuantityReportStruct> list_rq;
		
		public ListQReportStruct()
		{
			this.list_rq=new List<RowQuantityReportStruct>();
		}
		
		public RowQuantityReportStruct[] GetAll() {
			RowQuantityReportStruct[] arr_rq = new RowQuantityReportStruct[this.list_rq.Count];
			
			this.list_rq.CopyTo(arr_rq);
			return arr_rq;
		}
		
		public void Add(RowQuantityReportStruct rq) {
			this.list_rq.Add(rq);
		}
		
	}
}
