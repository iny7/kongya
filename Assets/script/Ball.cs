using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	//左侧LineRenderer
	private LineRenderer LineL;
	//右侧LineRenderer
	private LineRenderer LineR;
	private Transform bb;
	RaycastHit hitt;  
	void Start ()
	{
		//获取LineRenderer
		LineL=GameObject.Find("dangong").transform.FindChild("ropeL").
			transform.GetComponent<LineRenderer>();
		LineR=GameObject.Find("dangong").transform.FindChild("ropeR").
			transform.GetComponent<LineRenderer>();
		bb = GameObject.Find ("dangong").transform.FindChild ("ball").transform;
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetMouseButton(0))
		{ //获取鼠标位置
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
			Physics.Raycast(ray, out hitt);
			//设置小球的位置
			Vector3 pos = new Vector3(hitt.point.x, 0, hitt.point.z);
			bb.position = pos;
			//重新设置LineRenderer的位置
			LineL.SetPosition(0,hitt.point);
			LineR.SetPosition(0,hitt.point);
		}
		if(Input.GetMouseButtonUp(0))
		{
			//获取鼠标位置
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Physics.Raycast(ray, out hitt);
			//设置小球的位置
			Vector3 pos = new Vector3(hitt.point.x, 0, hitt.point.z);
			bb.position = pos;
			//重新设置LineRenderer的位置
			LineL.SetPosition(0,hitt.point);
			LineR.SetPosition(0,hitt.point);

			//计算小球合力方向
			Vector3 Vec3L=new Vector3(-2F-hitt.point.x,0F,0F-hitt.point.z);
			Vector3 Vec3R=new Vector3(2F-hitt.point.x,0F,0F-hitt.point.z);
			Vector3 Dir=(Vec3L+Vec3R).normalized;
			print (Dir);
			//获取刚体结构
			bb.GetComponent<Rigidbody>().useGravity=true;
			bb.GetComponent<Rigidbody>().AddForce(Dir*10F,ForceMode.Impulse);
			//恢复LineRenderer
			LineL.SetPosition(0,new Vector3(0F,0F,0F));
			LineR.SetPosition(0,new Vector3(0F,0F,0F));
		}
	
	}

}