/*	Author: Powered by Coffee
 * 	Description: Weapons object, Controls all damage output of player
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {
	private Gem gem1;
	private Gem gem2;
	private Gem gem3;
	private float damage;
	private float bonusDamage;
	private float totalDamage;
	public Weapon(){
		gem1 = new Gem();
		gem2 = new Gem();
		gem3 = new Gem();
		damage = 1;
		bonusDamage = 0;
		totalDamage = 0;
	}
	public Weapon(Gem gem1, Gem gem2, Gem gem3, float damage){
		this.gem1 = gem1;
		this.gem2 = gem2;
		this.gem3 = gem3;
		this.damage = damage;
		calculateBonusDamage ();
		calculateTotalDamage ();
	}
	public void setGem1(Gem gem){
		this.gem1 = gem;
	}
	public void setGem2(Gem gem){
		this.gem2 = gem;
	}
	public void setGem3(Gem gem){
		this.gem3 = gem;
	}
	public Gem getGem1(){
		return this.gem1;
	}
	public Gem getGem2(){
		return this.gem2;
	}
	public Gem getGem3(){
		return this.gem3;
	}
	public void setDamage(float damage){
		this.damage = damage;
	}
	public float getBonusDamage(){
		return this.bonusDamage;
	}
	public void setBonusDamage(float damage){
		this.bonusDamage = damage;
	}
	public float getTotalDamage(){
		return this.totalDamage;
	}
	public void setTotalDamage(float damage){
		this.totalDamage = damage;
	}
	public float getDamage(){
		return this.damage;
	}
	public void calculateBonusDamage(){
		float temp;
		temp = (gem1.getBonus () * damage) + (gem2.getBonus () * damage) + (gem3.getBonus () * damage);
		setBonusDamage (temp);
	}
	public void calculateTotalDamage(){
		float temp;
		temp = bonusDamage + damage;
		setTotalDamage (temp);
	}


}
