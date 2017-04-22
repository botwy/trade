/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 20.10.2016
 * Time: 11:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace trade
{
	/// <summary>
	/// Description of Validator.
	/// </summary>
	public class Validator
	{

public static bool TextBoxex<T>(TextBox textBox1
		                         ,TextBox textBox2
			                    ,out int int_text1
		                        ,out float float_text2) {
	      int_text1=0;
	      float_text2=0f;
	 bool val=true;
	 string msg1="";
	 string msg2="";
	 if (typeof(T).Equals(typeof(SellBill)) || typeof(T).Equals(typeof(BuyBill))) {
	 	msg1="В поле 'Количество' нужно ввести целое положительное число";
	 	msg2="В поле 'Цена' нужно ввести положительное число";
	 }
            if (string.IsNullOrEmpty(textBox1.Text) || !Int32.TryParse(textBox1.Text, out int_text1))
            {
            	textBox1.Text="0";
            	MessageBox.Show(msg1);
                val=false;
            }else{
				if (int_text1<0) {
            	textBox1.Text="0";	
				MessageBox.Show(msg1);
                val=false;	
				}
			}
    
            if (string.IsNullOrEmpty(textBox2.Text) || !float.TryParse(textBox2.Text, out float_text2))
            {
            	textBox2.Text="0";
            	MessageBox.Show(msg2);
               val = false;
            }else{
				if (float_text2<0) {
            	textBox2.Text="0";	
				MessageBox.Show(msg2);
                val=false;	
				}
			}
	 
	 
return val;          
		}
		
	public static bool TextBoxToFloat<T>(TextBox textBox
		                                ,out float float_text) {
	      
	      float_text=0f;
	 bool val=true;
	 string msg="";
	
	 if(typeof(T).Equals(typeof(Product))) {
	 	msg="В поле 'Цена' нужно ввести положительное число";
	 }
          
            if (string.IsNullOrEmpty(textBox.Text) || !float.TryParse(textBox.Text, out float_text))
            {
            	textBox.Text="0";
            	MessageBox.Show(msg);
               val = false;
            }else{
				if (float_text<0) {
            	textBox.Text="0";	
				MessageBox.Show(msg);
                val=false;	
				}
			}
	 
	 
return val;          
		}	

public static bool DgvCell<T>(string text, out int int_text) {
	int_text=0;
	 
	 bool val=true;
	 string msg="";
	
	 if (typeof(T).Equals(typeof(SellBill)) || typeof(T).Equals(typeof(BuyBill))) {
	 	msg="В поле 'Количество' нужно ввести положительное целое число";
	 	
	 }

			if (string.IsNullOrEmpty(text) || !Int32.TryParse(text, out int_text))
            {
            	MessageBox.Show(msg);
                val=false;
			}else{
				if (int_text<0) {
				MessageBox.Show(msg);
                val=false;	
				}
			}
			return val; 
		}
		
	
		
	}
}
