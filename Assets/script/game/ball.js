
// Use this for initialization

var bb : Transform;
//左侧LineRenderer
var LineL : LineRenderer;
//右侧LineRenderer
var LineR : LineRenderer;

function Start () {
	bb = GameObject.Find ("dangong").transform.FindChild ("ball").transform;
	LineL=GameObject.Find("dangong").transform.FindChild("ropeL").transform.GetComponent(LineRenderer);
	LineR=GameObject.Find("dangong").transform.FindChild("ropeR").transform.GetComponent(LineRenderer);
}


// Update is called once per frame
function Update () {
	var ray : Ray;
	var hitt : RaycastHit;
	var pos : Vector3;

	// 获得当前选中的对象
 
	if(Input.GetMouseButton(0))
 
   	{    
   		var rayy = Camera.main.ScreenPointToRay (Input.mousePosition);
        var hit : RaycastHit;    
   		if (Physics.Raycast (rayy, hit))     
   		{    
            Debug.DrawLine (rayy.origin, hit.point);    
         	curObject =  hit.collider.gameObject;
        	// 显示当前选中对象的名称
        	print(curObject);
  		}
   	}

	if(Input.GetMouseButton(0))
		{ //获取鼠标位置
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			Physics.Raycast(ray, hitt);
			//设置小球的位置
			pos = new Vector3(hitt.point.x, 0.5f, hitt.point.z);
			bb.position = pos;
			//重新设置LineRenderer的位置
			LineL.SetPosition(0,hitt.point);
			LineR.SetPosition(0,hitt.point);
		}
		if(Input.GetMouseButtonUp(0))
		{
			//获取鼠标位置
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			Physics.Raycast(ray, hitt);
			//设置小球的位置
			pos = new Vector3(hitt.point.x, 0.5f, hitt.point.z);
			bb.position = pos;
			//重新设置LineRenderer的位置
			LineL.SetPosition(0,hitt.point);
			LineR.SetPosition(0,hitt.point);

			//计算小球合力方向
			var Vec3L : Vector3 = new Vector3(-2F-hitt.point.x,0F,0F-hitt.point.z);
			var Vec3R : Vector3 = new Vector3(2F-hitt.point.x,0F,0F-hitt.point.z);
			var Dir : Vector3 =(Vec3L+Vec3R).normalized;
			print(Dir);
			//获取刚体结构
			bb.GetComponent(Rigidbody).useGravity=true;
			bb.GetComponent(Rigidbody).AddForce(Dir*10F,ForceMode.Impulse);
			//恢复LineRenderer
			LineL.SetPosition(0,new Vector3(0F,0F,0F));
			LineR.SetPosition(0,new Vector3(0F,0F,0F));
		}
}

