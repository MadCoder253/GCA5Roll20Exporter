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
        private List<string> allTemplateNeeds = new List<string>();

        public string GetAllTemplateNeeds()
        {
            return string.Join(", ", allTemplateNeeds.ToArray());
        }

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
                    if (!bonusItem.Contains("combat reflexes"))
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

        /// <summary>
        /// Gives is a list of traits provided by a template.
        /// Function will look for partial string matches to a trait name.
        /// </summary>
        /// <param name="trait"></param>
        /// <param name="gives"></param>
        /// <returns></returns>
        public bool IsRacialTrait(GCATrait trait, string needs)
        {
            var traitName = trait.FullName;

            var templateNeeds = needs.Split(',');

            bool isRacial = templateNeeds.Any(given => given.Contains(traitName));

            return isRacial;
        }

        public List<RepeatingTrait> GetRepeatingTraits(GCACharacter myCharacter, bool getRacialTraits = false, string needs = "")
        {
            List<RepeatingTrait> list = new List<RepeatingTrait>();

            var advantages = myCharacter.ItemsByType[(int)TraitTypes.Advantages];

            foreach (GCATrait item in advantages)
            {
                if (getRacialTraits == false && IsRacialTrait(item, GetAllTemplateNeeds()) == false)
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
                else if (getRacialTraits == true && IsRacialTrait(item, needs) == true)
                {
                    // this a racial trait, so add it
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

        public List<RepeatingPerk> GetRepeatingPerks(GCACharacter myCharacter, bool getRacialTraits = false, string needs = "")
        {
            List<RepeatingPerk> list = new List<RepeatingPerk>();

            // regular perks
            var perks = myCharacter.ItemsByType[(int)TraitTypes.Perks];

            foreach (GCATrait item in perks)
            {
                if (getRacialTraits == false && IsRacialTrait(item, GetAllTemplateNeeds()) == false)
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
                else if (getRacialTraits == true && IsRacialTrait(item, needs) == true)
                {
                    // this a racial trait, so add it
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

        public List<RepeatingPerk> GetRepeatingFeatures(GCACharacter myCharacter, bool getRacialTraits = false, string needs = "")
        {
            List<RepeatingPerk> list = new List<RepeatingPerk>();

            // regular perks
            var perks = myCharacter.ItemsByType[(int)TraitTypes.Features];

            foreach (GCATrait item in perks)
            {
                if (getRacialTraits == false && IsRacialTrait(item, GetAllTemplateNeeds()) == false)
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
                else if (getRacialTraits == true && IsRacialTrait(item, needs) == true)
                {
                    // this a racial trait, so add it
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

        public List<RepeatingQuirk> GetRepeatingQuirks(GCACharacter myCharacter, bool getRacialTraits = false, string needs = "")
        {
            List<RepeatingQuirk> list = new List<RepeatingQuirk>();

            var quirks = myCharacter.ItemsByType[(int)TraitTypes.Quirks];

            foreach (GCATrait item in quirks)
            {
                if (getRacialTraits == false && IsRacialTrait(item, GetAllTemplateNeeds()) == false)
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
                else if (getRacialTraits == true && IsRacialTrait(item, needs) == true)
                {
                    // this a racial quirk, so add it
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

        public List<RepeatingDisadvantage> GetRepeatingDisadvantages(GCACharacter myCharacter, bool getRacialTraits = false, string needs = "")
        {
            List<RepeatingDisadvantage> list = new List<RepeatingDisadvantage>();

            var disadvantages = myCharacter.ItemsByType[(int)TraitTypes.Disadvantages];

            foreach (GCATrait item in disadvantages)
            {
                if (getRacialTraits == false && IsRacialTrait(item, GetAllTemplateNeeds()) == false)
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
                else if (getRacialTraits == true && IsRacialTrait(item, needs) == true)
                {
                    // this a racial disadvantage, so add it
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

                var thisTemplatesNeeds = template.get_TagItem("needs").Split(seperators, StringSplitOptions.RemoveEmptyEntries);

                // there could be more than one template, so we want to store them all
                allTemplateNeeds.AddRange(thisTemplatesNeeds);

            }

            return string.Join(", ", templateNames.ToArray());
        }

        public List<RepeatingRacial> GetRepeatingTemplates(GCACharacter myCharacter)
        {
            var templates = myCharacter.ItemsByType[(int)TraitTypes.Templates];

            List<RepeatingRacial> list = new List<RepeatingRacial>();

            foreach (GCATrait template in templates)
            {
                var notes = GetRacialTemplateNotes(template);

                var racialTrait = new RepeatingRacial
                {
                    Idkey = template.IDKey.ToString(),
                    Name = template.FullName,
                    Points = template.Points,
                    Ref = template.get_TagItem("ref"),
                    Notes = notes
                };

                list.Add(racialTrait);

                // needs: advantages, disadvantages, etc. added to template
                var needs = template.get_TagItem("needs");

                if (!string.IsNullOrEmpty(needs))
                {
                    var racialNeeds = GetRepeatingRacialNeeds(myCharacter, needs);

                    list.AddRange(racialNeeds);
                };

            }

            return list;
        }

        public string GetRacialTemplateNotes(GCATrait trait)
        {
            string notes = "";

            List<string> listNotes = new List<string>();

            // description
            var description = trait.get_TagItem("description");

            if (!string.IsNullOrEmpty(description))
            {
                listNotes.Add("Description: " + description);
            }

            // needs: advantages, disadvantages, etc. added to template
            string[] seperators = { ", " };

            string[] listNeeds = trait.get_TagItem("needs").Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            if (listNeeds.Length > 0)
            {
                string notesNeeds = "Traits:\n" + string.Join("\n", listNeeds);

                listNotes.Add(notesNeeds);
            }

            // gives: modifiers to various traits; ST, IQ, etc.
            string[] listGives = trait.get_TagItem("gives").Split(',');

            if (listGives.Length > 0)
            {
                string notesGives = "Gives:\n" + string.Join("\n", listGives);

                listNotes.Add(notesGives);
            }

            if (listNotes.Count > 0)
            {
                notes = string.Join("\n", listNotes.ToArray());
            }

            return notes;
        }

        /// <summary>
        /// Gets all:needs (advantages, disadvantages, etc) for a specific template
        /// The needs is defined by the template, so we use that to find matching traits
        /// </summary>
        /// <param name="myCharacter"></param>
        /// <param name="needs"></param>
        /// <returns></returns>
        public List<RepeatingRacial> GetRepeatingRacialNeeds(GCACharacter myCharacter, string needs)
        {
            List<RepeatingRacial> list = new List<RepeatingRacial>();

            // get advantages
            var advantages = GetRepeatingTraits(myCharacter, true, needs);

            foreach (var trait in advantages)
            {
                var racialTrait = new RepeatingRacial()
                {
                    Idkey = trait.Idkey,
                    Name = trait.Name,
                    TraitLevel = trait.TraitLevel,
                    ControlRating = trait.Foa,
                    Points = 0,
                    Ref = trait.Ref,
                    Notes = trait.Notes
                };

                list.Add(racialTrait);
            }

            // get perks
            var perks = GetRepeatingPerks(myCharacter, true, needs);

            foreach (var perk in perks)
            {
                var racialTrait = new RepeatingRacial
                {
                    Idkey = perk.Idkey,
                    Name = perk.Name,
                    TraitLevel = "",
                    ControlRating = perk.Foa,
                    Points = 0,
                    Ref = perk.Ref,
                    Notes = perk.Notes
                };

                list.Add(racialTrait);

            }

            // get features
            var features = GetRepeatingFeatures(myCharacter, true, needs);

            foreach (var feature in features)
            {
                var racialTrait = new RepeatingRacial
                {
                    Idkey = feature.Idkey,
                    Name = feature.Name,
                    TraitLevel = "",
                    ControlRating = feature.Foa,
                    Points = 0,
                    Ref = feature.Ref,
                    Notes = feature.Notes
                };

                list.Add(racialTrait);

            }

            // get quirks
            var quirks = GetRepeatingQuirks(myCharacter, true, needs);

            foreach (var quirk in quirks)
            {
                var racialTrait = new RepeatingRacial
                {
                    Idkey = quirk.Idkey,
                    Name = quirk.Name,
                    TraitLevel = "",
                    ControlRating = quirk.ControlRating,
                    Points = 0,
                    Ref = quirk.Ref,
                    Notes = quirk.Notes
                };

                list.Add(racialTrait);
            }

            // get disadvantages
            var disadvantages = GetRepeatingDisadvantages(myCharacter, true, needs);

            foreach (var disadvantage in disadvantages)
            {
                var racialTrait = new RepeatingRacial
                {
                    Idkey = disadvantage.Idkey,
                    Name = disadvantage.Name,
                    TraitLevel = disadvantage.TraitLevel,
                    ControlRating = disadvantage.ControlRating,
                    Points = 0,
                    Ref = disadvantage.Ref,
                    Notes = disadvantage.Notes
                };

                list.Add(racialTrait);
            }

            return list;

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
            foreach(GCATrait trait in myCharacter.Items)
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

            if (trait.FullName != mode.Name)
            {
                defenseName += " (" + mode.Name + ")";
            }

            if (string.IsNullOrEmpty(accValue) && !string.IsNullOrEmpty(mode.Name) && parryScore > 0)
            {
                var item = new RepeatingDefense
                {
                    Idkey = trait.IDKey + "_" + mode.Name,
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

                var append = "power";

                if (mode.Name.ToLower().Contains("dodge"))
                {
                    defenseType = "Power Dodge";
                    append = "_power_dodge";
                }
                else if (mode.Name.ToLower().Contains("parry"))
                {
                    defenseType = "Power Parry";
                    append = "_power_parry";
                }
                else if (mode.Name.ToLower().Contains("block/physical"))
                {
                    defenseType = "Power Block";
                    append = "_power_block_physical";
                }
                else if (mode.Name.ToLower().Contains("block/mental"))
                {
                    defenseType = "Power Block Mental";
                    append = "_power_block_mental";
                }

                var scoreValue = mode.get_TagItem("charskillscore");

                if (double.TryParse(scoreValue, out double score))
                {

                    var powerDefense = new RepeatingDefense
                    {
                        Idkey = trait.IDKey + append,
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

            string noteDescription = string.Join("\n", notes.ToArray());

            return noteDescription;
        }

    }
}
