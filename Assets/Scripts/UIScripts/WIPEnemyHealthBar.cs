using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    static HealthBar instance;

    public RectTransform fillBar;
    float maxFill;

    private void Awake()
    {
        instance = this;

        fillBar = transform.GetChild(0).GetChild(0) as RectTransform;
        if (fillBar) maxFill = Mathf.Abs(fillBar.rect.size.x);
        else Debug.Log("Fill bar not found");

    }
    public static void Set(float health)
    {
        if (!instance)
        {
            Debug.LogError("Healthbar instance not found.");
            return;
        }
        if (health != Mathf.Clamp01(health))
        {
            Debug.LogWarning("Health value should be between 0 and 1");
            health = Mathf.Clamp01(health);
        }
        instance.fillBar.offsetMax = new Vector2(-(1-health) * instance.maxFill, instance.fillBar.offsetMax.y);
    }
}