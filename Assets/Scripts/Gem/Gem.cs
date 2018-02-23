/*	Author: Powered by Coffee
 * 	Description: Gem object for upgrade player gear
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem
{
	private float bonus;
	private char element;

	public Gem()
	{
		bonus = 0;
		element = 'N';
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
