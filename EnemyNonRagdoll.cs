using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/* This makes our enemy interactable. */

[RequireComponent(typeof(CharacterStats))]
public class EnemyNonRagdoll : Interactable
{
    CharacterStats stats;
    Animator anim;
    EnemyController rotation;
    NavMeshAgent agent;
    
    void Start()
    {
        stats = GetComponent<CharacterStats>();
        stats.OnHealthReachedZero += Die;
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rotation = GetComponent<EnemyController>();
    }

    // When we interact with the enemy: We attack it.
    public override void Interact()
    {
        //print ("Interact");
        CharacterCombat combatManager = Player.instance.playerCombatManager;
        combatManager.Attack(stats);
    }

    public void Die()
    {
        //Tried using SetBool("dead", true) to make a transition but did not work... Otherwise what would the point
        //of transitions be?
        //anim.SetTrigger("death");
        agent.speed = 0f;        
        anim.Play("die");
        Destroy(rotation);
        Destroy(gameObject, 5f);        
    }
}