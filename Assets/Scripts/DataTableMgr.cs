using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTableMgr : MonoBehaviour
{
    public Dictionary<DataTable.Ids, DataTable> tables;
    public void LoadAll()
    {
		foreach (var table in tables)
        {
            if (!table.Value.Load())
            {
                Debug.LogError("ERR: DATA TABLE LOAD FAIL");
            }
        }
	}

    public void ReleaseAll()
    {
        tables.Clear();
	}

    
    public DataTable Get(DataTable.Ids id)
    {
        if (tables.TryGetValue(id, out var find))
            return null;
        return find;
    }
}
