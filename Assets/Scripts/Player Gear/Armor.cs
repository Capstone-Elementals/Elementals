﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor {
	private Gem gem1;
	private Gem gem2;
	private Gem gem3;
	private float defense;
	private float bonusDefense;
	private float totalDefense;
	Armor(){
		gem1 = null;
		gem2 = null;
		gem3 = null;
	}
	Armor(Gem gem1, Gem gem2, Gem gem3, float defense){
		this.gem1 = gem1;
		this.gem2 = gem2;
		this.gem3 = gem3;
		this.defense = defense;
		calculateBonusDefense ();
		calculateTotalDefense ();
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
	public void setDefense(float defense){
		this.defense = defense;
	}
	public float getBonusDefense(){
		return this.bonusDefense;
	}
	public void setBonusDefense(float defense){
		this.bonusDefense = defense;
	}
	public float getTotalDefense(){
		return this.totalDefense;
	}
	public void setTotalDefense(float defense){
		this.totalDefense = defense;
	}
	public float getDefense(){
		return this.defense;
	}
	public void calculateBonusDefense(){
		float temp;
		temp = (gem1.getBonus () * defense) + (gem2.getBonus () * defense) + (gem3.getBonus () * defense);
		setBonusDefense (temp);
	}
	public void calculateTotalDefense(){
		float temp;
		temp = bonusDefense + defense;
		setTotalDefense (temp);
	}
}