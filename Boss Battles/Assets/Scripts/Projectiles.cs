using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{

    [SerializeField] float moveSpeed;
    
    void Update()
    {
        moveforward(); //Moves forward Would need to switch by 90 degrees
    }
    private void moveforward()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }
}
