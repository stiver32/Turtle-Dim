using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class SpellCooldown : MonoBehaviour
{
    Guard guardS;
    public Image imageCooldown;
    public TMP_Text textCooldown;

    public bool isCooldown = false;
    public float cooldownTime = 10.0f;
    public float cooldownTimer = 0.0f;




    // Start is called before the first frame update
    void Start()
    {

        guardS = FindObjectOfType<Guard>();
        if (guardS == null)
        {
            Debug.LogError("Guard component not found in the scene.");
        }

        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;


    }



    private void Update()
    {

        if (guardS != null)
        {
            if (isCooldown)
            {
                ApplyCooldown();
            }
        }

    }

    // Update is called once per frame
    public void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;

            guardS.StopGuarding(); // Ensure guarding stops when cooldown ends
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = cooldownTimer / cooldownTime;
        }
    }

    public void UseSpell()
    {
        if (isCooldown)
        {
            //clicked while in use
        }
        else
        {
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
        }

    }



}
