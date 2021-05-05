using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class DBConnector : MonoBehaviour
{
    DatabaseAccess dataBaseAccess;

    [SerializeField] private DBItem[] items;

    void Start()
    {
        dataBaseAccess = new DatabaseAccess();
        dataBaseAccess.Connect();
        items =  dataBaseAccess.GetItemsFromDataBase();
        dataBaseAccess.Disconnect();
    }

}


[System.Serializable]
public class DBItem
{
    public DBItem(int id, string itemName)
    {
        this.id = id;
        this.itemName = itemName;
    }

    [SerializeField] private int id;
    [SerializeField] private string itemName;
}
