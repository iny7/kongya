using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	GameObject curObject;

	MainLoop mainloop;

	float startX;
	float startY;
	float startZ;

//	bool flag = true;

	bool clickUseful = false;
	bool isChecking = false;

	// Use this for initialization
	void Start ()
	{
		mainloop = GetComponent ("MainLoop") as MainLoop;
	}

	void Update ()
	{
		if (Input.GetMouseButtonDown(0)) {

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				
				if (hit.collider != null) {
					curObject = hit.collider.gameObject;
					if (curObject == null) {
						return;
					}

					if (curObject.tag == "me" && mainloop.isMyTurn) {
						//点击有效
						clickUseful = true;
						//计算起始点坐标
						startX =curObject.transform.position.x;
						startY = curObject.transform.position.y;
						startZ = curObject.transform.position.z;
					}else if(curObject.tag == "enemy" && !mainloop.isMyTurn){
						//点击有效
						clickUseful = true;
						//计算起始点坐标
						startX =curObject.transform.position.x;
						startY = curObject.transform.position.y;
						startZ = curObject.transform.position.z;
					}
				}
			}
		}

		if(Input.GetMouseButtonUp(0) && clickUseful)
		{
			
			clickUseful = false;

			//获取鼠标位置
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				//计算释放点坐标
				float endX = hit.point.x;
				float endZ = hit.point.z;
				Vector3 ForceDir = new Vector3(startX - endX, 0, startZ - endZ);
				Rigidbody rb = curObject.GetComponent<Rigidbody> ();

//				rb.AddForce(ForceDir*5, ForceMode.Impulse);
				if(rb.mass == 3f){
					rb.AddForce(ForceDir*5, ForceMode.Impulse);	
				}else if(rb.mass == 1.3f){
					rb.AddForce(ForceDir*5, ForceMode.Impulse);
				}else{
					rb.AddForce(ForceDir*5, ForceMode.Impulse);
				}


				isChecking = true;
				//换顺序
				mainloop.isMyTurn = !mainloop.isMyTurn;
			}
		}
			
	}
}

