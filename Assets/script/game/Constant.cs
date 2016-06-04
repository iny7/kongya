using UnityEngine;
using System.Collections;

public class Constant : MonoBehaviour
{
	public static Vector3[] chessPos = {
		//big
		new Vector3 (0, 0.3f, -2.5f),
		//small
		new Vector3 (0, 0.2f, -1),
		new Vector3 (-2.7f, 0.2f, -1.5f),
		new Vector3 (2.7f, 0.2f, -1.5f),
		//mid
		new Vector3 (-2.6f, 0.2f, -3.5f),
		new Vector3 (-1.6f, 0.2f, -3.5f),
		new Vector3 (1.6f, 0.2f, -3.5f),
		new Vector3 (2.6f, 0.2f, -3.5f),
	};
	// Use this for initialization
	public static float BIG = 3f;
	public static float MIDDLE = 1.5f;
	public static float SMALL = 0.8f;
}

