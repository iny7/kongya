using UnityEngine;
using System.Collections;

public class MusicLayer : MonoBehaviour
{

    //�˵����汳��ͼƬ
    public Texture backgroundOfMusicLayer;
    //�������ְ�ť����	
    public Texture2D[] musicBtns;
    //������ť��Ӧ��ͼƬ
    public Texture2D[] musicTex;
    //������Ч��ť����
    public Texture2D[] effectBtns;
    //��Ч��ť��Ӧ��ͼƬ
    public Texture2D[] effectTex;
    //��Ч����
    private int effectIndex;
    //��������
    private int musicIndex;
    //��ť��ʽ
    public GUIStyle btStyle;
    //GUI����Ӧ����
    private Matrix4x4 guiMatrix;
    void Start()
    {
        //��ʼ����Ч����
        effectIndex = PlayerPrefs.GetInt("offEffect");
        //��ʼ����������
        musicIndex = PlayerPrefs.GetInt("offMusic");
        //��ʼ��GUI����Ӧ����
        guiMatrix = ConstOfMenu.getMatrix();
    }
    void OnGUI()
    {
        //����GUI����
        GUI.matrix = guiMatrix;
        //���Ʊ���ͼƬ
        GUI.DrawTexture(new Rect(0, 0, ConstOfMenu.desiginWidth, ConstOfMenu.desiginHeight), backgroundOfMusicLayer);
        //273,80ΪͼƬ��ʵ�ʴ�С����Ҫ��Ϊ��������Դ������
        GUI.DrawTexture(new Rect(200, 180, 273, 80), musicTex[musicIndex % 2]);
        //����������ͼƬ��Դ��̫�ã�����ͨ�����ֽ��е���
        if (GUI.Button(new Rect(473, 190, 110, 80), musicBtns[musicIndex % 2], btStyle))
        {
            //��ť������һ
            musicIndex++;
            //���µİ�ť��������prefer��
            PlayerPrefs.SetInt("offMusic", musicIndex % 2);

        }
        //������ʾͼƬ
        GUI.DrawTexture(new Rect(200, 320, 273, 80), effectTex[effectIndex % 2]);//273,80ΪͼƬ��ʵ�ʴ�С����Ҫ��Ϊ��������Դ������
        if (GUI.Button(new Rect(473, 330, 110, 80), effectBtns[effectIndex % 2], btStyle))//����������ͼƬ��Դ��̫�ã�����ͨ�����ֽ��е���
        {
            //��ť������һ
            effectIndex++;
            //���µİ�ť��������prefer��
            PlayerPrefs.SetInt("offEffect", effectIndex % 2);

        }
    }
}