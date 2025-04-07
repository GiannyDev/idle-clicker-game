using System;
using UnityEngine;

public class GoldManager : Singleton<GoldManager>
{
    [SerializeField] private float testGold = 0;
    
    public float CurrentGold { get; set; }
    private readonly string GOLD_KEY = "MY_GOLD";

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        LoadGold();
    }

    private void LoadGold()
    {
        CurrentGold = PlayerPrefs.GetFloat(GOLD_KEY, testGold);
    }
    
    public void AddGold(float amount)
    {
        CurrentGold += amount;
        PlayerPrefs.SetFloat(GOLD_KEY, CurrentGold);
        PlayerPrefs.Save();
    }

    // 15
    public void RemoveGold(float amount) // 10
    {
        if (amount <= CurrentGold)
        {
            CurrentGold -= amount;
            PlayerPrefs.SetFloat(GOLD_KEY, CurrentGold);
            PlayerPrefs.Save();
        }
    }
}