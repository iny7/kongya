using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour
{

	void OnCollisionEnter(Collision collision) {
		
//		print (collision.gameObject.name);

		//在这个位置根据tag做死亡统计

		Destroy(collision.gameObject);

		if (collision.relativeVelocity.magnitude > 2 && PlayerPrefs.GetInt ("offEffect") != 0)
			GetComponent<AudioSource>().Play();

	}
}

