using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{
    [SerializeField]
    Button NextButton;

    [SerializeField]
    Text ScriptText;

    [SerializeField]
    Text NameText;

    [SerializeField]
    Sprite[] CharacterSprite;

    [SerializeField]
    int Scene;

    string[] ShowScene;

    public int CharPerSecond=1;
    int index;
    string TargetMsg;

    string[] Scene11 =
    { "��ΰ� ������ ��ȭ�� �ͼ����� ����,:���踦 ���� �� �ִ� �� Į����, �ʿ� �����̾�!",
    "Ǫ��...",
    "...�׷� ������� �Ҹ� ���� ��!",
    "������ �� ���� �¾�.:�츮 ���̼� ������ Ȧ�� ����ϴ� �� ���� �ٺ� ���� ���̾�.",
    "���谡���� ��ƾ� ��!:������ �ƹ� ���谡�� �ȵ�.:���� ������ ���ذ� ������ ����...",
    "���� �ָ� ���� ���ϼ��� ���̴�!:���ִ��� ã�ƶ�!",
    "��...! �ƹٸ����� �������̴�!:���� �� ã�� ��ó� ��!:������ ���� �� ���� ���� ���� �� ����...",
    "...��, ����! �̺� �ű� ��!",
    "...��? ����?",
    "�׷� �ָ��ϰ� ���ΰ�ó�� ���� ��!:�� �Ʊ� ��� �� �ݾҴٰ� ��� �ִ� ���谡��?",
    "��, �� ����ŵ��!:�׸��� ��嵵 �� �ݾ����� ���� ���谡�� �ƴ϶󱸿�.",
    "�ƹ����� �ư�, ��:���ú��� �뺴�ض�.",
    "��? �뺴�̿�?",
    "�׷�! �� ���� �ձ��� ���ְ� ������ �ս� �뺴�̾�! ������!:�� ���� �� ����縦 ����!",
    "��! �� �սǿ��� ���غ��� �� ���̾����!:...���, ���� �����󱸿�?",
    "���ִ��� ã�Ҵ�!:���� ���ñ� ���� ��ƶ�!",
    "����...! ���״�!:��, �ƹ�ư �� ���� �� �뺴�̴ϱ� ��Ե� �������� ����!",
    "��?? ���� �ձ� ������ݾƿ�!:���� ����� �̱� �� ���ٱ���!",
    "���� �ʺ��� ����� �������� ����Ʈ����?:�ð����̶� ����!",
    "���谡���̿�! ����ġ�� ���ִ��� ��ƶ�!:��ƿ��� �ڿ��� ������� �ְڴ�!",
    "��? �����??:�� �׷��� ���� �ϵ� �����µ� �� �Ƴ�!",
    "���̰�!:������ �������� ���ż� ���ǹ��ϰ� �װ� �����!!",
    "���� �����ϴٴ� �ž�, �� �����̰�!:...�ƹ����� ������ �� �㿩��� �뺴���μ��� �ڰ��� �� ����ڴ°�.",
    "��! �̰� �޾�!",
    "�� ���̴�!	������!:�츮 �����... �ƴ� ���ִ��� �����ϴ� �༮����!",
    "��, ���� ���������� ������ ���谡 �ٿ� �ڼ��� �����.",
    "���谡! �������� ��� ���� �־�.:���� �������� ��ƿ� �״ϱ�!!"
    };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetScene(int Scene)
    {
        switch(Scene)
        {
            case 11:
                {
                    ShowScene = Scene11;
                    break;
                }

        }

        SceneStart();
    }

    void SceneStart()
    {

    }



    public void EffectStart()
    {
        ScriptText.text = "";
        index = 0;

        Invoke("Effecting", 1 / CharPerSecond);
    }

    void Effecting()
    {
        if (ScriptText.text == TargetMsg)
        {
            EffectEnd();
            return;
        }

        ScriptText.text += TargetMsg[index];
        index++;

        Invoke("Effecting",1/CharPerSecond);

    }
    
    void EffectEnd()
    {

    }
}
