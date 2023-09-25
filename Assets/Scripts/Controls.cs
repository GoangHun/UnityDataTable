using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    public Button button;
    public Toggle toggle1;
	public Toggle toggle2;
    public InputField inputField;
    public Slider slider;

	public GameObject prefab;
	public RectTransform content;

	private void Start()
	{
		button.onClick.AddListener(() => Debug.Log("Clicked"));
	}
	public void OnClikButton()
	{
		Instantiate(prefab, content);
	}

	public void OnClickToggle1(bool value)
	{
		Debug.Log(value);
	}

	public void OnClickToggle2(bool value)
	{
		Debug.Log(value);

	}

	public void OnEndEdit(string input)
	{
		Debug.Log(input);
	}

	public void OnSlider(float value)
	{
		Debug.Log(value);
	}
}
