using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataTableMgr
{
	//Key�� System.Type�� ���
	private static Dictionary<System.Type, DataTable> tables = new Dictionary<System.Type, DataTable>();

    static DataTableMgr()
    {
		tables.Clear();

        var stringTable = new StringTable();
        tables.Add(typeof(StringTable), stringTable);
	}

    public static T GetTable<T>() where T : DataTable
    {
        var id = typeof(T);
        if (!tables.ContainsKey(id))
        {
            return null;
        }
        return tables[id] as T;
    }
}
