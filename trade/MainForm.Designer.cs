/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 06.09.2016
 * Time: 9:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace trade
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
			this.котрагентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.NewStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.typeMarkupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newMarkupTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem1,
									this.toolStripMenuItem4,
									this.toolStripMenuItem5,
									this.toolStripMenuItem6,
									this.toolStripMenuItem7});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(692, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem2,
									this.toolStripMenuItem3,
									this.testToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(45, 20);
			this.toolStripMenuItem1.Text = "Файл";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(140, 22);
			this.toolStripMenuItem2.Text = "Сохранить";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(140, 22);
			this.toolStripMenuItem3.Text = "Выход";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
			this.testToolStripMenuItem.Text = "Test";
			this.testToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItemClick);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem8,
									this.котрагентыToolStripMenuItem,
									this.StorageToolStripMenuItem,
									this.typeMarkupToolStripMenuItem});
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 20);
			this.toolStripMenuItem4.Text = "Справочники";
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(156, 22);
			this.toolStripMenuItem8.Text = "Товары";
			this.toolStripMenuItem8.Click += new System.EventHandler(this.ToolStripMenuItem8Click);
			// 
			// котрагентыToolStripMenuItem
			// 
			this.котрагентыToolStripMenuItem.Name = "котрагентыToolStripMenuItem";
			this.котрагентыToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.котрагентыToolStripMenuItem.Text = "Котрагенты";
			this.котрагентыToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemPartnerClick);
			// 
			// StorageToolStripMenuItem
			// 
			this.StorageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.NewStorageToolStripMenuItem});
			this.StorageToolStripMenuItem.Name = "StorageToolStripMenuItem";
			this.StorageToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.StorageToolStripMenuItem.Text = "Склады";
			this.StorageToolStripMenuItem.Click += new System.EventHandler(this.StorageToolStripMenuItemClick);
			// 
			// NewStorageToolStripMenuItem
			// 
			this.NewStorageToolStripMenuItem.Name = "NewStorageToolStripMenuItem";
			this.NewStorageToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
			this.NewStorageToolStripMenuItem.Text = "Новый склад";
			this.NewStorageToolStripMenuItem.Click += new System.EventHandler(this.NewStorageToolStripMenuItemClick);
			// 
			// typeMarkupToolStripMenuItem
			// 
			this.typeMarkupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newMarkupTypeToolStripMenuItem});
			this.typeMarkupToolStripMenuItem.Name = "typeMarkupToolStripMenuItem";
			this.typeMarkupToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
			this.typeMarkupToolStripMenuItem.Text = "Типы наценок";
			this.typeMarkupToolStripMenuItem.Click += new System.EventHandler(this.TypeMarkupToolStripMenuItemClick);
			// 
			// newMarkupTypeToolStripMenuItem
			// 
			this.newMarkupTypeToolStripMenuItem.Name = "newMarkupTypeToolStripMenuItem";
			this.newMarkupTypeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.newMarkupTypeToolStripMenuItem.Text = "Новый тип наценок";
			this.newMarkupTypeToolStripMenuItem.Click += new System.EventHandler(this.NewMarkupTypeToolStripMenuItemClick);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem9,
									this.toolStripMenuItem10});
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(77, 20);
			this.toolStripMenuItem5.Text = "Документы";
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(203, 22);
			this.toolStripMenuItem9.Text = "Приходные накладные";
			this.toolStripMenuItem9.Click += new System.EventHandler(this.ToolStripMenuItem9Click);
			// 
			// toolStripMenuItem10
			// 
			this.toolStripMenuItem10.Name = "toolStripMenuItem10";
			this.toolStripMenuItem10.Size = new System.Drawing.Size(203, 22);
			this.toolStripMenuItem10.Text = "Расходные накладные";
			this.toolStripMenuItem10.Click += new System.EventHandler(this.ToolStripMenuItem10Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem11,
									this.toolStripMenuItem12});
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(67, 20);
			this.toolStripMenuItem6.Text = "Журналы";
			// 
			// toolStripMenuItem11
			// 
			this.toolStripMenuItem11.Name = "toolStripMenuItem11";
			this.toolStripMenuItem11.Size = new System.Drawing.Size(203, 22);
			this.toolStripMenuItem11.Text = "Приходные накладные";
			this.toolStripMenuItem11.Click += new System.EventHandler(this.ToolStripMenuItem11Click);
			// 
			// toolStripMenuItem12
			// 
			this.toolStripMenuItem12.Name = "toolStripMenuItem12";
			this.toolStripMenuItem12.Size = new System.Drawing.Size(203, 22);
			this.toolStripMenuItem12.Text = "Расходные накладные";
			this.toolStripMenuItem12.Click += new System.EventHandler(this.ToolStripMenuItem12Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripMenuItem13,
									this.toolStripMenuItem14});
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(59, 20);
			this.toolStripMenuItem7.Text = "Отчёты";
			// 
			// toolStripMenuItem13
			// 
			this.toolStripMenuItem13.Name = "toolStripMenuItem13";
			this.toolStripMenuItem13.Size = new System.Drawing.Size(131, 22);
			this.toolStripMenuItem13.Text = "Остатки";
			this.toolStripMenuItem13.Click += new System.EventHandler(this.ToolStripMenuItem13Click);
			// 
			// toolStripMenuItem14
			// 
			this.toolStripMenuItem14.Name = "toolStripMenuItem14";
			this.toolStripMenuItem14.Size = new System.Drawing.Size(131, 22);
			this.toolStripMenuItem14.Text = "Продажи";
			this.toolStripMenuItem14.Click += new System.EventHandler(this.ToolStripMenuItem14Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(692, 566);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "trade";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainFormFormClosing);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem newMarkupTypeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem typeMarkupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem NewStorageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem StorageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem котрагентыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.MenuStrip menuStrip1;
		
	
		
		
	}
}
