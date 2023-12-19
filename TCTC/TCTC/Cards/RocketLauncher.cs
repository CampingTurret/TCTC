using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using TCTC.MonoBehaviors;


namespace TCTC.Cards
{
    class RocketLauncher : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            gun.gravity = 0f;
            gun.bulletDamageMultiplier = 1.40f;
            gun.projectileSpeed = 0.3f;
            gun.ammo = -1;
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.attackSpeed *= 3f;
            GameObject gameObject = (GameObject)Resources.Load("0 cards/Thruster");
            List<ObjectsToSpawn> list = gun.objectsToSpawn.ToList<ObjectsToSpawn>();
            list.Add(new ObjectsToSpawn
            {
               AddToProjectile = new GameObject("A_RocketLaunch", new Type[] { typeof(Rocketmono) })
            });

            ObjectsToSpawn obj1 = gameObject.GetComponent<Gun>().objectsToSpawn[0];
            obj1.scaleFromDamage = 0;
            obj1.stickToAllTargets = false;
            //list.Add(obj1);
            GameObject gameObject2 = (GameObject)Resources.Load("0 cards/Explosive bullet");
            //gun.soundGun.AddSoundImpactModifier(gameObject2.GetComponent<Gun>().soundImpactModifier);
            list.Add(gameObject2.GetComponent<Gun>().objectsToSpawn[0]);
            gun.objectsToSpawn = list.ToArray();
            //Edits values on player when card is selected
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
        }

        protected override string GetTitle()
        {
            return "Rocket Launcher";
        }
        protected override string GetDescription()
        {
            return "Turn your gun into a rocket launcher. Based on SmartMario1's version";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Damage",
                    amount = "+40%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Projectile speed",
                    amount = "-70%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Attack speed",
                    amount = "-67%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Ammo",
                    amount = "-1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }
        public override string GetModName()
        {
            return TCTCards.ModInitials;
        }
    }
}
