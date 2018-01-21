using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats {
	private float Vitality;
	private float Strength;

	Stats(){
		Vitality = 0;
		Strength = 0;
	}
	Stats(float vit, float str){
		Vitality = vit;
		Strength = str;
	}
	public void setvit(float vit){
		Vitality = vit;
	}
	public void setstr(float str){
		Strength = str;
	}
	public float getvit(){
		return Vitality;
	}
	public float getstr(){
		return Strength;
	}
}
