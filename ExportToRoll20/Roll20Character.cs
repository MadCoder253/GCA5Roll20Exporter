using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ExportToRoll20
{
    public class RepeatingCulture
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "points")]
        public int Points { get; set; }
    }

    public class RepeatingDefense
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "info")]
        public string Info { get; set; }

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; }

        [XmlElement(ElementName = "skill_mod")]
        public int SkillMod { get; set; }

        [XmlElement(ElementName = "defense_mod_reason")]
        public string DefenseModReason { get; set; }

        [XmlElement(ElementName = "info_description")]
        public string InfoDescription { get; set; }
    }

    public class RepeatingDisadvantage
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "trait_level")]
        public string TraitLevel { get; set; }

        [XmlElement(ElementName = "control_rating")]
        public string ControlRating { get; set; }

        [XmlElement(ElementName = "points")]
        public int Points { get; set; }

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; }

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; }
    }

    public class RepeatingItem
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "tl")]
        public string Tl { get; set; }

        [XmlElement(ElementName = "legality_class")]
        public string LegalityClass { get; set; }

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; }

        [XmlElement(ElementName = "count")]
        public int Count { get; set; }

        [XmlElement(ElementName = "cost")]
        public double Cost { get; set; }

        [XmlElement(ElementName = "weight")]
        public double Weight { get; set; }

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; }
    }

    public class RepeatingLanguage
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "spoken")]
        public int Spoken { get; set; }

        [XmlElement(ElementName = "written")]
        public int Written { get; set; }

        [XmlElement(ElementName = "is_native")]
        public bool IsNative { get; set; }
    }

    public class RepeatingMelee
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "damage")]
        public string Damage { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "reach")]
        public string Reach { get; set; }

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; }

        [XmlElement(ElementName = "reason_for_mod")]
        public string ReasonForMod { get; set; }

        [XmlElement(ElementName = "armor_divisor")]
        public int ArmorDivisor { get; set; }

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; }
    }

    public class RepeatingPerk
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "foa")]
        public string Foa { get; set; }

        [XmlElement(ElementName = "points")]
        public int Points { get; set; }

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; }

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; }
    }

    public class RepeatingQuirk
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "control_rating")]
        public string ControlRating { get; set; }

        [XmlElement(ElementName = "points")]
        public int Points { get; set; }

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; }

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; }
    }

    public class RepeatingRacial
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "trait_level")]
        public string TraitLevel { get; set; }

        [XmlElement(ElementName = "control_rating")]
        public string ControlRating { get; set; }

        [XmlElement(ElementName = "points")]
        public int Points { get; set; }

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; }

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; }
    }

    public class RepeatingRanged
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "damage")]
        public string Damage { get; set; }

        [XmlElement(ElementName = "type")]
        public string Type { get; set; }

        [XmlElement(ElementName = "acc")]
        public string Acc { get; set; }

        [XmlElement(ElementName = "range")]
        public string Range { get; set; }

        [XmlElement(ElementName = "rof")]
        public string Rof { get; set; }

        [XmlElement(ElementName = "shots")]
        public string Shots { get; set; }

        [XmlElement(ElementName = "bulk")]
        public string Bulk { get; set; }

        [XmlElement(ElementName = "recoil")]
        public string Recoil { get; set; }

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; }

        [XmlElement(ElementName = "reason_for_mod")]
        public string ReasonForMod { get; set; }

        [XmlElement(ElementName = "malfunction")]
        public string Malfunction { get; set; }

        [XmlElement(ElementName = "malfunction_verify")]
        public bool MalfunctionVerify { get; set; }

        [XmlElement(ElementName = "malfunction_very_reliable")]
        public bool MalfunctionVeryReliable { get; set; }

        [XmlElement(ElementName = "armor_divisor")]
        public double ArmorDivisor { get; set; }

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; }
    }

    public class RepeatingSkill
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "tl")]
        public string Tl { get; set; }

        [XmlElement(ElementName = "base")]
        public string Base { get; set; }

        [XmlElement(ElementName = "difficulty")]
        public string Difficulty { get; set; }

        [XmlElement(ElementName = "bonus")]
        public int Bonus { get; set; }

        [XmlElement(ElementName = "points")]
        public int Points { get; set; }

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; }

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; }

        [XmlElement(ElementName = "skill_mod_notes")]
        public string SkillModNotes { get; set; }

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; }
    }

    public class RepeatingSpell
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "difficulty")]
        public string Difficulty { get; set; }

        [XmlElement(ElementName = "spell_modifier")]
        public int SpellModifier { get; set; }

        [XmlElement(ElementName = "points")]
        public int Points { get; set; }

        [XmlElement(ElementName = "spell_resisted_by")]
        public string SpellResistedBy { get; set; }

        [XmlElement(ElementName = "duration")]
        public string Duration { get; set; }

        [XmlElement(ElementName = "cost")]
        public string Cost { get; set; }

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; }

        [XmlElement(ElementName = "casttime")]
        public string Casttime { get; set; }

        [XmlElement(ElementName = "maintain")]
        public string Maintain { get; set; }

        [XmlElement(ElementName = "spell_class")]
        public string SpellClass { get; set; }

        [XmlElement(ElementName = "spell_college")]
        public string SpellCollege { get; set; }

        [XmlElement(ElementName = "spell_college_secondary")]
        public string SpellCollegeSecondary { get; set; }

        [XmlElement(ElementName = "spell_mod_notes")]
        public string SpellModNotes { get; set; }

        [XmlElement(ElementName = "spell_notes")]
        public string SpellNotes { get; set; }
    }

    public class RepeatingTechniquesrevised
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "parent")]
        public string Parent { get; set; }

        [XmlElement(ElementName = "base_level")]
        public int BaseLevel { get; set; }

        [XmlElement(ElementName = "default")]
        public int Default { get; set; }

        [XmlElement(ElementName = "max_modifier")]
        public int MaxModifier { get; set; }

        [XmlElement(ElementName = "difficulty")]
        public string Difficulty { get; set; }

        [XmlElement(ElementName = "skill_modifier")]
        public int SkillModifier { get; set; }

        [XmlElement(ElementName = "points")]
        public int Points { get; set; }

        [XmlElement(ElementName = "skill")]
        public int Skill { get; set; }

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; }

        [XmlElement(ElementName = "skill_mod_notes")]
        public string SkillModNotes { get; set; }

        [XmlElement(ElementName = "notes")]
        public string Notes { get; set; }
    }

    public class RepeatingTrait
    {
        [XmlElement(ElementName = "idkey")]
        public string Idkey { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "trait_level")]
        public string TraitLevel { get; set; }

        [XmlElement(ElementName = "foa")]
        public string Foa { get; set; }

        [XmlElement(ElementName = "points")]
        public int Points { get; set; }

        [XmlElement(ElementName = "ref")]
        public string Ref { get; set; }

        [XmlElement(ElementName = "trait_level")]
        public string Notes { get; set; }
    }

    public class Roll20Character
    {
        [XmlElement(ElementName = "character_name")]
        public string CharacterName { get; set; }
        
        [XmlElement(ElementName = "fullname")]
        public string Fullname { get; set; }

        [XmlElement(ElementName = "playername")]
        public string Playername { get; set; }

        [XmlElement(ElementName = "nickname")]
        public string Nickname { get; set; }

        [XmlElement(ElementName = "race")]
        public string Race { get; set; }
        
        [XmlElement(ElementName = "race_ref")]
        public string RaceRef { get; set; }

        [XmlElement(ElementName = "template_names")]
        public string TemplateNames { get; set; }

        [XmlElement(ElementName = "gender")]
        public string Gender { get; set; }

        [XmlElement(ElementName = "size")]
        public int Size { get; set; }

        [XmlElement(ElementName = "apply_size_modifier")]
        public bool ApplySizeModifier { get; set; }

        [XmlElement(ElementName = "reactions")]
        public string Reactions { get; set; }

        [XmlElement(ElementName = "campaign_tl")]
        public int CampaignTl { get; set; }

        [XmlElement(ElementName = "tl")]
        public int Tl { get; set; }

        [XmlElement(ElementName = "tl_pts")]
        public int TlPts { get; set; }

        [XmlElement(ElementName = "status")]
        public string Status { get; set; }

        [XmlElement(ElementName = "wealth")]
        public string Wealth { get; set; }

        [XmlElement(ElementName = "income")]
        public int Income { get; set; }

        [XmlElement(ElementName = "cost_of_living")]
        public int CostOfLiving { get; set; }

        [XmlElement(ElementName = "stash")]
        public int Stash { get; set; }

        [XmlElement(ElementName = "age")]
        public int Age { get; set; }

        [XmlElement(ElementName = "height")]
        public string Height { get; set; }

        [XmlElement(ElementName = "weight")]
        public int Weight { get; set; }

        [XmlElement(ElementName = "appearance")]
        public int Appearance { get; set; }

        [XmlElement(ElementName = "general_appearance")]
        public string GeneralAppearance { get; set; }

        [XmlElement(ElementName = "strength_mod")]
        public int StrengthMod { get; set; }

        [XmlElement(ElementName = "strength_points")]
        public int StrengthPoints { get; set; }

        [XmlElement(ElementName = "dexterity_mod")]
        public int DexterityMod { get; set; }

        [XmlElement(ElementName = "dexterity_points")]
        public int DexterityPoints { get; set; }

        [XmlElement(ElementName = "intelligence_mod")]
        public int IntelligenceMod { get; set; }

        [XmlElement(ElementName = "health_mod")]
        public int HealthMod { get; set; }

        [XmlElement(ElementName = "health_points")]
        public int HealthPoints { get; set; }

        [XmlElement(ElementName = "perception_mod")]
        public int PerceptionMod { get; set; }

        [XmlElement(ElementName = "perception_points")]
        public int PerceptionPoints { get; set; }

        [XmlElement(ElementName = "vision_mod")]
        public int VisionMod { get; set; }

        [XmlElement(ElementName = "hearing_mod")]
        public int HearingMod { get; set; }

        [XmlElement(ElementName = "hearing_points")]
        public int HearingPoints { get; set; }

        [XmlElement(ElementName = "taste_smell_mod")]
        public int TasteSmellMod { get; set; }

        [XmlElement(ElementName = "taste_smell_points")]
        public int TasteSmellPoints { get; set; }

        [XmlElement(ElementName = "touch_mod")]
        public int TouchMod { get; set; }

        [XmlElement(ElementName = "touch_points")]
        public int TouchPoints { get; set; }

        [XmlElement(ElementName = "willpower_mod")]
        public int WillpowerMod { get; set; }

        [XmlElement(ElementName = "willpower_points")]
        public int WillpowerPoints { get; set; }

        [XmlElement(ElementName = "fear_check_mod")]
        public int FearCheckMod { get; set; }
        
        [XmlElement(ElementName = "fear_check_points")]
        public int FearCheckPoints { get; set; }

        [XmlElement(ElementName = "stun_check_mod")]
        public int StunCheckMod { get; set; }

        [XmlElement(ElementName = "knockdown_check_mod")]
        public int KnockdownCheckMod { get; set; }

        [XmlElement(ElementName = "unconscious_check_mod")]
        public int UnconsciousCheckMod { get; set; }

        [XmlElement(ElementName = "unconscious_check_points")]
        public int UnconsciousCheckPoints { get; set; }

        [XmlElement(ElementName = "death_check_mod")]
        public int DeathCheckMod { get; set; }

        [XmlElement(ElementName = "death_check_points")]
        public int DeathCheckPoints { get; set; }

        [XmlElement(ElementName = "basic_speed_mod")]
        public int BasicSpeedMod { get; set; }

        [XmlElement(ElementName = "basic_speed_points")]
        public int BasicSpeedPoints { get; set; }

        [XmlElement(ElementName = "basic_move_mod")]
        public int BasicMoveMod { get; set; }

        [XmlElement(ElementName = "basic_move_points")]
        public int BasicMovePoints { get; set; }

        [XmlElement(ElementName = "enhanced_ground_move_mod")]
        public int EnhancedGroundMoveMod { get; set; }

        [XmlElement(ElementName = "enhanced_ground_move_points")]
        public int EnhancedGroundMovePoints { get; set; }

        [XmlElement(ElementName = "dodge_mod")]
        public int DodgeMod { get; set; }

        [XmlElement(ElementName = "lift_st_mod")]
        public int LiftStMod { get; set; }

        [XmlElement(ElementName = "lift_st_points")]
        public int LiftStPoints { get; set; }

        [XmlElement(ElementName = "striking_st_mod")]
        public int StrikingStMod { get; set; }

        [XmlElement(ElementName = "striking_st_points")]
        public int StrikingStPoints { get; set; }

        [XmlElement(ElementName = "hit_points_mod")]
        public int HitPointsMod { get; set; }

        [XmlElement(ElementName = "hit_points_points")]
        public int HitPointsPoints { get; set; }

        [XmlElement(ElementName = "hit_points")]
        public int HitPoints { get; set; }

        [XmlElement(ElementName = "fatigue_points_mod")]
        public int FatiguePointsMod { get; set; }

        [XmlElement(ElementName = "fatigue_points_points")]
        public int FatiguePointsPoints { get; set; }

        [XmlElement(ElementName = "fatigue_points")]
        public int FatiguePoints { get; set; }

        [XmlElement(ElementName = "flight_checked")]
        public bool FlightChecked { get; set; }

        [XmlElement(ElementName = "flight_points")]
        public int FlightPoints { get; set; }

        [XmlElement(ElementName = "basic_air_move_mod")]
        public int BasicAirMoveMod { get; set; }

        [XmlElement(ElementName = "basic_air_move_points")]
        public int BasicAirMovePoints { get; set; }

        [XmlElement(ElementName = "enhanced_air_level")]
        public int EnhancedAirLevel { get; set; }

        [XmlElement(ElementName = "enhanced_air_move_points")]
        public int EnhancedAirMovePoints { get; set; }

        [XmlElement(ElementName = "amphibious_checked")]
        public bool AmphibiousChecked { get; set; }

        [XmlElement(ElementName = "amphibious_points")]
        public int AmphibiousPoints { get; set; }

        [XmlElement(ElementName = "basic_water_move_mod")]
        public int BasicWaterMoveMod { get; set; }

        [XmlElement(ElementName = "basic_water_move_points")]
        public int BasicWaterMovePoints { get; set; }

        [XmlElement(ElementName = "enhanced_water_level")]
        public int EnhancedWaterLevel { get; set; }

        [XmlElement(ElementName = "enhanced_water_move_points")]
        public int EnhancedWaterMovePoints { get; set; }

        [XmlElement(ElementName = "super_jump_entered_level")]
        public int SuperJumpEnteredLevel { get; set; }

        [XmlElement(ElementName = "super_jump_points")]
        public int SuperJumpPoints { get; set; }

        [XmlElement(ElementName = "spell_bonus")]
        public int SpellBonus { get; set; }

        [XmlElement(ElementName = "combat_reflexes")]
        public bool CombatReflexes { get; set; }

        [XmlElement(ElementName = "repeating_languages")]
        public List<RepeatingLanguage> RepeatingLanguages { get; set; }

        [XmlElement(ElementName = "repeating_cultures")]
        public List<RepeatingCulture> RepeatingCultures { get; set; }

        [XmlElement(ElementName = "repeating_traits")]
        public List<RepeatingTrait> RepeatingTraits { get; set; }
        
        [XmlElement(ElementName = "repeating_perks")]
        public List<RepeatingPerk> RepeatingPerks { get; set; }

        [XmlElement(ElementName = "repeating_quirks")]
        public List<RepeatingQuirk> RepeatingQuirks { get; set; }

        [XmlElement(ElementName = "repeating_disadvantages")]
        public List<RepeatingDisadvantage> RepeatingDisadvantages { get; set; }

        [XmlElement(ElementName = "repeating_racial")]
        public List<RepeatingRacial> RepeatingRacial { get; set; }

        [XmlElement(ElementName = "repeating_skills")]
        public List<RepeatingSkill> RepeatingSkills { get; set; }

        [XmlElement(ElementName = "repeating_techniquesrevised")]
        public List<RepeatingTechniquesrevised> RepeatingTechniquesrevised { get; set; }

        [XmlElement(ElementName = "repeating_defense")]
        public List<RepeatingDefense> RepeatingDefense { get; set; }

        [XmlElement(ElementName = "repeating_melee")]
        public List<RepeatingMelee> RepeatingMelee { get; set; }

        [XmlElement(ElementName = "repeating_ranged")]
        public List<RepeatingRanged> RepeatingRanged { get; set; }
        
        [XmlElement(ElementName = "repeating_item")]
        public List<RepeatingItem> RepeatingItem { get; set; }

        [XmlElement(ElementName = "repeating_spells")]
        public List<RepeatingSpell> RepeatingSpells { get; set; }

    }



}
