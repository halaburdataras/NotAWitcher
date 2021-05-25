using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int maxHealth = 100;

        private int _curHealth;
        public int curHealth
        {
            get { return _curHealth; }
            set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
        }

        public void Init()
        {
            curHealth = maxHealth;
        }
    }

    public PlayerStats stats = new PlayerStats();

    [SerializeField]
    private StatusIndicator statusIndicator;

    void Start()
    {
        stats.Init();

        if(statusIndicator == null)
        {
            Debug.LogError("No status indicator on player");
        }
        else
        {
            statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
        }
    }

    public Transform damageIndicator;
    public Transform gameOverScreen;

    public void DamagePlayer(int damage)
    {
        stats.curHealth -= damage;
        if(stats.curHealth <= 0)
        {
            damageIndicator.gameObject.SetActive(false);
            gameOverScreen.gameObject.SetActive(true);
            GameMaster.KillPlayer(this);
            Debug.Log("Add kill method in GM");
        }

        statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
    }
}
