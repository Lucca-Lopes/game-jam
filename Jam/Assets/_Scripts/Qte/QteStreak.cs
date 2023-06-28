using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QteStreak
{
    public static int streakTaps = 0;
    public static int score = 0;

    public void ResetStreak(){
        streakTaps = 0;
    }
    public void AddStreak(double points){
        streakTaps++;

        PlayerManager.Instance.pontuacaoTotal += points * streakTaps;

        //adicionar score no score total do personagem durante a batalha
        Debug.Log($"streak: {streakTaps}");
    }
}
