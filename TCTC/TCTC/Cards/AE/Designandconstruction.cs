﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using TCTC.MonoBehaviors;
using ClassesManagerReborn.Util;

namespace TCTC.Cards.AE
{
    class DAC : CustomCard
    {

        public static CardInfo card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            statModifiers.health = 3f;
            cardInfo.allowMultiple = false;
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            if (player.GetComponent<ECTSmono>() != null)
            {
                ECTSmono ECTS = player.GetComponent<ECTSmono>();
                ECTS.IncreaseECTS(15); 
            }
            Stressmono x = player.gameObject.AddComponent<Stressmono>();
            x.damage = 10;
            x.timetildot = 15;
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
            return "Aerospace Design and Construction";
        }
        protected override string GetDescription()
        {
            return "Mutualy exclusive with Exploring Aerospace Engineering";
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
                    stat = "Health",
                    amount = "+200%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Stress damage",
                    amount = "10",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "time until stress",
                    amount = "15s",
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
