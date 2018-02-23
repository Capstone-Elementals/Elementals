/*	Author: Powered by Coffee
 * 	Description: Player Stats will be stored here
 * 
 * 
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats 
{
	private float Vitality;
	private float Strength;

	public Stats()
	{
		Vitality = 1;
		Strength = 1;
	}
	 public Stats(float vit, float str)
	{
		Vitality = vit;
		Strength = str;
	}
	public void setVitality(float vit)
	{
		Vitality = vit;
	}
	public void setStrength(float str)
	{
		Strength = str;
	}
	public float getVitality()
	{
		return Vitality;
	}
	public float getStrength()
	{
		return Strength;
	}
}
