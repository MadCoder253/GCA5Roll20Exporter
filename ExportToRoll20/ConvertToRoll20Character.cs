using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCA5.Interfaces;
using GCA5Engine;

namespace ExportToRoll20
{
    public class ConvertToRoll20Character
    {
        private string TargetFileName;

        public Roll20Character GetCharacter(GCACharacter currentCharacter, string targetFilename)
        {
            Roll20Character roll20Character = new Roll20Character();

            TargetFileName = targetFilename;

            if (currentCharacter != null)
            {
                roll20Character.CharacterName = currentCharacter.Name;
                roll20Character.Fullname = currentCharacter.FullName;
                roll20Character.Playername = currentCharacter.Player;
                roll20Character.Nickname = "";
                roll20Character.Race = currentCharacter.Race;
                roll20Character.RaceRef = "";
                roll20Character.TemplateNames = "";
                roll20Character.Gender = "";

                GCATrait traitSizeMod = currentCharacter.ItemByNameAndExt("Size Modifier", (int)TraitTypes.Attributes);
                roll20Character.Size = traitSizeMod.Score;
                roll20Character.ApplySizeModifier = traitSizeMod.Score > 0;

                roll20Character.Reactions = GetReactions(currentCharacter);

                if (int.TryParse(currentCharacter.Campaign.BaseTL, out int campaignTl))
                {
                    roll20Character.CampaignTl = campaignTl;
                }
                else
                {
                    roll20Character.CampaignTl = 0;
                }

                roll20Character.TotalPoints = currentCharacter.Campaign.BasePoints;

                if (int.TryParse(currentCharacter.TL, out int techLevel))
                {
                    roll20Character.Tl = techLevel;
                }
                else
                {
                    roll20Character.Tl = 0;
                }
                GCATrait traitTechLevel = currentCharacter.ItemByNameAndExt("Tech Level", (int)TraitTypes.Attributes);

                roll20Character.TlPts = traitTechLevel.Points;

                GCATrait traitStatus = currentCharacter.ItemByNameAndExt("Status", (int)TraitTypes.Attributes);
                roll20Character.Status = traitStatus.Score.ToString();

                roll20Character.Wealth = GetWealthLevel(currentCharacter);

                GCATrait traitMoney = currentCharacter.ItemByNameAndExt("Money", (int)TraitTypes.Attributes);
                roll20Character.Stash = traitMoney.Score;

                GCATrait traitMonthlyPay = currentCharacter.ItemByNameAndExt("Monthly Pay", (int)TraitTypes.Attributes);
                roll20Character.Income = traitMonthlyPay.Score;

                GCATrait traitCostOfLiving = currentCharacter.ItemByNameAndExt("Cost of Living", (int)TraitTypes.Attributes);
                roll20Character.CostOfLiving = traitCostOfLiving.Score;

                roll20Character.Age = currentCharacter.Age;
                roll20Character.Height = currentCharacter.Height;
                if (double.TryParse(currentCharacter.Weight, out double weight))
                {
                    roll20Character.Weight = weight;
                }
                else
                {
                    roll20Character.Weight = 0;
                }

                roll20Character.Appearance = GetAppearanceScore(currentCharacter);
                roll20Character.GeneralAppearance = currentCharacter.Appearance;

                GCATrait traitStrength = currentCharacter.ItemByNameAndExt("ST", (int)TraitTypes.Attributes);
                roll20Character.StrengthPoints = traitStrength.Points;
                roll20Character.StrengthMod = GetTraitModifier(traitStrength);

                GCATrait traitDex = currentCharacter.ItemByNameAndExt("DX", (int)TraitTypes.Attributes);
                roll20Character.DexterityPoints = traitDex.Points;
                roll20Character.DexterityMod = GetTraitModifier(traitDex);

                GCATrait traitIq = currentCharacter.ItemByNameAndExt("IQ", (int)TraitTypes.Attributes);
                roll20Character.IntelligencePoints = traitIq.Points;
                roll20Character.IntelligenceMod = GetTraitModifier(traitIq);

                GCATrait traitHealth = currentCharacter.ItemByNameAndExt("HT", (int)TraitTypes.Attributes);
                roll20Character.HealthPoints = traitHealth.Points;
                roll20Character.HealthMod = GetTraitModifier(traitHealth);

                GCATrait traitPerception = currentCharacter.ItemByNameAndExt("Perception", (int)TraitTypes.Attributes);
                roll20Character.PerceptionPoints = traitPerception.Points;
                roll20Character.PerceptionMod = GetTraitModifier(traitPerception);

                GCATrait traitVision = currentCharacter.ItemByNameAndExt("Vision", (int)TraitTypes.Attributes);
                roll20Character.VisionPoints = traitVision.Points;
                roll20Character.VisionMod = GetTraitModifier(traitVision);

                GCATrait traitHearing = currentCharacter.ItemByNameAndExt("Hearing", (int)TraitTypes.Attributes);
                roll20Character.HearingPoints = traitHearing.Points;
                roll20Character.HearingMod = GetTraitModifier(traitHearing);

                GCATrait traitTasteSmell = currentCharacter.ItemByNameAndExt("Taste/Smell", (int)TraitTypes.Attributes);
                roll20Character.TasteSmellPoints = traitTasteSmell.Points;
                roll20Character.TasteSmellMod = GetTraitModifier(traitTasteSmell);

                GCATrait traitTouch = currentCharacter.ItemByNameAndExt("Touch", (int)TraitTypes.Attributes);
                roll20Character.TouchPoints = traitTouch.Points;
                roll20Character.TouchMod = GetTraitModifier(traitTouch);

                GCATrait traitWill = currentCharacter.ItemByNameAndExt("Will", (int)TraitTypes.Attributes);
                roll20Character.WillpowerPoints = traitWill.Points;
                roll20Character.WillpowerMod = GetTraitModifier(traitWill);

                GCATrait traitFear = currentCharacter.ItemByNameAndExt("Fright Check", (int)TraitTypes.Attributes);
                roll20Character.FearCheckPoints = traitFear.Points;
                roll20Character.FearCheckMod = GetTraitModifier(traitFear);

                // TODO: place holder determine if there's other modifiers
                roll20Character.StunCheckMod = 0;

                GCATrait traitConsciousnessCheck = currentCharacter.ItemByNameAndExt("Consciousness Check", (int)TraitTypes.Attributes);
                roll20Character.UnconsciousCheckMod = GetTraitModifier(traitConsciousnessCheck);

                GCATrait traitDeathCheck = currentCharacter.ItemByNameAndExt("Death Check", (int)TraitTypes.Attributes);
                roll20Character.DeathCheckMod = GetTraitModifier(traitDeathCheck);

                GCATrait traitBasicSpeed = currentCharacter.ItemByNameAndExt("Basic Speed", (int)TraitTypes.Attributes);
                roll20Character.BasicSpeedPoints = traitBasicSpeed.Points;
                roll20Character.BasicSpeedMod = GetTraitModifier(traitBasicSpeed);

                GCATrait traitBasicMove = currentCharacter.ItemByNameAndExt("Basic Move", (int)TraitTypes.Attributes);
                roll20Character.BasicMovePoints = traitBasicMove.Points;
                roll20Character.BasicMoveMod = GetTraitModifier(traitBasicMove);

                GCATrait traitEnhancedGround = currentCharacter.ItemByNameAndExt("Enhanced Ground Move", (int)TraitTypes.Attributes);
                roll20Character.EnhancedGroundMoveMod = traitEnhancedGround.Score;

                GCATrait traitDodge = currentCharacter.ItemByNameAndExt("Dodge", (int)TraitTypes.Attributes);
                roll20Character.DodgeMod = GetTraitModifier(traitDodge);

                GCATrait traitLiftingST = currentCharacter.ItemByNameAndExt("Lifting ST", (int)TraitTypes.Attributes);
                roll20Character.LiftStPoints = traitLiftingST.Points;
                roll20Character.LiftStMod = GetTraitModifier(traitLiftingST);

                GCATrait traitSrikingST = currentCharacter.ItemByNameAndExt("Striking ST", (int)TraitTypes.Attributes);
                roll20Character.StrikingStPoints = traitSrikingST.Points;
                roll20Character.StrikingStMod = GetTraitModifier(traitSrikingST);

                GCATrait traitHitPoints = currentCharacter.ItemByNameAndExt("Hit Points", (int)TraitTypes.Attributes);
                roll20Character.HitPoints = traitHitPoints.Score;
                roll20Character.HitPointsPoints = traitHitPoints.Points;
                roll20Character.HitPointsMod = GetTraitModifier(traitHitPoints);

                GCATrait traitFatigue = currentCharacter.ItemByNameAndExt("Fatigue Points", (int)TraitTypes.Attributes);
                roll20Character.FatiguePoints = traitFatigue.Score;
                roll20Character.FatiguePointsPoints = traitFatigue.Points;
                roll20Character.FatiguePointsMod = GetTraitModifier(traitFatigue);

                GCATrait traitFlight = currentCharacter.ItemByNameAndExt("Flight", (int)TraitTypes.Advantages);
                if (traitFlight != null)
                {
                    roll20Character.FlightChecked = true;
                }

                GCATrait traitBasicAirMove = currentCharacter.ItemByNameAndExt("Basic Air Move", (int)TraitTypes.Attributes);
                if (traitBasicAirMove != null)
                {
                    roll20Character.BasicAirMoveMod = GetTraitModifier(traitBasicAirMove) ;
                }

                GCATrait traitEnhancedAirMove = currentCharacter.ItemByNameAndExt("Enhanced Air Move", (int)TraitTypes.Attributes);
                if (traitEnhancedAirMove != null)
                {
                    roll20Character.EnhancedAirLevel = traitEnhancedAirMove.Score;
                }

                GCATrait traitAmphibous = currentCharacter.ItemByNameAndExt("Amphibious", (int)TraitTypes.Advantages);
                if (traitAmphibous != null)
                {
                    roll20Character.AmphibiousChecked = true;
                }

                GCATrait traitBasicWaterMove = currentCharacter.ItemByNameAndExt("Basic Water Move", (int)TraitTypes.Attributes);
                roll20Character.BasicWaterMoveMod = GetTraitModifier(traitBasicWaterMove);

                GCATrait traitWaterMove = currentCharacter.ItemByNameAndExt("Water Move", (int)TraitTypes.Attributes);
                if (traitWaterMove != null)
                {
                    roll20Character.BasicWaterMovePoints = traitWaterMove.Points;
                }

                GCATrait traitEnhancedWaterMove = currentCharacter.ItemByNameAndExt("Enhanced Water Move", (int)TraitTypes.Attributes);
                if (traitEnhancedWaterMove != null)
                {
                    roll20Character.EnhancedWaterLevel = traitEnhancedWaterMove.Score;
                }

                GCATrait traitSuperJump = currentCharacter.ItemByNameAndExt("Super Jump", (int)TraitTypes.Attributes);
                roll20Character.SuperJumpEnteredLevel = traitSuperJump.Score;

                GCATrait traitMagery = currentCharacter.ItemByNameAndExt("Magery", (int)TraitTypes.Attributes);
                roll20Character.SpellBonus = traitMagery.Score;

                // check for ritual magery
                GCATrait traitRitualMagery = currentCharacter.ItemByNameAndExt("Ritual Magery", (int)TraitTypes.Advantages);
                if(traitRitualMagery != null && traitRitualMagery.Level > roll20Character.SpellBonus)
                {
                    roll20Character.SpellBonus = traitRitualMagery.Level;
                }

                // get all the power investiture types. Determine if it's the highest score
                var traitsPowerInvestitures = currentCharacter.ItemsByName("Power Investiture", (int)TraitTypes.Advantages);

                if (traitsPowerInvestitures != null)
                {
                    foreach(GCATrait trait in traitsPowerInvestitures)
                    {
                        if (trait.Level > roll20Character.SpellBonus)
                        {
                            roll20Character.SpellBonus = trait.Level;
                        }
                    }
                }

                GCATrait traitCombatReflexes = currentCharacter.ItemByNameAndExt("Combat Reflexes", (int)TraitTypes.Advantages);
                if (traitCombatReflexes != null)
                {
                    roll20Character.CombatReflexes = true;
                }

                roll20Character.RepeatingCultures = GetRepeatingCultures(currentCharacter);
                
            }   

            return roll20Character;

        }

        public string GetReactions(GCACharacter currentCharacter)
        {
            GCATrait traitReactions = currentCharacter.ItemByNameAndExt("Reaction", (int)TraitTypes.Attributes);
            
            string reactionBonusList = GetTraitModifiersList(traitReactions);
            
            string reactionConditionalList = GetTraitConditionalList(traitReactions);
            
            string reactions = reactionBonusList;
            
            if (reactionConditionalList.Length > 0)
            {
                if (reactionBonusList.Length > 0)
                {
                    // add line between bonus list and conditionals
                    reactions += "\n";
                }

                reactions += "Conditional:\n" + reactionConditionalList;

            }

            return reactions;
            
        }

        public List<RepeatingCulture> GetRepeatingCultures(GCACharacter currentCharacter)
        {
            List<RepeatingCulture> cultures = new List<RepeatingCulture>();

            var traitCultures = currentCharacter.ItemsByType[(int)TraitTypes.Cultures];

            foreach (GCATrait item in traitCultures)
            {
                var culture = new RepeatingCulture();
                culture.Idkey = item.IDKey.ToString();
                culture.Name = item.DisplayName;
                culture.Points = item.Points;

                cultures.Add(culture);
            }

            return cultures;
        }

        public string GetWealthLevel(GCACharacter currentCharacter)
        {
            GCATrait advantageWealth = currentCharacter.ItemByNameAndExt("Wealth", (int)TraitTypes.Advantages);

            if (advantageWealth != null)
            {
                return advantageWealth.LevelName;
            }

            GCATrait disadvantageWealth = currentCharacter.ItemByNameAndExt("Wealth", (int)TraitTypes.Disadvantages);


            if (disadvantageWealth != null)
            { return disadvantageWealth.LevelName; }

            return "Average";
        }

        public double GetAppearanceScore(GCACharacter currentCharacter)
        {
            GCATrait advantageAppearance = currentCharacter.ItemByNameAndExt("Appearance", (int)TraitTypes.Advantages);

            if (advantageAppearance != null)
            {
                return (int)advantageAppearance.Score;
            }

            GCATrait disadvantageAppearance = currentCharacter.ItemByNameAndExt("Appearance", (int)TraitTypes.Disadvantages);

            if (disadvantageAppearance != null)
            {
                return (int)disadvantageAppearance.Score;
            }

            return 0;
        }

        /// <summary>
        /// Get the final trait modifier. will ignore combat reflex bonuses
        /// since that is factpored in by the Roll20 character sheet
        /// TODO: Future enhancement. Convert to an extension for GCACharacter object
        /// </summary>
        /// <param name="theTrait"></param>
        /// <returns></returns>
        public double GetTraitModifier(GCATrait theTrait)
        {
            double finalModifier = 0;

            if (theTrait != null)
            {
                for (int index = 1; index <= theTrait.BonusListItemsCount(); index++)
                {
                    string bonusItem = theTrait.BonusListItems(index);

                    // ignore combat reflexes bonuses, that is added on the Roll20 character sheet
                    if (!bonusItem.Contains("combat reflexes"))
                    {
                        // example string: +1 from 'Extra ST'
                        // handles negative also: -1 from 'Reduced IQ`
                        string[] splitBonusItem = bonusItem.Split(' ');

                        // only need the first part
                        double modifier;
                        if (double.TryParse(splitBonusItem[0], out modifier))
                        {
                            finalModifier += modifier;
                        }

                    }

                }

            }

            return finalModifier;
        }

        /// <summary>
        /// Gets a comma separated list of reasons for bonuslist items
        /// ignores combat reflexes, which is handled by Roll20 sheet
        /// </summary>
        /// <param name="theTrait"></param>
        /// <returns></returns>
        public string GetTraitModifiersList(GCATrait theTrait)
        {
            var reasons = new ArrayList();

            if (theTrait != null)
            {
                for (int index = 1; index <= theTrait.BonusListItemsCount(); index++)
                {
                    string bonusItem = theTrait.BonusListItems(index);

                    // ignore combat reflexes bonuses, that is added on the Roll20 character sheet
                    if (!bonusItem.Contains("combat reflexes"))
                    {
                        reasons.Add(bonusItem);

                    }

                }

            }

            return string.Join("\n", reasons.ToArray());
        }

        /// <summary>
        /// Gets a comma separated list of reasons for conditiallist items
        /// ignores combat reflexes, which is handled by Roll20 sheet
        /// </summary>
        /// <param name="theTrait"></param>
        /// <returns></returns>
        public string GetTraitConditionalList(GCATrait theTrait)
        {
            var conditionalLists = new ArrayList();

            if (theTrait != null)
            {
                for (int index = 1; index <= theTrait.ConditionalListItemsCount(); index++)
                {
                    conditionalLists.Add(theTrait.ConditionalListItems(index));
                }

            }

            return string.Join("\n", conditionalLists.ToArray());
        }

    }
}
