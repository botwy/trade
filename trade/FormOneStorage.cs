/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 28.10.2016
 * Time: 11:20
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace trade
{
	/// <summary>
	/// Description of FormOneStorage.
	/// </summary>
	public partial class FormOneStorage : Form
	{
		TradeApp app;
		Storage storage;
		bool new_item;
		
		public FormOneStorage(TradeApp app)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.app=app;
			this.Text="Новый склад *";
			this.new_item=true;
		}
		
		public FormOneStorage(TradeApp app, Storage storage)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.app=app;
			this.storage=storage;
			textBox1.Text=this.storage.Title;
			
			this.Text=this.storage.Title+"-Карточка склада";
			this.new_item=false;
		}
		
		
		
		void Button1Click(object sender, EventArgs e)
		{
			if (this.new_item) {
				Storage new_storage= new Storage(textBox1.Text);
				int id=DB.InsertUnit<Storage>(new_storage);
				this.storage=DB.GetUnitById<Storage>(id.ToString());
				//textBox1.Text=this.storage.Title;
				this.Text=this.storage.Title+"-Карточка склада";
				this.new_item=false;
				app.EventOneStorageUpdate(this.storage);
			}else
			{
         storage.Title=textBox1.Text;
		DB.UpdateUnit<Storage>(this.storage);
		Storage u_storage=DB.GetUnitById<Storage>(storage.Id.ToString());
		label2.Text="Текущее наименование: "+u_storage.Title;
		
		this.Text=u_storage.Title+"-Карточка склада";
		app.EventOneStorageUpdate(u_storage);
			}
			                                       
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			if ((!this.new_item)&&(this.storage!=null))
			this.Text=this.storage.Title+"-Карточка склада *";
		}
		
		
	}
}
