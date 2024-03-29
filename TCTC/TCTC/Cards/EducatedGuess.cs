﻿using System;
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
    class Educatedguess : CustomCard
    {
        public static CardInfo card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            
            
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            player.gameObject.AddComponent<Educatedguessmono>();
            if (player.GetComponent<UIhandelermono>() == null)
            {
                player.gameObject.AddComponent<UIhandelermono>();
            }

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Destroy(player.gameObject.GetComponent<Educatedguessmono>());
            
            //Run when the card is removed from the player
        }

        protected override string GetTitle()
        {
            return "Educated guess";
        }
        protected override string GetDescription()
        {
            return "Every 5 seconds flip an unfair coin, heads means a stat boost, while tails means a debuff";
        }
        protected override GameObject GetCardArt()
        {
            return TCTCards.EducatedGuessArt;
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
                    stat = "on heads:",
                    amount = "Buff",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "on tails:",
                    amount = "Debuff",
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
