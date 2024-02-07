using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class Status
{
    public int atk;
    public int def;
    public int str;
    public int crt;

    public Status()
    {
        atk = 10;
        def = 20;
        str = 30;
        crt = 40;
    }
    public Status(int atk, int def, int str, int crt)
    {
        this.atk = atk;
        this.def = def;
        this.str = str;
        this.crt = crt;
    }
}

[System.Serializable]
public class UserData
{
    public string Name;
    public int Level;
    public int NowExp;
    public int FullExp;
    public Status Stat;
    public List<Item> inventory = new List<Item>();

    public Status GetAllStat()
    {
        Status status = new Status();
        
        foreach(Item item in inventory)
        {
            if(item.isEquipped)
            {
                status.atk += item.data.stat.atk;
                status.def += item.data.stat.def;
                status.str += item.data.stat.str;
                status.crt += item.data.stat.crt;
            }
        }

        return status;
    }
}

[System.Serializable]
public class Item
{
    public bool isEquipped;
    public Items data;
}

public class GameManager : MonoBehaviour
{
    public Popup popup;
    public UserData userData;
    public static GameManager instance;

    private void Awake() 
    {
        if(instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ItemEquip()
    {
        userData.Stat = userData.GetAllStat();
        popup.Refresh();
    }
}
