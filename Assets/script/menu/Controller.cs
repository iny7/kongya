using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    //��ʼ��ǰ����ID
    private int currentID = ConstOfMenu.MainID;
    //�����ű����
    MonoBehaviour[] script;
    void Awake() {
        //����ű����
        script = GetComponents<MonoBehaviour>();
    }	
	// Update is called once per frame
	void Update () {
        //���ؼ�����
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            //����EscapeEvent����
            EscapeEvent();
        }
	}
    //�޸Ľ���ķ���
    public void ChangeScrip(int offID,int onID )
    {        
		print (script[offID]);
		print (script[onID]);

        //�л�����֮ǰ����Ҫ��������������ݴ������ã������������а�ť��λ�õ�
        restData();
        //���õ�ǰ����ű����
        script[offID].enabled = false;
        //������Ҫ�������Ľű����
        script[onID].enabled = true;
        //���õ�ǰ����ID
        currentID = onID;
    }
    //���ؼ����õķ���
    void EscapeEvent()
    {
        //ÿ�ΰ��·��ؼ����Ӧ����ת���Ǹ�����
        switch (currentID)
        {
            //�ű����0-n�ǰ�˳����صģ�������д�·��صķ���
            case 1: if ((GetComponent("MainLayer") as MainLayer).moveFlag)
                    {
                        break;
                    }Application.Quit(); break;
            case 2:
            case 3:
            case 4:
            case 5:
                ChangeScrip(currentID,ConstOfMenu.MainID); break;
//            case 6:
//                ChangeScrip(currentID,ConstOfMenu.ChoiceID); break;
//            case 7:
//                ChangeScrip(currentID,ConstOfMenu.ModeChoiceID); break;
        }
    }
    //���ø����ű�����������������ݵķ������������ݲ��ո���restData����
    private void restData()
    {
        (GetComponent("MainLayer") as MainLayer).restData();
        
//        HelpLayer helpLayer = GetComponent("HelpLayer") as HelpLayer;
//        helpLayer.restData();

    }       
    
}
