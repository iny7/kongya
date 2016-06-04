using UnityEngine;
using System.Collections;
public class ConstOfMenu : MonoBehaviour
{
    //��׼���Ŀ���߶�
    public static float desiginWidth = 800.0f;
    public static float desiginHeight = 480.0f;

    //���������а�ťͼƬ����
    public static int START_BUTTON = 0;
    public static int MUSSIC_BUTTON = 1;
    public static int HELP_BUTTON = 2;
    public static int ABOUT_BUTTON = 3;
    public static int EIGHT_BUTTON = 0;
    public static int NINE_BUTTON = 1;
    public static int COUNTDOW_BUTTON = 0;
    public static int PRACTICE_BUTTON = 1;
    public static int RANK_BUTTON = 2;
    //�����水ť���ƶ��ٶ�
    public static float movingSpeed = 80f;
    //�����水ť��λ��
    public static float[] ButtonPositionOfX = new float[4] { 128, 416, 128, 416 };
    //�����水ť���ƶ�����
    public static float[] ButtonMovingStep = new float[4] { 1, -1, 1, -1 };
    //ModeChoiceLayer���水ť��λ��
    public static float[] BPositionXOfMode = new float[3] { 128, 416, 128 };
    //ModeChoiceLayer���水ť���ƶ�����
    public static float[] BMovingXStepOfMode = new float[3] { -1, 1, -1 };
    //�ý��水ť���ƶ��ٶ�
    public static float movingSpeedOFMode = 80f;
    //����ID�������
    public static int MainID = 1;
	public static int SoundID = 2;
	public static int AboutID = 3;
    //GUI����Ӧ����
    public static Matrix4x4 getMatrix()
    {
        //��ȡ��λ����
        Matrix4x4 guiMatrix = Matrix4x4.identity;
        //����λ�ƾ���
        float lux = (Screen.width - ConstOfMenu.desiginWidth * Screen.height / ConstOfMenu.desiginHeight) / 2.0f;
        //����GUI���󣬱�׼��Ļ800*480
        guiMatrix.SetTRS(new Vector3(lux,0,0), Quaternion.identity, new Vector3(Screen.height / ConstOfMenu.desiginHeight, Screen.height / ConstOfMenu.desiginHeight, 1));
        //���ظþ���
        return guiMatrix;
    }
	//GUI����Ӧ����
    public static Matrix4x4 getInvertMatrix()
    {
        //��ȡGUI����
        Matrix4x4 guiInverseMatrix = getMatrix();
        //����GUI�����
        guiInverseMatrix = Matrix4x4.Inverse(guiInverseMatrix);
        //���ظþ���
        return guiInverseMatrix;
    }
}
