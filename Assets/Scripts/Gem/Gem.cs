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
	private char element;
	private int grade;
	public Gem()
	{
		element = 'N';
		grade = 0;
	}
	public Gem(char newelement, int newgrade)
	{
		element = newelement;
		grade = newgrade;
	}
	public void setGrade(int grade)
	{
		this.grade = grade;
	}
	public int getGrade()
	{
		return this.grade;
	}
	public void setElement(char element)
	{
		this.element = element;
	}
	public string getElementS()
	{
		switch (this.element) {
		case 'F':
			return "Fire";
			break;
		case 'A':
			return "Air";
			break;
		case 'E':
			return "Earth";
			break;
		case 'W':
			return "Water";
			break;
		default:
			return "";
			break;
		}
		return "";
	}
	public char getElement()
	{
		return this.element;
	}
}
