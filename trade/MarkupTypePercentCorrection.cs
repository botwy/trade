/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 02.12.2016
 * Time: 12:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of MarkupTypePercentCorrection.
	/// </summary>
	public class MarkupTypePercentCorrection
	{
		MarkupType markupType;
		float begin_number;
		float end_number;
		float percent;
		float fix_price;
		
	//	List<RoundCorrectionStruct> list_round;
		
		
		
		public MarkupType Markup_type {get{return markupType;}set{markupType=value;}}
	
	//	public List<RoundCorrectionStruct> List_round {get{return list_round;}set{list_round=value;}}
		public float Begin_number {get{return begin_number;}}
		public float End_number {get{return end_number;}}
		public float Percent {get{return percent;}}
		public float Fix_price {get{return fix_price;}}
		

public MarkupTypePercentCorrection(MarkupType m_type,float begin_number
		                                  ,float end_number
		                                 ,float percent
		                                ,float fix_price)
		{
			this.markupType=m_type;
			this.begin_number=begin_number;
			this.end_number=end_number;
			this.percent=percent;
			this.fix_price=fix_price;
		}
		
		public MarkupTypePercentCorrection()
		{
			markupType=null;
			begin_number=0f;
			end_number=0f;
			percent=0f;
			fix_price=0f;
		}
		
		public float CalculatePrice(float initial_price, float result_price) {
			
			if (markupType==null) return result_price;
			
			if ((initial_price>=begin_number)&&(initial_price<=end_number)) {
			result_price=float.Parse((Math.Round(initial_price*((percent+100)/100),0)).ToString());
			if (fix_price>0f) result_price=fix_price;
			}
		
			return result_price;	
		}
		
		public bool CheckBeginEnd(float new_begin, float new_end) {
			
			if (new_end<=new_begin) return false;
			
			if (((new_begin>=begin_number)&&(new_begin<=end_number))
			    ||((new_end>=begin_number)&&(new_end<=end_number))
			    ||((new_begin<begin_number)&&(new_end>end_number)))
				return false;
			
			return true;
		}
	}
}
