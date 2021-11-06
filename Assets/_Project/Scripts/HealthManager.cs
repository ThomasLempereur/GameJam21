using System.Collections.Generic;
using UnityEngine;

public class HealthManager : SingletonBehaviour<HealthManager>, IHealthManager
{
    [SerializeField] private GameObject heartUp;
    [SerializeField] private Transform hearthBar;
    [SerializeField] private int numberHeart;
    private List<GameObject> hearts;

    private int actualHealth;

    public void Reset()
    {
        if (hearts != null)
        {
            DecreaseUp(hearts.Count);
        }
        else
        {
            hearts = new List<GameObject>();
        }
        actualHealth = 0;
        for (int i = 0; i < numberHeart; i++)
        {
            IncreaseUp();
        }
    }

    public int IncreaseUp()
    {
        if (actualHealth < numberHeart)
        {
            Vector3 heartPosition = new Vector3();

            if (hearts.Count == 0)
            {
                heartPosition = new Vector3(-278f, 74f, 0f);

            }
            else
            {
                GameObject lastHeart = hearts[hearts.Count - 1];
                RectTransform rTransformLastheart = lastHeart.GetComponent<RectTransform>();
                heartPosition = new Vector3(rTransformLastheart.localPosition.x + 40f, 74f, 0f);
            }

            GameObject newHeart = Instantiate(heartUp, hearthBar);
            RectTransform rt = newHeart.GetComponent<RectTransform>();
            rt.localPosition = heartPosition;

            hearts.Add(newHeart);
            return actualHealth++;
        }

        return actualHealth;
    }

    public int DecreaseUp(int numberLostHearts)
    {
        for (int i = 0; i < numberLostHearts; i++)
        {
            if (actualHealth == 0)
            {
                break;
            }
            GameObject heartToRemove = hearts[actualHealth - 1];
            hearts.Remove(heartToRemove);
            Destroy(heartToRemove);
            actualHealth--;
        }
        return actualHealth;
    }

    public int GetActualHearth()
    {
        return actualHealth;
    }

    public int GetMaximumHearth()
    {
        return numberHeart;
    }

    public void SetMaximumHearth(int max)
    {
        numberHeart = max;
    }

}
