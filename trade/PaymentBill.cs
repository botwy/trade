/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 06.12.2016
 * Time: 12:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace trade
{
	/// <summary>
	/// Description of PaymentBill.
	/// </summary>
	public class PaymentBill
	{
		int id;
		int number;
		DateTime date;
		float sum;
		string details;
		
		Partner sender;
		Partner receiver;
		
		string sender_acount;
		string receiver_acount;
		
		string sender_bank;
		string receiver_bank;
		
		string sender_bank_bik;
		string receiver_bank_bik;
		
		string sender_bank_acount;
		string receiver_bank_acount;
		
		string sender_inn;
		string receiver_inn;
		
		string sender_kpp;
		string receiver_kpp;
		
		string payment_type;
		string kbk;
		string oktmo;
		
		string payment_time;
		string priority;
		string code;
		
		string tax_base;
		string tax_period;
		string tax_doc_number;
		
		string tax_base_date;
		string tax_payment_type;
		
		public PaymentBill()
		{
		}
	}
}
