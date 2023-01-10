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
    class Systemdes: CustomCard
    {

        public static CardInfo card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            statModifiers.movementSpeed = 1.5f;
            gun.bulletDamageMultiplier = 1.4f;
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
                ECTS.IncreaseECTS(15); 
            }
            Stress2mono x = player.gameObject.AddComponent<Stress2mono>();
            x.damage = 20;
            x.timetildot = 30;
            //Edits values on player when card is selected
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.GetComponent<ECTSmono>() != null)
            {
                ECTSmono ECTS = player.GetComponent<ECTSmono>();
                ECTS.IncreaseECTS(-15);
            }
            Destroy(player.gameObject.GetComponent<Stressmono>());
            //Run when the card is removed from the player
        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = AEclass.name;
        }

        protected override string GetTitle()
        {
            return "Systems Design";
        }
        protected override string GetDescription()
        {
            return "Mutualy exclusive with Test, Analysis and Simulation";
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
                    stat = "Movement speed",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
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
                    stat = "Stress damage",
                    amount = "20",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "time until stress",
                    amount = "30s",
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
