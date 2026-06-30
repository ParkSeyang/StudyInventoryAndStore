using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Jay;
using UnityEngine.Serialization;

public class MainSystem : SingletonBase<MainSystem>
{
    private const float MINIMUMLIMIT = 0.0f;
    private const float MAXIMUMLIMIT = 100.0f;
    private int hungercount = 0;
    
    public TMP_Text NameText;
    public TMP_Text GoldText;
    public TMP_Text HealthText;
    public TMP_Text ManaText;
    public TMP_Text HungerText;

    public Image healthGauge;
    public Image manaGauge;
    public Image hungerGauge;

    public void test()
    {
        // 비율 = 전체 중에 부분
        // 부분 / 전체 = 현재 HP / 최대 HP
    }
    
    protected override void Awake()
    {
        base.Awake();
        
        InitializeUser();
        SettingGauge();
        Debug.Log($"[MainSystem] 유저 정보 초기화 : User Name : {UserData.Instance.Name}," +
                  $"User Money : {UserData.Instance.Money}");
        
    }
    
    public void Update()
    {
        MoneyScore();
        HealthGauge();
        ManaGauge();
        HungerGauge();
       
    }
    
    
    private void InitializeUser()
    {
        UserData.Instance = new UserData("WrzardMan77", 10000, 15.0f, 15.0f, 
            100.0f, 3.0f);
        NameText.SetText(UserData.Instance.Name);
    }
    public void MoneyScore()
    {
        UserData MoneyData = UserData.Instance;
        GoldText.SetText(MoneyData.Money.ToString());
    }

    public void HealthGauge()
    {
        UserData HealthData = UserData.Instance;
        healthGauge.fillAmount = HealthData.Health / MAXIMUMLIMIT;
        HealthText.SetText(HealthData.Health.ToString());
    }

    public void ManaGauge()
    {
        UserData ManaData = UserData.Instance;
        manaGauge.fillAmount = ManaData.Mana / MAXIMUMLIMIT;
        ManaText.SetText(ManaData.Mana.ToString());
    }

    public void HungerGauge()
    {
        hungercount++;
        UserData HungerData = UserData.Instance;
        if (hungercount == 1000)
        {
            if (HungerData.Hunger < MINIMUMLIMIT)
            {
                hungerGauge.fillAmount = Mathf.Clamp(HungerData.Hunger, MINIMUMLIMIT, MAXIMUMLIMIT);
                HungerText.SetText($"{HungerData.Hunger.ToString()}");
            }
            if (HungerData.Hunger <= MAXIMUMLIMIT && HungerData.Hunger > MINIMUMLIMIT)
            {
                HungerData.Hunger -= 5.0f;
                hungerGauge.fillAmount = HungerData.Hunger / MAXIMUMLIMIT;
                HungerText.SetText($"{HungerData.Hunger.ToString()}");
                hungercount = 0;
            }
        }
        
        while (HungerData.Hunger == 0)
        { 
            HungerData.Health -= 1.0f;
            HungerData.Mana -= 1.0f;
        }
        
    }

    
    public void SettingGauge()
    {   
        UserData HealthReset = UserData.Instance;
        UserData ManaReset = UserData.Instance;
        UserData HungerReset = UserData.Instance;
       
        healthGauge.fillAmount = HealthReset.Health / MAXIMUMLIMIT;
        HealthText.SetText(HealthReset.Health.ToString());
        
        manaGauge.fillAmount = ManaReset.Mana / MAXIMUMLIMIT;
        ManaText.SetText(ManaReset.Mana.ToString());
        
        hungerGauge.fillAmount = HungerReset.Hunger / MAXIMUMLIMIT;
        HungerText.SetText($"{HungerReset.Hunger.ToString()}");
    }
}