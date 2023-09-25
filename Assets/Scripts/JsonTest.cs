using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class MyClass
{
	public string myClassname;
}

[System.Serializable]
public class MyClass2 : MyClass
{
	public string myClassname2 = "2";
}

[System.Serializable]
public class PlayerInfo
{
	public string name;
	public int lives;
	public float health;

	public MyClass2 myClass2;
	public MyClass myClass;

	public int[] array;
	public Hashtable ht;

	public Vector3 position;

	// Given JSON input:
	// {"name":"Dr Charles","lives":3,"health":0.8}
	// this example will return a PlayerInfo object with
	// name == "Dr Charles", lives == 3, and health == 0.8f.
}

public class JsonTest : MonoBehaviour
{
    // Start is called before the first frame update
    /*void Start()
    {
		var info = new PlayerInfo();

		info.name = "Dr Charles";
		info.lives = 3;
		info.health = 3.2f;
		info.myClass = new MyClass2();
		info.myClass.myClassname = "test";

		info.array = new int[3] { 1, 2, 3 };
		info.ht = new Hashtable();
		info.ht.Add("key1", "value1");

		info.position = new Vector3(1, 2, 3);

		var json = JsonConvert.SerializeObject(info, new Vector3Converter());
		Debug.Log(json);

		//string jsonString = @"{""name"":""Dr Charles"",""lives"":3,""health"":0.8, ""array"": [1, 2, 3]}";
		//var info = PlayerInfo.CreateFromJSON(jsonString);

		//Debug.Log(info.name);
		//Debug.Log(info.lives);
		//Debug.Log(info.health);

		//foreach (var a in info.array)
		//{
		//	Debug.Log(a);
		//}

		//info.name = "Dr Charles Jr !!!";
		//info.lives = 0;
		//info.health = 0.9f;

		//jsonString = info.SaveToString();
		//Debug.Log(jsonString);
	}*/



}
