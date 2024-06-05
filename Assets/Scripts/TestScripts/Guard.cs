using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class Guard : MonoBehaviour
{
    Inputs guardInput;
    SpellCooldown spellCooldown;
    float damagereduction = 1;
    public float guardTime;


    void Start()
    {
        guardInput = GetComponent<Inputs>();
        guardInput.GetComponent<Animator>();

        spellCooldown = FindObjectOfType<SpellCooldown>();
        if (spellCooldown == null)
        {
            Debug.LogError("SpellCooldown component not found on the GameObject.");
        }
    }

    void Update()
    {
        if (spellCooldown != null && spellCooldown.isCooldown)
        {
            spellCooldown.ApplyCooldown();
        }
    }

    public void GuardPressed()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (spellCooldown != null)
            {
                spellCooldown.UseSpell();

                if(guardInput.myAnimator != null)
                {
                    guardInput.myAnimator.SetTrigger("guardPressed");
                    guardInput.myAnimator.SetBool("isGuarding",true);
                }
             
            }
        }
    }

    public void StopGuarding()
    {
        if (guardInput.myAnimator != null)
        {
            guardInput.myAnimator.SetBool("isGuarding", false);
        }
    }
}


