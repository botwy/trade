/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 02.12.2016
 * Time: 12:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trade
{
	/// <summary>
	/// Description of RoundCorrectionStruct.
	/// </summary>
	public class RoundPriceCorrection
	{
		MarkupType markupType;
		float begin_number;
		float end_number;
		float round_result;
	
		public MarkupType Markup_type {get{return markupType;}set{markupType=value;}}
		public float Begin_number {get{return begin_number;}}
		public float End_number {get{return end_number;}}
		public float Round_result {get{return round_result;}}
		
		public RoundPriceCorrection(MarkupType m_type
			                         ,float begin_number
		                            ,float end_number
		                           ,float round_result) {
			this.markupType=m_type;
			this.begin_number=begin_number;
			this.end_number=end_number;
			this.round_result=round_result;
		}
		
		public float CalculatePrice(float initial_price) {
			float result_price=initial_price;
			
			if (markupType==null) return result_price;
			
			//foreach (RoundCorrectionStruct row_round in list_round) {
				
				string result_priceString=(Math.Round(initial_price,0)).ToString();
				int result_priceLength=result_priceString.Length;
				
				string round_resString=(Math.Round(round_result,0)).ToString();
				int round_resLenght=round_resString.Length;
				string end_numString=(Math.Round(end_number,0)).ToString();
				int end_numLength=end_numString.Length;
				
				if(result_priceLength<=end_numLength) return result_price;
				
				float compare_number=float.Parse(result_priceString.Substring(result_priceLength-end_numLength));
				
				if ((compare_number>=begin_number)&&
					(compare_number<=end_number))
			result_price=float.Parse((Math.Round(result_price/(Math.Pow(10,round_resLenght)),0)-1).ToString()+round_resString);
					
			//}
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
