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

namespace TCTC.Cards.AE
{
    class Statics : CustomCard
    {


        public static CardInfo card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            statModifiers.health = 1.6f;
            statModifiers.movementSpeed = 0.7f;
            cardInfo.allowMultiple = false;
            cardInfo.categories = new CardCategory[]
            {
                CustomCardCategories.instance.CardCategory("AEclass")
            };
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.GetComponent<ECTSmono>() != null)
            {
                ECTSmono ECTS = player.GetComponent<ECTSmono>();
                ECTS.IncreaseECTS(10); 
            }
            //Edits values on player when card is selected
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.GetComponent<ECTSmono>() != null)
            {
                ECTSmono ECTS = player.GetComponent<ECTSmono>();
                ECTS.IncreaseECTS(-10);
            }
            //Run when the card is removed from the player
        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = AEclass.name;
        }

        protected override string GetTitle()
        {
            return "Statics";
        }
        protected override string GetDescription()
        {
            return "Mutualy exclusive with dynamics";
        }
        protected override GameObject GetCardArt()
        {
            return TCTCards.StaticsArt;
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
                    stat = "health",
                    amount = "+60%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Movement speed",
                    amount = "-30%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "ECTS",
                    amount = "+10",
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
