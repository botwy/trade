/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 27.09.2016
 * Time: 15:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Data;
namespace trade
{
	/// <summary>
	/// Description of DrawForPrint.
	/// </summary>
	public class DrawForPrint
	{
//		public DrawForPrint()
//		{
//		}
		public static void DrawDocWhithTable (Graphics g, string[] data, DataTable dt) {
			 //   String message = System.Environment.UserName;

			 string title=data[0];
			 string total_q=data[1];
			 string total_sum=data[2];
			 
    Font titleFont = new Font("Arial",

             20,System.Drawing.GraphicsUnit.Point);
    Font lineFont = new Font("Arial",

             14,System.Drawing.GraphicsUnit.Point);        

    g.DrawString(title,titleFont,Brushes.Black,100,100);
  //  g.DrawString(
  //  	new RectangleF(
   // g.DrawLine(Pens.Black,5,50,100,50);
   
   
   
   g.DrawLine(Pens.Black,80,135,650,135);
   g.DrawLine(Pens.Black,80,165,650,165);

   g.DrawLine(Pens.Black,80,135,80,165);
    g.DrawLine(Pens.Black,650,135,650,165);
     g.DrawLine(Pens.Black,330,135,330,165);
     g.DrawLine(Pens.Black,470,135,470,165);
     g.DrawLine(Pens.Black,540,135,540,165);
   //g.DrawString("Наименование товара Наименование товара",lineFont,Brushes.Black,100,140);
   g.DrawString("Наименование товара"
                ,lineFont,Brushes.Black,new RectangleF(100.0f,140.0f,230.0f,25.0f));
//   g.DrawString("Количество",lineFont,Brushes.Black,340,140);
//   g.DrawString("Цена",lineFont,Brushes.Black,480,140);
//   g.DrawString("Сумма",lineFont,Brushes.Black,550,140);
   
   g.DrawString("Количество",lineFont,Brushes.Black,new RectangleF(340.0f,140.0f,130.0f,25.0f));
   g.DrawString("Цена",lineFont,Brushes.Black,new RectangleF(480.0f,140.0f,60.0f,25.0f));
   g.DrawString("Сумма",lineFont,Brushes.Black,new RectangleF(550.0f,140.0f,100.0f,25.0f));
//   string line="";
//   line +='\n';
//   line +='\n';
//   	line +='\n'+"Наименование товара";
//   	line +='\t'+"Количество";
//   	line +='\t'+"Цена";
//   	line +='\t'+"Сумма";
   	int line_pos=0;
   	int line_height=25;
   	int first_line_pos=155;
   for (int i=0; i<dt.Rows.Count; i++) {
   		line_pos = (i+1)*line_height+first_line_pos;
   		if (i==0) {
   	g.DrawLine(Pens.Black,80,165,80,line_pos);	
   g.DrawLine(Pens.Black,650,165,650,line_pos);
     g.DrawLine(Pens.Black,330,165,330,line_pos);
     g.DrawLine(Pens.Black,470,165,470,line_pos);
     g.DrawLine(Pens.Black,540,165,540,line_pos);	
   		}
   	g.DrawLine(Pens.Black,80,line_pos,80,line_pos+25);	
   g.DrawLine(Pens.Black,650,line_pos,650,line_pos+25);
     g.DrawLine(Pens.Black,330,line_pos,330,line_pos+25);
     g.DrawLine(Pens.Black,470,line_pos,470,line_pos+25);
     g.DrawLine(Pens.Black,540,line_pos,540,line_pos+25);
     
  g.DrawLine(Pens.Black,80,line_pos+25,650,line_pos+25);
  
//g.DrawString(dt.Rows[i][0].ToString(),lineFont,Brushes.Black,102,line_pos);
//g.DrawString(dt.Rows[i][1].ToString(),lineFont,Brushes.Black,400,line_pos);
//g.DrawString(dt.Rows[i][2].ToString(),lineFont,Brushes.Black,482,line_pos);
//g.DrawString(dt.Rows[i][3].ToString(),lineFont,Brushes.Black,552,line_pos);

g.DrawString(dt.Rows[i][0].ToString(),lineFont,Brushes.Black
             ,new RectangleF (102.0f,line_pos,228.0f,line_height));
g.DrawString(dt.Rows[i][1].ToString(),lineFont,Brushes.Black
             ,new RectangleF(400.0f,line_pos,70.0f,line_height));
g.DrawString(dt.Rows[i][2].ToString(),lineFont,Brushes.Black
             ,new RectangleF(482.0f,line_pos,58.0f,line_height));
g.DrawString(dt.Rows[i][3].ToString(),lineFont,Brushes.Black
             ,new RectangleF(552,line_pos,98.0f,line_height));
//line +='\n'+dt.Rows[i][0].ToString();
//   	line +='\t'+dt.Rows[i][1].ToString();
//   	line +='\t'+dt.Rows[i][2].ToString();
//   	line +='\t'+dt.Rows[i][3].ToString();
   		
   }
   //	g.DrawString(line,lineFont,Brushes.Black,100,100);
   	
//   	line +='\n';
//   	
//   	
//   	line +='\n'+"Итого количество";
//   	line +='\t'+this.sell_bill.Total_quantity.ToString();
//   	line +='\t'+"Итого сумма ";
//   	line +='\t'+this.sell_bill.Total_sum.ToString();
//   	
//   	g.DrawString(line,lineFont,Brushes.Black,100,100);
line_pos +=50;
g.DrawString("Итого количество:",lineFont,Brushes.Black,200,line_pos);
g.DrawString(total_q,lineFont,Brushes.Black,400,line_pos);		
g.DrawString("Итого сумма:",lineFont,Brushes.Black,450,line_pos);
g.DrawString(total_sum,lineFont,Brushes.Black,600,line_pos);
		}
		
	}
}
