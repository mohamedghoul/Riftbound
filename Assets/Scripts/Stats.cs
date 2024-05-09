using UnityEngine.AI;
using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
    public float hp;

    public float def;

    public float atk;

    // Buffs/debuffs
    public void DebuffDef(float debuff, float duration)
    {
        StartCoroutine(DebuffDefCoroutine(debuff, duration));
    }

    public IEnumerator DebuffDefCoroutine(float debuff, float duration)
    {
        yield return new WaitForSeconds(duration);
        def += debuff;
    }

    public void BuffDef(float buff, float duration)
    {
        StartCoroutine(BuffDefCoroutine(buff, duration));
    }

        public IEnumerator BuffDefCoroutine(float debuff, float duration)
    {
        yield return new WaitForSeconds(duration);
        def -= debuff;
    }

    public void DebuffAtk(float debuff, float duration)
    {
        StartCoroutine(DebuffAtkCoroutine(debuff, duration));
    }

        public IEnumerator DebuffAtkCoroutine(float debuff, float duration)
    {
        yield return new WaitForSeconds(duration);
        atk += debuff;
    }

    public void BuffAtk(float buff, float duration)
    {
        StartCoroutine(BuffAtkCoroutine(buff, duration));
    }

    public IEnumerator BuffAtkCoroutine(float buff, float duration)
    {
        yield return new WaitForSeconds(duration);
        atk -= buff;
    }

    public void TakeDamage(float damage)
    {
        float actualDamage = damage - def;
        if (actualDamage > 0)
        {
            Debug.Log(gameObject.name + " took " + actualDamage + " damage");
            hp -= actualDamage;
            if (hp <= 0)
            {
                // If the player dies, we display a game over message
                // There is no else statement for opponents because they have their own death logic in the OpponentAI script
                if (gameObject.CompareTag("Player")){
                    Debug.Log("You died");
                    // TODO game over screen
                }
            }
        }
    }
}