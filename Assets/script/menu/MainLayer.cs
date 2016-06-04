using UnityEngine;
using System.Collections;

public class MainLayer : MonoBehaviour {
 
    //菜单界面背景图片
    public Texture backgroundOfMainMenu;
    //菜单界面按钮图样式
    public GUIStyle[] buttonStyleOfMain;
    //首先需要创建数组
    private float[] ButtonPositionOfX = new float[4];
    //按钮直接的高度差
    private float buttonOfficerOfHeight;
    //第一个按钮的起始Y坐标
    private float startYOfMainMenu;
    //主菜单界面按钮是否进行移动动作的标志位
    public bool moveFlag;
    //主菜单界面按钮当前移动的距离
    private float buttonOfCurrentMovingDistance;
    //主菜单界面按钮移动的最大距离 
    private float buttonOfMaxDistance;
    //GUI矩阵
    private Matrix4x4 guiMatrix;
	// Use this for initialization
	void Start () {
        //初始图片的高度
        buttonOfficerOfHeight = 75;
        //Main界面最上面那个按钮的高度，其余按钮的高度在此基础上进行计算
        startYOfMainMenu = 150;
        //移动的标志位
        moveFlag = true;     
        //重新设置位置等信息
        restData();
        //按钮移动距离
        buttonOfCurrentMovingDistance = 0;
        //按钮最大移动距离
        buttonOfMaxDistance = 80;
        //获取GUI自适应矩阵
        guiMatrix = ConstOfMenu.getMatrix();	    
	}
    void OnGUI()
    {
        //设置GUI自适应矩阵
        GUI.matrix = guiMatrix;
        //绘制背景图片
        GUI.DrawTexture(new Rect(0, 0, ConstOfMenu.desiginWidth, ConstOfMenu.desiginHeight), backgroundOfMainMenu);
        //绘制menu界面
        DrawMainMenu();
        //判断是否允许移动
        if (moveFlag)
        {
            //如果按钮需要移动就移动吧
            ButtonOfManiMenuMove();
        }
    }
    //绘制主菜单界面
    void DrawMainMenu() 
    {
        if (GUI.Button(new Rect(ButtonPositionOfX[ConstOfMenu.START_BUTTON], startYOfMainMenu + buttonOfficerOfHeight * 0, 256, 64), "", buttonStyleOfMain[ConstOfMenu.START_BUTTON]))
        {
            if (!moveFlag)
            {
				//AI数量为1
				PlayerPrefs.SetInt("AINum", 1);

				//设置游戏界面的静态变量?苌//				GameLayer.resetAllStaticData();
				//加载LevelSelectScene场景
				Application.LoadLevel("demo");

            }
        }

        if (GUI.Button(new Rect(ButtonPositionOfX[ConstOfMenu.MUSSIC_BUTTON], startYOfMainMenu + buttonOfficerOfHeight * 1, 256, 64), "", buttonStyleOfMain[ConstOfMenu.MUSSIC_BUTTON]))
        {
            if (!moveFlag)
            {
				//AI数量为0
				PlayerPrefs.SetInt("AINum", 0);

				//设置游戏界面的静态变量数据
//				GameLayer.resetAllStaticData();

				//加载LevelSelectScene场景
				Application.LoadLevel("demo");

            }
        }

        if (GUI.Button(new Rect(ButtonPositionOfX[ConstOfMenu.HELP_BUTTON], startYOfMainMenu + buttonOfficerOfHeight * 2, 256, 64), "", buttonStyleOfMain[ConstOfMenu.HELP_BUTTON]))
        {
            if (!moveFlag)
            {
                //如果按钮没有移动          
				(GetComponent("Controller") as Controller).ChangeScrip(ConstOfMenu.MainID, ConstOfMenu.SoundID);
            }

        }
        if (GUI.Button(new Rect(ButtonPositionOfX[ConstOfMenu.ABOUT_BUTTON], startYOfMainMenu + buttonOfficerOfHeight * 3, 256, 64), "", buttonStyleOfMain[ConstOfMenu.ABOUT_BUTTON]))
        {
            if (!moveFlag)
            {
                //如果按钮没有移动   
				(GetComponent("Controller") as Controller).ChangeScrip(ConstOfMenu.MainID, ConstOfMenu.AboutID);
            }
        }
    }
    //按钮移动的方法
    void ButtonOfManiMenuMove()
    {
        //按钮移动的距离
        float length = ConstOfMenu.movingSpeed * Time.deltaTime;
        //按钮移动一下 
        buttonOfCurrentMovingDistance += length;
        //设置按钮的位置，ConstOfMenu.ButtonMovingStep[i]表示每个按钮的移动方向
        for (int i = 0; i < ButtonPositionOfX.Length; i++)
        {
            ButtonPositionOfX[i] += (ConstOfMenu.ButtonMovingStep[i] * length);
        }    
        //计算是否移动到最大距离
        moveFlag = buttonOfCurrentMovingDistance < buttonOfMaxDistance;
    }
    //重新设置数据的方法
    public void restData()
    {
        for (int i = 0; i < ConstOfMenu.ButtonPositionOfX.Length; i++)
        {
            //设置位置
            ButtonPositionOfX[i] = ConstOfMenu.ButtonPositionOfX[i];
        }
        //重置当前移动距离为0
        buttonOfCurrentMovingDistance = 0;
        //移动的标志位
        moveFlag = true;
    }	
}
