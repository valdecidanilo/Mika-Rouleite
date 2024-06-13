using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Reel : MonoBehaviour
{
    public RectTransform[] symbols;
    public Sprite[] imageSymbols;
    public Sprite[] imageSpins;
    public float speed = 1f;
    public bool isActive;

    public void Spin()
    {
        foreach (var s in symbols)
        {
            s.anchoredPosition = new Vector2(s.anchoredPosition.x, s.anchoredPosition.y - speed * Time.deltaTime);
            if (s.anchoredPosition.y < -973.0001f)
            {
                s.GetComponent<Image>().sprite = imageSymbols[Random.Range(0, imageSymbols.Length)];
                s.anchoredPosition = new Vector2(s.anchoredPosition.x, 102f);
            }
        }
    }
    
    private void Update()
    {
        if(isActive) Spin();
    }
}
