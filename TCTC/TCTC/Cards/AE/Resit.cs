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
using UnityEngine.Diagnostics;
using ClassesManagerReborn;

namespace TCTC.Cards.AE
{
    class ResitAE : CustomCard
    {


        public static CardInfo card = null;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            
            cardInfo.categories = new CardCategory[]
            {
                CustomCardCategories.instance.CardCategory("CardManipulation"),
                CustomCardCategories.instance.CardCategory("AEclass")
            };
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            for (int i = 0; i < 2; i++)
            {
                UnityEngine.Debug.Log("pre card");
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
            bool con3 = true;
            if (added.Count > 0)
            {

                if(added[0] == card)
                {
                    UnityEngine.Debug.Log("Same Card: "+ card.cardName);
                    con3 = false;
                }
                if (ClassesRegistry.Get(added[0]).BlackList.Contains(card))
                {
                    UnityEngine.Debug.Log("Blacklisted Card" + card.cardName);
                    con3 = false;
                }
            }
            bool con4 = true;
            if (con3)
            {
                foreach(CardInfo c in player.data.currentCards)
                {
                    if (c.categories.Intersect(ResitAE.yesCardCategories).Any<CardCategory>())
                    {
                        if (ClassesRegistry.Get(c).BlackList.Contains(card))
                        {
                            con4 = false;
                        }
                    }
                }
            }

            if (!card.categories.Intersect(ResitAE.noCardCategories).Any<CardCategory>() && card.categories.Intersect(ResitAE.yesCardCategories).Any<CardCategory>() && con3 && con4)
            {
                added.Add(card);
                if (added.Count > 1)
                {
                    added.Clear();
                }
                return true;
            }
            else
            {
                return false;
            }
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

        List<CardInfo> added = new List<CardInfo>();
    }
}
