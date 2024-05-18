using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCooldown : MonoBehaviour
{
    
    [SerializeField] Image imageCooldown;
    [SerializeField] TMP_Text textCooldown;

    [SerializeField] bool isCooldown = false;
    [SerializeField] float cooldownTime = 10.0f;
    [SerializeField] float cooldownTimer = 0.0f;




    // Start is called before the first frame update
    void Start()
    {

        textCooldown.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;


    }



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseSpell();
        }
        if (isCooldown)
        {
            ApplyCooldown();
        }
    }

    // Update is called once per frame
    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;

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
