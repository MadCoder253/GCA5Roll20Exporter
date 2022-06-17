using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExportToRoll20
{
    [XmlRoot("character")]
    public class RepeatingCulture
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "points")]
        public int Points { get; set; } = 0;
    }

    public class RepeatingDefense
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "type")]
        public string Type { get; set; } = "";

        [XmlElement(ElementName = "info")]
        public string Info { get; set; } = "";

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; } = 0;

        [XmlElement(ElementName = "skill_mod")]
        public int SkillMod { get; set; } = 0;

        [XmlElement(ElementName = "defense_mod_reason")]
        public string DefenseModReason { get; set; } = "";

        [XmlElement(ElementName = "info_description")]
        public string InfoDescription { get; set; } = "";
    }

    public class RepeatingDisadvantage
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "trait_level")]
        public string TraitLevel { get; set; } = "";

        [XmlElement(ElementName = "control_rating")]
        public string ControlRating { get; set; } = "";

        [XmlElement(ElementName = "points")]
        public int Points { get; set; } = 0;

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; } = "";

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class RepeatingItem
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "tl")]
        public string Tl { get; set; } = "";

        [XmlElement(ElementName = "legality_class")]
        public string LegalityClass { get; set; } = "";

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; } = "";

        [XmlElement(ElementName = "count")]
        public int Count { get; set; } = 0;

        [XmlElement(ElementName = "cost")]
        public double Cost { get; set; } = 0;

        [XmlElement(ElementName = "weight")]
        public double Weight { get; set; } = 0;

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class RepeatingLanguage
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "spoken")]
        public int Spoken { get; set; } = 0;

        [XmlElement(ElementName = "written")]
        public int Written { get; set; } = 0;

        [XmlElement(ElementName = "is_native")]
        public bool IsNative { get; set; } = false;
    }

    public class RepeatingMelee
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "damage")]
        public string Damage { get; set; } = "";

        [XmlElement(ElementName = "type")]
        public string Type { get; set; } = "";

        [XmlElement(ElementName = "reach")]
        public string Reach { get; set; } = "";

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; } = 0;

        [XmlElement(ElementName = "reason_for_mod")]
        public string ReasonForMod { get; set; } = "";

        [XmlElement(ElementName = "armor_divisor")]
        public int ArmorDivisor { get; set; } = 0;

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class RepeatingPerk
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "foa")]
        public string Foa { get; set; } = "";

        [XmlElement(ElementName = "points")]
        public int Points { get; set; } = 0;

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; } = "";

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class RepeatingQuirk
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "control_rating")]
        public string ControlRating { get; set; } = "";

        [XmlElement(ElementName = "points")]
        public int Points { get; set; } = 0;

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; } = "";

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class RepeatingRacial
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "trait_level")]
        public string TraitLevel { get; set; } = "";

        [XmlElement(ElementName = "control_rating")]
        public string ControlRating { get; set; } = "";

        [XmlElement(ElementName = "points")]
        public int Points { get; set; } = 0;

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; } = "";

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class RepeatingRanged
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "damage")]
        public string Damage { get; set; } = "";

        [XmlElement(ElementName = "type")]
        public string Type { get; set; } = "";

        [XmlElement(ElementName = "acc")]
        public string Acc { get; set; } = "";

        [XmlElement(ElementName = "range")]
        public string Range { get; set; } = "";

        [XmlElement(ElementName = "rof")]
        public string Rof { get; set; } = "";

        [XmlElement(ElementName = "shots")]
        public string Shots { get; set; } = "";

        [XmlElement(ElementName = "bulk")]
        public string Bulk { get; set; } = "";

        [XmlElement(ElementName = "recoil")]
        public string Recoil { get; set; } = "";

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; } = 0;

        [XmlElement(ElementName = "reason_for_mod")]
        public string ReasonForMod { get; set; } = "";

        [XmlElement(ElementName = "malfunction")]
        public string Malfunction { get; set; } = "";

        [XmlElement(ElementName = "malfunction_verify")]
        public bool MalfunctionVerify { get; set; } = false;

        [XmlElement(ElementName = "malfunction_very_reliable")]
        public bool MalfunctionVeryReliable { get; set; } = false;

        [XmlElement(ElementName = "armor_divisor")]
        public double ArmorDivisor { get; set; } = 0;

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class RepeatingSkill
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "tl")]
        public string Tl { get; set; } = "";

        [XmlElement(ElementName = "base")]
        public string Base { get; set; } = "";

        [XmlElement(ElementName = "difficulty")]
        public string Difficulty { get; set; } = "";

        [XmlElement(ElementName = "bonus")]
        public int Bonus { get; set; } = 0;

        [XmlElement(ElementName = "points")]
        public int Points { get; set; } = 0;

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; } = 0;

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; } = "";

        [XmlElement(ElementName = "skill_mod_notes")]
        public string SkillModNotes { get; set; } = "";

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class RepeatingSpell
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "difficulty")]
        public string Difficulty { get; set; } = "";

        [XmlElement(ElementName = "spell_modifier")]
        public int SpellModifier { get; set; } = 0;

        [XmlElement(ElementName = "points")]
        public int Points { get; set; } = 0;

        [XmlElement(ElementName = "spell_resisted_by")]
        public string SpellResistedBy { get; set; } = "";

        [XmlElement(ElementName = "duration")]
        public string Duration { get; set; } = "";

        [XmlElement(ElementName = "cost")]
        public string Cost { get; set; } = "";

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; } = 0;

        [XmlElement(ElementName = "casttime")]
        public string Casttime { get; set; } = "";

        [XmlElement(ElementName = "maintain")]
        public string Maintain { get; set; } = "";

        [XmlElement(ElementName = "spell_class")]
        public string SpellClass { get; set; } = "";

        [XmlElement(ElementName = "spell_college")]
        public string SpellCollege { get; set; } = "";

        [XmlElement(ElementName = "spell_college_secondary")]
        public string SpellCollegeSecondary { get; set; } = "";

        [XmlElement(ElementName = "spell_mod_notes")]
        public string SpellModNotes { get; set; } = "";

        [XmlElement(ElementName = "spell_notes")]
        public string SpellNotes { get; set; } = "";
    }

    public class RepeatingTechniquesrevised
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "parent")]
        public string Parent { get; set; } = "";

        [XmlElement(ElementName = "base_level")]
        public int BaseLevel { get; set; } = 0;

        [XmlElement(ElementName = "default")]
        public int Default { get; set; } = 0;

        [XmlElement(ElementName = "max_modifier")]
        public int MaxModifier { get; set; } = 0;

        [XmlElement(ElementName = "difficulty")]
        public string Difficulty { get; set; } = "";

        [XmlElement(ElementName = "skill_modifier")]
        public int SkillModifier { get; set; } = 0;

        [XmlElement(ElementName = "points")]
        public int Points { get; set; } = 0;

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; } = 0;

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; } = "";

        [XmlElement(ElementName = "skill_mod_notes")]
        public string SkillModNotes { get; set; } = "";

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class RepeatingTrait
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; } = "";

        [XmlElement(ElementName = "name")]
        public string Name { get; set; } = "";

        [XmlElement(ElementName = "trait_level")]
        public string TraitLevel { get; set; } = "";

        [XmlElement(ElementName = "foa")]
        public string Foa { get; set; } = "";

        [XmlElement(ElementName = "points")]
        public int Points { get; set; } = 0;

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; } = "";

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; } = "";
    }

    public class Roll20Character
    {
        [XmlElement(ElementName = "character_name")]
        public string CharacterName { get; set; } = "";

        [XmlElement(ElementName = "fullname")]
        public string Fullname { get; set; } = "";

        [XmlElement(ElementName = "playername")]
        public string Playername { get; set; } = "";

        [XmlElement(ElementName = "nickname")]
        public string Nickname { get; set; } = "";

        [XmlElement(ElementName = "race")]
        public string Race { get; set; } = "";

        [XmlElement(ElementName = "race_ref")]
        public string RaceRef { get; set; } = "";

        [XmlElement(ElementName = "template_names")]
        public string TemplateNames { get; set; } = "";

        [XmlElement(ElementName = "gender")]
        public string Gender { get; set; } = "";

        [XmlElement(ElementName = "size")]
        public int Size { get; set; } = 0;

        [XmlElement(ElementName = "apply_size_modifier")]
        public bool ApplySizeModifier { get; set; } = false;

        [XmlElement(ElementName = "reactions")]
        public string Reactions { get; set; } = "";

        [XmlElement(ElementName = "campaign_tl")]
        public int CampaignTl { get; set; } = 0;

        [XmlElement(ElementName = "total_points")]
        public int TotalPoints { get; set; } = 0;

        [XmlElement(ElementName = "tl")]
        public int Tl { get; set; } = 0;

        [XmlElement(ElementName = "tl_pts")]
        public int TlPts { get; set; } = 0;

        [XmlElement(ElementName = "status")]
        public string Status { get; set; } = "";

        [XmlElement(ElementName = "wealth")]
        public string Wealth { get; set; } = "";

        [XmlElement(ElementName = "income")]
        public double Income { get; set; } = 0;

        [XmlElement(ElementName = "cost_of_living")]
        public double CostOfLiving { get; set; } = 0;

        [XmlElement(ElementName = "stash")]
        public double Stash { get; set; } = 0;

        [XmlElement(ElementName = "age")]
        public string Age { get; set; } = "";

        [XmlElement(ElementName = "height")]
        public string Height { get; set; } = "";

        [XmlElement(ElementName = "weight")]
        public double Weight { get; set; } = 0;

        [XmlElement(ElementName = "appearance")]
        public int Appearance { get; set; } = 0;

        [XmlElement(ElementName = "general_appearance")]
        public string GeneralAppearance { get; set; } = "";

        [XmlElement(ElementName = "strength_mod")]
        public int StrengthMod { get; set; } = 0;

        [XmlElement(ElementName = "strength_points")]
        public int StrengthPoints { get; set; } = 0;

        [XmlElement(ElementName = "dexterity_mod")]
        public int DexterityMod { get; set; } = 0;

        [XmlElement(ElementName = "dexterity_points")]
        public int DexterityPoints { get; set; } = 0;

        [XmlElement(ElementName = "intelligence_mod")]
        public int IntelligenceMod { get; set; } = 0;

        [XmlElement(ElementName = "intelligence_points")]
        public int IntelligencePoints { get; set; } = 0;

        [XmlElement(ElementName = "health_mod")]
        public int HealthMod { get; set; } = 0;

        [XmlElement(ElementName = "health_points")]
        public int HealthPoints { get; set; } = 0;

        [XmlElement(ElementName = "perception_mod")]
        public int PerceptionMod { get; set; } = 0;

        [XmlElement(ElementName = "perception_points")]
        public int PerceptionPoints { get; set; } = 0;

        [XmlElement(ElementName = "vision_mod")]
        public int VisionMod { get; set; } = 0;

        [XmlElement(ElementName = "vision_points")]
        public int VisionPoints { get; set; } = 0;

        [XmlElement(ElementName = "hearing_mod")]
        public int HearingMod { get; set; } = 0;

        [XmlElement(ElementName = "hearing_points")]
        public int HearingPoints { get; set; } = 0;

        [XmlElement(ElementName = "taste_smell_mod")]
        public int TasteSmellMod { get; set; } = 0;

        [XmlElement(ElementName = "taste_smell_points")]
        public int TasteSmellPoints { get; set; } = 0;

        [XmlElement(ElementName = "touch_mod")]
        public int TouchMod { get; set; } = 0;

        [XmlElement(ElementName = "touch_points")]
        public int TouchPoints { get; set; } = 0;

        [XmlElement(ElementName = "willpower_mod")]
        public int WillpowerMod { get; set; } = 0;

        [XmlElement(ElementName = "willpower_points")]
        public int WillpowerPoints { get; set; } = 0;

        [XmlElement(ElementName = "fear_check_mod")]
        public int FearCheckMod { get; set; } = 0;

        [XmlElement(ElementName = "fear_check_points")]
        public int FearCheckPoints { get; set; } = 0;

        [XmlElement(ElementName = "stun_check_mod")]
        public int StunCheckMod { get; set; } = 0;

        [XmlElement(ElementName = "knockdown_check_mod")]
        public int KnockdownCheckMod { get; set; } = 0;

        [XmlElement(ElementName = "unconscious_check_mod")]
        public int UnconsciousCheckMod { get; set; } = 0;

        [XmlElement(ElementName = "unconscious_check_points")]
        public int UnconsciousCheckPoints { get; set; } = 0;

        [XmlElement(ElementName = "death_check_mod")]
        public int DeathCheckMod { get; set; } = 0;

        [XmlElement(ElementName = "death_check_points")]
        public int DeathCheckPoints { get; set; } = 0;

        [XmlElement(ElementName = "basic_speed_mod")]
        public int BasicSpeedMod { get; set; } = 0;

        [XmlElement(ElementName = "basic_speed_points")]
        public int BasicSpeedPoints { get; set; } = 0;

        [XmlElement(ElementName = "basic_move_mod")]
        public int BasicMoveMod { get; set; } = 0;

        [XmlElement(ElementName = "basic_move_points")]
        public int BasicMovePoints { get; set; } = 0;

        [XmlElement(ElementName = "enhanced_ground_move_mod")]
        public int EnhancedGroundMoveMod { get; set; } = 0;

        [XmlElement(ElementName = "enhanced_ground_move_points")]
        public int EnhancedGroundMovePoints { get; set; } = 0;

        [XmlElement(ElementName = "dodge_mod")]
        public int DodgeMod { get; set; } = 0;

        [XmlElement(ElementName = "lift_st_mod")]
        public int LiftStMod { get; set; } = 0;

        [XmlElement(ElementName = "lift_st_points")]
        public int LiftStPoints { get; set; } = 0;

        [XmlElement(ElementName = "striking_st_mod")]
        public int StrikingStMod { get; set; } = 0;

        [XmlElement(ElementName = "striking_st_points")]
        public int StrikingStPoints { get; set; } = 0;

        [XmlElement(ElementName = "hit_points_mod")]
        public int HitPointsMod { get; set; } = 0;

        [XmlElement(ElementName = "hit_points_points")]
        public int HitPointsPoints { get; set; } = 0;

        [XmlElement(ElementName = "hit_points")]
        public int HitPoints { get; set; } = 0;

        [XmlElement(ElementName = "fatigue_points_mod")]
        public int FatiguePointsMod { get; set; } = 0;

        [XmlElement(ElementName = "fatigue_points_points")]
        public int FatiguePointsPoints { get; set; } = 0;

        [XmlElement(ElementName = "fatigue_points")]
        public int FatiguePoints { get; set; } = 0;

        [XmlElement(ElementName = "flight_checked")]
        public bool FlightChecked { get; set; } = false;

        [XmlElement(ElementName = "flight_points")]
        public int FlightPoints { get; set; } = 0;

        [XmlElement(ElementName = "basic_air_move_mod")]
        public int BasicAirMoveMod { get; set; } = 0;

        [XmlElement(ElementName = "basic_air_move_points")]
        public int BasicAirMovePoints { get; set; } = 0;

        [XmlElement(ElementName = "enhanced_air_level")]
        public int EnhancedAirLevel { get; set; } = 0;

        [XmlElement(ElementName = "enhanced_air_move_points")]
        public int EnhancedAirMovePoints { get; set; } = 0;

        [XmlElement(ElementName = "amphibious_checked")]
        public bool AmphibiousChecked { get; set; } = false;

        [XmlElement(ElementName = "amphibious_points")]
        public int AmphibiousPoints { get; set; } = 0;

        [XmlElement(ElementName = "basic_water_move_mod")]
        public int BasicWaterMoveMod { get; set; } = 0;

        [XmlElement(ElementName = "basic_water_move_points")]
        public int BasicWaterMovePoints { get; set; } = 0;

        [XmlElement(ElementName = "enhanced_water_level")]
        public int EnhancedWaterLevel { get; set; } = 0;

        [XmlElement(ElementName = "enhanced_water_move_points")]
        public int EnhancedWaterMovePoints { get; set; } = 0;

        [XmlElement(ElementName = "super_jump_entered_level")]
        public int SuperJumpEnteredLevel { get; set; } = 0;

        [XmlElement(ElementName = "super_jump_points")]
        public int SuperJumpPoints { get; set; } = 0;

        [XmlElement(ElementName = "spell_bonus")]
        public int SpellBonus { get; set; } = 0;

        [XmlElement(ElementName = "combat_reflexes")]
        public bool CombatReflexes { get; set; } = false;

        [XmlArray("repeating_languages")]
        [XmlArrayItem("language")]
        public List<RepeatingLanguage> RepeatingLanguages { get; set; } = new List<RepeatingLanguage>();

        [XmlArray("repeating_cultures")]
        [XmlArrayItem("culture")]
        public List<RepeatingCulture> RepeatingCultures { get; set; } = new List<RepeatingCulture>();

        [XmlArray("repeating_traits")]
        [XmlArrayItem("trait")]
        public List<RepeatingTrait> RepeatingTraits { get; set; } = new List<RepeatingTrait>();

        [XmlArray("repeating_perks")]
        [XmlArrayItem("perk")]
        public List<RepeatingPerk> RepeatingPerks { get; set; } = new List<RepeatingPerk>();

        [XmlArray("repeating_quirks")]
        [XmlArrayItem("quirk")]
        public List<RepeatingQuirk> RepeatingQuirks { get; set; } = new List<RepeatingQuirk>();

        [XmlArray("repeating_disadvantages")]
        [XmlArrayItem("disadvantage")]
        public List<RepeatingDisadvantage> RepeatingDisadvantages { get; set; } = new List<RepeatingDisadvantage>();

        [XmlArray("repeating_racial")]
        [XmlArrayItem("racial_trait")]
        public List<RepeatingRacial> RepeatingRacial { get; set; } = new List<RepeatingRacial>();

        [XmlArray("repeating_skills")]
        [XmlArrayItem("skill")]
        public List<RepeatingSkill> RepeatingSkills { get; set; } = new List<RepeatingSkill>();

        [XmlArray("repeating_techniquesrevised")]
        [XmlArrayItem("technique")]
        public List<RepeatingTechniquesrevised> RepeatingTechniquesrevised { get; set; } = new List<RepeatingTechniquesrevised>();

        [XmlArray("repeating_defense")]
        [XmlArrayItem("defense")]
        public List<RepeatingDefense> RepeatingDefense { get; set; } = new List<RepeatingDefense>();

        [XmlArray("repeating_melee")]
        [XmlArrayItem("melee")]
        public List<RepeatingMelee> RepeatingMelee { get; set; } = new List<RepeatingMelee>();

        [XmlArray("repeating_ranged")]
        [XmlArrayItem("ranged")]
        public List<RepeatingRanged> RepeatingRanged { get; set; } = new List<RepeatingRanged>();

        [XmlArray("repeating_item")]
        [XmlArrayItem("item")]
        public List<RepeatingItem> RepeatingItem { get; set; } = new List<RepeatingItem>();

        [XmlArray("repeating_spells")]
        [XmlArrayItem("spell")]
        public List<RepeatingSpell> RepeatingSpells { get; set; } = new List<RepeatingSpell>();

    }

}
