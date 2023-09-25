using System;
using System.Globalization;
using System.IO;
using UnityEngine;
using CsvHelper;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine.Profiling;

public class CubeDataTable : DataTable
{
	public DataTable.Ids TableId { get; private set; } = Ids.Cube;

	public struct MyTransform
	{
		public Vector3 position;
		public Quaternion rotation;
	}

	public MyTransform[] transforms;

	public override bool Load()
	{
		var path = Path.Combine(Application.persistentDataPath, "cubes.csv");  //���� ������ ��θ� ��ȯ

		using (var reader = new StreamReader(path))
		using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
		{
			var records = csv.GetRecords<MyTransform>();  //�����͸� ����
			foreach (var record in records)
			{
				Debug.Log(record.position);
				Debug.Log(record.rotation);
				
			}
            return true;
        }
	}

	public override bool Release()
	{
		throw new System.NotImplementedException();
	}

    public override void Save()
    {
        var tranformList = new List<MyTransform>();
        var cubes = GameObject.FindGameObjectsWithTag("Cube");
        foreach (var cube in cubes)
        {
            var temp = new MyTransform();
            temp.position = cube.transform.position;
            temp.rotation = cube.transform.rotation;
            tranformList.Add(temp);
        }

        var path = Path.Combine(Application.persistentDataPath, "cubes.csv");  //���� ������ ��θ� ��ȯ
        Debug.Log(path);

        using (var writer = new StreamWriter(path))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecord(tranformList);
        }
    }
}
