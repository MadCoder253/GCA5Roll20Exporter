using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportToRoll20
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FinalValues
    {
        public bool CombatReflexes { get; set; }
    }

    public class RepeatingCulture
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
    }

    public class RepeatingDefense
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Info { get; set; }
        public int Skill { get; set; }
        public int SkillMod { get; set; }
        public string DefenseModReason { get; set; }
        public string InfoDescription { get; set; }
    }

    public class RepeatingDisadvantage
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string TraitLevel { get; set; }
        public string ControlRating { get; set; }
        public int Points { get; set; }
        public string Ref { get; set; }
        public string Notes { get; set; }
    }

    public class RepeatingItem
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string Tl { get; set; }
        public string LegalityClass { get; set; }
        public string Ref { get; set; }
        public int Count { get; set; }
        public double Cost { get; set; }
        public double Weight { get; set; }
        public string Notes { get; set; }
    }

    public class RepeatingLanguage
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public int Spoken { get; set; }
        public int Written { get; set; }
        public bool IsNative { get; set; }
    }

    public class RepeatingMelee
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public string Type { get; set; }
        public string Reach { get; set; }
        public int Skill { get; set; }
        public string ReasonForMod { get; set; }
        public int ArmorDivisor { get; set; }
        public string Notes { get; set; }
    }

    public class RepeatingPerk
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string Foa { get; set; }
        public int Points { get; set; }
        public string Ref { get; set; }
        public string Notes { get; set; }
    }

    public class RepeatingQuirk
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string ControlRating { get; set; }
        public int Points { get; set; }
        public string Ref { get; set; }
        public string Notes { get; set; }
    }

    public class RepeatingRacial
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string TraitLevel { get; set; }
        public string ControlRating { get; set; }
        public int Points { get; set; }
        public string Ref { get; set; }
        public string Notes { get; set; }
    }

    public class RepeatingRanged
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string Damage { get; set; }
        public string Type { get; set; }
        public string Acc { get; set; }
        public string Range { get; set; }
        public string Rof { get; set; }
        public string Shots { get; set; }
        public string Bulk { get; set; }
        public string Recoil { get; set; }
        public int Skill { get; set; }
        public string ReasonForMod { get; set; }
        public string Malfunction { get; set; }
        public bool MalfunctionVerify { get; set; }
        public bool MalfunctionVeryReliable { get; set; }
        public double ArmorDivisor { get; set; }
        public string Notes { get; set; }
    }

    public class RepeatingSkill
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string Tl { get; set; }
        public string Base { get; set; }
        public string Difficulty { get; set; }
        public int Bonus { get; set; }
        public int Points { get; set; }
        public int UseWildcardPoints { get; set; }
        public int UseNormalPoints { get; set; }
        public int WildcardSkillPoints { get; set; }
        public string Ref { get; set; }
        public string SkillModNotes { get; set; }
        public string Notes { get; set; }
    }

    public class RepeatingSpell
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string Difficulty { get; set; }
        public int SpellModifier { get; set; }
        public int Points { get; set; }
        public string SpellResistedBy { get; set; }
        public string Duration { get; set; }
        public string Cost { get; set; }
        public string Casttime { get; set; }
        public string Maintain { get; set; }
        public string SpellClass { get; set; }
        public string SpellCollege { get; set; }
        public string SpellCollegeSecondary { get; set; }
        public string SpellModNotes { get; set; }
        public string SpellNotes { get; set; }
    }

    public class RepeatingTechniquesrevised
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string Parent { get; set; }
        public int BaseLevel { get; set; }
        public int Default { get; set; }
        public int MaxModifier { get; set; }
        public string Difficulty { get; set; }
        public int SkillModifier { get; set; }
        public int Points { get; set; }
        public string Ref { get; set; }
        public string SkillModNotes { get; set; }
        public string Notes { get; set; }
    }

    public class RepeatingTrait
    {
        public string Idkey { get; set; }
        public string Name { get; set; }
        public string TraitLevel { get; set; }
        public string Foa { get; set; }
        public int Points { get; set; }
        public string Ref { get; set; }
        public string Notes { get; set; }
    }

    public class Roll20Character
    {
        public string CharacterName { get; set; }
        public string Fullname { get; set; }
        public string Playername { get; set; }
        public string Nickname { get; set; }
        public string Race { get; set; }
        public string RaceRef { get; set; }
        public string TemplateNames { get; set; }
        public string Gender { get; set; }
        public int Size { get; set; }
        public bool ApplySizeModifier { get; set; }
        public string Reactions { get; set; }
        public int CampaignTl { get; set; }
        public int Tl { get; set; }
        public int TlPts { get; set; }
        public string Status { get; set; }
        public string Wealth { get; set; }
        public int Income { get; set; }
        public int CostOfLiving { get; set; }
        public int Stash { get; set; }
        public int Age { get; set; }
        public string Height { get; set; }
        public int Weight { get; set; }
        public int Appearance { get; set; }
        public string GeneralAppearance { get; set; }
        public int StrengthMod { get; set; }
        public int StrengthPoints { get; set; }
        public int DexterityMod { get; set; }
        public int DexterityPoints { get; set; }
        public int IntelligenceMod { get; set; }
        public int HealthMod { get; set; }
        public int HealthPoints { get; set; }
        public int PerceptionMod { get; set; }
        public int PerceptionPoints { get; set; }
        public int VisionMod { get; set; }
        public int HearingMod { get; set; }
        public int HearingPoints { get; set; }
        public int TasteSmellMod { get; set; }
        public int TasteSmellPoints { get; set; }
        public int TouchMod { get; set; }
        public int WillpowerMod { get; set; }
        public int WillpowerPoints { get; set; }
        public int FearCheckMod { get; set; }
        public int FearCheckPoints { get; set; }
        public int StunCheckMod { get; set; }
        public int KnockdownCheckMod { get; set; }
        public int UnconsciousCheckMod { get; set; }
        public int UnconsciousCheckPoints { get; set; }
        public int DeathCheckMod { get; set; }
        public int DeathCheckPoints { get; set; }
        public int BasicSpeedMod { get; set; }
        public int BasicSpeedPoints { get; set; }
        public int BasicMoveMod { get; set; }
        public int BasicMovePoints { get; set; }
        public int EnhancedGroundMoveMod { get; set; }
        public int EnhancedGroundMovePoints { get; set; }
        public int DodgeMod { get; set; }
        public int LiftStMod { get; set; }
        public int LiftStPoints { get; set; }
        public int StrikingStMod { get; set; }
        public int StrikingStPoints { get; set; }
        public int HitPointsMod { get; set; }
        public int HitPointsPoints { get; set; }
        public int HitPoints { get; set; }
        public int FatiguePointsMod { get; set; }
        public int FatiguePointsPoints { get; set; }
        public int FatiguePoints { get; set; }
        public bool FlightChecked { get; set; }
        public int FlightPoints { get; set; }
        public int BasicAirMoveMod { get; set; }
        public int BasicAirMovePoints { get; set; }
        public int EnhancedAirLevel { get; set; }
        public int EnhancedAirMovePoints { get; set; }
        public bool AmphibiousChecked { get; set; }
        public int AmphibiousPoints { get; set; }
        public int BasicWaterMoveMod { get; set; }
        public int BasicWaterMovePoints { get; set; }
        public int EnhancedWaterLevel { get; set; }
        public int EnhancedWaterMovePoints { get; set; }
        public int SuperJumpEnteredLevel { get; set; }
        public int SuperJumpPoints { get; set; }
        public int SpellBonus { get; set; }
        public List<RepeatingLanguage> RepeatingLanguages { get; set; }
        public List<RepeatingCulture> RepeatingCultures { get; set; }
        public List<RepeatingTrait> RepeatingTraits { get; set; }
        public List<RepeatingPerk> RepeatingPerks { get; set; }
        public List<RepeatingQuirk> RepeatingQuirks { get; set; }
        public List<RepeatingDisadvantage> RepeatingDisadvantages { get; set; }
        public List<RepeatingRacial> RepeatingRacial { get; set; }
        public List<RepeatingSkill> RepeatingSkills { get; set; }
        public List<RepeatingTechniquesrevised> RepeatingTechniquesrevised { get; set; }
        public List<RepeatingDefense> RepeatingDefense { get; set; }
        public List<RepeatingMelee> RepeatingMelee { get; set; }
        public List<RepeatingRanged> RepeatingRanged { get; set; }
        public List<RepeatingItem> RepeatingItem { get; set; }
        public List<RepeatingSpell> RepeatingSpells { get; set; }
        public FinalValues FinalValues { get; set; }
    }



}
