using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QteBotao : MonoBehaviour
{
    [SerializeField] List<GameObject> previousObjects;
    public float maxTimer, timer = 0;
    [Range(0, 1)]
    [SerializeField] float speed;
    [SerializeField] Color test, start, original, tap, disappear;
    [SerializeField] Image img;
    [SerializeField] TMP_Text txt;
    [SerializeField] Button button;
    QteStreak streak;
    float timer1 = 0, timer2 = 0;

    void Awake()
    {
        streak = new QteStreak();
    }

    void Update()
    {
        if (!button.IsInteractable())
            return;

        if (timer < maxTimer)
            timer += Time.deltaTime * speed;

        if (timer < maxTimer * 1 / 5)
        {
            img.color = Color.Lerp(start, original, (timer / (maxTimer * 1 / 5)));
            txt.color = Color.Lerp(start, Color.black, timer / (maxTimer * 1 / 5));
            timer1 = timer;
        }
        else if (timer >= maxTimer * 1 / 2 && timer < maxTimer * 5 / 8)
        {
            img.color = Color.Lerp(original, tap, Mathf.Abs((timer - (maxTimer * 1 / 2)) / ((maxTimer * 5 / 8) - (maxTimer * 1 / 2))));
        }
        else if (timer >= maxTimer * 9 / 10)
        {
            //print($"{} of {}");
            img.color = Color.Lerp(tap, disappear, Mathf.Abs((timer - (maxTimer * 9 / 10)) / (maxTimer - (maxTimer * 9 / 10))));
            txt.color = Color.Lerp(Color.black, disappear, Mathf.Abs((timer - (maxTimer * 9 / 10)) / (maxTimer - (maxTimer * 9 / 10))));
        }
        if (timer >= maxTimer)
        {

            streak.ResetStreak();
            button.interactable = false;
        }
    }



    public void Tap()
    {
        print("tapeou");
        button.interactable = false;
        img.color = disappear;
        txt.color = disappear;

        bool foundActivePo = false;
        foreach (GameObject po in previousObjects)
        {
            if (po.activeSelf && po.GetComponent<Button>().IsInteractable())
            {
                print($"found active one");
                foundActivePo = true;
                po.GetComponent<QteBotao>().timer = maxTimer;
            }
        }
        if (foundActivePo)
        {
            streak.ResetStreak();
            foundActivePo = false;
        }

        if (timer >= maxTimer * 1 / 2 && timer < maxTimer * 3 / 4)
        {
            streak.AddStreak(50);
        }
        else
        {
            streak.AddStreak(25);
        }
    }
}
