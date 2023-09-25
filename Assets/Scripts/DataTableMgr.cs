using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTableMgr : MonoBehaviour
{
    private Dictionary<DataTable.Ids, DataTable> tablesDictionary = new Dictionary<DataTable.Ids, DataTable>();

    private void Awake()
    {
        var table = new CubeDataTable();
        tablesDictionary.Add(table.tableId, table);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach(var table in tablesDictionary.Values)
            {
                table.Save();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (var table in tablesDictionary.Values)
            {
                table.Load();
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //Clear();
        }
    }

    public void LoadAll()
    {
		foreach (var table in tablesDictionary)
        {
            if (!table.Value.Load())
            {
                Debug.LogError("ERR: DATA TABLE LOAD FAIL");
            }
        }
	}

    public void ReleaseAll()
    {
        //tables.Clear();
	}

    
    //public DataTable Get(DataTable.Ids id)
    //{
    //    if (tables.TryGetValue(id, out var find))
    //        return null;
    //    return find;
    //}
}
