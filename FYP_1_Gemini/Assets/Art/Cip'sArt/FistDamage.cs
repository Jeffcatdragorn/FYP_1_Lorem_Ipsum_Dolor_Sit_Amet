using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FistDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider enemyCollider)
    {
        Enemies_Manager enemy = enemyCollider.transform.GetComponent<Enemies_Manager>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
        }
    }
}
