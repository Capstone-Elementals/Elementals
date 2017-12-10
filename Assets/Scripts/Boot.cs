using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boot {
	private Gem bootgem;

	Boot (){
		bootgem = null;
	}

	public void setBootGem(Gem gem){
		bootgem = gem;
	}
	public Gem getBootGem(){
		return this.bootgem;
	}

	public void skill(){
		switch (bootgem.getElement()) {
			case 'F':
				//Fire gem bonus
				break;
			case 'A':
				//Air Gem bonus
				break;
			case 'E':
				//Earth Gem bonus
				break;
			case 'W':
				//Water Gem Bonus
				break;
			default:
				break;
		}
	}
}
