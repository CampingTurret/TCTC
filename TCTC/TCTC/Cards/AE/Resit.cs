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

namespace TCTC.Cards.AE
{
    class ResitAE : CustomCard
    {


        public static CardInfo card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            
            cardInfo.categories = new CardCategory[]
            {
                CustomCardCategories.instance.CardCategory("CardManipulation")
            };
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            for (int i = 0; i < 2; i++)
            {
                CardInfo cardInfo = ModdingUtils.Utils.Cards.instance.NORARITY_GetRandomCardWithCondition(player, gun, gunAmmo, data, health, gravity, block, characterStats, new Func<CardInfo, Player, Gun, GunAmmo, CharacterData, HealthHandler, Gravity, Block, CharacterStatModifiers, bool>(this.Condition), 1000);
                if (cardInfo.categories.Intersect(ResitAE.yesCardCategories).Any<CardCategory>())
                {
                
                    ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, cardInfo, false, "", 0f, 0f, true);
                    CardBarUtils.instance.ShowAtEndOfPhase(player, cardInfo);
                }   
            }
            //Edits values on player when card is selected
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            
            //Run when the card is removed from the player
        }
        public override void Callback()
        {
            gameObject.GetOrAddComponent<ClassNameMono>().className = AEclass.name;
        }

        protected override string GetTitle()
        {
            return "Resit";
        }
        protected override string GetDescription()
        {
            return "Redo some of your failed exams";
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
                    stat = "AE subjects",
                    amount = "+2",
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

        public bool Condition(CardInfo card, Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            return !card.categories.Intersect(ResitAE.noCardCategories).Any<CardCategory>() && card.categories.Intersect(ResitAE.yesCardCategories).Any<CardCategory>();
        }
        public static CardCategory[] noCardCategories = new CardCategory[]
        {
            CustomCardCategories.instance.CardCategory("CardManipulation"),
            CustomCardCategories.instance.CardCategory("NoRandom")
        };
        public static CardCategory[] yesCardCategories = new CardCategory[]
        {
            CustomCardCategories.instance.CardCategory("AEclass")
            
        };
    }
}
