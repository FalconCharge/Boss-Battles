using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordCollision : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private GameObject sparks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponentInParent<BossBase>().TakeDamage(damage);
            GameObject sparksInstance = Instantiate(sparks, collision.ClosestPoint(transform.position), transform.rotation * Quaternion.Euler(0f, 0f, 90f));
            Destroy(sparksInstance, 1f);
        }
    }
}
