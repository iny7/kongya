using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt("offMusic") != 0)
		{
			//���ű�������
			GetComponent<AudioSource>().Pause();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
