using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using TCTC.MonoBehaviors;
using ClassesManagerReborn.Util;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using ModdingUtils.Utils;
using UnboundLib.Utils;
using TMPro;
using System.Collections.ObjectModel;
using System.Reflection;

namespace TCTC.Cards.AE
{
    class DSE: CustomCard
    {


        public static CardInfo card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {

            gun.bursts = 3;
            gun.timeBetweenBullets = 0.5f;
            gun.ammo = 4;
            gun.bulletDamageMultiplier = 1.5f;
            cardInfo.allowMultiple = false;
            cardInfo.categories = new CardCategory[]
            {
                CustomCardCategories.instance.CardCategory("AEclass")
            };
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected

            //ECTS stuff
            if (player.GetComponent<ECTSmono>() != null)
            {
                ECTSmono ECTS = player.GetComponent<ECTSmono>();
                ECTS.IncreaseECTS(15); 
            }
            
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.GetComponent<ECTSmono>() != null)
            {
                ECTSmono ECTS = player.GetComponent<ECTSmono>();
                ECTS.IncreaseECTS(-15);
            }
            //Run when the card is removed from the player
        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = AEclass.name;
        }

        protected override string GetTitle()
        {
            return "Design Synthesis";
        }
        protected override string GetDescription()
        {
            return "The final project";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Damage",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Ammo",
                    amount = "+4",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                 new CardInfoStat()
                {
                    positive = true,
                    stat = "Bullets",
                    amount = "+2",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "ECTS",
                    amount = "+15",
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
