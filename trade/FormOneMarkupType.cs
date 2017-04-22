/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 24.11.2016
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace trade
{
	/// <summary>
	/// Description of FormOneMarkupType.
	/// </summary>
	public partial class FormOneMarkupType : Form
	{
		TradeApp app;
		MarkupType markup_type;
		bool new_item;
		public FormOneMarkupType(TradeApp app)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.app=app;
			this.Text="Новый тип наценки *";
			this.new_item=true;
		}
		
		public FormOneMarkupType(TradeApp app, MarkupType markup_type)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.app=app;
			this.markup_type=markup_type;
			textBox1.Text=this.markup_type.Title;
			textBox2.Text=this.markup_type.Basic_percent.ToString();
			
			this.Text=this.markup_type.Title+"-Карточка типа наценки";
			this.new_item=false;
			
			label3.Text="Текущее наименование: "+this.markup_type.Title;
		label4.Text="Текущее наименование: "+this.markup_type.Basic_percent.ToString();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if (this.new_item) {
				MarkupType new_markup= new MarkupType(textBox1.Text);
				new_markup.Basic_percent=float.Parse(textBox2.Text);
				int id=DB.InsertUnit<MarkupType>(new_markup);
				this.markup_type=DB.GetUnitById<MarkupType>(id.ToString());
			//	textBox1.Text=this.markup_type.Title;
				this.Text=this.markup_type.Title+"-Карточка типа наценок";
				this.new_item=false;
			//	app.EventOneStorageUpdate(this.storage);
			}else
			{
         this.markup_type.Title=textBox1.Text;
         this.markup_type.Basic_percent=float.Parse(textBox2.Text);
		DB.UpdateUnit<MarkupType>(this.markup_type);
		MarkupType u_markup=DB.GetUnitById<MarkupType>(this.markup_type.Id.ToString());
		label3.Text="Текущее наименование: "+u_markup.Title;
		label4.Text="Текущее наименование: "+u_markup.Basic_percent.ToString();
		this.Text=u_markup.Title+"-Карточка типа наценки";
	//	app.EventOneStorageUpdate(u_storage);
			}
			                                       
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			if ((!this.new_item)&&(this.markup_type!=null))
			this.Text=this.markup_type.Title+"-Карточка типа наценки*";
		}
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			if ((!this.new_item)&&(this.markup_type!=null))
			this.Text=this.markup_type.Title+"-Карточка типа наценки*";
		}
	}
}
