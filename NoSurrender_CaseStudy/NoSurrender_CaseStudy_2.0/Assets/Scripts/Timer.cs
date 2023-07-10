using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public float startTime = 30;
	public Text textBox;

	// Use this for initialization
	void Start()
	{
		textBox.text = startTime.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		startTime -= Time.deltaTime;
		textBox.text = Mathf.Round(startTime).ToString();
	}

}