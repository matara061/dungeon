﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable
{
	// Damage
	public int damage = 1;
	public float pushForce = 5;

	//public bool Damage;

	protected override void OnCollide(Collider2D coll)
	{

		if (coll.tag == "Fighter" && coll.name == "Player")
		{
			

			// create a new damage object, before sending it o the player 
			Damage dmg = new Damage
			{

				damageAmount = damage,
				origin = transform.position,
				pushForce = pushForce
			};


			//Debug.Log(coll.name);
			coll.SendMessage("ReceiveDamage", dmg);
		}
	}


}