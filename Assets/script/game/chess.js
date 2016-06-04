
// Use this for initialization


var curObject : GameObject;

var startX : float;
var startY : float;
var startZ : float;


//左侧LineRenderer
var LineL : LineRenderer;
//右侧LineRenderer
var LineR : LineRenderer;

var flag = true;
var clickUseful = false;


// Update is called once per frame
function Update () {
	var ray : Ray;
	var hitt : RaycastHit;
	var pos : Vector3;


	if(Input.GetMouseButton(0))
	{ //获取鼠标位置
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(flag && Physics.Raycast(ray, hitt)){
			flag = false;
			//找到点击的物体
			curObject =  hitt.collider.gameObject;
			if(curObject.tag != 'chess'){
				flag = true;
				return;
			}
			clickUseful = true;

			//计算起始点坐标
			startX =curObject.transform.position.x;
			startY = curObject.transform.position.y;
			startZ = curObject.transform.position.z;
		}

//			bb.position = pos;
//			//重新设置LineRenderer的位置
//			LineL.SetPosition(0,hitt.point);
//			LineR.SetPosition(0,hitt.point);
	}
	if(Input.GetMouseButtonUp(0) && clickUseful)
	{
		clickUseful = false;
		print('realize');
		//获取鼠标位置
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Physics.Raycast(ray, hitt);

		//计算释放点坐标
		var endX = hitt.point.x;
		var endZ = hitt.point.z;
//		print(startX - endX, 0, startZ - endZ);
		var ForceDir : Vector3 = new Vector3(startX - endX, 0, startZ - endZ);

		var rb = curObject.GetComponent(Rigidbody);
		rb.AddForce(ForceDir*3, ForceMode.Impulse);
		flag = true;
//			//重新设置LineRenderer的位置
//			LineL.SetPosition(0,hitt.point);
//			LineR.SetPosition(0,hitt.point);
//
//			//计算小球合力方向
//			var Vec3L : Vector3 = new Vector3(-2F-hitt.point.x,0F,0F-hitt.point.z);
//			var Vec3R : Vector3 = new Vector3(2F-hitt.point.x,0F,0F-hitt.point.z);
//			var Dir : Vector3 =(Vec3L+Vec3R).normalized;
//			print(Dir);
//			//获取刚体结构
//			bb.GetComponent(Rigidbody).useGravity=true;
//			bb.GetComponent(Rigidbody).AddForce(Dir*10F,ForceMode.Impulse);
//			//恢复LineRenderer
//			LineL.SetPosition(0,new Vector3(0F,0F,0F));
//			LineR.SetPosition(0,new Vector3(0F,0F,0F));
	}
}

