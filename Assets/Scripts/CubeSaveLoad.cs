using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System;

public class CubeSaveLoad : MonoBehaviour
{
    public GameObject prefab;

    public struct MyTransform
    {
        public Vector3 position;
        public Quaternion rotation;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Save();
        }

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Load();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Clear();
		}
	}
    public void Save()
    {
		var tranformList = new List<MyTransform>();
		var cubes = GameObject.FindGameObjectsWithTag("cube");
        foreach(var cube in cubes)
        {
            var temp = new MyTransform();
            temp.position = cube.transform.position;
            temp.rotation = cube.transform.rotation;
			tranformList.Add(temp);
		}

		var path = Path.Combine(Application.persistentDataPath, "cubes.json");  //저장 가능한 경로를 반환
		Debug.Log(path);

		var json = JsonConvert.SerializeObject(tranformList, new Vector3Converter(), new QuaternionConverter());
        Debug.Log(json);

        File.WriteAllText(path, json);
    }

    public void Clear()
    {
        var cubes = GameObject.FindGameObjectsWithTag("cube");
        foreach(var cube in cubes)
        {
            Destroy(cube);
        }
    }

    public void Load()
    {
		var path = Path.Combine(Application.persistentDataPath, "cubes.json");  //저장 가능한 경로를 반환
		var json = File.ReadAllText(path);
        var cubeList = JsonConvert.DeserializeObject<List<MyTransform>>(json, new Vector3Converter(), new QuaternionConverter());

        foreach (var cube in cubeList)
        {
            Instantiate(prefab, cube.position, cube.rotation);
        }

	}
}
