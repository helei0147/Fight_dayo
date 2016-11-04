using UnityEngine;
using System.Collections;
/// <summary>
///  这个脚本必须挂在一个已经有KeyManager脚本的Sprite上。
///  负责根据现在的按键状态更改Sprite的位置，状态等信息。
/// </summary>
public class Controller : MonoBehaviour {
    private KeyManager manager;
    private Character selfState;
	// Use this for initialization
	void Start () {
        manager = GetComponent<KeyManager>();
        selfState = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
        uint downMap = manager.downKeymap;
        uint upMap = manager.upKeymap;
        uint pressMap = manager.pressKeymap;
        if(StateTool.GetControlState(downMap))
        {
            //  招式识别相关代码
        }
        else
        {
            if(StateTool.GetLeftArrowState(pressMap))
            {
                transform.Translate(new Vector3(-selfState.speed, 0, 0));
            }
            if(StateTool.GetRightArrowState(pressMap))
            {
                transform.Translate(new Vector3(selfState.speed, 0, 0));
            }
            if(StateTool.GetUpArrowState(pressMap))
            {
                transform.Translate(new Vector3(0, selfState.speed, 0));
            }
            if(StateTool.GetDownArrowState(pressMap))
            {
                transform.Translate(new Vector3(0, -selfState.speed, 0));
            }

        }
	}
}
