/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 23.11.2016
 * Time: 17:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trade
{
	/// <summary>
	/// Description of MarkupType.
	/// </summary>
	public class MarkupType:Unit
	{
		float basic_percent;
		
		public MarkupType(string title)
		{
			this.Title=title;
		}
		
		public MarkupType()
		{
			this.Title="";
		}
		
		public float Basic_percent {set{this.basic_percent=value;}get{return this.basic_percent;}}
	}
}
