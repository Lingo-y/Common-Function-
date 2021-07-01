using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Damage : MonoBehaviour
{
    public float maxHP = 100;
    public float currentHP=100;
    private Image HP_Effect;
    private Image HP_Point;
    private Damage damage;

    private void Awake()
    {
        currentHP = maxHP;
        HP_Point = GameObject.Find("Canvas/HP_Point").GetComponent<Image>();
        HP_Effect = GameObject.Find("Canvas/HP_Effect").GetComponent<Image>();
       
    }

    IEnumerator Hurt()
    {
        HP_Point.fillAmount = currentHP / maxHP;
        while (HP_Point.fillAmount <= HP_Effect.fillAmount)
        {
            HP_Effect.fillAmount -= 0.003f;
            yield return new WaitForSeconds(0.005f);
        }
        if (HP_Point.fillAmount > HP_Effect.fillAmount)
            HP_Effect.fillAmount = HP_Point.fillAmount;
    }

    public void Attack() {
        if (currentHP <= 0)
            return;
        currentHP -= 10;
        StartCoroutine(Hurt());
    }
}
