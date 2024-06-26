using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Machine : MonoBehaviour
{
    [Header("Machine")]
    public Button spin;
    public Reel[] reels;
    public float timeMax = 2f;
    public float time = 0;
    public bool spining;
    [Header("Wallet")]
    public float credit;
    public float bet;
    public float maxBet = 10f;
    public TMP_Text txtHelper;

    private string[] helper =
    {
        "Good Luck!",
        "Place your bets!"
    };
    [Header("View")] public TMP_Text txtCredit, txtBet;
    private void Start()
    {
        spin.onClick.AddListener(ClickSpin);
        credit = 10000;
        bet = 1;
        UpdateView();
    }

    private void ClickSpin()
    {
        credit -= bet = Mathf.Clamp(bet, 0, 9999999999);
        UpdateView();
        txtHelper.text = helper[0];
        StartCoroutine(nameof(Waiting));
    }

    public void PlusBet()
    {
        bet += 1;
        UpdateView();
    }

    public void MinusBet()
    {
        bet -= 1;
        UpdateView();
    }
    private void UpdateView()
    {
        // KKKK
        txtCredit.text = "R$ " + credit.ToString("N2");
        txtBet.text = "R$ " + bet.ToString("N2");
    }
    private void Update()
    {
        if (!spining) return;
        if (time > 0)
            time -= 1f * Time.deltaTime;
        else
        {
            time = 0;
            StartCoroutine(nameof(Stoping));
        }
    }

    private IEnumerator Stoping()
    {
        foreach (var r in reels)
        {
            yield return new WaitForSeconds(0.2f);
            r.isActive = false;
        }
        spining = false;
        txtHelper.text = helper[1];
    }
    private IEnumerator Waiting()
    {
        foreach (var r in reels)
        {
            yield return new WaitForSeconds(0.1f);
            r.isActive = true;
        }
        spining = true;
        time = timeMax;
    }
}
