using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GCA5.Interfaces;
using GCA5Engine;
using Microsoft.VisualBasic;

namespace ExportToRoll20
{
    public class ConvertToRoll20Character
    {
        // TODO: convert to using pkids, much more accurate.
        private readonly List<string> idkeysForAllTemplates = new List<string>();

        public Roll20Character GetCharacter(GCACharacter currentCharacter)
        {
            Roll20Character roll20Character = new Roll20Character();

            if (currentCharacter != null)
            {
                roll20Character.CharacterName = currentCharacter.Name;
                roll20Character.Fullname = currentCharacter.FullName;
                roll20Character.Playername = currentCharacter.Player;
                roll20Character.Nickname = "";
                roll20Character.Race = currentCharacter.Race;
                roll20Character.RaceRef = "";
                roll20Character.TemplateNames = SetTemplateMetaDataReturnTemplateNames(currentCharacter);
                roll20Character.Gender = "";

                GCATrait traitSizeMod = currentCharacter.ItemByNameAndExt("Size Modifier", (int)TraitTypes.Attributes);
                if (traitSizeMod != null )
                {
                    roll20Character.Size = traitSizeMod.Score;
                    roll20Character.ApplySizeModifier = traitSizeMod.Score > 0;
                }

                roll20Character.Reactions = GetReactions(currentCharacter);

                int campaignTl = 0;
                bool result = int.TryParse(currentCharacter.Campaign.BaseTL, out campaignTl);
                if (result)
                {
                    roll20Character.CampaignTl = campaignTl;
                }
                else
                {
                    roll20Character.CampaignTl = 0;
                }

                roll20Character.TotalPoints = currentCharacter.Campaign.BasePoints;

                int techLevel = 0;
                result = int.TryParse(currentCharacter.TL, out techLevel);
                if (result)
                {
                    roll20Character.Tl = techLevel;
                }
                else
                {
                    roll20Character.Tl = 0;
                }


                GCATrait traitTechLevel = currentCharacter.ItemByNameAndExt("Tech Level", (int)TraitTypes.Attributes);
                if (traitTechLevel != null)
                {
                    roll20Character.TlPts = traitTechLevel.Points;
                }

                GCATrait traitStatus = currentCharacter.ItemByNameAndExt("Status", (int)TraitTypes.Attributes);
                if (traitStatus != null)
                {
                    roll20Character.Status = traitStatus.Score.ToString();
                }

                roll20Character.Wealth = GetWealthLevel(currentCharacter);

                GCATrait traitMoney = currentCharacter.ItemByNameAndExt("Money", (int)TraitTypes.Attributes);
                if (traitMoney != null)
                {
                    roll20Character.Stash = traitMoney.Score;
                }

                GCATrait traitMonthlyPay = currentCharacter.ItemByNameAndExt("Monthly Pay", (int)TraitTypes.Attributes);
                if (traitMonthlyPay != null)
                {
                    roll20Character.Income = traitMonthlyPay.Score;
                }

                GCATrait traitCostOfLiving = currentCharacter.ItemByNameAndExt("Cost of Living", (int)TraitTypes.Attributes);
                if (traitCostOfLiving != null)
                {
                    roll20Character.CostOfLiving = traitCostOfLiving.Score;
                }

                roll20Character.Age = currentCharacter.Age;
                roll20Character.Height = currentCharacter.Height;

                double weight = 0;
                result = double.TryParse(currentCharacter.Weight, out weight);
                if (result)
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
                if (traitSizeMod != null)
                {
                    roll20Character.StrengthPoints = traitStrength.Points;
                    roll20Character.StrengthMod = GetTraitModifier(traitStrength);
                }

                GCATrait traitDex = currentCharacter.ItemByNameAndExt("DX", (int)TraitTypes.Attributes);
                if (traitDex != null)
                {
                    roll20Character.DexterityPoints = traitDex.Points;
                    roll20Character.DexterityMod = GetTraitModifier(traitDex);
                }

                GCATrait traitIq = currentCharacter.ItemByNameAndExt("IQ", (int)TraitTypes.Attributes);
                if (traitIq != null)
                {
                    roll20Character.IntelligencePoints = traitIq.Points;
                    roll20Character.IntelligenceMod = GetTraitModifier(traitIq);
                }

                GCATrait traitHealth = currentCharacter.ItemByNameAndExt("HT", (int)TraitTypes.Attributes);
                if (traitHealth != null)
                {
                    roll20Character.HealthPoints = traitHealth.Points;
                    roll20Character.HealthMod = GetTraitModifier(traitHealth);
                }

                GCATrait traitPerception = currentCharacter.ItemByNameAndExt("Perception", (int)TraitTypes.Attributes);
                if (traitPerception != null)
                {
                    roll20Character.PerceptionPoints = traitPerception.Points;
                    roll20Character.PerceptionMod = GetTraitModifier(traitPerception);
                }

                GCATrait traitVision = currentCharacter.ItemByNameAndExt("Vision", (int)TraitTypes.Attributes);
                if (traitVision != null)
                {
                    roll20Character.VisionPoints = traitVision.Points;
                    roll20Character.VisionMod = GetTraitModifier(traitVision);
                }

                GCATrait traitHearing = currentCharacter.ItemByNameAndExt("Hearing", (int)TraitTypes.Attributes);
                if (traitHearing != null)
                {
                    roll20Character.HearingPoints = traitHearing.Points;
                    roll20Character.HearingMod = GetTraitModifier(traitHearing);
                }

                GCATrait traitTasteSmell = currentCharacter.ItemByNameAndExt("Taste/Smell", (int)TraitTypes.Attributes);
                if (traitTasteSmell != null)
                {
                    roll20Character.TasteSmellPoints = traitTasteSmell.Points;
                    roll20Character.TasteSmellMod = GetTraitModifier(traitTasteSmell);
                }

                GCATrait traitTouch = currentCharacter.ItemByNameAndExt("Touch", (int)TraitTypes.Attributes);
                if(traitTouch != null)
                {
                    roll20Character.TouchPoints = traitTouch.Points;
                    roll20Character.TouchMod = GetTraitModifier(traitTouch);
                }

                GCATrait traitWill = currentCharacter.ItemByNameAndExt("Will", (int)TraitTypes.Attributes);
                if (traitWill != null)
                {
                    roll20Character.WillpowerPoints = traitWill.Points;
                    roll20Character.WillpowerMod = GetTraitModifier(traitWill);
                }

                GCATrait traitFear = currentCharacter.ItemByNameAndExt("Fright Check", (int)TraitTypes.Attributes);
                if (traitFear != null)
                {
                    roll20Character.FearCheckPoints = traitFear.Points;
                    roll20Character.FearCheckMod = GetTraitModifier(traitFear);
                }

                // TODO: place holder determine if there's other modifiers
                roll20Character.StunCheckMod = 0;

                GCATrait traitConsciousnessCheck = currentCharacter.ItemByNameAndExt("Consciousness Check", (int)TraitTypes.Attributes);
                if (traitConsciousnessCheck != null)
                {
                    roll20Character.UnconsciousCheckMod = GetTraitModifier(traitConsciousnessCheck);
                }

                GCATrait traitDeathCheck = currentCharacter.ItemByNameAndExt("Death Check", (int)TraitTypes.Attributes);
                if (traitDeathCheck != null)
                {
                    roll20Character.DeathCheckMod = GetTraitModifier(traitDeathCheck);
                }

                GCATrait traitBasicSpeed = currentCharacter.ItemByNameAndExt("Basic Speed", (int)TraitTypes.Attributes);
                if (traitBasicSpeed != null)
                {
                    roll20Character.BasicSpeedPoints = traitBasicSpeed.Points;
                    roll20Character.BasicSpeedMod = GetTraitModifier(traitBasicSpeed);
                }

                GCATrait traitBasicMove = currentCharacter.ItemByNameAndExt("Basic Move", (int)TraitTypes.Attributes);
                if (traitBasicMove != null)
                {
                    roll20Character.BasicMovePoints = traitBasicMove.Points;
                    roll20Character.BasicMoveMod = GetTraitModifier(traitBasicMove);
                }

                GCATrait traitEnhancedGround = currentCharacter.ItemByNameAndExt("Enhanced Ground Move", (int)TraitTypes.Attributes);
                if (traitEnhancedGround != null)
                {
                    roll20Character.EnhancedGroundMoveMod = traitEnhancedGround.Score;
                }

                GCATrait traitDodge = currentCharacter.ItemByNameAndExt("Dodge", (int)TraitTypes.Attributes);
                if (traitDodge != null)
                {
                    roll20Character.DodgeMod = GetTraitModifier(traitDodge);
                }

                GCATrait traitLiftingST = currentCharacter.ItemByNameAndExt("Lifting ST", (int)TraitTypes.Attributes);
                if (traitLiftingST != null)
                {
                    roll20Character.LiftStPoints = traitLiftingST.Points;
                    roll20Character.LiftStMod = GetTraitModifier(traitLiftingST);
                }

                GCATrait traitSrikingST = currentCharacter.ItemByNameAndExt("Striking ST", (int)TraitTypes.Attributes);
                if (traitSrikingST != null)
                {
                    roll20Character.StrikingStPoints = traitSrikingST.Points;
                    roll20Character.StrikingStMod = GetTraitModifier(traitSrikingST);
                }

                GCATrait traitHitPoints = currentCharacter.ItemByNameAndExt("Hit Points", (int)TraitTypes.Attributes);
                if (traitHitPoints != null)
                {
                    roll20Character.HitPoints = traitHitPoints.Score;
                    roll20Character.HitPointsPoints = traitHitPoints.Points;
                    roll20Character.HitPointsMod = GetTraitModifier(traitHitPoints);
                }

                GCATrait traitFatiguePoints = currentCharacter.ItemByNameAndExt("Fatigue Points", (int)TraitTypes.Attributes);
                if (traitFatiguePoints != null)
                {
                    roll20Character.FatiguePoints = traitFatiguePoints.Score;
                    roll20Character.FatiguePointsPoints = traitFatiguePoints.Points;
                    roll20Character.FatiguePointsMod = GetTraitModifier(traitFatiguePoints);
                }

                GCATrait traitFlight = currentCharacter.ItemByNameAndExt("Flight", (int)TraitTypes.Advantages);
                if (traitFlight != null)
                {
                    roll20Character.FlightChecked = true;
                }

                GCATrait traitBasicAirMove = currentCharacter.ItemByNameAndExt("Basic Air Move", (int)TraitTypes.Attributes);
                if (traitBasicAirMove != null)
                {
                    roll20Character.BasicAirMoveMod = GetTraitModifier(traitBasicAirMove);
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
                if (traitBasicWaterMove != null)
                {
                    roll20Character.BasicWaterMoveMod = GetTraitModifier(traitBasicWaterMove);
                }

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
                if (traitSuperJump != null)
                {
                    roll20Character.SuperJumpEnteredLevel = traitSuperJump.Score;
                }

                GCATrait traitMagery = currentCharacter.ItemByNameAndExt("Magery", (int)TraitTypes.Attributes);
                if (traitMagery != null)
                {
                    roll20Character.SpellBonus = traitMagery.Score;
                }

                GCATrait traitRitualMagery = currentCharacter.ItemByNameAndExt("Ritual Magery", (int)TraitTypes.Advantages);
                if (traitRitualMagery != null)
                {
                    roll20Character.SpellBonus = traitRitualMagery.Score;
                }

                // get all the power investiture types. Determine if it's the highest score
                var traitsPowerInvestitures = currentCharacter.ItemsByName("Power Investiture", (int)TraitTypes.Advantages);
                if (traitsPowerInvestitures != null)
                {
                    foreach (GCATrait trait in traitsPowerInvestitures)
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

                roll20Character.RepeatingLanguages = GetRepeatingLanguages(currentCharacter);

                roll20Character.RepeatingCultures = GetRepeatingCultures(currentCharacter);

                roll20Character.RepeatingTraits = GetRepeatingTraits(currentCharacter);

                roll20Character.RepeatingPerks = GetRepeatingPerks(currentCharacter);

                var features = GetRepeatingFeatures(currentCharacter);

                // add any features to the end of the list of perks
                roll20Character.RepeatingPerks.AddRange(features);

                roll20Character.RepeatingQuirks = GetRepeatingQuirks(currentCharacter);

                roll20Character.RepeatingDisadvantages = GetRepeatingDisadvantages(currentCharacter);

                roll20Character.RepeatingRacial = GetRepeatingTemplates(currentCharacter);

                roll20Character.RepeatingSkills = GetRepeatingSkills(currentCharacter);

                roll20Character.RepeatingTechniquesrevised = GetRepeatingTechniques(currentCharacter);

                roll20Character.RepeatingDefense = GetRepeatingDefenses(currentCharacter);

                roll20Character.RepeatingMelee = GetRepeatingMelee(currentCharacter);

                roll20Character.RepeatingRanged = GetRepeatingRanged(currentCharacter);

                roll20Character.RepeatingItem = GetRepeatingItems(currentCharacter);

                roll20Character.RepeatingSpells = GetRepeatingSpells(currentCharacter, roll20Character.RepeatingTechniquesrevised);
            }

            return roll20Character;

        }

        public string GetReactions(GCACharacter currentCharacter)
        {
            GCATrait traitReactions = currentCharacter.ItemByNameAndExt("Reaction", (int)TraitTypes.Attributes);

            if (traitReactions == null) return string.Empty;

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

        public List<RepeatingLanguage> GetRepeatingLanguages(GCACharacter currentCharacter)
        {
            List<RepeatingLanguage> languages = new List<RepeatingLanguage>();

            var traitLanguages = currentCharacter.ItemsByType[(int)TraitTypes.Languages];

            foreach (GCATrait item in traitLanguages)
            {
                var basedOn = item.get_TagItem("basedon").ToLower();

                var isNative = basedOn.Contains("native");

                var isSpoken = item.NameExt.ToLower().Contains("spoken");

                var isWritten = item.NameExt.ToLower().Contains("written");
                
                double spokenPoints;
                
                double writtenPoints;
                
                if (isWritten)
                {
                    spokenPoints = 0;

                    writtenPoints = item.Points;

                }
                else if (isSpoken)
                {
                    spokenPoints = item.Points;

                    writtenPoints = 0;

                }
                else
                {
                    spokenPoints = item.Points/2;

                    writtenPoints = item.Points/2;
                }

                var language = new RepeatingLanguage
                {
                    Idkey = item.IDKey.ToString(),
                    Name = item.Name,
                    Spoken = spokenPoints,
                    Written = writtenPoints,
                    IsNative = isNative,
                };

                languages.Add(language);
            }

            return languages;
        }

        public double GetWrittenPoints(GCACharacter currentCharacter, GCATrait spokenTrait)
        {
            double spokenPoints = 0;

            var traitLanguages = currentCharacter.ItemsByType[(int)TraitTypes.Languages];

            // loop through and find written version
            foreach (GCATrait item in traitLanguages)
            {
                if (item.Name == spokenTrait.Name && item.NameExt.ToLower().Contains("written"))
                {
                    spokenPoints = item.Points;
                    break;
                }

            }

            return spokenPoints;

        }

        public List<RepeatingCulture> GetRepeatingCultures(GCACharacter currentCharacter)
        {
            List<RepeatingCulture> cultures = new List<RepeatingCulture>();

            var traitCultures = currentCharacter.ItemsByType[(int)TraitTypes.Cultures];

            foreach (GCATrait item in traitCultures)
            {
                var culture = new RepeatingCulture
                {
                    Idkey = item.IDKey.ToString(),
                    Name = item.FullName,
                    Points = item.Points
                };

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
            { 
                return disadvantageWealth.LevelName; 
            }

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
                    // also ignore magery and Power Investiture
                    if (!bonusItem.Contains("combat reflexes") && !bonusItem.Contains("Magery") && !bonusItem.Contains("Power Investiture"))
                    {
                        // example string: +1 from 'Extra ST'
                        // handles negative also: -1 from 'Reduced IQ`
                        string[] splitBonusItem = bonusItem.Split(' ');

                        // only need the first part
                        double modifier;
                        bool result = double.TryParse(splitBonusItem[0], out modifier);
                        if (result)
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
        /// ignores combat reflexes, magery, and power investiture, which is handled by Roll20 sheet
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
                    // ignore Magery and Power Investiture
                    if (!bonusItem.Contains("combat reflexes") && !bonusItem.Contains("Magery") && !bonusItem.Contains("Power Investiture"))
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

        /// <summary>
        /// Gives is a list of traits provided by a template.
        /// Function will query the idkeys assocaited with templates. 
        /// if found, returns true
        /// </summary>
        /// <param name="trait"></param>
        /// <param name="gives"></param>
        /// <returns></returns>
        public bool IsRacialTrait(GCATrait trait)
        {

            bool isRacial = idkeysForAllTemplates.Any(key => key == trait.IDKey.ToString());

            return isRacial;
        }

        public List<RepeatingTrait> GetRepeatingTraits(GCACharacter myCharacter)
        {
            List<RepeatingTrait> list = new List<RepeatingTrait>();

            var advantages = myCharacter.ItemsByType[(int)TraitTypes.Advantages];

            foreach (GCATrait item in advantages)
            {
                if (IsRacialTrait(item) == false)
                {
                    double traitPoints = item.Points;

                    double parentId = GetParentId(item);

                    string itemName = item.FullName;

                    if (parentId > 0)
                    {
                        // get the parent trait
                        GCATrait parentTrait = GetTraitByIdKey(myCharacter, parentId.ToString());

                        if (parentTrait != null)
                        {
                            itemName =  parentTrait.FullName + " (Parent): " + itemName;

                        }
                    }

                    // if it is a parent, set the points to zero
                    var childIds = GetChildIds(item);

                    if (childIds.Length > 0)
                    {
                        traitPoints = 0;
                    }

                    var listItem = new RepeatingTrait
                    {
                        Idkey = item.IDKey.ToString(),
                        Name = itemName,
                        TraitLevel = item.Level.ToString(),
                        Foa = GetFrequencyOfAppearance(item),
                        Points = traitPoints,
                        Ref = item.get_TagItem("page"),
                        Notes = GetTraitNotes(item)
                    };

                    list.Add(listItem);
                }

            }

            return list;
        }

        protected double GetParentId(GCATrait item)
        {
            double parentId = 0;

            string parentKey = item.get_TagItem("parentkey");

            if ( string.IsNullOrEmpty(parentKey)) return parentId;

            // remove the "k" from the beginning of the key
            parentKey = parentKey.Substring(1);

            // convert to double
            parentId = Convert.ToDouble(parentKey);

            return parentId;
        }

        protected string[] GetChildIds(GCATrait trait)
        {
            string[] seperators = { ", " };

            var childIds = trait.get_TagItem("childkeylist").Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            return childIds;
        }

        public List<RepeatingPerk> GetRepeatingPerks(GCACharacter myCharacter)
        {
            List<RepeatingPerk> list = new List<RepeatingPerk>();

            // regular perks
            var perks = myCharacter.ItemsByType[(int)TraitTypes.Perks];

            foreach (GCATrait item in perks)
            {
                if (IsRacialTrait(item) == false)
                {
                    // this is a regular perk so add it.
                    var listItem = new RepeatingPerk
                    {
                        Idkey = item.IDKey.ToString(),
                        Name = item.FullName,
                        Foa = GetFrequencyOfAppearance(item),
                        Points = item.Points,
                        Ref = item.get_TagItem("page"),
                        Notes = GetTraitNotes(item)
                    };

                    list.Add(listItem);
                }
            }

            return list;

        }

        public List<RepeatingPerk> GetRepeatingFeatures(GCACharacter myCharacter)
        {
            List<RepeatingPerk> list = new List<RepeatingPerk>();

            // regular perks
            var perks = myCharacter.ItemsByType[(int)TraitTypes.Features];

            foreach (GCATrait item in perks)
            {
                if (IsRacialTrait(item) == false)
                {
                    // this is a regular perk so add it.
                    var listItem = new RepeatingPerk
                    {
                        Idkey = item.IDKey.ToString(),
                        Name = "Feature: " + item.FullName,
                        Foa = GetFrequencyOfAppearance(item),
                        Points = item.Points,
                        Ref = item.get_TagItem("page"),
                        Notes = GetTraitNotes(item)
                    };

                    list.Add(listItem);
                }
            }

            return list;
        }

        public List<RepeatingQuirk> GetRepeatingQuirks(GCACharacter myCharacter)
        {
            List<RepeatingQuirk> list = new List<RepeatingQuirk>();

            var quirks = myCharacter.ItemsByType[(int)TraitTypes.Quirks];

            foreach (GCATrait item in quirks)
            {
                if (IsRacialTrait(item) == false)
                {
                    // this is a regular quirk so add it.
                    var listItem = new RepeatingQuirk
                    {
                        Idkey = item.IDKey.ToString(),
                        Name = item.FullName,
                        ControlRating = GetControlRating(item),
                        Points = item.Points,
                        Ref = item.get_TagItem("page"),
                        Notes = GetTraitNotes(item)
                    };

                    list.Add(listItem);
                }

            }

            return list;

        }

        public List<RepeatingDisadvantage> GetRepeatingDisadvantages(GCACharacter myCharacter)
        {
            List<RepeatingDisadvantage> list = new List<RepeatingDisadvantage>();

            var disadvantages = myCharacter.ItemsByType[(int)TraitTypes.Disadvantages];

            foreach (GCATrait item in disadvantages)
            {
                if (IsRacialTrait(item) == false)
                {
                    // this is a regular disadvantage so add it.
                    var listItem = new RepeatingDisadvantage
                    {
                        Idkey = item.IDKey.ToString(),
                        Name = item.FullName,
                        TraitLevel = item.Level.ToString(),
                        ControlRating = GetControlRating(item),
                        Points = item.Points,
                        Ref = item.get_TagItem("page"),
                        Notes = GetTraitNotes(item)
                    };

                    list.Add(listItem);
                }

            }

            return list;
        }

        public string SetTemplateMetaDataReturnTemplateNames(GCACharacter myCharacter)
        {
            var templates = myCharacter.ItemsByType[(int)TraitTypes.Templates];

            List<string> templateNames = new List<string>();

            foreach (GCATrait template in templates)
            {
                templateNames.Add(template.FullName);

                // get the needs for this template
                // needs: advantages, disadvantages, etc. added to template
                string[] seperators = { ", " };

                var templateIds = template.get_TagItem("pkids").Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                idkeysForAllTemplates.AddRange(templateIds);

            }

            return string.Join(", ", templateNames.ToArray());
        }

        public List<RepeatingRacial> GetRepeatingTemplates(GCACharacter myCharacter)
        {
            var templates = myCharacter.ItemsByType[(int)TraitTypes.Templates];

            List<RepeatingRacial> list = new List<RepeatingRacial>();

            foreach (GCATrait template in templates)
            {
                var notes = GetTraitNotes(template);

                var racialTrait = new RepeatingRacial
                {
                    Idkey = template.IDKey.ToString(),
                    Name = template.FullName,
                    Points = template.PreModsPoints,
                    Ref = template.get_TagItem("ref"),
                    Notes = notes
                };

                list.Add(racialTrait);

                // get all the idkeys for the template
                var pkids = template.get_TagItem("pkids");

                if (!string.IsNullOrEmpty(pkids))
                {
                    var templateTraits = GetTemplateTraits(myCharacter, pkids);

                    list.AddRange(templateTraits);
                };

            }

            return list;
        }

        public List<RepeatingRacial> GetTemplateTraits(GCACharacter myCharacter, string idkeys)
        {
            List<RepeatingRacial> list = new List<RepeatingRacial>();

            string[] seperators = { ", " };

            var arrKeys = idkeys.Split(seperators, StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            foreach (var idKey in arrKeys)
            {
                GCATrait trait = GetTraitByIdKey(myCharacter, idKey);

                if (trait != null)
                {
                    var refPage = trait.get_TagItem("ref");

                    var traitNotes = GetTraitNotes(trait);

                    var controlRating = GetControlRating(trait);

                    // if empty check for FOA
                    if (string.IsNullOrEmpty(controlRating))
                    {
                        controlRating = GetFrequencyOfAppearance(trait);
                    }

                    var racialTrait = new RepeatingRacial()
                    {
                        Idkey = trait.IDKey.ToString(),
                        Name = trait.FullName,
                        TraitLevel = trait.Level.ToString(),
                        ControlRating = controlRating,
                        Points = trait.Points,
                        Ref = refPage,
                        Notes = traitNotes
                    };

                    list.Add(racialTrait);
                }

            }

            return list;
        }

        public GCATrait GetTraitByIdKey(GCACharacter myCharacter, string IdKey)
        {
            // loop through ALL items
            foreach (GCATrait trait in myCharacter.Items)
            {
                // is the item one of the idkeys associated with the template
                if (IdKey == trait.IDKey.ToString())
                {
                    return trait;
                }
            }

            return null;
        }

        // TODO: Wildcard!
        public List<RepeatingSkill> GetRepeatingSkills(GCACharacter myCharacter)
        {
            List<RepeatingSkill> list = new List<RepeatingSkill>();

            var skills = myCharacter.ItemsByType[(int)TraitTypes.Skills];

            foreach (GCATrait skill in skills)
            {
                // only add regular skills
                if (!skill.SkillType.StartsWith("Tech"))
                {
                    var listItem = new RepeatingSkill
                    {
                        Idkey = skill.IDKey.ToString(),
                        Name = skill.FullName,
                        Tl = skill.get_TagItem("tl"),
                        Base = GetBaseAttributeForSkill(skill.get_TagItem("stepoff")),
                        Difficulty = GetDifficultyForSkill(skill.SkillType),
                        Bonus = GetTraitModifier(skill),
                        Points = skill.Points,
                        Skill = skill.Level,
                        Ref = skill.get_TagItem("page"),
                        SkillModNotes = GetTraitModifiersList(skill),
                        Notes = GetTraitNotes(skill)
                    };

                    list.Add(listItem);
                }
            }

            return list;
        }

        public string GetDifficultyForSkill(string skillType)
        {
            string[] arrSkillType = skillType.Split('/');

            string difficulty = arrSkillType[1];

            return difficulty;
        }

        public string GetBaseAttributeForSkill(string stepoff)
        {
            string baseAttribute = "10";

            switch (stepoff.ToUpper())
            {
                case "ST":
                    baseAttribute = "@{strength}";
                    break;

                case "DX":
                    baseAttribute = "@{dexterity}";
                    break;

                case "IQ":
                    baseAttribute = "@{intelligence}";
                    break;

                case "HT":
                    baseAttribute = "@{health}";
                    break;

                case "WILL":
                    baseAttribute = "@{willpower}";
                    break;

                case "PER":
                    baseAttribute = "@{perception}";
                    break;

                default:
                    break;
            }

            return baseAttribute;
        }

        public List<RepeatingTechniquesrevised> GetRepeatingTechniques(GCACharacter myCharacter)
        {
            List<RepeatingTechniquesrevised> list = new List<RepeatingTechniquesrevised>();

            var skills = myCharacter.ItemsByType[(int)TraitTypes.Skills];

            foreach (GCATrait skill in skills)
            {
                // only add techniques
                if (skill.SkillType.StartsWith("Tech"))
                {
                    var listItem = new RepeatingTechniquesrevised
                    {
                        Idkey = skill.IDKey.ToString(),
                        Name = skill.FullName,
                        Parent = skill.get_TagItem("deffrom"),
                        BaseLevel = skill.get_TagItem("deflevel"),
                        Default = GetTechniqueDefaultModifier(skill),
                        MaxModifier = GetTechniqueMaxModifier(skill),
                        Difficulty = GetDifficultyForTechnique(skill.SkillType),
                        SkillModifier = GetTraitModifier(skill),
                        Points = skill.Points,
                        Skill = skill.Level,
                        Ref = skill.get_TagItem("page"),
                        SkillModNotes = GetTraitModifiersList(skill),
                        Notes = GetTraitNotes(skill)
                    };

                    list.Add(listItem);
                }

            }

            return list;

        }

        public string GetDifficultyForTechnique(string skillType)
        {
            string[] arrSkillType = skillType.Split('/');

            string difficulty = arrSkillType[1];

            return difficulty;
        }

        public List<RepeatingDefense> GetRepeatingDefenses(GCACharacter myCharacter)
        {
            List<RepeatingDefense> list = new List<RepeatingDefense>();

            // loop through all items
            foreach (GCATrait trait in myCharacter.Items)
            {
                // loop through the modes, (usually an attack mode)
                // <attackmodes count="1">
                foreach (Mode mode in trait.Modes)
                {
                    var parryDefense = GetParryDefense(trait, mode);

                    // if there's a name, we have a valid parry defense
                    if (parryDefense != null)
                    {
                        list.Add(parryDefense);
                    }

                    var powerDefense = GetPowerDefense(trait, mode);

                    if (powerDefense != null)
                    {
                        list.Add(powerDefense);
                    }

                }

                var blockDefense = GetBlockDefense(trait);

                if (blockDefense != null)
                {
                    list.Add(blockDefense);
                }
            }

            return list;
        }

        /// <summary>
        /// strip out all characters except letters and numbers
        /// </summary>
        /// <param name="oldValue"></param>
        /// <returns></returns>
        public string GetAlphaNumericCharacters(string oldValue)
        {
            string newValue;

            Regex rgx = new Regex("[^a-zA-Z0-9 -]");
            
            newValue = rgx.Replace(oldValue, "");
            
            return newValue;
        }

        public List<RepeatingMelee> GetRepeatingMelee(GCACharacter myCharacter)
        {
            List<RepeatingMelee> list = new List<RepeatingMelee>();

            // loop through all items
            foreach (GCATrait trait in myCharacter.Items)
            {
                ModeManager modeManager = trait.Modes.MeleeAttackModes();

                if (modeManager != null)
                {
                    int num = modeManager.Count();
                    for (int i = 1; i <= num; i = checked(i + 1))
                    {
                        Mode mode = modeManager.Mode(i);

                        string idKeyTraitName = GetAlphaNumericCharacters(trait.Name.ToLower().Replace(" ", "_"));

                        string idKeyModeName = GetAlphaNumericCharacters(mode.Name.ToLower().Replace(" ", "_"));

                        string meleeIdKey = trait.IDKey.ToString() + "_" + idKeyTraitName + "_" + idKeyModeName;

                        string meleeName = trait.FullName;

                        if (trait.FullName != mode.Name && mode.Name.Length > 0)
                        {
                            meleeName += " (" + mode.Name + ")";
                        }

                        var meleeDamage = mode.get_TagItem("chardamage").Replace("d", "d6");

                        double meleeSkill;
                        bool result = double.TryParse(mode.get_TagItem("charskillscore"), out meleeSkill);
                        if (!result)
                        {
                            meleeSkill = 0;
                        }

                        double armorDivisor;
                        result = double.TryParse(mode.get_TagItem("chararmordivisor"), out armorDivisor);
                        if (!result)
                        {
                            armorDivisor = 1;
                        }

                        var item = new RepeatingMelee()
                        {
                            Idkey = meleeIdKey,
                            Name = meleeName,
                            Damage = meleeDamage,
                            Type = mode.get_TagItem("chardamtype"),
                            Reach = mode.get_TagItem("reach"),
                            Skill = meleeSkill,
                            ArmorDivisor = armorDivisor,
                            Notes = mode.get_TagItem("itemnotes")
                        };

                        list.Add(item); 
                    }
                }

            }

            return list;
        }

        public List<RepeatingRanged> GetRepeatingRanged(GCACharacter myCharacter)
        {
            List<RepeatingRanged> list = new List<RepeatingRanged>();

            // loop through all items
            foreach (GCATrait trait in myCharacter.Items)
            {
                ModeManager modeManager = trait.Modes.RangedAttackModes();

                if (modeManager != null)
                {
                    int num = modeManager.Count();
                    for (int i = 1; i <= num; i = checked(i + 1))
                    {
                        Mode mode = modeManager.Mode(i);

                        string idKeyTraitName = GetAlphaNumericCharacters(trait.Name.ToLower().Replace(" ", "_"));

                        string idKeyModeName = GetAlphaNumericCharacters(mode.Name.ToLower().Replace(" ", "_"));

                        string rangedIdKey = trait.IDKey.ToString() + "_" + idKeyTraitName + "_" + idKeyModeName;

                        string rangedName = trait.FullName;

                        if (trait.FullName != mode.Name && mode.Name.Length > 0)
                        {
                            rangedName += " (" + mode.Name + ")";
                        }

                        var rangedDamage = mode.get_TagItem("chardamage").Replace("d", "d6");

                        double rangedSkill;
                        bool result = double.TryParse(mode.get_TagItem("charskillscore"), out rangedSkill);
                        if (!result)
                        {
                            rangedSkill = 0;
                        }

                        double armorDivisor;
                        result = double.TryParse(mode.get_TagItem("chararmordivisor"), out armorDivisor);
                        if (!result)
                        {
                            armorDivisor = 1;
                        }

                        string halfRange = mode.get_TagItem("charrangehalfdam");

                        string maxRange = mode.get_TagItem("charrangemax");

                        List<string> ranges = new List<string>();

                        if (halfRange.Length > 0)
                        {
                            ranges.Add(halfRange);
                        }

                        if (maxRange.Length > 0 && maxRange != halfRange)
                        {
                            ranges.Add(maxRange);
                        }

                        string finalRange = string.Join("/", ranges.ToArray());

                        var item = new RepeatingRanged()
                        {
                            Idkey = rangedIdKey,
                            Name = rangedName,
                            Damage = rangedDamage,
                            Type = mode.get_TagItem("chardamtype"),
                            Acc = mode.get_TagItem("characc"),
                            Range = finalRange,
                            Rof = mode.get_TagItem("charrof"),
                            Shots = mode.get_TagItem("charshots"),
                            Bulk = mode.get_TagItem("charbulk"),
                            Recoil = mode.get_TagItem("charrcl"),
                            Skill = rangedSkill,
                            Malfunction = mode.get_TagItem("charmalf"),
                            ArmorDivisor = armorDivisor,
                            Notes = mode.get_TagItem("itemnotes")
                        };

                        list.Add(item);


                    }
                }

            }

            return list;
        }

        public List<RepeatingItem> GetRepeatingItems(GCACharacter myCharacter)
        {
            List<RepeatingItem> list = new List<RepeatingItem>();

            var items = myCharacter.ItemsByType[(int)TraitTypes.Equipment];

            foreach (GCATrait trait in items)
            {
                string legalityClass = GetLegalityClass(trait);

                double itemCount;
                bool result = double.TryParse(trait.get_TagItem("count"), out itemCount);
                if (!result)
                {
                    itemCount = 0;
                }

                double itemWeight;
                result = double.TryParse(trait.get_TagItem("baseweight"), out itemWeight);
                if (!result)
                {
                    itemWeight = 0;
                }

                double itemCost;
                result = double.TryParse(trait.get_TagItem("basecost"), out itemCost);
                if (!result)
                {
                    itemCost = 0;
                }

                string notes = GetTraitNotes(trait);

                var item = new RepeatingItem()
                {
                    Idkey = trait.IDKey.ToString(),
                    Name = trait.FullName,
                    Tl = trait.get_TagItem("techlvl"),
                    LegalityClass = legalityClass,
                    Ref = trait.get_TagItem("page"),
                    Count = itemCount,
                    Weight = itemWeight,
                    Cost = itemCost,
                    Notes = notes
                };

                list.Add(item);

            }

            return list;

        }

        public List<RepeatingSpell> GetRepeatingSpells(GCACharacter myCharacter, List<RepeatingTechniquesrevised> repeatingTechniquesrevised)
        {
            List<RepeatingSpell> list = new List<RepeatingSpell>();

            var spells = myCharacter.ItemsByType[(int)TraitTypes.Spells];

            foreach (GCATrait trait in spells)
            {
                string spellClassSummary = trait.get_TagItem("class");

                string resistedBy = "";

                string spellClass;

                // <class>Regular/R-HT</class>
                if (spellClassSummary.Contains("/R"))
                {
                    var arrSpellClass = spellClassSummary.Split('/');

                    spellClass = arrSpellClass[0];

                    resistedBy = arrSpellClass[1];
                }
                else
                {
                    spellClass = spellClassSummary;
                }

                string primaryCollege = "";

                string secondaryCollege = "";

                var categories = trait.get_TagItem("cat");

                string[] seperators = { ", " };

                var arrCats = categories.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                if (arrCats.Length > 0)
                {
                    primaryCollege = arrCats[0];

                    if (arrCats.Length > 1)
                    {
                        secondaryCollege = arrCats[1];
                    }
                }

                // if it is a parent, set the points to zero
                var childIds = trait.get_TagItem("childkeylist").Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                double spellPoints = trait.Points;

                var difficulty = GetDifficultyForSkill(trait.SkillType);

                var spellName = trait.FullName;

                if (childIds.Length > 0)
                {
                    spellPoints = Conversion.Val(trait.get_TagItem("basepoints"));

                } else if (trait.SkillType.ToLower().StartsWith("tech"))
                {
                    spellPoints = 0;

                    difficulty = "T/H";

                    // add the technique to the repeating techniques list
                    var technique = this.getRepeatingTechnique(trait);

                    repeatingTechniquesrevised.Add(technique);


                }

                var spell = new RepeatingSpell()
                {
                    Idkey = trait.IDKey.ToString(),
                    Name = spellName,
                    Difficulty = difficulty,
                    SpellModifier = GetTraitModifier(trait),
                    Points = spellPoints,
                    SpellResistedBy = resistedBy,
                    Duration = trait.get_TagItem("duration"),
                    Cost = trait.get_TagItem("castingcost"),
                    Skill = trait.Level,
                    Ref = trait.get_TagItem("page"),
                    Casttime = trait.get_TagItem("time"),
                    Maintain = "",
                    SpellClass = spellClass,
                    SpellCollege = primaryCollege,
                    SpellCollegeSecondary = secondaryCollege,
                    SpellModNotes = GetTraitModifiersList(trait),
                    SpellNotes = GetTraitNotes(trait)
                };

                list.Add(spell);

            }

            return list;
        }

        protected RepeatingTechniquesrevised getRepeatingTechnique(GCATrait skill)
        {
            var technique = new RepeatingTechniquesrevised() {
                Idkey = skill.IDKey.ToString() + "-ritual",
                Name = skill.FullName,
                Parent = skill.get_TagItem("deffrom"),
                BaseLevel = skill.get_TagItem("deflevel"),
                Default = GetTechniqueDefaultModifier(skill),
                MaxModifier = GetTechniqueMaxModifier(skill),
                Difficulty = GetDifficultyForTechnique(skill.SkillType),
                SkillModifier = GetTraitModifier(skill),
                Points = skill.Points,
                Skill = skill.Level,
                Ref = skill.get_TagItem("page"),
                SkillModNotes = GetTraitModifiersList(skill),
                Notes = GetTraitNotes(skill)
            };

            return technique;

        }

        public string GetLegalityClass(GCATrait trait)
        {
            foreach (Mode mode in trait.Modes)
            {
                if (!string.IsNullOrEmpty(mode.get_TagItem("lc")))
                {
                    return mode.get_TagItem("lc");
                }
            }

            return "";
        }

        /// <summary>
        /// Get parry defense item
        /// </summary>
        /// <param name="trait"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public RepeatingDefense GetParryDefense(GCATrait trait, Mode mode)
        {
            // set defense type
            var defenseType = "Parry";

            var idKeySuffix = "parry";

            if (mode.Name.ToLower() == "brawling" || mode.Name.ToLower() == "karate" || mode.Name.ToLower() == "punch")
            {
                defenseType = "Unarmed Parry";

                idKeySuffix = "unarmed_parry";
            }

            // attempt to get a parry score
            var parryValue = mode.get_TagItem("charparryscore");

            double parryScore;
            bool result = double.TryParse(parryValue, out parryScore);
            if (!result)
            {
                parryScore = 0;
            }

            // attemp to get a acc value. If there's a ACC value, don't create a valid defense
            var accValue = mode.get_TagItem("acc");

            var defenseName = trait.FullName;

            if (trait.FullName != mode.Name && mode.Name.Length > 0)
            {
                defenseName += " (" + mode.Name + ")";
            }

            if (string.IsNullOrEmpty(accValue) && !string.IsNullOrEmpty(mode.Name) && parryScore > 0)
            {
                var item = new RepeatingDefense
                {
                    Idkey = trait.IDKey + "_" + idKeySuffix,
                    Name = defenseName,
                    Type = defenseType,
                    Info = "",
                    Skill = parryScore,
                    SkillMod = 0,
                    DefenseModReason = "",
                    InfoDescription = ""
                };

                return item;
            };

            return null;

        }

        public RepeatingDefense GetBlockDefense(GCATrait trait)
        {
            var blockValue = trait.get_TagItem("blocklevel");

            var categories = trait.get_TagItem("cat");

            // ignore the DX attribute & talents
            double block;
            bool result = double.TryParse(blockValue, out block);
            if (trait.Name != "DX" && !categories.ToLower().Contains("talent") && result)
            {
                var item = new RepeatingDefense
                {
                    Idkey = trait.IDKey + "_block",
                    Name = trait.FullName,
                    Type = "Block",
                    Info = "",
                    Skill = block,
                    SkillMod = 0,
                    DefenseModReason = "",
                    InfoDescription = ""
                };

                return item;
            }

            return null;

        }

        public RepeatingDefense GetPowerDefense(GCATrait trait, Mode mode)
        {
            var categories = trait.get_TagItem("cat");

            if (categories.ToLower().Contains("talent"))
            {
                var defenseType = "Power";

                var idKeySuffix = "power";

                if (mode.Name.ToLower().Contains("dodge"))
                {
                    defenseType = "Power Dodge";

                    idKeySuffix = "power_dodge";

                }
                else if (mode.Name.ToLower().Contains("parry"))
                {
                    defenseType = "Power Parry";

                    idKeySuffix = "power_parry";
                }
                else if (mode.Name.ToLower().Contains("block/physical"))
                {
                    defenseType = "Power Block";

                    idKeySuffix = "power_block";
                }
                else if (mode.Name.ToLower().Contains("block/mental"))
                {
                    defenseType = "Power Block Mental";

                    idKeySuffix = "power_block_mental";
                }

                var scoreValue = mode.get_TagItem("charskillscore");

                double score;
                bool result = double.TryParse(scoreValue, out score);
                if (result)
                {

                    var powerDefense = new RepeatingDefense
                    {
                        Idkey = trait.IDKey + "_" + idKeySuffix,
                        Name = trait.FullName + " (" + mode.Name + ")",
                        Type = defenseType,
                        Info = "",
                        Skill = score,
                        SkillMod = 0,
                        DefenseModReason = "",
                        InfoDescription = ""
                    };

                    if (powerDefense != null)
                    {
                        return powerDefense;
                    }
                }

            }

            return null;

        }

        public double GetTechniqueDefaultModifier(GCATrait skill)
        {
            double modifier = 0;

            // example: "SK:Brawling::parrylevel" - 1
            string[] mods = skill.get_TagItem("default").Split(' ');
            if (mods.Length == 3)
            {
                // Example: should be -1
                string value = mods[1] + mods[2];
                if (!double.TryParse(value, out modifier))
                {
                    modifier = 0;
                }
            }


            return modifier;
        }

        public double GetTechniqueMaxModifier(GCATrait skill)
        {
            double modifier = 0;

            // example: <upto>prereq + 4</upto>
            string[] mods = skill.get_TagItem("upto").Split(' ');
            if (mods.Length == 3)
            {
                // Example: should be -1
                string value = mods[1] + mods[2];
                if (!double.TryParse(value, out modifier))
                {
                    modifier = 0;
                }
            }

            return modifier;
        }

        public string GetFrequencyOfAppearance(GCATrait trait)
        {
            string Foa = "";

            foreach (GCAModifier mod in trait.Mods)
            {
                if (mod.Group.Contains("Frequency of Appearance"))
                {
                    // <shortname>9 or less</shortname>
                    string[] shortNameParts = mod.get_CaptionExpanded(false).Split(' ');

                    Foa = shortNameParts[0];

                }

            }

            return Foa;
        }

        public string GetControlRating(GCATrait trait)
        {
            string controlRating = "";

            foreach (GCAModifier mod in trait.Mods)
            {
                if (mod.Group.Contains("Self-Control"))
                {
                    // <shortname>12 or less</shortname>
                    string[] shortNameParts = mod.get_CaptionExpanded(false).Split(' ');

                    controlRating = shortNameParts[0];

                }

            }

            return controlRating;
        }

        public string GetTraitNotes(GCATrait trait)
        {
            var notes = new ArrayList();

            if (trait.DisplayName.Length > 0 && trait.DisplayName.Contains("("))
            {
                // Contact (Effective Skill 12; Rival Gang; 9 or less, *1; Somewhat Reliable, *1)
                // Crossbow 3 (Armor Piercing) (Armor Divisor, 2, +50%; Increased Range, x2, +10%)
                // we want the value inside the parenthesis 

                // remove the name and nameext
                string name = trait.DisplayName;

                // try to remove name + level
                name = name.Replace(trait.Name + " " + trait.Level.ToString() + " ", "");

                // if previous didn't work, try remove the name
                name = name.Replace(trait.Name + " ", "");

                string nameExtension = "(" + trait.NameExt + ") ";

                if (name.StartsWith(nameExtension))
                {
                    // remove the extension
                    name = name.Replace(nameExtension, "");
                }

                // remove last parenthese 
                name = name.Remove(name.Length - 1);

                // remove first parenthese
                name = name.Remove(0, 1);

                string[] seperators = { "; " };

                string[] nameParts = name.Split(seperators, System.StringSplitOptions.RemoveEmptyEntries);

                if (nameParts.Length > 0)
                {
                    notes.Add("**Features**:\n" + string.Join("\n", nameParts) + "\n");
                }

            }

            // --------- User Notes ------------
            var userNotes = trait.GetNotes(true);

            if (!string.IsNullOrEmpty(userNotes))
            {
                notes.Add("**User Notes:**\n" + userNotes);
            }

            // --------- Description ------------
            var tagDescription = trait.get_TagItem("description").Trim();

            if (!string.IsNullOrEmpty(tagDescription))
            {
                // convert to plain text
                tagDescription = modHelperFunctions.RTFtoPlainText(tagDescription);

                notes.Add("**Description:**\n" + tagDescription);
            }

            // --------- VTT Notes ------------
            var vttNotes = trait.get_TagItem("vttnotes").Trim();

            if (!string.IsNullOrEmpty(vttNotes))
            {
                // convert to plain text
                vttNotes = modHelperFunctions.RTFtoPlainText(vttNotes);

                notes.Add("**VTT Notes:**\n" + vttNotes);
            }

            // combine everything
            string noteDescription = string.Join("\n", notes.ToArray());

            return noteDescription;
        }

    }
}
