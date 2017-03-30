using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace M3Ueditor
{
    /// <summary>
    ///  DataTable with channel informations (group, audio language...)
    /// </summary>
    static class ChannelTable
    {
         private static  DataSet dataset = new DataSet("TransparentMenu");
         private static DataTable t = new DataTable("Menu");

         static ChannelTable() {
         
         DataColumn column;

             string tm_ip="Ip";
             string tm_chan = "Chan";
             string tm_name = "Name";
             string tm_group = "Group";
             string tm_audio = "Audio";
             string tm_fav = "Fav";
             string tm_skip = "Skip";
             string tm_logo = "Logo";
             string tm_locked = "Locked";
             
             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = tm_ip;
             column.DefaultValue = "";
             column.AllowDBNull = false;
             column.ReadOnly = false;
             column.Unique = true;
             t.Columns.Add(column);
             t.PrimaryKey = new DataColumn[] {column};
            
             column = new DataColumn();
             column.DataType = typeof(int);
             column.ColumnName = tm_chan;
             column.ReadOnly = false;
             column.Unique = false;
             column.DefaultValue = 0;
             t.Columns.Add(column);

             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = tm_name;
             column.DefaultValue = "";
             column.AllowDBNull = false;
             column.ReadOnly = false;
             column.Unique = false;
             t.Columns.Add(column);

             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = tm_group;
             column.ReadOnly = false;
             column.Unique = false;
             column.DefaultValue = "";
             column.AllowDBNull = false;
             t.Columns.Add(column);

             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = tm_audio;
             column.ReadOnly = false;
             column.Unique = false;
             column.DefaultValue = "";
             column.AllowDBNull = false;
             t.Columns.Add(column);
           
             column = new DataColumn();
             column.DataType = typeof(bool);
             column.ColumnName = tm_fav;
             column.ReadOnly = false;
             column.Unique = false;
             column.DefaultValue = false;
             column.AllowDBNull = false;
             t.Columns.Add(column);
            
             column = new DataColumn();
             column.DataType = typeof(bool);
             column.ColumnName = tm_skip;
             column.DefaultValue = false;
             column.ReadOnly = false;
             column.Unique = false;
             t.Columns.Add(column);

             column = new DataColumn();
             column.DataType = System.Type.GetType("System.String");
             column.ColumnName = tm_logo;
             column.ReadOnly = false;
             column.Unique = false;
             column.AllowDBNull = false;
             column.DefaultValue = "";
             t.Columns.Add(column);

             column = new DataColumn();
             column.DataType = typeof(bool);
             column.ColumnName = tm_locked;
             column.ReadOnly = false;
             column.Unique = false;
             column.DefaultValue = false;
             t.Columns.Add(column);
                   
             dataset.Tables.Add(t);

         }

         public static DataSet menu {
             get
             {
                 return dataset;
             }
             set
             {
                 dataset= value;
             }
        }
    }
}
