using System;
using System.Globalization;
using System.IO;
using UnityEngine;
using CsvHelper;

public class CubeDataTable : DataTable
{
	public struct MyTransform
	{
		public Vector3 position;
		public Quaternion rotation;
	}

	public MyTransform[] transforms;

	public override bool Load()
	{
		var path = Path.Combine(Application.persistentDataPath, "cubes.csv");  //���� ������ ��θ� ��ȯ
		//var csv = File.ReadAllText(path);

		using (var reader = new StreamReader(path))
		using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
		{
			var records = csv.GetRecords<MyTransform>();  //�����͸� ����
			foreach (var record in records)
			{
				Debug.Log(record.position);
				Debug.Log(record.rotation);
			}
		}
		return true;
	}

	public override bool Release()
	{
		throw new System.NotImplementedException();
	}
}
