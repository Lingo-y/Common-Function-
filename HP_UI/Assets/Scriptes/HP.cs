using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    private Image HP_Effect;
    private Image HP_Point;
    private Damage damage;

    private void Awake()
    {
        HP_Point = GameObject.Find("Canvas/HP_Point").GetComponent<Image>();
        HP_Effect = GameObject.Find("Canvas/HP_Effect").GetComponent<Image>();
        damage = GameObject.Find("Canvas/Button_Damge").GetComponent<Damage>();
        StartCoroutine(Hurt());
    }

    IEnumerator Hurt() {
        HP_Point.fillAmount = damage.currentHP / damage.maxHP;
        while (HP_Point.fillAmount<=HP_Effect.fillAmount) {
            HP_Effect.fillAmount -= 0.003f;
            yield return new WaitForSeconds(0.005f);
        }
        if (HP_Point.fillAmount > HP_Effect.fillAmount)
            HP_Effect.fillAmount = HP_Point.fillAmount;
    }
    //private void Update()
    //{
    //    HP_Point.fillAmount = damage.currentHP / damage.maxHP;
    //    if(HP_Point.fillAmount < HP_Effect.fillAmount)
    //    {
    //        HP_Effect.fillAmount -= 0.003f;
    //    }
    //    if (HP_Point.fillAmount > HP_Effect.fillAmount)
    //        HP_Effect.fillAmount = HP_Point.fillAmount;
    //}

}
