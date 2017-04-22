/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 22.10.2016
 * Time: 16:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of FormOnePartner.
	/// </summary>
	public partial class FormOnePartner : Form
	{
		TradeApp app;
		Partner pa;
public FormOnePartner(TradeApp app, Partner pa)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		
			this.app=app;
			this.pa=pa;
			textBox1.Text=this.pa.Title;
			textBox2.Text=this.pa.Phone;
			textBox3.Text=this.pa.E_mail;
		//	comboBox1.Text=this.pa.Markup_type.Title;
			
			foreach (MarkupType mType in DB.GetAll<MarkupType>())
				comboBox1.Items.Add(mType.Title);
			if (this.pa.Markup_type!=null)
			comboBox1.SelectedItem=this.pa.Markup_type.Title;
			
			this.Text=this.pa.Title+"-Карточка контрагента";
			
		UpdateMarkupTypeList();
		UpdateMarkupPercentCorrectList();
		UpdateRoundPriceCorrectList();
			
		foreach (MarkupType m_type in DB.GetAll<MarkupType>()){
				comboBox2.Items.Add(m_type.Title);
				comboBox3.Items.Add(m_type.Title);
				comboBox4.Items.Add(m_type.Title);
		}
		}
		
void UpdateMarkupTypeList() {
			DataTable dt = new DataTable();
			dt.Columns.Add("X");
			dt.Columns.Add("Тип наценки");
			dt.Columns.Add("% наценки");
			
			
			if (pa.List_markupTypeToProd==null) return;
			
			foreach (KeyValuePair<MarkupType,float> keyValue in pa.List_markupTypeToProd)
				dt.Rows.Add("x",keyValue.Key.Title,keyValue.Value.ToString());
			
			dataGridView1.DataSource=dt;
			dataGridView1.Columns[0].Width=20;
			dataGridView1.Columns[0].ReadOnly=true;
			dataGridView1.Columns[1].ReadOnly=true;
		}
		
		void UpdateMarkupPercentCorrectList() {
			DataTable dt = new DataTable();
			dt.Columns.Add("X");
			dt.Columns.Add("Тип наценки");
			dt.Columns.Add("Нач цена");
			dt.Columns.Add("Конечн цена");
			dt.Columns.Add("% наценки");
			dt.Columns.Add("фиксир цена");
			
			if (pa.List_mtypeCorrect==null) return;
			
			foreach (MarkupTypePercentCorrection mtype_correct in pa.List_mtypeCorrect)
				dt.Rows.Add("x"
				            ,mtype_correct.Markup_type.Title
				            ,mtype_correct.Begin_number
				           ,mtype_correct.End_number
				          ,mtype_correct.Percent
				         ,mtype_correct.Fix_price);
			
			dataGridView2.DataSource=dt;
			dataGridView2.Columns[0].Width=20;
			dataGridView2.Columns[0].ReadOnly=true;
			dataGridView2.Columns[1].ReadOnly=true;
			dataGridView2.Columns[2].ReadOnly=true;
			dataGridView2.Columns[3].ReadOnly=true;
			dataGridView2.Columns[4].ReadOnly=true;
			dataGridView2.Columns[5].ReadOnly=true;
		}
		
//		void UpdateMarkupTypeList() {
//			DataTable dt = new DataTable();
//			dt.Columns.Add("X");
//			dt.Columns.Add("Тип наценки");
//			dt.Columns.Add("% наценки");
//			
//			
//			if (pa.List_markupTypeToProd==null) return;
//			
//			foreach (KeyValuePair<MarkupType,float> keyValue in pa.List_markupTypeToProd)
//				dt.Rows.Add("x",keyValue.Key.Title,keyValue.Value.ToString());
//			
//			dataGridView1.DataSource=dt;
//			dataGridView1.Columns[0].Width=20;
//			dataGridView1.Columns[0].ReadOnly=true;
//			dataGridView1.Columns[1].ReadOnly=true;
//		}
		
void UpdateRoundPriceCorrectList() {
			DataTable dt = new DataTable();
			dt.Columns.Add("X");
			dt.Columns.Add("Тип наценки");
			dt.Columns.Add("Нач число(последние цифры цены)");
			dt.Columns.Add("Конечн число(последние цифры цены)");
			dt.Columns.Add("Цифры, до которых округляем");
		
			
			if (pa.List_roundCorrect==null) return;
			
			foreach (RoundPriceCorrection round_correct in pa.List_roundCorrect)
				dt.Rows.Add("x"
				            ,round_correct.Markup_type.Title
				            ,round_correct.Begin_number
				           ,round_correct.End_number
				          ,round_correct.Round_result);
			
			dataGridView3.DataSource=dt;
			dataGridView3.Columns[0].Width=20;
			dataGridView3.Columns[0].ReadOnly=true;
			dataGridView3.Columns[1].ReadOnly=true;
			dataGridView3.Columns[2].ReadOnly=true;
			dataGridView3.Columns[3].ReadOnly=true;
			dataGridView3.Columns[4].ReadOnly=true;
		}
		
void Button1Click(object sender, EventArgs e)
		{
		
		string new_phone=textBox2.Text;
		string new_e_mail=textBox3.Text;
		
		pa.Phone=new_phone;
		pa.E_mail=new_e_mail;
		pa.Markup_type=DB.GetUnitByTitle<MarkupType>(comboBox1.Text);
		
		DB.UpdateUnit<Partner>(this.pa);
		Partner u_pa=DB.GetUnitById<Partner>(pa.Id.ToString());
		label5.Text="Текущий ном. тел.: "+u_pa.Phone;
		label6.Text="Текущий e-mail: "+u_pa.E_mail;
		this.Text=u_pa.Title+"-Карточка контрагента";
		app.EventOnePartnerUpdate(u_pa);
			                                       
		}
		
void TextBox2TextChanged(object sender, EventArgs e)
		{
		this.Text=this.pa.Title+"-Карточка контрагента *";	
		}
		
void TextBox3TextChanged(object sender, EventArgs e)
		{
			this.Text=this.pa.Title+"-Карточка контрагента *";
		}
				
		
void Button2Click(object sender, EventArgs e)
		{
			MarkupType m_type=DB.GetUnitByTitle<MarkupType>(comboBox2.Text);
			float percent=float.Parse(textBox4.Text);
			//MessageBox.Show(prod.List_markupType.ContainsKey(m_type).ToString());
			
			if (pa.List_markupTypeToProd!=null) {
			foreach (KeyValuePair<MarkupType,float> keyValue in pa.List_markupTypeToProd) {
				if (keyValue.Key.Id==m_type.Id) {
				MessageBox.Show("Такой тип наценки для товаров уже есть у этого поставщика");
                return;				
				}
			}
			}
			
			
			    pa.List_markupTypeToProd.Add(m_type,percent);
			UpdateMarkupTypeList();
			this.Text=this.pa.Title+"-Карточка контрагента(поставщик) *";
		//	DB.UpdateUnit<Product>(this.prod);
			
			
		}
	
void Button3Click(object sender, EventArgs e)
		{
			MarkupType m_type=DB.GetUnitByTitle<MarkupType>(comboBox3.Text);
			float begin_number=float.Parse(textBox5.Text);
			float end_number=float.Parse(textBox6.Text);
			float percent=float.Parse(textBox7.Text);
			float fix_price=(textBox8.Text=="")?0f:float.Parse(textBox8.Text);
			//MessageBox.Show(prod.List_markupType.ContainsKey(m_type).ToString());
			
			
			bool is_mtype=false;
			foreach (KeyValuePair<MarkupType,float> keyValue in pa.List_markupTypeToProd)
				if (keyValue.Key.Id==m_type.Id) is_mtype=true;
			
			if (!is_mtype) {
				MessageBox.Show("У поставщика нет такого типа наценки. Сначала надо внести этот тип наценки на 1ой вкладке.");
					return;
			}
			
			foreach (MarkupTypePercentCorrection mtype_correct in pa.List_mtypeCorrect) {
				if (mtype_correct.Markup_type.Id!=m_type.Id) continue;
				
			if (!mtype_correct.CheckBeginEnd(begin_number,end_number)) {
					MessageBox.Show("Интервал пересекается с уже существующей записью. Или конечное число не больше начального.");
					return;
				}
			}
			
			
			pa.List_mtypeCorrect.Add(new MarkupTypePercentCorrection(m_type
				                    ,begin_number
		                            ,end_number
		                           ,percent
		                           ,fix_price
			));
			UpdateMarkupPercentCorrectList();
			this.Text=this.pa.Title+"-Карточка контрагента(поставщик) *";
		//	DB.UpdateUnit<Product>(this.prod);
			
			
		}
		
void Button4Click(object sender, EventArgs e)
		{
			MarkupType m_type=DB.GetUnitByTitle<MarkupType>(comboBox4.Text);
			float begin_number=float.Parse(textBox9.Text);
			float end_number=float.Parse(textBox10.Text);
			float round_result=float.Parse(textBox11.Text);
			
			bool is_mtype=false;
			foreach (KeyValuePair<MarkupType,float> keyValue in pa.List_markupTypeToProd)
				if (keyValue.Key.Id==m_type.Id) is_mtype=true;
			
			if (!is_mtype) {
				MessageBox.Show("У поставщика нет такого типа наценки. Сначала надо внести этот тип наценки на 1ой вкладке.");
					return;
			}
			
			foreach (RoundPriceCorrection round_correct in pa.List_roundCorrect) {
				if (round_correct.Markup_type.Id!=m_type.Id) continue;
				if (!round_correct.CheckBeginEnd(begin_number,end_number)) {
					MessageBox.Show("Интервал пересекается с уже существующей записью. Или конечное число не больше начального.");
					return;
 				}
            }
			
//			round_correct.Markup_type=m_type;
//			round_correct.Begin_number=begin_number;
//			round_correct.End_number=end_number;
//			round_correct.Round_result=round_result;
						
			pa.List_roundCorrect.Add(new RoundPriceCorrection(m_type
				                     ,begin_number
		                            ,end_number
		                           ,round_result
		                          )
		                          );
			UpdateRoundPriceCorrectList();
			this.Text=this.pa.Title+"-Карточка контрагента(поставщик) *";
		//	DB.UpdateUnit<Product>(this.prod);
			
			
		}
		
void DataGridView1CellClick(object sender, DataGridViewCellEventArgs e)
		{
			MarkupType cur_mtype=null;
			if ((e.ColumnIndex==0)&&(dataGridView1[e.ColumnIndex,e.RowIndex].Value.ToString()=="x")) {
				string mtype_name=(dataGridView1[1,e.RowIndex].Value).ToString();
				//MarkupType cur_mtype= DB.GetUnitByTitle<MarkupType>(mtype_name);
				  if(MessageBox.Show("Также будут удалены корректировки наценки и корректировки округления по этому типу наценки. Продолжить?"
				                   ,"Удаление типа наценки у поставщика", MessageBoxButtons.YesNo)!= DialogResult.Yes)
                                return;
	  
			//	if (cur_mtype!=null) {
					foreach (KeyValuePair<MarkupType, float> keyValue in pa.List_markupTypeToProd) {
				if (keyValue.Key.Title==mtype_name) {
					cur_mtype=keyValue.Key;
					
				//	MessageBox.Show(cur_mtype.Title);
					
				}
				
				
					}
			
			if (cur_mtype!=null)
				this.pa.List_markupTypeToProd.Remove(cur_mtype);
			
			
	
		pa.List_mtypeCorrect.RemoveAll(x=>x.Markup_type.Id==cur_mtype.Id);
		pa.List_roundCorrect.RemoveAll(x=>x.Markup_type.Id==cur_mtype.Id);
//	}
			
					UpdateMarkupTypeList();
					UpdateMarkupPercentCorrectList();
					UpdateRoundPriceCorrectList();
					this.Text=this.pa.Title+"-Карточка контрагента(поставщик)*";
			}
		}


void DataGridView1CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
	MarkupType cur_mtype=null;
		
	 if (e.ColumnIndex==2) {
//			
			object obj=dataGridView1[e.ColumnIndex,e.RowIndex].Value;
			object obj_mtype_name=dataGridView1[1,e.RowIndex].Value;
			//int new_quantity=(obj.ToString()!="")?int.Parse(obj.ToString()):0;
//			if (!Validator.DgvCell<SellBill>(obj.ToString(),out new_quantity)) {
//				UpdateTotalAndDataGridView();
//				return;
//			}
			
				float new_percent=float.Parse(obj.ToString());
				string mtype_name=obj_mtype_name.ToString();
		
	foreach (KeyValuePair<MarkupType, float> keyValue in pa.List_markupTypeToProd) {
				if (keyValue.Key.Title==mtype_name) {
						cur_mtype=keyValue.Key;
						
			//		keyValue.Value=new_percent; //ReadOnly
           //	MessageBox.Show(cur_mtype.Title);
					}
				}
				
		if (cur_mtype!=null)
				pa.List_markupTypeToProd[cur_mtype]=new_percent;
			UpdateMarkupTypeList();
		this.Text=this.pa.Title+"-Карточка контрагента(поставщик) *";
			
		}
	
	}
	
	void DataGridView2CellClick(object sender, DataGridViewCellEventArgs e)
		{
			
			if ((e.ColumnIndex==0)&&(dataGridView2[e.ColumnIndex,e.RowIndex].Value.ToString()=="x")) {
				string mtype_name=(dataGridView2[1,e.RowIndex].Value).ToString();
			int index=this.pa.List_mtypeCorrect.FindIndex(x=>x.Markup_type.Title==mtype_name);
			if (index>=0)
				this.pa.List_mtypeCorrect.RemoveAt(index);
			        UpdateMarkupPercentCorrectList();
					this.Text=this.pa.Title+"-Карточка контрагента(поставщик)*";
			}
		}
		
		void DataGridView3CellClick(object sender, DataGridViewCellEventArgs e)
		{
			
			if ((e.ColumnIndex==0)&&(dataGridView3[e.ColumnIndex,e.RowIndex].Value.ToString()=="x")) {
				string mtype_name=(dataGridView3[1,e.RowIndex].Value).ToString();
			int index=this.pa.List_roundCorrect.FindIndex(x=>x.Markup_type.Title==mtype_name);
			if (index>=0)
				this.pa.List_roundCorrect.RemoveAt(index);
			        UpdateRoundPriceCorrectList();
					this.Text=this.pa.Title+"-Карточка контрагента(поставщик)*";
			}
		}
		
		
		
		
	}
}
