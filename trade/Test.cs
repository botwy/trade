/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 28.10.2016
 * Time: 19:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of Test.
	/// </summary>
	public partial class Test : Form
	{
		public Test()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			LoadBuyBill();
			LoadProdQtyStorage();
			
//			MarkupTypePercentCorrection mtype_correct=new MarkupTypePercentCorrection();
//			List<RoundCorrectionStruct> list=new List<RoundCorrectionStruct>();
//			list.Add(new RoundCorrectionStruct(0f,29f,99f));
//			list.Add(new RoundCorrectionStruct(0f,4f,9f));
//			mtype_correct.List_round=list;
//			MarkupType markup_type=DB.GetUnitById<MarkupType>("1");
//			mtype_correct.Markup_type=markup_type;
//			MessageBox.Show((mtype_correct.CalculatePrice(28f)).ToString());
			
		}
		
				void LoadBuyBill()
		{
			DataTable dt=new DataTable();
			
	        dt.Columns.Add("id");
			dt.Columns.Add("number");
			dt.Columns.Add("product");
			
			dt.Columns.Add("storage_id");
			dt.Columns.Add("stock");
			dt.Columns.Add("Date");
		
		

		foreach (DbDataRecord rec in SQLiteDataBase.GetAllRows("quantity_report")) {
		//	Storage st=	DB.GetUnitById<Storage>(rec["storage_id"].ToString());
		//	string st_text;
		//	if (st==null)st_text=""; else st_text=st.Title;
	dt.Rows.Add(rec["id"].ToString()
		         	,rec["doc_number"].ToString()
		         	,DB.GetUnitById<Product>(rec["prod_id"].ToString()).Title
		         	,rec["storage_id"].ToString()
		         	,rec["stock_quantity"].ToString()
		         	,rec["date"].ToString()
		        );
		         }

			dataGridView1.DataSource=dt;
		}
				

void LoadProdQtyStorage()
		{
			DataTable dt=new DataTable();
			
	        dt.Columns.Add("id");
			dt.Columns.Add("prod");
			
			dt.Columns.Add("storage");
			dt.Columns.Add("quantity");
		
		

		foreach (DbDataRecord rec in SQLiteDataBase.GetAllRows("prodqty_storage")) {
	Storage st=	DB.GetUnitById<Storage>(rec["storage_id"].ToString());
			string st_text;
			if (st==null)st_text=""; else st_text=st.Title;
		

Product prod=	DB.GetUnitById<Product>(rec["prod_id"].ToString());
			string prod_text;
			if (prod==null)prod_text=""; else prod_text=prod.Title;			
			dt.Rows.Add(rec["id"].ToString()
		         	,prod_text
		         
		         	,st_text
                    	,rec["quantity"].ToString()        
		        );
		         }

			dataGridView2.DataSource=dt;
		}
								
	}
}
