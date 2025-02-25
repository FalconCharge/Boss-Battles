using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Hugaxium : BossBase
{
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private GameObject orb;

    [SerializeField] private float startSpecialAttack;
    private float timeBTWSpecialAttack;

    private void Update()
    {
        if (timeBTWSpecialAttack >= startSpecialAttack)
        {
            SpecialAttack();
            timeBTWSpecialAttack = 0;
        }
        else{ timeBTWSpecialAttack += Time.deltaTime;}
    }

    private void SpecialAttack()
    {
        //Start animation for Power UP!
        PowerUP();
    }
    private void PowerUP()
    {
        //I'm thinking I'll instanciate several orbs in their spawnpoints locations And have the animation start on awake and which will start as nothing and grow
        //To their right size

        //Spawn in 8 orbs!
        for(int i = 0; i < spawnPoints.Count; i++)
        {
            Instantiate(orb, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
        }
        Debug.Log("Spawned the orbs!");


    }
}
