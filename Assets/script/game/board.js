#pragma strict

var floor : Transform;
var me : GameObject;
var enemy : GameObject;
var chessPos : Vector3[];

chessPos = new Vector3[8];

//var posArr = MultiDim.V3Array2D()
//var foo = MultiDim.IntArray2D(5, 8);

//big
chessPos[0] = new Vector3(0, 0.3, -2.5);
//small
chessPos[1] = new Vector3(0, 0.2, -1);
chessPos[2] = new Vector3(-2.7, 0.2, -1.5);
chessPos[3] = new Vector3(2.7, 0.2, -1.5);
//mid
chessPos[4] = new Vector3(-2.6, 0.2, -3.5);
chessPos[5] = new Vector3(-1.6, 0.2, -3.5);
chessPos[6] = new Vector3(1.6, 0.2, -3.5);
chessPos[7] = new Vector3(2.6, 0.2, -3.5);

function Start () {
	floor = GameObject.Find ("platform-2").transform;
//	floor.position = initPos;
	var initPos = new Vector3(0, 0, 0);
	for(var i = 0 ; i < chessPos.length ; i ++){
		var chessObject = GameObject.Instantiate(me);
//		chessObject.transform.SetParent(floor, true);
		var pos = chessPos[i];
		var rb = chessObject.GetComponent(Rigidbody);
		//big
		if(0 == i){
			chessObject.transform.localScale = new Vector3(1.2, 0.3, 1.2);
			rb.mass = 2;

		//small
		}else if(i > 0 && i < 4){
			chessObject.transform.localScale = new Vector3(0.6, 0.2, 0.6);
			rb.mass = 0.5;

		//middle
		}else{
			chessObject.transform.localScale = new Vector3(0.8, 0.2, 0.8);
			rb.mass = 1.3;
		}
//		chessObject.transform.parent = floor;
//		chessObject.transform.localPosition = pos;
		chessObject.transform.position = pos;
	}
	for(var j = 0 ; j < chessPos.length ; j ++){
		var chessObject2 = GameObject.Instantiate(enemy);
//		chessObject.transform.SetParent(floor, true);
		var pos2 = chessPos[j];
		var rb2 = chessObject2.GetComponent(Rigidbody);
		//big
		if(0 == j){
			chessObject2.transform.localScale = new Vector3(1.2, 0.3, 1.2);
			rb2.mass = 2;

		//small
		}else if(j > 0 && j < 4){
			chessObject2.transform.localScale = new Vector3(0.6, 0.2, 0.6);
			rb2.mass = 1.5;

		//middle
		}else{
			chessObject2.transform.localScale = new Vector3(0.8, 0.2, 0.8);
			rb2.mass = 1.8;
		}
//		chessObject.transform.parent = floor;
//		chessObject.transform.localPosition = pos;
		chessObject2.transform.position = -pos2;
	}

}

function Update () {

}