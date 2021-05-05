using Mono.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class DatabaseAccess
{
    private readonly string PATH = "URI=file:" + Application.persistentDataPath + "/" + "City_Game_Database.db";

    private IDbConnection connection;
    private IDbCommand command;
    private IDataReader reader;

    public DatabaseAccess()
    {

    }

    public void Connect()
    {
        connection = new SqliteConnection(PATH);
        connection.Open();
    }

    public void Disconnect()
    {
        connection.Close();
        command = null;
        reader = null;
    }

    public void GetWhoSchuylerLoves()
    {
        List<DBItem> items = new List<DBItem>();
        DBItem item;

        var query = "SELECT *,  " +
            "FROM items ";

        command = connection.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();
    }

    public DBItem[] GetItemsFromDataBase()
    {
        List<DBItem> items = new List<DBItem>();
        DBItem item;

        var query = "SELECT id, itemName " +
            "FROM items ";

        command = connection.CreateCommand();
        command.CommandText = query;
        reader = command.ExecuteReader();

        while (reader.Read())
        {
            item = new DBItem(Int32.Parse(reader[0].ToString()), reader[1].ToString());
            items.Add(item);
        }

        return items.ToArray();

    }

}
