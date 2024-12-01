using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public float health = 12;
    private Animator animator;
    public GameObject puffPrefab;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > 3.5)
        {
            health -= collision.relativeVelocity.magnitude;
            animator.SetFloat("Health", health);

            if (health <= 0)
            {
                Instantiate(puffPrefab, transform.position, transform.rotation);
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
