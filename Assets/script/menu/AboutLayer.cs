using UnityEngine;
using System.Collections;

public class AboutLayer : MonoBehaviour {

    //���汳��ͼƬ
    public Texture backgroundOfAboutLayer;
    //���ڽ��汳��ͼƬ
    public Texture aboutOfAboutLayer;
    //GUI����Ӧ����
    private Matrix4x4 guiMatrix;
	// Use this for initialization
	void Start () {
        //��ȡGUI����Ӧ����
        guiMatrix = ConstOfMenu.getMatrix();
	}
    void OnGUI()
    {
        //����GUI����
        GUI.matrix = guiMatrix;
        //���ƴ󱳾�
        GUI.DrawTexture(new Rect(0, 0, ConstOfMenu.desiginWidth, ConstOfMenu.desiginHeight), backgroundOfAboutLayer);
        //���ƹ���ͼƬ
        GUI.DrawTexture(new Rect(148, 150, 504, 299), aboutOfAboutLayer); 
    }
}
