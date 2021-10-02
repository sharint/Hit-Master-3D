using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int currentWaypoint;
    [SerializeField] Slider healthBar;

    private SceneController sceneController;
    private RagdollController ragdollController;

    private int health = 3;

    private void Start()
    {
        GameObject sceneControllerGameObject = GameObject.Find("Controller");
        sceneController = sceneControllerGameObject.GetComponent<SceneController>();
        ragdollController = gameObject.GetComponent<RagdollController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            EnemyHitted();
        }
    }

    private void EnemyHitted()
    {
        HitEnemy();
        if (isEnemyDead())
        {
            KillEnemy();
        }
    }

    private void HitEnemy()
    {
        health -= 1;
        healthBar.value -= 1;
    }

    private bool isEnemyDead()
    {
        if (health == 0)
        {
            return true;
        }
        return false;
    }

    private void KillEnemy()
    {
        sceneController.EnemyDied(currentWaypoint);
        Destroy(healthBar.gameObject);
        ragdollController.SetRagdoll(true);
    }
}
