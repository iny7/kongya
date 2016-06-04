using UnityEngine;
using System.Collections;
public class ConstOfMenu : MonoBehaviour
{
    //标准屏的宽与高度
    public static float desiginWidth = 800.0f;
    public static float desiginHeight = 480.0f;

    //各个界面中按钮图片索引
    public static int START_BUTTON = 0;
    public static int MUSSIC_BUTTON = 1;
    public static int HELP_BUTTON = 2;
    public static int ABOUT_BUTTON = 3;
    public static int EIGHT_BUTTON = 0;
    public static int NINE_BUTTON = 1;
    public static int COUNTDOW_BUTTON = 0;
    public static int PRACTICE_BUTTON = 1;
    public static int RANK_BUTTON = 2;
    //主界面按钮的移动速度
    public static float movingSpeed = 80f;
    //主界面按钮的位置
    public static float[] ButtonPositionOfX = new float[4] { 128, 416, 128, 416 };
    //主界面按钮的移动方向
    public static float[] ButtonMovingStep = new float[4] { 1, -1, 1, -1 };
    //ModeChoiceLayer界面按钮的位置
    public static float[] BPositionXOfMode = new float[3] { 128, 416, 128 };
    //ModeChoiceLayer界面按钮的移动方向
    public static float[] BMovingXStepOfMode = new float[3] { -1, 1, -1 };
    //该界面按钮的移动速度
    public static float movingSpeedOFMode = 80f;
    //界面ID方便管理
    public static int MainID = 1;
	public static int SoundID = 2;
	public static int AboutID = 3;
    //GUI自适应矩阵
    public static Matrix4x4 getMatrix()
    {
        //获取单位矩阵
        Matrix4x4 guiMatrix = Matrix4x4.identity;
        //计算位移距离
        float lux = (Screen.width - ConstOfMenu.desiginWidth * Screen.height / ConstOfMenu.desiginHeight) / 2.0f;
        //设置GUI矩阵，标准屏幕800*480
        guiMatrix.SetTRS(new Vector3(lux,0,0), Quaternion.identity, new Vector3(Screen.height / ConstOfMenu.desiginHeight, Screen.height / ConstOfMenu.desiginHeight, 1));
        //返回该矩阵
        return guiMatrix;
    }
	//GUI自适应矩阵
    public static Matrix4x4 getInvertMatrix()
    {
        //获取GUI矩阵
        Matrix4x4 guiInverseMatrix = getMatrix();
        //计算GUI逆矩阵
        guiInverseMatrix = Matrix4x4.Inverse(guiInverseMatrix);
        //返回该矩阵
        return guiInverseMatrix;
    }
}
