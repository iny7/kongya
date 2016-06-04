using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    //初始当前界面ID
    private int currentID = ConstOfMenu.MainID;
    //声明脚本组件
    MonoBehaviour[] script;
    void Awake() {
        //定义脚本组件
        script = GetComponents<MonoBehaviour>();
    }	
	// Update is called once per frame
	void Update () {
        //返回键监听
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            //调用EscapeEvent方法
            EscapeEvent();
        }
	}
    //修改界面的方法
    public void ChangeScrip(int offID,int onID )
    {        
		print (script[offID]);
		print (script[onID]);

        //切换界面之前首先要将其他界面的数据从新设置，例如主界面中按钮的位置等
        restData();
        //禁用当前界面脚本组件
        script[offID].enabled = false;
        //启用需要进入界面的脚本组件
        script[onID].enabled = true;
        //设置当前界面ID
        currentID = onID;
    }
    //返回键调用的方法
    void EscapeEvent()
    {
        //每次按下返回键检测应该跳转到那个界面
        switch (currentID)
        {
            //脚本组件0-n是按顺序加载的，对着这写下返回的方法
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
    //调用各个脚本组件的重新设置数据的方法，具体内容参照各个restData方法
    private void restData()
    {
        (GetComponent("MainLayer") as MainLayer).restData();
        
//        HelpLayer helpLayer = GetComponent("HelpLayer") as HelpLayer;
//        helpLayer.restData();

    }       
    
}
