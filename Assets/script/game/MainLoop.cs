using UnityEngine;
using System.Collections;

public class MainLoop : MonoBehaviour {

	ChessUtil util;

	// 人工智能
	AI _ai;

	public bool isMyTurn;

	bool needAI;

	bool isOver;

	int winner;

	void Start () {

		needAI = PlayerPrefs.GetInt ("AINum") == 1;
//		needAI = true;
		print (needAI);
//		needAI = false;
		//if single player, initial AI
		if (needAI) {
			_ai = new AI ();
		}

		//player first
		isMyTurn = true;
		isOver = false;

		util = GetComponent ("ChessUtil") as ChessUtil;
		util.initAllChess ();

	}
	
	void Update () {
		//判断游戏是否结束
		judgeGameOver ();
		if (isOver) {
			print("游戏结束");
			if (winner == 1) {
				print ("玩家1获胜");
			} else if (winner == 2) {
				print ("玩家2获胜");
			}
			return;
		}
		//如果当前还有棋子在运动,则什么也不做
		if (!util.isSleeping ()) {
			print ("still Running");
			return;
		}
		//如果不是我的回合
		if (!isMyTurn) {
			//判断是人机还是人人,若是人机
			if (needAI) {
				print ("该AI了!");
				_ai.shoot ();

				// 换玩家走
				print ("AI操作完毕,该您了!");
				isMyTurn = true;

			//人人
			}else{
				print("该玩家2了");
			}
		}
			

	}

	private void judgeGameOver(){
		if (util.getMyChess () == 0) {
			winner = 2;
			isOver = true;

		}else if (util.getEnemyChess () == 0) {
			winner = 1;
			isOver = true;
		}
	}
		
}
