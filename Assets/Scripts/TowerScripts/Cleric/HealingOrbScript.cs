using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrbScript : MonoBehaviour
{
	[Header("References")]
	[SerializeField] private Rigidbody2D rb;
    
	[Header("Attributes")]
	[SerializeField] private float bulletSpeed;
	[SerializeField] private int bulletDmg;
    
	private Transform target;

	public void SetTarget(Transform _target)
	{
		target = _target;
	}

	private void FixedUpdate()
	{
		if (!target) return;
        
		Vector2 direction = (target.position - transform.position).normalized;
        
		rb.velocity = direction * bulletSpeed;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other == null)
			return;
		other.gameObject.GetComponent<TowerHealthManager>().Heal(bulletDmg);
		Destroy(gameObject);
	}
}
