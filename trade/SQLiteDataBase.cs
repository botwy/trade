/*
 * Created by SharpDevelop.
 * User: Гончаров Денис
 * Date: 04.10.2016
 * Time: 13:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data.Common;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Collections.Generic;

namespace trade
{
	/// <summary>
	/// Description of SQLiteDataBase.
	/// </summary>
	public class SQLiteDataBase
	{
		public static string GetDataBase() {
		string databaseName = Config.database;
       // SQLiteConnection.CreateFile(databaseName);
       if (!File.Exists(databaseName)) SQLiteConnection.CreateFile(databaseName);
       // MessageBox.Show(File.Exists(databaseName) ? "База данных создана" : "Возникла ошиюка при создании базы данных");
		return databaseName;
		}
		
		public static SQLiteConnection ConnectDB() {
			string databaseName=GetDataBase();
			 SQLiteConnection connection = 
            new SQLiteConnection(string.Format("Data Source={0};", databaseName));
		return connection;
		}

		public static void CreateTable(string tableName) {
			SQLiteCommand command;
			SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
			switch (tableName) {
				case "product":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS product (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                  ", title TEXT" +
		    	                 ", quantity INTEGER" +
		    	                 ", price_buy REAL" +
		    	                ", barcode TEXT" +
		    	               ");", connection);
            command.ExecuteNonQuery();
            break;
            
            case "partner":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS partner (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                  ", title TEXT" +
		    	                 ", phone TEXT" +
		    	                 ", e_mail TEXT" +
		    	                 ", markup_type_id INTEGER" +
		    	                ");", connection);
            command.ExecuteNonQuery();
            
            break;
            
             case "buybill":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS buybill (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                  ", number INTEGER" +
		    	                  ", date TEXT" +
		    	                 ", total_quantity INTEGER" +
		    	                 ", total_sum REAL" +
		    	                 ", storage_id INTEGER" +
		    	                 ", provider_id INTEGER);", connection);
            command.ExecuteNonQuery();
            
            break;
            
             case "rows_in_buybill":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS rows_in_buybill (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                  ", buybill_id INTEGER" +
		    	                  ", product_id INTEGER" +
		    	                 ", quantity INTEGER" +
		    	                 ", price REAL" +
		    	                 ", sum REAL" +
		    	                 ");", connection);
            command.ExecuteNonQuery();
            
            break;
            
            case "sellbill":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS sellbill (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                  ", number INTEGER" +
		    	                  ", date TEXT" +
		    	                 ", total_quantity INTEGER" +
		    	                 ", total_sum REAL" +
		    	                 ", storage_id INTEGER" +
		    	                 ", consumer_id INTEGER);", connection);
            command.ExecuteNonQuery();
            
            break;
            
             case "rows_in_sellbill":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS rows_in_sellbill (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                  ", sellbill_id INTEGER" +
		    	                  ", product_id INTEGER" +
		    	                 ", quantity INTEGER" +
		    	                 ", price REAL" +
		    	                 ", sum REAL);", connection);
            command.ExecuteNonQuery();
            
            break;
            
             case "trade_operation":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS trade_operation (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                  ", date TEXT" +
		    	                   ", doc_number INTEGER" +
		    	                  ", doc_type TEXT" +
		    	                 ", doc_id INTEGER" +
		    	                 ", prod_id INTEGER" +
		    	                  ", storage_id INTEGER" +
		    	                 ", quantity INTEGER" +
		    	                 ", price REAL" +
		    	                 ", sum REAL" +
		    	                 ", price_buy REAL" +
		    	                 ", profit REAL" +
		    	                 ", partner_id INTEGER);", connection);
            command.ExecuteNonQuery();
            
            break;
			
             case "quantity_report":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS quantity_report (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                ", date TEXT" +
		    	                ", doc_number INTEGER" +
		    	                  ", doc_type TEXT" +
		    	                 ", doc_id INTEGER" +
		    	                 ", prod_id INTEGER" +
		    	                 ", storage_id INTEGER" +
		    	                 ", income INTEGER" +
		    	                 ", outgo INTEGER" +
		    	                 ", stock_quantity INTEGER" +
		    	                 ", price_buy REAL);", connection);
            command.ExecuteNonQuery();
            
            break;
            
               case "storage":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS storage (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                ", title TEXT);", connection);
            command.ExecuteNonQuery();
            
            break;
			
             case "prodqty_storage":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS prodqty_storage (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                ", prod_id INTEGER" +
		    	                  ", storage_id INTEGER" +
		    	                  ", quantity INTEGER);", connection);
            command.ExecuteNonQuery();
            
            break;
            
            case "markup_type":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS markup_type (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                ", title TEXT" +
		    	                  ", basic_percent REAL);", connection);
            command.ExecuteNonQuery();
            
            break;
            
             case "prod_markup":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS prod_markup (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                ", prod_id INTEGER" +
		    	                  ", markup_type_id INTEGER" +
		    	                  ", fix_price REAL);", connection);
            command.ExecuteNonQuery();
            
            break;
            
             case "partner_markuptoprod":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS partner_markuptoprod (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                ", partner_id INTEGER" +
		    	                  ", markup_type_id INTEGER" +
		    	                  ", percent REAL);", connection);
            command.ExecuteNonQuery();
            
            break;
            
             case "partner_markup_correct":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS partner_markup_correct (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                ", partner_id INTEGER" +
		    	                  ", markup_type_id INTEGER" +
		    	                  ", begin_number REAL" +
		    	                  ", end_number REAL" +
		    	                  ", percent REAL" +
		    	                  ", fix_price REAL);", connection);
            command.ExecuteNonQuery();
            
            break;
            
            case "partner_round_correct":
		    command =
               new SQLiteCommand("CREATE TABLE IF NOT EXISTS partner_round_correct (" +
		    	                  "id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT" +
		    	                ", partner_id INTEGER" +
		    	                  ", markup_type_id INTEGER" +
		    	                  ", begin_number REAL" +
		    	                  ", end_number REAL" +
		    	                  ", round_result REAL);", connection);
            command.ExecuteNonQuery();
            
            break;
			}
			 
			 
			
       // MessageBox.Show(status.ToString());
        connection.Close();
		}
		
		public static void Execute(string textCommand) {
			SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
		SQLiteCommand command = new SQLiteCommand(textCommand, connection);
            command.ExecuteNonQuery();
            connection.Close();
		}
		
		public static void ShowAllRows(string table) {
			SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
		SQLiteCommand command = new SQLiteCommand(
			 	"SELECT * FROM "+table+";", connection);
			 SQLiteDataReader reader=command.ExecuteReader();
			 foreach (DbDataRecord record in reader) 
			 	MessageBox.Show(record[0].ToString()+'\t'
			 	                +record[1].ToString()+'\t'
			 	                +record[2].ToString()+'\t'
			 	                +record[3].ToString()+'\n');
			 	                
            connection.Close();
		}
		
		public static DbDataRecord GetRecordByTitle(string title, string table) {
		 SQLiteDataReader reader;
		 DbDataRecord record=null;
		 
		 SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
		SQLiteCommand command = new SQLiteCommand(
		"SELECT * FROM "+table+" where title='"+title+"';", connection);
			
		  reader=command.ExecuteReader();
		  foreach (DbDataRecord rec in reader) record=rec;
		 connection.Close();
		 return record;
		}
		
public static DbDataRecord GetRecordById(string id, string table) {
		 SQLiteDataReader reader;
		 DbDataRecord record=null;
		 
		 SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
		SQLiteCommand command = new SQLiteCommand(
		"SELECT * FROM "+table+" where id='"+id+"';", connection);
			
		  reader=command.ExecuteReader();
		  foreach (DbDataRecord rec in reader) record=rec;
		 connection.Close();
		 return record;
		}
		
public static DbDataRecord GetRecordByBarcode(string barcode, string table) {
		 SQLiteDataReader reader;
		 DbDataRecord record=null;
		 
		 SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
		SQLiteCommand command = new SQLiteCommand(
		"SELECT * FROM "+table+" where barcode='"+barcode+"';", connection);
			
		  reader=command.ExecuteReader();
		  foreach (DbDataRecord rec in reader) record=rec;
		 connection.Close();
		 return record;
		}		
		
		public static int GetMaxValueOfColumn(string column, string table) {
		 SQLiteDataReader reader;
		 DbDataRecord record=null;
		 int val=0;
		 SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
			 
		//	 MessageBox.Show("SELECT max("+column+") FROM "+table+";");
		
		// !!! column must be INTEGER
		SQLiteCommand command = new SQLiteCommand(
		"SELECT max("+column+") FROM "+table+";"
		//"SELECT * FROM "+table+";"
		, connection);
			
		  reader=command.ExecuteReader();
		 // string text="";
		  
		  foreach (DbDataRecord rec in reader) {
		  	record=rec;
		  //	int curr=int.Parse(rec[0].ToString());
		  //	if (curr>val) val=curr;
		  //	for (int i=0; i<record.FieldCount; i++) text +=record[i].ToString()+" ";
		  //	text +='\n';
		  }
		
		  // MessageBox.Show(text);
		  	 
		//  MessageBox.Show(record[0].ToString());
		if ((record[0]!=null)&&(record[0].ToString()!="")) val=int.Parse(record[0].ToString());
	connection.Close();
	 //MessageBox.Show("max "+column+" in table "+table+"="+val);
	return val;
		}

public static void UpdateRecordByTitle(string[] columns
		                                       , string[] values, string title, string table) {
   SQLiteConnection connection=SQLiteDataBase.ConnectDB();
	 connection.Open();
	 string commandText="UPDATE "+table+" SET ";
	 for (int i=0; i<columns.Length; i++) {
	 	if (i!=0) commandText +=", ";
	 	commandText +=columns[i]+"='"+values[i]+"'";
	 }
	 commandText +=" where title='"+title+"';";
	// MessageBox.Show(commandText);
	SQLiteCommand command = new SQLiteCommand(commandText, connection);
	command.ExecuteNonQuery();	
	  connection.Close();
		}
		
public static void UpdateRecordById(string[] columns
		                                       , string[] values, string id, string table) {
   SQLiteConnection connection=SQLiteDataBase.ConnectDB();
	 connection.Open();
	 string commandText="UPDATE "+table+" SET ";
	 for (int i=0; i<columns.Length; i++) {
	 	if (i!=0) commandText +=", ";
	 	commandText +=columns[i]+"='"+values[i]+"'";
	 }
	 commandText +=" where id='"+id+"';";
	// MessageBox.Show(commandText);
	SQLiteCommand command = new SQLiteCommand(commandText, connection);
	command.ExecuteNonQuery();	
	  connection.Close();
		}		
		
public static List<DbDataRecord> GetAllRows(string table) {
			SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
		SQLiteCommand command = new SQLiteCommand(
			 	"SELECT * FROM "+table+";", connection);
			 SQLiteDataReader reader=command.ExecuteReader();
			 
			 List<DbDataRecord> list_rec=new List<DbDataRecord>();
			 
			 foreach (DbDataRecord record in reader) 
			 	list_rec.Add(record);
			 	                
            connection.Close();
            
            return list_rec;
		}	
		

public static List<DbDataRecord> GetAllRowsByColsValues(string[] columns, string[] values, string table) {
			SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
			 string commandText="SELECT * FROM "+table;
			 if (columns.Length>0) {
			 	commandText +=" where ";
			 for (int i=0; i<columns.Length; i++) {
			 		if (i==0) commandText +=columns[i]+"='"+values[i]+"'";
			 		else
			 	commandText +=" and "+columns[i]+"='"+values[i]+"'";
			 }
			 	commandText +=";";
			 }
		SQLiteCommand command = new SQLiteCommand(commandText, connection);
			 SQLiteDataReader reader=command.ExecuteReader();
			 
			 List<DbDataRecord> list_rec=new List<DbDataRecord>();
			 
			 foreach (DbDataRecord record in reader) 
			 	list_rec.Add(record);
			 	                
            connection.Close();
            
            return list_rec;
		}	

	
		
public static int AddOneRecord(string[] columns
		                                       , string[] values
		                                       , string table) {
   int val=0;
	SQLiteConnection connection=SQLiteDataBase.ConnectDB();
	 connection.Open();
	 string commandText="INSERT INTO "+table+" (";
	 for (int i=0; i<columns.Length; i++) {
	 	if (i!=0) commandText +=", ";
	 	
	 	commandText +=columns[i];
	 }
	 commandText +=" ) VALUES (";
	 for (int i=0; i<columns.Length; i++) {
	 	if (i!=0) commandText +=", ";
	 	          
	 	commandText +="'"+values[i]+"'";
	 	
	 }
	  commandText +=");";
	  
	// MessageBox.Show(commandText);
	SQLiteCommand command = new SQLiteCommand(commandText, connection);
	command.ExecuteNonQuery();
	//MessageBox.Show("select seq from sqlite_sequence where name='"+table+"'");
	SQLiteCommand command_2 = new SQLiteCommand("select seq from sqlite_sequence where name='"+table+"';", connection);
	DbDataRecord record=null;
	  SQLiteDataReader reader=command_2.ExecuteReader();
		  foreach (DbDataRecord rec in reader) record=rec;
		  if (record["seq"]!=null) val=int.Parse(record["seq"].ToString());
	connection.Close();
	// MessageBox.Show("max id in table buybill="+val);
	return val;
		}
		
public static void AddManyRecords(string[,] rows
		                                       , string table) {
   SQLiteConnection connection=SQLiteDataBase.ConnectDB();
	 connection.Open();
//	 foreach (string[][] row in rows) {
	 	//string[] columns=row[0];
	 	//string[] values=row[1];
	 
	 
	 //int n=1; со второй строки, т. к. первая строка это заголовки
	 for (int n=1; n<rows.GetLength(0); n++) {
	 	string commandText="INSERT INTO "+table+" (";
	      for (int i=0; i<rows.GetLength(1); i++) {
	 	if (i!=0) commandText +=", ";
	 	
	 	commandText +=rows[0,i];
	       }
	 commandText +=" ) VALUES (";
	 	for (int i=0; i<rows.GetLength(1); i++) {
	 	if (i!=0) commandText +=", ";
	 	          
	 	commandText +="'"+rows[n,i]+"'";
	 	}
	 commandText +=");";
	  
	 //MessageBox.Show(commandText);
	SQLiteCommand command = new SQLiteCommand(commandText, connection);
	command.ExecuteNonQuery();
	 }
	  
	// }
	  connection.Close();
		}
		
public static void DeleteAllRowsByColsValues (string[] columns, string[] values, string table) {
	 SQLiteConnection connection=SQLiteDataBase.ConnectDB();
			 connection.Open();
			 string commandText="DELETE FROM "+table;
			 if (columns.Length>0) {
			 	commandText +=" where ";
			 for (int i=0; i<columns.Length; i++) {
			 		if (i==0) commandText +=columns[i]+"='"+values[i]+"'";
			 		else
			 	commandText +=" and "+columns[i]+"='"+values[i]+"'";
			 }
			 	commandText +=";";
			 }
		SQLiteCommand command = new SQLiteCommand(commandText, connection);
			 SQLiteDataReader reader=command.ExecuteReader();
			 
			 			 	                
            connection.Close();
		}	
		
	}
}
