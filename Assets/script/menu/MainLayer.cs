using UnityEngine;
using System.Collections;

public class MainLayer : MonoBehaviour {
 
    //�˵����汳��ͼƬ
    public Texture backgroundOfMainMenu;
    //�˵����水ťͼ��ʽ
    public GUIStyle[] buttonStyleOfMain;
    //������Ҫ��������
    private float[] ButtonPositionOfX = new float[4];
    //��ťֱ�ӵĸ߶Ȳ�
    private float buttonOfficerOfHeight;
    //��һ����ť����ʼY����
    private float startYOfMainMenu;
    //���˵����水ť�Ƿ�����ƶ������ı�־λ
    public bool moveFlag;
    //���˵����水ť��ǰ�ƶ��ľ���
    private float buttonOfCurrentMovingDistance;
    //���˵����水ť�ƶ��������� 
    private float buttonOfMaxDistance;
    //GUI����
    private Matrix4x4 guiMatrix;
	// Use this for initialization
	void Start () {
        //��ʼͼƬ�ĸ߶�
        buttonOfficerOfHeight = 75;
        //Main�����������Ǹ���ť�ĸ߶ȣ����ఴť�ĸ߶��ڴ˻����Ͻ��м���
        startYOfMainMenu = 150;
        //�ƶ��ı�־λ
        moveFlag = true;     
        //��������λ�õ���Ϣ
        restData();
        //��ť�ƶ�����
        buttonOfCurrentMovingDistance = 0;
        //��ť����ƶ�����
        buttonOfMaxDistance = 80;
        //��ȡGUI����Ӧ����
        guiMatrix = ConstOfMenu.getMatrix();	    
	}
    void OnGUI()
    {
        //����GUI����Ӧ����
        GUI.matrix = guiMatrix;
        //���Ʊ���ͼƬ
        GUI.DrawTexture(new Rect(0, 0, ConstOfMenu.desiginWidth, ConstOfMenu.desiginHeight), backgroundOfMainMenu);
        //����menu����
        DrawMainMenu();
        //�ж��Ƿ������ƶ�
        if (moveFlag)
        {
            //�����ť��Ҫ�ƶ����ƶ���
            ButtonOfManiMenuMove();
        }
    }
    //�������˵�����
    void DrawMainMenu() 
    {
        if (GUI.Button(new Rect(ButtonPositionOfX[ConstOfMenu.START_BUTTON], startYOfMainMenu + buttonOfficerOfHeight * 0, 256, 64), "", buttonStyleOfMain[ConstOfMenu.START_BUTTON]))
        {
            if (!moveFlag)
            {
				//AI����Ϊ1
				PlayerPrefs.SetInt("AINum", 1);

				//������Ϸ����ľ�̬����?��//				GameLayer.resetAllStaticData();
				//����LevelSelectScene����
				Application.LoadLevel("demo");

            }
        }

        if (GUI.Button(new Rect(ButtonPositionOfX[ConstOfMenu.MUSSIC_BUTTON], startYOfMainMenu + buttonOfficerOfHeight * 1, 256, 64), "", buttonStyleOfMain[ConstOfMenu.MUSSIC_BUTTON]))
        {
            if (!moveFlag)
            {
				//AI����Ϊ0
				PlayerPrefs.SetInt("AINum", 0);

				//������Ϸ����ľ�̬��������
//				GameLayer.resetAllStaticData();

				//����LevelSelectScene����
				Application.LoadLevel("demo");

            }
        }

        if (GUI.Button(new Rect(ButtonPositionOfX[ConstOfMenu.HELP_BUTTON], startYOfMainMenu + buttonOfficerOfHeight * 2, 256, 64), "", buttonStyleOfMain[ConstOfMenu.HELP_BUTTON]))
        {
            if (!moveFlag)
            {
                //�����ťû���ƶ�          
				(GetComponent("Controller") as Controller).ChangeScrip(ConstOfMenu.MainID, ConstOfMenu.SoundID);
            }

        }
        if (GUI.Button(new Rect(ButtonPositionOfX[ConstOfMenu.ABOUT_BUTTON], startYOfMainMenu + buttonOfficerOfHeight * 3, 256, 64), "", buttonStyleOfMain[ConstOfMenu.ABOUT_BUTTON]))
        {
            if (!moveFlag)
            {
                //�����ťû���ƶ�   
				(GetComponent("Controller") as Controller).ChangeScrip(ConstOfMenu.MainID, ConstOfMenu.AboutID);
            }
        }
    }
    //��ť�ƶ��ķ���
    void ButtonOfManiMenuMove()
    {
        //��ť�ƶ��ľ���
        float length = ConstOfMenu.movingSpeed * Time.deltaTime;
        //��ť�ƶ�һ�� 
        buttonOfCurrentMovingDistance += length;
        //���ð�ť��λ�ã�ConstOfMenu.ButtonMovingStep[i]��ʾÿ����ť���ƶ�����
        for (int i = 0; i < ButtonPositionOfX.Length; i++)
        {
            ButtonPositionOfX[i] += (ConstOfMenu.ButtonMovingStep[i] * length);
        }    
        //�����Ƿ��ƶ���������
        moveFlag = buttonOfCurrentMovingDistance < buttonOfMaxDistance;
    }
    //�����������ݵķ���
    public void restData()
    {
        for (int i = 0; i < ConstOfMenu.ButtonPositionOfX.Length; i++)
        {
            //����λ��
            ButtonPositionOfX[i] = ConstOfMenu.ButtonPositionOfX[i];
        }
        //���õ�ǰ�ƶ�����Ϊ0
        buttonOfCurrentMovingDistance = 0;
        //�ƶ��ı�־λ
        moveFlag = true;
    }	
}
