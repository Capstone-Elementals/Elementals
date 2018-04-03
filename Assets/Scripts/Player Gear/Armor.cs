/*	Author: Powered by Coffee
 * 	Description: Armor object controls all defensive player gear
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Armor 
{
	private Gem gem1;
	private float defense;
	private float bonusDefense;
	private float totalDefense;
	public Armor()
	{
		gem1 = new Gem();
		defense = 1;
		bonusDefense = 0;
		totalDefense = 0;
	}
	public Armor(Gem gem1,  float defense)
	{
		this.gem1 = gem1;
		this.defense = defense;
		calculateBonusDefense ();
		calculateTotalDefense ();
	}
	public void setGem1(Gem gem)
	{
		this.gem1 = gem;
	}
	public Gem getGem1()
	{
		return this.gem1;
	}
	public void setDefense(float defense)
	{
		this.defense = defense;
	}
	public float getBonusDefense()
	{
		return this.bonusDefense;
	}
	public void setBonusDefense(float defense)
	{
		this.bonusDefense = defense;
	}
	public float getTotalDefense()
	{
		return this.totalDefense;
	}
	public void setTotalDefense(float defense)
	{
		this.totalDefense = defense;
	}
	public float getDefense()
	{
		return this.defense;
	}
	public void calculateBonusDefense()
	{
		float temp;
		temp = (gem1.getGrade () * defense);
		setBonusDefense (temp);
	}
	public void calculateTotalDefense()
	{
		float temp;
		temp = bonusDefense + defense;
		setTotalDefense (temp);
	}
}
