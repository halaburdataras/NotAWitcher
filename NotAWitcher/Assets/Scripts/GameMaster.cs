using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public static GameMaster gm;

    private AudioManager audioManager;

    public string mainThemeSound;

    private bool isPlaying = false;

    void Start()
    {
        if(gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }

        audioManager = AudioManager.instance;

        if (audioManager == null)
        {
            Debug.LogError("No AudioManager found in the scene");
        }
    }

    void Update()
    {
        if (!isPlaying)
        {
            isPlaying = !isPlaying;
            audioManager.PlaySound(mainThemeSound);
        }
    }

    public static void KillPlayer (Player player)
    {
        Destroy(player.gameObject);
    }

    public static void KillEnemy(Enemy enemy)
    {
        Transform deadBody = Instantiate(enemy.deadEnemyPrefab, enemy.transform.position, enemy.transform.rotation);
        Destroy(enemy.gameObject);
        Destroy(deadBody.gameObject, 10f);
    }
}
