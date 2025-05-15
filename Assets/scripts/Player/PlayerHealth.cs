using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int Hp;
    public int maxhp;

    public Image[] hearts;
    public Sprite fullheart;
    public Sprite halfheart;
    public Sprite emptyheart;

    void Update()
    {
        if (Hp > maxhp)
        {
            Hp = maxhp; 
        } else if (Hp < 0) { Hp = 0; }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            damageHP(3);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            healHP(3);
        }
    }

    public void damageHP(int damageAmount)
    {
        for (int i = 0; i < damageAmount; i++)
        {
            Hp -= 1;
            updatehp();
        }
    }

    public void healHP(int healAmount)
    {
        for (int i = 0; i < healAmount; i++)
        {
            Hp += 1;
            updatehp();
        }
    }

    public void updatehp()
    {

        for (int i = 0; i < Hp; i++)
        {
            float temphp = Mathf.Clamp(Hp - (i * 2), 0, 2);

            switch (temphp)
            {
                case 0:
                    hearts[i].sprite = emptyheart;
                    break;
                case 1:
                    hearts[i].sprite = halfheart;
                    break;
                case 2:
                    hearts[i].sprite = fullheart;
                    break;
            }
        }
    }
}
