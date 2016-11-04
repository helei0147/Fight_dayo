using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum Binding
{
    Up = 1,
    Down = 2,
    Left = 4,
    Right = 8,
    shoot = 16,
    ripple = 32,
    slow = 64,
    control=128
}
public class Bind1 : DoubleDictionary
{
    public Bind1()
    {
        AddKey(Binding.Up, KeyCode.UpArrow);
        AddKey(Binding.Down, KeyCode.DownArrow);
        AddKey(Binding.Left, KeyCode.LeftArrow);
        AddKey(Binding.Right, KeyCode.RightArrow);
        AddKey(Binding.shoot, KeyCode.Z);
        AddKey(Binding.ripple, KeyCode.X);
        AddKey(Binding.control, KeyCode.LeftControl);
    }
}
public class DoubleDictionary{

    private Dictionary<KeyCode, Binding> ReverseDic = new Dictionary<KeyCode, Binding>();// 与Dic相反, 生成双向字典。
    private Dictionary<Binding, KeyCode> Dic = new Dictionary<Binding, KeyCode>();//虚拟按键为键，虚拟键码值为值
    public DoubleDictionary()
    {
        
    }
    public bool AddKey(Binding tempBinding, KeyCode tempKeyCode)
    {
        if(Dic.ContainsKey(tempBinding))
        {
            KeyCode old = Dic[tempBinding];
            if(Dic.ContainsValue(tempKeyCode))
            {
                // 交换已有按键绑定
                Binding anotherBind = ReverseDic[tempKeyCode];
                KeyCode anotherOld = Dic[anotherBind];
                Dic[tempBinding] = anotherOld;
                Dic[anotherBind] = old;
                ReverseDic[old] = anotherBind;
                ReverseDic[anotherOld] = tempBinding;
            }
            else
            {
                Dic[tempBinding] = tempKeyCode;
                ReverseDic[tempKeyCode] = tempBinding;
            }
        }
        else
        {
            ReverseDic.Add(tempKeyCode, tempBinding);
            Dic.Add(tempBinding, tempKeyCode);
        }
        if (!Check())
        {
            return false;
        }
        else
            return true;
    }
    public List<KeyCode> GetAllKeyCode()
    {
        List<KeyCode> keycodeCollection = new List<KeyCode>();
        foreach(var i in Dic)
        {
            keycodeCollection.Add(i.Value);
        }
        return keycodeCollection;
    }
    public Binding GetBinding(KeyCode key)
    {
        return ReverseDic[key];
    }
    public KeyCode GetKeyCode(Binding key)
    {
        return Dic[key];
    }
    private bool Check()
    {
        if(ReverseDic.Count!=Dic.Count)
        {
            return false;
        }
        foreach(var key in ReverseDic)
        {
            var origin = key.Key;
            if (origin != Dic[key.Value])
                return false;
        }
        foreach(var key in Dic)
        {
            var origin = key.Key;
            if(origin!=ReverseDic[key.Value])
            {
                return false;
            }
        }
        return true;
    }
}
