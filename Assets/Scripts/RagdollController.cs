using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    [SerializeField] List<Rigidbody> ragdollElements;

    private Animation enemyAnimation;

    private void Start()
    {
        enemyAnimation = gameObject.GetComponent<Animation>();
        SetRagdoll(false);
    }

    public void SetRagdoll(bool state)
    {
        enemyAnimation.enabled = !state;
        foreach (Rigidbody rigibody in ragdollElements)
        {
            rigibody.isKinematic = !state;
        }
    }
}

