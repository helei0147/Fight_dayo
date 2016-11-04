using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyManager : MonoBehaviour {
    public static DoubleDictionary keybinding;
    // 下面两个变量不使用static的原因是不同的player有不同的按键状态，一个实例绑定某个玩家的按键，获得某个玩家当前按下或者松开的map
    // 设置为public的原因是让其他的类能够轻松地访问到某个玩家的按键状态。
    public uint upKeymap;
    public uint downKeymap;
    public uint pressKeymap;
    void Awake()
    {
        keybinding = new Bind1();
    }
	// Use this for initialization
	void Start () {
        
	}
	void ChangeBindSet(int setIndex)
    {
        if(setIndex==1)
        {
            keybinding = new Bind1();
        }
    }
	// Update is called once per frame
	void Update () {
        GetKeymap(out downKeymap, out upKeymap,out pressKeymap);
    }
    // 这个函数不应被其他的实例访问，不用static
    public void GetKeymap(out uint downKey,out uint upKey,out uint pressKey)
    {
        List<KeyCode> AllCode = keybinding.GetAllKeyCode();
        uint downResult = 0;
        uint upResult = 0;
        uint pressResult = 0;
        foreach (KeyCode i in AllCode)
        {
            if(Input.GetKey(i))
            {
                pressResult = pressResult | (uint)keybinding.GetBinding(i);
                print(i);
            }
            if (Input.GetKeyDown(i))
            {
                downResult=downResult|(uint)keybinding.GetBinding(i);
                
            }
            if(Input.GetKeyUp(i))
            {
                upResult = upResult | (uint)keybinding.GetBinding(i);
            }
        }
        downKey = downResult;
        upKey = upResult;
        pressKey = pressResult;
    }
    #region 弃用的读取按键方式
    //public static uint GetVirtualKeyUp()
    //{
    //    if (Input.GetKeyUp(KeyCode.UpArrow))
    //        return (int)Binding.Up;
    //    else if(Input.GetKeyUp(KeyCode.DownArrow))
    //    {
    //        return (int)Binding.Down;
    //    }
    //    else if(Input.GetKeyUp(KeyCode.LeftArrow))
    //    {
    //        return (int)Binding.Left;
    //    }
    //    else if(Input.GetKeyUp(KeyCode.RightArrow))
    //    {
    //        return (int)Binding.Right;
    //    }
    //    else
    //    {
    //        return -1;
    //    }
    //}
    //public static int GetVirtualKeyDown()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //        return (int)Binding.Up;
    //    else if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        return (int)Binding.Down;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        return (int)Binding.Left;
    //    }
    //    else if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        return (int)Binding.Right;
    //    }
    //    else
    //    {
    //        return -1;
    //    }
    //}
    #endregion
}

public class StateTool
    /// 从KeyMap得出相应的哪个按键产生了状态。
{
    public static bool GetShootState(uint keystate)
    {
        uint shoot_number = (uint)Binding.shoot;
        if((shoot_number&keystate)!=0)
        {
            return true;
        }
        return false;
    }
    public static bool GetRippleState(uint keystate)
    {
        uint rippleIndex = (uint)Binding.ripple;
        if((rippleIndex&keystate)!=0)
        {
            return true;
        }
        return false;
    }
    public static bool GetControlState(uint keystate)
    {
        uint controlIndex = (uint)Binding.control;
        if ((controlIndex & keystate) != 0)
        {
            return true;
        }
        else
            return false;
    }
    public static bool GetLeftArrowState(uint keystate)
    {
        uint leftIndex = (uint)Binding.Left;
        if ((leftIndex & keystate) != 0)
            return true;
        return false;
    }
    public static bool GetRightArrowState(uint keystate)
    {
        uint rightIndex = (uint)Binding.Right;
        if ((rightIndex & keystate) != 0)
        {
            return true;
        }
        else
            return false;
    }
    public static bool GetUpArrowState(uint keystate)
    {
        uint upIndex = (uint)Binding.Up;
        if ((upIndex & keystate) != 0)
            return true;
        return false;
    }
    public static bool GetDownArrowState(uint keystate)
    {
        uint downIndex = (uint)Binding.Down;
        if((downIndex&keystate)!=0)
        {
            return true;
        }
        return false;
    }
}