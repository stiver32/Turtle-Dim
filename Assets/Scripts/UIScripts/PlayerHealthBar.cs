using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public GameObject heartPrefab;
    public PlayerScript playerHealth;

    List<HealthHeart> hearts = new List<HealthHeart>();



    private void OnEnable()
    {
        PlayerScript.OnPlayerDamaged += DrawHearts;

    }

    private void OnDisable()
    {
        PlayerScript.OnPlayerDamaged -= DrawHearts;
    }




    private void Start()
    {
        DrawHearts();

    }


    public void DrawHearts()
    {
        ClearHearts();


        float maxHealthRemainder = playerHealth.maxHealth % 2;
        int heartsToMake = (int)((playerHealth.maxHealth / 2) + maxHealthRemainder);



        for (int i = 0; i < heartsToMake; i++)
        {
            CreateEmptyHeart();
        }

        for (int i = 0; i < hearts.Count; i++)
        {

            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - (i*2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }

    }


    public void CreateEmptyHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);
        
        
        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();

        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }


    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }

        hearts = new List<HealthHeart>();
    }

}
            
