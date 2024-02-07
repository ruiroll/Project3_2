using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    [SerializeField] private GameObject BtnUI;
    [SerializeField] private GameObject StatusUI;
    [SerializeField] private GameObject InventoryUI;

    [Header("User Info")]
    [SerializeField] private Text userName;
    [SerializeField] private Text userLevel;
    [SerializeField] private Slider userExpSlider;

    [Header("User Stat")]
    [SerializeField] private Text userAtk;
    [SerializeField] private Text userDef;
    [SerializeField] private Text userStr;
    [SerializeField] private Text userCrt;
    
    private void Start() 
    {
        Refresh();
    }

    public void Refresh()
    {
        UserData userData = GameManager.instance.userData;

        userName.text = userData.Name;
        userLevel.text = $"LV <size=72%>{userData.Level}</size>";
        userExpSlider.value = (float)userData.NowExp / userData.FullExp;

        userAtk.text = userData.Stat.atk.ToString();
        userDef.text = userData.Stat.def.ToString();
        userStr.text = userData.Stat.str.ToString();
        userCrt.text = userData.Stat.crt.ToString();
    }

    public void OpenStatus()
    {
        StatusUI.SetActive(true);
        BtnUI.SetActive(false);
    }
    public void CloseStatus()
    {
        StatusUI.SetActive(false);
        BtnUI.SetActive(true);
    }

    public void OpenInventory()
    {
        InventoryUI.SetActive(true);
        BtnUI.SetActive(false);
    }
    public void CloseInventory()
    {
        InventoryUI.SetActive(false);
        BtnUI.SetActive(true);
    }
    
}
