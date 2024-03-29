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
    class Noguesswork : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            
            
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            player.gameObject.AddComponent<noguessworkmono>();
            if (player.GetComponent<UIhandelermono>() == null)
            {
                player.gameObject.AddComponent<UIhandelermono>();
            }

        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Destroy(player.gameObject.GetComponent<noguessworkmono>());
            
            //Run when the card is removed from the player
        }

        protected override string GetTitle()
        {
            return "No guess work";
        }
        protected override string GetDescription()
        {
            return "Every 5 seconds gain a different boost";
        }
        protected override GameObject GetCardArt()
        {
            return TCTCards.NoGuessWorkArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Different buff every 5 seconds",
                    amount = "true",
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
