using System;
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

                // TODO: Get reactions
                roll20Character.Reactions = "";

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
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.StrengthMod = GetTraitModifier(traitStrength);

                GCATrait traitDex = currentCharacter.ItemByNameAndExt("DX", (int)TraitTypes.Attributes);
                roll20Character.DexterityPoints = traitDex.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.DexterityMod = 0;

                GCATrait traitIq = currentCharacter.ItemByNameAndExt("IQ", (int)TraitTypes.Attributes);
                roll20Character.IntelligencePoints = traitIq.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.IntelligenceMod = 0;

                GCATrait traitHealth = currentCharacter.ItemByNameAndExt("HT", (int)TraitTypes.Attributes);
                roll20Character.HealthPoints = traitHealth.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.HealthMod = 0;

                GCATrait traitPerception = currentCharacter.ItemByNameAndExt("Perception", (int)TraitTypes.Attributes);
                roll20Character.PerceptionPoints = traitPerception.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.PerceptionMod = 0;

                GCATrait traitVision = currentCharacter.ItemByNameAndExt("Vision", (int)TraitTypes.Attributes);
                roll20Character.VisionPoints = traitVision.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.VisionMod = 0;

                GCATrait traitHearing = currentCharacter.ItemByNameAndExt("Hearing", (int)TraitTypes.Attributes);
                roll20Character.HearingPoints = traitHearing.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.HearingMod = 0;

                GCATrait traitTasteSmell = currentCharacter.ItemByNameAndExt("Taste/Smell", (int)TraitTypes.Attributes);
                roll20Character.TasteSmellPoints = traitTasteSmell.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.TasteSmellMod = 0;

                GCATrait traitTouch = currentCharacter.ItemByNameAndExt("Touch", (int)TraitTypes.Attributes);
                roll20Character.TouchPoints = traitTouch.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.TouchMod = 0;

                GCATrait traitWill = currentCharacter.ItemByNameAndExt("Will", (int)TraitTypes.Attributes);
                roll20Character.WillpowerPoints = traitWill.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                roll20Character.WillpowerMod = 0;

                GCATrait traitFear = currentCharacter.ItemByNameAndExt("Fright Check", (int)TraitTypes.Attributes);
                roll20Character.FearCheckPoints = traitFear.Points;
                // TODO: <bonuslist>+2 from 'Combat Reflexes'</bonuslist>
                // NOTE: ignore combat reflexes that will be added automatically by roll20 checkbox
                roll20Character.FearCheckMod = 0;

                // TODO: place holder determine if there's other modifiers
                roll20Character.StunCheckMod = 0;

                GCATrait traitConsciousnessCheck = currentCharacter.ItemByNameAndExt("Consciousness Check", (int)TraitTypes.Attributes);
                // NOTE: no need to set points, not used. advantages are used instead.
                roll20Character.UnconsciousCheckPoints = 0;
                // TODO: <bonuslist>+1 from 'fit'</bonuslist>
                roll20Character.UnconsciousCheckMod = 0;

                GCATrait traitDeathCheck = currentCharacter.ItemByNameAndExt("Death Check", (int)TraitTypes.Attributes);
                // NOTE: no need to set points, not used. advantages are used instead.
                roll20Character.DeathCheckPoints = 0;
                // TODO: <bonuslist>+1 from 'fit'</bonuslist>
                roll20Character.DeathCheckMod = 0;

                GCATrait traitBasicSpeed = currentCharacter.ItemByNameAndExt("Basic Speed", (int)TraitTypes.Attributes);
                roll20Character.BasicSpeedPoints = traitBasicSpeed.Points;
                // TODO: <bonuslist>+1 from 'fit'</bonuslist>
                roll20Character.BasicSpeedMod = 0;

                GCATrait traitBasicMove = currentCharacter.ItemByNameAndExt("Basic Move", (int)TraitTypes.Attributes);
                roll20Character.BasicMovePoints = traitBasicMove.Points;
                // TODO: <bonuslist>+1 from 'fit'</bonuslist>
                roll20Character.BasicMoveMod = 0;

                // TODO: Find the advantage and apply points/mods
                roll20Character.EnhancedGroundMovePoints = 0;
                roll20Character.EnhancedGroundMoveMod = 0;

                GCATrait traitDodge = currentCharacter.ItemByNameAndExt("Basic Move", (int)TraitTypes.Attributes);
                // TODO: <bonuslist>+1 from 'Combat Reflexes', +1 from 'Enhanced Dodge'</bonuslist>
                // NOTE: Ignore combat reflexes
                roll20Character.DodgeMod = 0;

                GCATrait traitLiftingST = currentCharacter.ItemByNameAndExt("Lifting ST", (int)TraitTypes.Attributes);
                roll20Character.LiftStPoints = traitLiftingST.Points;
                // TODO: <bonuslist>+4 from 'Enhanced Muscle', +3 from 'Lifting ST'</bonuslist>
                // NOTE: the Lifting ST bonus is in addition to lifting st points!
                roll20Character.LiftStMod = 0;

                GCATrait traitSrikingST = currentCharacter.ItemByNameAndExt("Striking ST", (int)TraitTypes.Attributes);
                roll20Character.StrikingStPoints = traitSrikingST.Points;
                // TODO: <bonuslist>+4 from 'Enhanced Muscle', +3 from 'String ST'</bonuslist>
                // NOTE: the Lifting ST bonus is in addition to Striking st points!
                roll20Character.StrikingStMod = 0;

                GCATrait traitHitPoints = currentCharacter.ItemByNameAndExt("Hit Points", (int)TraitTypes.Attributes);
                roll20Character.HitPoints = traitHitPoints.Score;
                roll20Character.HitPointsPoints = traitHitPoints.Points;
                // TODO: <bonuslist>+4 from 'Enhanced Muscle', +3 from 'String ST'</bonuslist>
                roll20Character.HitPointsMod = 0;

                GCATrait traitFatigue = currentCharacter.ItemByNameAndExt("Fatigue Points", (int)TraitTypes.Attributes);
                roll20Character.FatiguePoints = traitFatigue.Score;
                roll20Character.FatiguePointsPoints = traitFatigue.Points;
                roll20Character.FatiguePointsMod = 0;

                // TODO: Check for flight advantage, don't worry about points, that will be placed under advantages
                roll20Character.FlightChecked = false;

                // TODO: Check for basic air move mods, points will be placed under advantages
                roll20Character.BasicAirMoveMod = 0;

                // TODO: Check for enhanced air level
                roll20Character.EnhancedAirLevel = 0;

                // TODO: check for amphibious advantage
                roll20Character.AmphibiousChecked = false;
                roll20Character.BasicAirMoveMod = 0;
                roll20Character.EnhancedWaterLevel = 0;

                // TODO: Check for water move mods
                roll20Character.BasicWaterMoveMod = 0;
                roll20Character.EnhancedWaterLevel = 0;

                // TODO: check for super jump levels
                roll20Character.SuperJumpEnteredLevel = 0;

                // TODO: check for magery level or PI bonus
                roll20Character.SpellBonus = 0;

                // TODO: Check for combat reflexes
                GCATrait traitCombatReflexes = currentCharacter.ItemByNameAndExt("Combat Reflexes", (int)TraitTypes.Advantages);
                if (traitCombatReflexes != null)
                {
                    roll20Character.CombatReflexes = true;
                }
                




            }   

            return roll20Character;

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

        public void LogItem(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                FileWriter fileWriter = new FileWriter();

                try
                {
                    fileWriter.FileOpen(this.TargetFileName + ".log");

                    fileWriter.WriteLine(message);
                }
                finally
                {
                    fileWriter.FileClose();
                }
            };
        }

    }
}
