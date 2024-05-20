using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	public int maxHealth = 500;
	public int health;
	public TMP_Text textDamage;
	public bool isInvulnerable = false;
	
	private void Start()
	{
		health = maxHealth;
	}
	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;
		StartCoroutine(CreateTextDamage(damage));
		health -= damage;

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Destroy(gameObject);
	}
	
	IEnumerator CreateTextDamage(int damageVal)
	{
		TMP_Text text = Instantiate(textDamage,
			new Vector2(transform.position.x + UnityEngine.Random.Range(-1, 1), transform.position.y + UnityEngine.Random.Range(-1, 1)),
			Quaternion.identity);
		text.text = damageVal + "";
		yield return new WaitForSeconds(0.7f);
		Destroy(text.gameObject);
	}

}
