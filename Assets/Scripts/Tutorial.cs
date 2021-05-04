using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
	[SerializeField] private GameObject pauseMessage;

	private void Start()
	{
		pauseMessage.SetActive(false);
		StartCoroutine("pause");
	}

	private void Update()
	{
		/*
		if (Input.GetKeyDown(KeyCode.P))
		{
			if (!pauseMessage.activeInHierarchy)
			{
				Time.timeScale = 0;
				pauseMessage.SetActive(true);
			}
			if (pauseMessage.activeInHierarchy)
			{
				Time.timeScale = 1;
				pauseMessage.SetActive(false);
			}
		}
		*/
	}

	IEnumerator pause()
	{
		pauseMessage.GetComponent<Text>().text = "press rt to shoot";
		pauseMessage.SetActive(true);
		Time.timeScale = 0;

		yield return new WaitForSecondsRealtime(5.0f);

		pauseMessage.SetActive(false);
		Time.timeScale = 1;
	}
}
