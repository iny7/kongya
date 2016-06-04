using UnityEngine;
using System.Collections;

public class AboutLayer : MonoBehaviour {

    //界面背景图片
    public Texture backgroundOfAboutLayer;
    //关于界面背景图片
    public Texture aboutOfAboutLayer;
    //GUI自适应矩阵
    private Matrix4x4 guiMatrix;
	// Use this for initialization
	void Start () {
        //获取GUI自适应矩阵
        guiMatrix = ConstOfMenu.getMatrix();
	}
    void OnGUI()
    {
        //设置GUI矩阵
        GUI.matrix = guiMatrix;
        //绘制大背景
        GUI.DrawTexture(new Rect(0, 0, ConstOfMenu.desiginWidth, ConstOfMenu.desiginHeight), backgroundOfAboutLayer);
        //绘制关于图片
        GUI.DrawTexture(new Rect(148, 150, 504, 299), aboutOfAboutLayer); 
    }
}
