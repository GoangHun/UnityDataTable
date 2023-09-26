using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.IO;
using SaveDataVC = SaveDataV3;

public class StringElement
{
	public string ID { get; set; }
	public string KOREAN { get; set; }
}


public class Example : MonoBehaviour
{
	public TextAsset csvFile;
	public GameObject prefab;

	public void Start()
	{
		//var str = DataTableMGR.GetTable<StringTable>().GetString("YOU DIE");
		//Debug.Log(str);

		// var saveData = new SaveDataV1();
		//saveData.Gold = 100;

		//SaveLoadSystem.Save(saveData, "test1.json");

		

	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			var transforms = new List<MyTransform>();
			var cubes = GameObject.FindGameObjectsWithTag("Cube");
			foreach (var cube in cubes)
			{
				var temp = new MyTransform();
				temp.position = cube.transform.position;
				temp.rotation = cube.transform.rotation;
				temp.scale = cube.transform.localScale;
				transforms.Add(temp);
			}
			var data = new SaveDataV3();
			data.Gold = 0;
			data.Name = "";
			data.Transform = transforms;
			SaveLoadSystem.Save(data, "test1.json");
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			var data = SaveLoadSystem.Load("test1.json") as SaveDataVC;
			
			foreach (var cube in data.Transform)
			{
				Instantiate(prefab, cube.position, cube.rotation);
			}

			Debug.Log(data.Gold);
			Debug.Log(data.Name);
			Debug.Log(data.Transform);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			var cubes = GameObject.FindGameObjectsWithTag("Cube");
			foreach (var cube in cubes)
			{
				Destroy(cube);
			}
		}
	}
}



//public class StringElement
//{
//	public string ID { get; set; }
//	public string KOREAN { get; set; }
//}

//public class Example : MonoBehaviour
//{
//	public TextAsset csvFile;   //원시 텍스트 또는 이진 파일

//	public void Start()
//	{
//		//var str = DataTableMgr.GetTable<StringTable>().GetString("YOU DIE");
//		//Debug.Log(str);

//		//var saveData = new SaveDataV1();
//		//saveData.Gold = 100;

//		//SaveLoadSystem.Save(saveData, "test1.json");

//		var data = SaveLoadSystem.Load("test1.json") as SaveDataV1;
//		Debug.Log(data.Gold);
//	}
//}
