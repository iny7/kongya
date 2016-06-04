using UnityEngine;
using System.Collections;

/*
 * Mathf.Sqrt平方根 
	static function Sqrt (f : float) : float 
	计算并返回 f 的平方根。 

	Mathf.Pow次方 
	static function Pow (f : float, p : float): float 
	计算并返回 f 的 p 次方。
*/
public class AI : MonoBehaviour
{

	public void shoot(){
		GameObject[] chess = GameObject.FindGameObjectsWithTag("enemy");
		GameObject[] playerChess = GameObject.FindGameObjectsWithTag("me");
		int comLength = chess.Length;
		int playerLength = playerChess.Length;
		GameObject fromChess = chess[0];
		GameObject toChess = playerChess[0];
		float max = 0;
		//对电脑的每个棋子
		for (int i = 0; i < comLength; i++) {
			
			//都计算每个玩家棋子与其关系
			for (int j = 0; j < playerLength; j++) {
				//计算该情况权重
				float importance = getImportance (chess [i], playerChess [j]);
				//如果该权重大于当前最大权重
				if (importance > max) {
					//更新最大权重
					max = importance;
					//更新发射棋子
					fromChess = chess[i];
					//更新目标棋子
					toChess = playerChess [j];
				}
			}
		}
		print("AI shoot");

		Vector3 dir = getDirection (fromChess, toChess);
		float distance = getDistance (fromChess, toChess);
		distance = distance < 5f ? 5f : distance;
		//如果所有的都无法击中
		if (max == 0) {
			//随机选一个 小力气发射
			print("no can hit");
			float force = 2f;
			fromChess.GetComponent<Rigidbody>().AddForce(dir*force, ForceMode.Impulse);
		}else{

			Rigidbody rb = fromChess.GetComponent<Rigidbody> ();

			float force = distance > 15f ? 15f : distance;
			print (force);
			if(rb.mass == Constant.BIG){
				rb.AddForce(dir*force*5f, ForceMode.Impulse);	
			}else if(rb.mass == Constant.MIDDLE){
				rb.AddForce(dir*force / 2, ForceMode.Impulse);
			}else{
				print(dir*force);
				rb.AddForce(dir*force / 4, ForceMode.Impulse);
			}
		}


	}

	private Vector3 getDirection(GameObject from, GameObject to){
		Vector3 fromPos = from.transform.position;
		Vector3 toPos = to.transform.position;

		return toPos - fromPos;
	}

	private float getDistance(GameObject from, GameObject to){
		float deltaX = from.transform.position.x - to.transform.position.x;
		float deltaZ = from.transform.position.z - to.transform.position.z;
		float distance = Mathf.Sqrt (Mathf.Pow (deltaX, 2) + Mathf.Pow (deltaZ, 2));
		return distance;
	}

	private float getImportance(GameObject from, GameObject to){
		//需要考虑的因素
		//1.本棋子位置
		Vector3 fromPos = from.transform.position;
		//2.本棋子重量
		float fromMass = from.GetComponent<Rigidbody>().mass;
		//3.对方棋子位置
		Vector3 toPos = to.transform.position;
		//4.对方棋子重量
		float toMass = to.GetComponent<Rigidbody>().mass;
		//5.直接击中的目标
		float hitValue = getImportanceByHitObject(from, to);
		//权重系数
		int a = 10;
		int b = 10;
		int c = 50;
		int d = 50;
		return hitValue * 
			(a * getImportanceByPosition(fromPos)
				+ b * getImportanceByOtherPosition(toPos)
				+ c * getImportanceByMass(fromMass)
				+ d * getImportanceByOtherMass(toMass)
			);
	}

	//上平台大小 5 * 5
	//下平台大小 10 * 10
	private float getImportanceByPosition(Vector3 position){
		float value = 0;

		float x = position.x;
		float z = position.z;

		//距离棋盘中心距离
		float distance = Mathf.Sqrt (Mathf.Pow (x, 2) + Mathf.Pow (z, 2));
		//先判断在上平台还是下平台
		if (x > -5f && x < 5f) {
			//在上平台 高权重	
			value = 100 * distance;
		} else {
			//在下平台 低权重
			value += 5 * distance;;
		}
			
		return value;
	}

	private float getImportanceByOtherPosition(Vector3 position){
		float value = 0;

		float x = position.x;
		float z = position.z;

		//距离棋盘中心距离
		float distance = Mathf.Sqrt (Mathf.Pow (x, 2) + Mathf.Pow (z, 2));
		//先判断在上平台还是下平台
		if (x > -5f && x < 5f) {
			//在上平台 高权重	
			value = 5 * distance;
		} else {
			//在下平台 低权重
			value += 20 * distance;;
		}

		return value;
	}

	private float getImportanceByMass(float weight){
		float value;
		//电脑的大子
		if (weight == 2) {
			value = 100;
		//电脑的中子
		}else if(weight == 1.3f){
			value = 50;
		//电脑的小子
		}else{
			value = 1;
		}
		return value;
	}

	private float getImportanceByOtherMass(float weight){
		float value;
		//玩家的大子
		if (weight == 2) {
			value = 200;
		//玩家的中子
		}else if(weight == 1.3f){
			value = 100;
		//玩家的小子
		}else{
			value = 50;
		}
		return value;
	}

	//核心函数,判断能否击中
	private float getImportanceByHitObject(GameObject from, GameObject to){
		float value = 0;
		Vector3 fromPos= from.transform.position;
		Vector3 toPos = to.transform.position;
		Vector3 direction = toPos - fromPos;
		RaycastHit hit;
		GameObject hitObject;
		Ray ray = new Ray(fromPos, direction);
		if (Physics.Raycast (ray, out hit)) {

			if (hit.collider != null) {
				hitObject = hit.collider.gameObject;
				//如果能击中玩家棋子
				if (hitObject.tag == "me") {
					value = 1000;
				//如果能击中自己棋子
				} else if (hitObject.tag == "enemy") {
					value = 1;
				//其他情况(击中障碍物或击不中)
				} else {
					value = 0;
				}

			}
		}
		return value;
	}
    
}

