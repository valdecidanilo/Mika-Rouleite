using UnityEngine;
using UnityEngine.UI;
public class Reel : MonoBehaviour
{
    public RectTransform[] symbols;
    public Sprite[] imageSymbols;
    public Sprite[] imageSpins;
    public float speed = 1f;
    private void Update()
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
}
