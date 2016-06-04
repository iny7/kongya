using UnityEngine;
using System.Collections;

public class MusicLayer : MonoBehaviour
{

    //菜单界面背景图片
    public Texture backgroundOfMusicLayer;
    //声明音乐按钮数组	
    public Texture2D[] musicBtns;
    //声音按钮对应的图片
    public Texture2D[] musicTex;
    //声明音效按钮数组
    public Texture2D[] effectBtns;
    //音效按钮对应的图片
    public Texture2D[] effectTex;
    //音效索引
    private int effectIndex;
    //音乐索引
    private int musicIndex;
    //按钮样式
    public GUIStyle btStyle;
    //GUI自适应矩阵
    private Matrix4x4 guiMatrix;
    void Start()
    {
        //初始化音效索引
        effectIndex = PlayerPrefs.GetInt("offEffect");
        //初始化音乐索引
        musicIndex = PlayerPrefs.GetInt("offMusic");
        //初始化GUI自适应矩阵
        guiMatrix = ConstOfMenu.getMatrix();
    }
    void OnGUI()
    {
        //设置GUI矩阵
        GUI.matrix = guiMatrix;
        //绘制背景图片
        GUI.DrawTexture(new Rect(0, 0, ConstOfMenu.desiginWidth, ConstOfMenu.desiginHeight), backgroundOfMusicLayer);
        //273,80为图片的实际大小，主要是为了适配资源不变形
        GUI.DrawTexture(new Rect(200, 180, 273, 80), musicTex[musicIndex % 2]);
        //这里它给的图片资源不太好，所以通过数字进行调整
        if (GUI.Button(new Rect(473, 190, 110, 80), musicBtns[musicIndex % 2], btStyle))
        {
            //按钮索引加一
            musicIndex++;
            //将新的按钮索引存入prefer中
            PlayerPrefs.SetInt("offMusic", musicIndex % 2);

        }
        //绘制显示图片
        GUI.DrawTexture(new Rect(200, 320, 273, 80), effectTex[effectIndex % 2]);//273,80为图片的实际大小，主要是为了适配资源不变形
        if (GUI.Button(new Rect(473, 330, 110, 80), effectBtns[effectIndex % 2], btStyle))//这里它给的图片资源不太好，所以通过数字进行调整
        {
            //按钮索引加一
            effectIndex++;
            //将新的按钮索引存入prefer中
            PlayerPrefs.SetInt("offEffect", effectIndex % 2);

        }
    }
}