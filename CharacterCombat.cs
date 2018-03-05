using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This resorts combat for all characters. */

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	public float attackRate = 1f;
	private float attackCountdown = 0f;
    private float attackDelay = .6f;

	public event System.Action OnAttack;

	public Transform healthBarPos;

	CharacterStats myStats;
	CharacterStats enemyStats;


	void Start ()
	{
		myStats = GetComponent<CharacterStats>();
		HealthUIManager.instance.Create (healthBarPos, myStats);
	}

	void Update ()
	{
		attackCountdown -= Time.deltaTime;
	}

	public void Attack (CharacterStats enemyStats)
	{
		if (attackCountdown <= 0f)
		{
			this.enemyStats = enemyStats;
			attackCountdown = 1f / attackRate;

			StartCoroutine(DoDamage(enemyStats, attackDelay));

			if (OnAttack != null) {
				OnAttack ();
			}
		}
	}

	IEnumerator DoDamage(CharacterStats stats, float delay) {
		print ("Start");
		yield return new WaitForSeconds (delay);

		enemyStats.TakeDamage (myStats.damage.GetValue ());
	}


}
