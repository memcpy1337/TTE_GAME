using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Text;
using TTE_GAME.Classes;

namespace TTE_GAME.ExtraFunction
{
    public class MysqlQuerry
    {

        public void Execute_Insert(string[] rows, string[] values, string table, bool if_not_exist)
        {
            try
            {
                string sql_insert = "";
                if (if_not_exist == true)
                {
                    sql_insert = "INSERT IGNORE INTO " + table + " (";
                }
                else
                {
                    sql_insert = "INSERT INTO " + table + " (";
                }
                for (int i = 0; i < rows.Length; i++)
                {
                    sql_insert += rows[i];
                    if (i < rows.Length - 1)
                    {
                        sql_insert += ", ";
                    }
                }
                sql_insert += ") VALUES (";
                for (int i = 0; i < values.Length; i++)
                {
                    sql_insert += "@" + values[i] + "_" + i;
                    if (i < values.Length - 1)
                    {
                        sql_insert += ", ";
                    }
                }

                sql_insert += ")";
               
                MySqlConnection conn = new MySqlConnection(Variables_Static.conn);

                conn.OpenAsync();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = sql_insert;
                for (int i = 0; i < values.Length; i++)
                {
                    comm.Parameters.AddWithValue("@" + values[i] + "_" + i, values[i]);
                }
                Console.WriteLine(comm.ExecuteNonQueryAsync());

                // string sql_reg_acc = "INSERT INTO users (vkid, vkname) VALUES (@param_vkid, @param_vkname)";

                conn.CloseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void Execute_Update_Where(string[] rows, string[] values, string table, bool if_not_exist, bool where, string target_row, string value)
        {
            try
            {
                string sql_insert = "";
                if (if_not_exist == true)
                {
                    sql_insert = "UPDATE " + table + " SET ";
                }
                else
                {
                    sql_insert = "UPDATE " + table + " SET ";
                }
                for (int i = 0; i < rows.Length; i++)
                {
                    sql_insert += rows[i] + " = @" + values[i] + "_" + i;
                    if (i < rows.Length - 1)
                    {
                        sql_insert += ", ";
                    }
                }
               
                sql_insert += " WHERE " + target_row + " = @" + value;
              

                MySqlConnection conn = new MySqlConnection(Variables_Static.conn);

                conn.OpenAsync();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = sql_insert;
                for (int i = 0; i < values.Length; i++)
                {
                    comm.Parameters.AddWithValue("@" + values[i] + "_" + i, values[i]);
                }
                comm.Parameters.AddWithValue("@" + value, value);
                Console.WriteLine(comm.ExecuteNonQueryAsync());

                // string sql_reg_acc = "INSERT INTO users (vkid, vkname) VALUES (@param_vkid, @param_vkname)";

                conn.CloseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public string Execute_Select_One(string row, string values, string searching_value, string table)
        {
            try
            {
                string sql_insert = "SELECT " + row + " FROM " + table + " WHERE " + values + " = @" + searching_value;


                MySqlConnection conn = new MySqlConnection(Variables_Static.conn);

                conn.OpenAsync();
                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = sql_insert;
                comm.Parameters.AddWithValue("@" + searching_value, searching_value);

                var output = comm.ExecuteScalar();
                if (output == null)
                {
                    return "error";
                }
                if (output.ToString() == "")
                {
                    return "error";
                }
                // string sql_reg_acc = "INSERT INTO users (vkid, vkname) VALUES (@param_vkid, @param_vkname)";

                conn.CloseAsync();
                return output.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return "error";
            }

        }
        public List<string> Execute_Select_Multi(string[] row, string values, string searching_value, string table)
        {
            try
            {
                string sql_insert = "SELECT ";

                for (int i = 0; i < row.Length; i++)
                {
                    sql_insert += row[i];
                    if (i < row.Length - 1)
                    {
                        sql_insert += ", ";
                    }

                }
                sql_insert += " FROM " + table + " WHERE " + values + " = @" + searching_value;
                MySqlConnection conn = new MySqlConnection(Variables_Static.conn);

                conn.OpenAsync();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = sql_insert;
                comm.Parameters.AddWithValue("@" + searching_value, searching_value);
                MySqlDataReader reader = comm.ExecuteReader();
                
               
                List<string> res = new List<string>();
                
                while (reader.Read())
                {
                    for (int y = 0; y < row.Length; y++)
                    {
                        res.Add(reader[row[y]].ToString());
                    }
                  
                }
                reader.Close();
                conn.CloseAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return new List<string> { "error" };
        }

        public void Execute_Delete_One(string values, string searching_value, string table)
        {
            try
            {
                string sql_insert = "DELETE FROM " + table + " WHERE " + values + " = @" + searching_value;


                MySqlConnection conn = new MySqlConnection(Variables_Static.conn);

                conn.OpenAsync();
                MySqlCommand comm = conn.CreateCommand();

                comm.CommandText = sql_insert;
                comm.Parameters.AddWithValue("@" + searching_value, searching_value);

                var output = comm.ExecuteNonQuery();
                
                // string sql_reg_acc = "INSERT INTO users (vkid, vkname) VALUES (@param_vkid, @param_vkname)";

                conn.CloseAsync();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               
            }

        }
    }
}

