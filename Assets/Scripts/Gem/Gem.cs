/*	Author: Powered by Coffee
 * 	Description: Gem object for upgrade player gear
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Gem
{
	private float bonus;
	private char element;
	private int grade;
	public Gem()
	{
		bonus = 0;
		element = 'N';
		grade = 0;
	}
	public void setGrade(int grade)
	{
		this.grade = grade;
	}
	public int getGrade()
	{
		return this.grade;
	}
	public void setBonus(float bonus)
	{
		this.bonus = bonus;
	}
	public float getBonus()
	{
		return this.bonus;
	}
	public void setElement(char element)
	{
		this.element = element;
	}
	public char getElement()
	{
		return this.element;
	}
}
