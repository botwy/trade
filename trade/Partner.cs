/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 27.09.2016
 * Time: 16:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of Partner.
	/// </summary>
	public class Partner:Unit
	{
			
	
		string phone;
		string e_mail;
		MarkupType markup_type;
		Dictionary<MarkupType, float> list_markupTypeToProd;
		List<MarkupTypePercentCorrection> list_mtypeCorrect;
		List<RoundPriceCorrection> list_roundCorrect;
		
		public string Phone{get{return phone;}set{phone=value;}}
		public string E_mail{get{return e_mail;}set{e_mail=value;}}
		public MarkupType Markup_type{get{return this.markup_type;}set{this.markup_type=value;}}
		public Dictionary<MarkupType,float> List_markupTypeToProd {get{return this.list_markupTypeToProd;}set{this.list_markupTypeToProd=value;}}
		public List<MarkupTypePercentCorrection> List_mtypeCorrect {get{return list_mtypeCorrect;}set{list_mtypeCorrect=value;}}
		public List<RoundPriceCorrection> List_roundCorrect {get{return list_roundCorrect;}set{list_roundCorrect=value;}}
		
		public Partner(string title)
		{
			this.Id=0;
	    	this.Title=title;
			this.phone="";
			this.e_mail="";
			
			this.list_markupTypeToProd=new Dictionary<MarkupType, float>();
			this.list_mtypeCorrect=new List<MarkupTypePercentCorrection>();
			this.list_roundCorrect=new List<RoundPriceCorrection>();
		}
		
		public Partner()
		{
			this.Id=0;
	    	this.Title="";
			this.phone="";
			this.e_mail="";
				
			this.list_markupTypeToProd=new Dictionary<MarkupType, float>();
			this.list_mtypeCorrect=new List<MarkupTypePercentCorrection>();
			this.list_roundCorrect=new List<RoundPriceCorrection>();
		}
		
		public void AddToDB() {
			DB.InsertUnit<Partner>(this);
		}
	}
}
