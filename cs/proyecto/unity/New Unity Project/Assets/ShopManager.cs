﻿using UnityEngine;
using System.Collections;

public class ShopManager : MonoBehaviour {
	
	public int Cost1;
	public int Cost2;

	public int LevelOfSword;
	public bool waterIsOn;
	public bool thunderIsON;
	public int LevelOfAxe;
	public int LevelOfBow;

	public bool [] skills;

	public Animator anim;
	public Animator animPlayer;

	public GameObject weapon;
	public GameObject player;

	public Sprite StandarSword;
	public Sprite SwordAgua;
	public Sprite SwordAguaCargada;
	public GoldManager gold;
	public GameObject hover;
	private bool canChange = false;
	private bool canChangeArmor = false;
	public string weaponInUsage;
	public string armorInUsage;

	private PlayerStats PS;
	private PotionManager PM;
	//public GameObject SwordRayo;

	// Use this for initialization
	void Start () {
		PM= FindObjectOfType<PotionManager> ();
		PS = FindObjectOfType<PlayerStats> ();
		gold = FindObjectOfType<GoldManager> ();
		//hover.SetActive(false);
		waterIsOn = false;
		thunderIsON = false;
		weapon = GameObject.Find ("sword");
		anim = weapon.GetComponent<Animator> ();

		player = GameObject.Find ("Player");
		animPlayer = player.GetComponent<Animator> ();

		LevelOfSword = 0;
	    //anim = weapon.GetComponent<Animator> (); DEBERÍA ARREGLARLO ALGÚN DÍA
	}
	
	// Update is called once per frame
	void Update () {
		if (canChange) {
			canChange = false;
			anim.SetBool ("Standar", false);
			anim.SetBool ("Water", false);
			anim.SetBool ("Thunder", false);
			anim.SetBool ("FireSword", false);
			anim.SetBool ("ThunderAxe", false);
			anim.SetBool ("FireAxe", false);
			anim.SetBool ("StandardBow", false);
			anim.SetBool ("WaterAxe", false);
			anim.SetBool ("BloodAxe", false);
			anim.SetBool (weaponInUsage, true);
		}

		if (canChangeArmor) {
			canChangeArmor = false;
			animPlayer.SetBool ("isStandard", false);
			animPlayer.SetBool ("isArmorRed", false);
			animPlayer.SetBool (armorInUsage, true);
		}

	}
	public void catchNameOfWeapon(string nameofweapon)
	{
		if (gold.gold >= 100 ) {
			
		weaponInUsage = nameofweapon;
		PS.saveWeapon (nameofweapon);
		canChange = true;
		
		LevelOfSword = 0;
			gold.gold -= 100;
		}

	}
	public void catchNameOfWeaponFORSCENES(string nameofweapon)
	{
			weaponInUsage = nameofweapon;
			canChange = true;
	
	}

	public void catchNameOfArmor(string nameofarmor)
	{
		if (gold.gold >= 100 ) {
			armorInUsage = nameofarmor;
			PS.saveArmor (nameofarmor);
			canChangeArmor = true;
			PS.RESLegit = PS.RESLegit + 5;
			gold.gold -= 100;
			PS.saveStats ();
		}
	}
	public void catchNameOfArmorForScenes(string nameofarmor)
	{
			armorInUsage = nameofarmor;
			canChangeArmor = true;
	}

	public void stamina()
	{
		if (gold.gold > 50) {
			gold.gold = gold.gold - 50;
			PS.STAMINALegit = PS.STAMINALegit + 10;
			PS.saveStats();
		}
	}
	public void atq()
	{
		if (gold.gold > 50) {
			gold.gold = gold.gold - 50;
			PS.ATQLegir = PS.ATQLegir + 10;
			PS.saveStats ();
		}
	}
	public void pot()
	{
		if (gold.gold > 50) {
			gold.gold = gold.gold - 50;
			PM.AddPotion (1);
		}
	}
}
