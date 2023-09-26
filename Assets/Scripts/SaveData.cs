using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct MyTransform
{
	public Vector3 position;
	public Quaternion rotation;
	public Vector3 scale;
}

public abstract class SaveData
{
	public int Version { get; set; }

	public abstract SaveData VersionUp();

}

public class SaveDataV1 : SaveData
{
	public SaveDataV1()
	{
		Version = 1;
	}

	public int Gold { get; set; }

	public override SaveData VersionUp()
	{
		var data = new SaveDataV2();
		data.Gold = Gold;
		return data;
	}
}

public class SaveDataV2 : SaveData//새버전 나올때마다 추가
{
	public SaveDataV2()
	{
		Version = 2;
	}

	public int Gold { get; set; }
	public string Name { get; set; } = "Unknown";

	public override SaveData VersionUp()
	{
		var data = new SaveDataV3();
		data.Gold = Gold;
		data.Name = Name;
		return data;
	}
}

public class SaveDataV3 : SaveData  //새버전 나올때마다 추가
{
	public SaveDataV3()
	{
		Version = 3;
	}

	public int Gold { get; set; }
	public string Name { get; set; }
	public List<MyTransform> Transform { get; set; }

	//public List<Transform> Transform { get; set; }


	public override SaveData VersionUp()
	{
		return null;
	}
}


//public abstract class SaveData
//{
//    public int Version { get; set; }

//    public abstract SaveData VersionUp();

//}

//public class SaveDataV1 : SaveData
//{
//	public SaveDataV1() 
//	{ 
//		Version = 1;
//	}

//	public int Gold { get; set; }
//	public override SaveData VersionUp()
//	{
//		var data = new SaveDataV1();
//		data.Gold = Gold;
//		return data;
//	}
//}


//public class SaveDataV2 : SaveData
//{
//	public SaveDataV2()
//	{
//		Version = 2;
//	}

//	public int Gold { get; set; }
//	public string Name { get; set; } = "Unknown";

//	public override SaveData VersionUp()
//	{
//		return null;
//	}
//}
