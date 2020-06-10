﻿using UnityEngine;

public class Ahss : OdmgEquipment, Weapon
{
    [SerializeField] public int maxAmmo = 7;
    public int leftGunAmmo { get; set; }
    public int rightGunAmmo { get; set; }
    public bool leftGunLoaded { get; set; }
    public bool rightGunLoaded { get; set; }

    protected override void Awake()
    {
        leftGunAmmo = maxAmmo;
        rightGunAmmo = maxAmmo;
    }

    protected override void Update()
    {
    }

    #region Equipment Methods
    //public override void SetStats(HeroStat heroStat)
    //{
    //    base.SetStats(heroStat);
    //}

    public override void Equip()
    {
        base.Equip();

        //part_3dmg_gas_l = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Character/" + heroSetupScript.myCostume.mesh_3dmg_gas_l));
        //part_3dmg_gas_l.GetComponent<Renderer>().material = CharacterMaterials.materials[heroSetupScript.myCostume._3dmg_texture];
        //part_3dmg_gas_r = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Character/" + heroSetupScript.myCostume.mesh_3dmg_gas_r));
        //part_3dmg_gas_r.GetComponent<Renderer>().material = CharacterMaterials.materials[heroSetupScript.myCostume._3dmg_texture];

        part_3dmg_gas_l.transform.position = heroObject.transform.position;
        part_3dmg_gas_l.transform.parent = heroArmature.thigh_L;

        part_3dmg_gas_r.transform.position = heroObject.transform.position;
        part_3dmg_gas_r.transform.parent = heroArmature.thigh_R;
    }

    public override bool NeedResupply()
    {
        if (base.NeedResupply() || leftGunAmmo != maxAmmo || rightGunAmmo != maxAmmo)
            return true;

        return false;
    }

    public override void Resupply()
    {
        base.Resupply();
        leftGunAmmo = maxAmmo;
        rightGunAmmo = maxAmmo;
    }

    public override void updateSupplyUI()
    {
        base.updateSupplyUI();

        var ammoUI = myHeroScript.InGameUI.GetComponentInChildren<Assets.Scripts.UI.InGame.Weapon.AHSS>();
        ammoUI.SetAHSS(leftGunAmmo, rightGunAmmo);

        //if (leftGunLoaded)
        //    myHeroScript.cachedSprites["bulletL"].enabled = true;
        //else
        //    myHeroScript.cachedSprites["bulletL"].enabled = false;

        //if (rightGunLoaded)
        //    myHeroScript.cachedSprites["bulletR"].enabled = true;
        //else
        //    myHeroScript.cachedSprites["bulletR"].enabled = false;
    }
    #endregion

    #region Weapon Methods
    public void Attack()
    {

    }

    public void PlayReloadAnimation()
    {
        if (myHeroScript.grounded || FengGameManagerMKII.NewRoundGamemode.AhssAirReload)
        {
            myHeroScript.state = HERO_STATE.ChangeBlade;
            myHeroScript.throwedBlades = false;

            if (!leftGunLoaded && !rightGunLoaded)
            {
                if (myHeroScript.grounded)
                {
                    myHeroScript.reloadAnimation = "AHSS_gun_reload_both";
                }
                else
                {
                    myHeroScript.reloadAnimation = "AHSS_gun_reload_both_air";
                }
            }
            else if (!leftGunLoaded)
            {
                if (myHeroScript.grounded)
                {
                    myHeroScript.reloadAnimation = "AHSS_gun_reload_l";
                }
                else
                {
                    myHeroScript.reloadAnimation = "AHSS_gun_reload_l_air";
                }
            }
            else if (!rightGunLoaded)
            {
                if (myHeroScript.grounded)
                {
                    myHeroScript.reloadAnimation = "AHSS_gun_reload_r";
                }
                else
                {
                    myHeroScript.reloadAnimation = "AHSS_gun_reload_r_air";
                }
            }

            myHeroScript.crossFade(myHeroScript.reloadAnimation, 0.05f);
        }
    }
    #endregion

    #region AHSS Methods
    #endregion
}