﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
	// public fields
	public int hitpoint = 10;
	public int maxHitpoint = 10;
	public float pushRecoverySpeed = 0.2f;

	// immunity
	public float immuneTime = 1.0f;
	protected float lastImmune;

	//push
	protected Vector3 pushDirection;
	

	void Start()
    {
		
	}

    // All fighters can ReceiveDamage / die
    protected virtual void ReceiveDamage(Damage dmg)
	{
		if (Time.time - lastImmune > immuneTime)
		{
			
			lastImmune = Time.time;
			hitpoint -= dmg.damageAmount;

			pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;
				//FindObjectOfType<AudioManager>().Play("Soundtrack batlle");
			

			//GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);
			if (hitpoint <= 0)
			{
				hitpoint = 0;
				Death();
			}
			//if (hitpoint >= 1)
			//{
			//	FindObjectOfType<AudioManager>().Play("EnemyDamage");
			//
			//}

		}
	}


	protected virtual void Death()
    {

    }
}
