/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 29.09.2016
 * Time: 13:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trade
{
	/// <summary>
	/// Description of Unit.
	/// </summary>
	public class Unit
	{
		int id;
		string title;
		public string Title{get{return title;}set {title=value;}}
	    public int Id{get{return id;}set{this.id=value;}}
	}
}
