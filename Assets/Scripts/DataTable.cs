using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataTable : MonoBehaviour
{
	public enum  Ids
	{
		None = -1,
		String,
		Monster,
		Tile,
		Skill,
	};

	public Ids tableId = Ids.None;

	public abstract bool Load();
	public abstract bool Release();

}
