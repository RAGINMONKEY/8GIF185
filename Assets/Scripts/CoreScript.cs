using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CoreScript : MonoBehaviour
{
    [SerializeField] private int baseCoreHP;
    [SerializeField] private Image defeatImage = null;
    [SerializeField] private HealthBar healthBar = null;

    public int currentCoreHP;
    
    void Start()
    {
        currentCoreHP = baseCoreHP;
        defeatImage.enabled = false;
        healthBar.SetMaxHealth(baseCoreHP);
    }

    public void LoseHealth()
    {
        currentCoreHP--;
        healthBar.SetHealth(currentCoreHP);
    }
    private void Update()
    {
        if (currentCoreHP <= 0)
            StartCoroutine(DefeatScreen());
    }
    private IEnumerator DefeatScreen()
    {
        defeatImage.enabled =true;
        yield return new WaitForSeconds(5f);
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MenuScene");
        


    }
}
