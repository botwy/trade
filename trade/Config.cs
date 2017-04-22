/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 04.10.2016
 * Time: 17:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;

namespace trade
{
	
//	delegate void SetTextCallback(string text);	
	
//	delegate void SetDataTableCallback();	
	
//	delegate void DoCloseCallback();

	public delegate void GetDataFromOtherForm(string text);
	
	/// <summary>
	/// Description of Config.
	/// </summary>
	public struct Config
	{
	public static string dbServer;
	public static string barcode_port;
	public static bool ask_barcode;
	public static float markup=50f;
	public static string database="\\TorgProg\\torg_prog_sqlite.db";
	//public static string database="C:\\TorgProg1\\torg_prog_sqlite.db";
	}
}
