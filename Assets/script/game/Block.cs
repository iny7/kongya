using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour
{

	void OnCollisionEnter(Collision collision) {

		if(collision.gameObject.tag != "me" && collision.gameObject.tag != "enemy"){
			return;
		}
			
		if (collision.relativeVelocity.magnitude > 2 && PlayerPrefs.GetInt ("offEffect") != 0)
			GetComponent<AudioSource>().Play();

	}
}

