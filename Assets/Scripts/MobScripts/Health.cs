using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 7;
    [SerializeField] private int goldDrop = 25;
    [SerializeField] private int citizenKills = 1;

    private bool isDestroyed = false;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.AddGold(goldDrop);
            isDestroyed = true;
            Destroy(gameObject);
        }
    }

    public void DoDamage()
    {
	    LevelManager.main.LoseLife(citizenKills);
    }
}
