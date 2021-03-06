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

namespace ExportToRoll20
{
    public class ConvertToRoll20Character
    {
        // TODO: convert to using pkids, much more accurate.
        private List<string> idkeysForAllTemplates = new List<string>();

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
                if (traitRitualMagery != null && traitRitualMagery.Level > roll20Character.SpellBonus)
                {
                    roll20Character.SpellBonus = traitRitualMagery.Level;
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

                roll20Character.RepeatingSpells = GetRepeatingSpells(currentCharacter);
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
                    // also ignore magery and Power Investiture
                    if (!bonusItem.Contains("combat reflexes") && !bonusItem.Contains("Magery") && !bonusItem.Contains("Power Investiture"))
                    {
                        // example string: +1 from 'Extra ST'
                        // handles negative also: -1 from 'Reduced IQ`
                        string[] splitBonusItem = bonusItem.Split(' ');

                        // only need the first part
                        if (double.TryParse(splitBonusItem[0], out double modifier))
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
                    // this is a regual trait so add it.
                    var listItem = new RepeatingTrait
                    {
                        Idkey = item.IDKey.ToString(),
                        Name = item.FullName,
                        TraitLevel = item.Level.ToString(),
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
                    Points = 0,
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
                        Difficulty = skill.SkillType,
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
                        Difficulty = skill.SkillType,
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

        public List<RepeatingMelee> GetRepeatingMelee(GCACharacter myCharacter)
        {
            List<RepeatingMelee> list = new List<RepeatingMelee>();

            // loop through all items
            foreach (GCATrait trait in myCharacter.Items)
            {
                // loop through the modes, (usually an attack mode)
                // <attackmodes count="1">
                foreach (Mode mode in trait.Modes)
                {
                    bool isMeleeWeapon = !string.IsNullOrEmpty(mode.get_TagItem("reach"));

                    if (isMeleeWeapon)
                    {
                        string meleeIdKey = trait.IDKey.ToString() + "_" + mode.CollectionKey;

                        string meleeName = trait.FullName;

                        if (trait.FullName != mode.Name && mode.Name.Length > 0)
                        {
                            meleeName += " (" + mode.Name + ")";
                        }

                        var meleeDamage = mode.get_TagItem("chardamage").Replace("d", "d6");

                        if (!double.TryParse(mode.get_TagItem("charskillscore"), out double meleeSkill))
                        {
                            meleeSkill = 0;
                        }

                        if (!double.TryParse(mode.get_TagItem("chararmordivisor"), out double armorDivisor))
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
                // loop through the modes, (usually an attack mode)
                // <attackmodes count="1">
                foreach (Mode mode in trait.Modes)
                {
                    bool isRanged = !string.IsNullOrEmpty(mode.get_TagItem("acc"));

                    if (isRanged)
                    {
                        string rangedIdKey = trait.IDKey.ToString() + "_" + mode.CollectionKey;

                        string rangedName = trait.FullName;

                        if (trait.FullName != mode.Name && mode.Name.Length > 0)
                        {
                            rangedName += " (" + mode.Name + ")";
                        }

                        var rangedDamage = mode.get_TagItem("chardamage").Replace("d", "d6");

                        if (!double.TryParse(mode.get_TagItem("charskillscore"), out double rangedSkill))
                        {
                            rangedSkill = 0;
                        }

                        if (!double.TryParse(mode.get_TagItem("chararmordivisor"), out double armorDivisor))
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

                if (!double.TryParse(trait.get_TagItem("count"), out double itemCount))
                {
                    itemCount = 0;
                }

                if (!double.TryParse(trait.get_TagItem("weight"), out double itemWeight))
                {
                    itemWeight = 0;
                }

                if (!double.TryParse(trait.get_TagItem("cost"), out double itemCost))
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

        public List<RepeatingSpell> GetRepeatingSpells(GCACharacter myCharacter)
        {
            List<RepeatingSpell> list = new List<RepeatingSpell>();

            var spells = myCharacter.ItemsByType[(int)TraitTypes.Spells];

            foreach (GCATrait trait in spells)
            {
                // only get regular spells
                if (!trait.SkillType.StartsWith("tech"))
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

                    var spell = new RepeatingSpell()
                    {
                        Idkey = trait.IDKey.ToString(),
                        Name = trait.FullName,
                        Difficulty = trait.SkillType,
                        SpellModifier = GetTraitModifier(trait),
                        Points = trait.Points,
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

            }

            return list;
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

            if (mode.Name.ToLower() == "brawling" || mode.Name.ToLower() == "karate" || mode.Name.ToLower() == "punch")
            {
                defenseType = "Unarmed Parry";
            }

            // attempt to get a parry score
            var parryValue = mode.get_TagItem("charparryscore");

            if (!double.TryParse(parryValue, out double parryScore))
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
                    Idkey = trait.IDKey + "_" + mode.CollectionKey,
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
            if (trait.Name != "DX" && !categories.ToLower().Contains("talent") && double.TryParse(blockValue, out double block))
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

                if (mode.Name.ToLower().Contains("dodge"))
                {
                    defenseType = "Power Dodge";
                }
                else if (mode.Name.ToLower().Contains("parry"))
                {
                    defenseType = "Power Parry";
                }
                else if (mode.Name.ToLower().Contains("block/physical"))
                {
                    defenseType = "Power Block";
                }
                else if (mode.Name.ToLower().Contains("block/mental"))
                {
                    defenseType = "Power Block Mental";
                }

                var scoreValue = mode.get_TagItem("charskillscore");

                if (double.TryParse(scoreValue, out double score))
                {

                    var powerDefense = new RepeatingDefense
                    {
                        Idkey = trait.IDKey + "_" + mode.CollectionKey,
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

            var userNotes = trait.get_TagItem("usernotes");

            if (userNotes != null)
            {
                notes.Add(userNotes);
            }

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
                    notes.Add(string.Join("\n", nameParts));
                }

            }

            if (trait.Notes.Length > 0)
            {
                notes.Add(trait.Notes);
            }

            var tagDescription = trait.get_TagItem("description");

            if (!string.IsNullOrEmpty(tagDescription))
            {
                notes.Add(tagDescription);
            }

            string noteDescription = string.Join("\n", notes.ToArray());

            return noteDescription;
        }

    }
}
