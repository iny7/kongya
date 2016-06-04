using UnityEngine;
using System.Collections;

public class ChessUtil : MonoBehaviour
{
	public GameObject board;
	public GameObject me;
	public GameObject enemy;
	public Vector3[] chessPos = Constant.chessPos;


	public void initAllChess(){
		
		board = GameObject.Find ("platform-2");

		//我方
		for(int i = 0 ; i < chessPos.Length ; i ++){
			GameObject chess = Instantiate(me);
			chess.transform.position = chessPos[i];
			 
			Rigidbody rb = chess.GetComponent<Rigidbody>();
			//big
			if(i == 0){
				chess.transform.localScale = new Vector3(1.2f, 0.3f, 1.2f);
				rb.mass = Constant.BIG;

			//small
			}else if(i > 0 && i < 4){
				chess.transform.localScale = new Vector3(0.6f, 0.2f, 0.6f);
				rb.mass = Constant.SMALL;

			//middle
			}else{
				chess.transform.localScale = new Vector3(0.8f, 0.2f, 0.8f);
				rb.mass = Constant.MIDDLE;
			}
		}

		//敌方
		for(int i = 0 ; i < chessPos.Length ; i ++){
			GameObject chess = Instantiate(enemy);
			chess.transform.position = -chessPos[i];
			//			chess.transform.SetParent(board.transform, false);

			Rigidbody rb = chess.GetComponent<Rigidbody>();
			//big
			if(i == 0){
				chess.transform.localScale = new Vector3(1.2f, 0.3f, 1.2f);
				rb.mass = Constant.BIG;

				//small
			}else if(i > 0 && i < 4){
				chess.transform.localScale = new Vector3(0.6f, 0.2f, 0.6f);
				rb.mass = Constant.SMALL;

				//middle
			}else{
				chess.transform.localScale = new Vector3(0.8f, 0.2f, 0.8f);
				rb.mass = Constant.MIDDLE;
			}
			//		chessObject.transform.parent = floor;
			//		chessObject.transform.localPosition = pos;
		}
	}

	//更新棋盘,返回当前剩余的棋子数
	public int getMyChess(){
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("me");
//		ArrayList myChess = new ArrayList ();

		int num = objs.Length;
		for (int i = 0; i < num; i++) {
			if (objs [i].transform.position.y < -1.2f) {
//				num--;
//				Destroy (objs [i]);
			}
//			myChess.Add (objs [i]);
		}

		return num;
	}

	//更新棋盘,返回当前剩余的棋子数
	public int getEnemyChess(){
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("enemy");
//		ArrayList enemyChess = new ArrayList ();
		int num = objs.Length;
		for (int i = 0; i < num; i++) {
			if (objs [i].transform.position.y < -1.2f) {
//				num--;
//				Destroy (objs [i]);
			}
			//			myChess.Add (objs [i]);
		}

		return num;
	}

	public bool isSleeping(){
		GameObject[] myChess = GameObject.FindGameObjectsWithTag ("me");
		GameObject[] enemyChess = GameObject.FindGameObjectsWithTag ("enemy");
		int num = myChess.Length;
		bool allStop = true;
		for (int i = 0; i < num; i++) {
			Rigidbody rb = myChess [i].GetComponent<Rigidbody> ();
			if (!rb.IsSleeping()) {
				allStop = false;
			}
		}
		int num2 = enemyChess.Length;
		for (int i = 0; i < num2; i++) {
			Rigidbody rb = enemyChess [i].GetComponent<Rigidbody> ();
			if (!rb.IsSleeping()) {
				allStop = false;
			}
		}
		return allStop;
	}
}

