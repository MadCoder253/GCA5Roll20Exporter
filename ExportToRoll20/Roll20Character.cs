using System.Collections.Generic;

namespace ExportToRoll20
{
    public class RepeatingCulture
    {
        public RepeatingCulture()
        {
            Idkey = "";
            Name = "";
            Points = 0;
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public double Points { get; set; }

    }

    public class RepeatingDefense
    {
        public RepeatingDefense()
        {
            Idkey = "";
            Name = "";
            Type = "";
            Info = "";
            Skill = 0;
            SkillMod = 0;
            DefenseModReason = "";
            InfoDescription = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Info { get; set; }

        public double Skill { get; set; }

        public double SkillMod { get; set; }

        public string DefenseModReason { get; set; }

        public string InfoDescription { get; set; }

    }

    public class RepeatingDisadvantage
    {
        public RepeatingDisadvantage()
        {
            Idkey = "";
            Name = "";
            TraitLevel = "";
            ControlRating = "";
            Points = 0;
            Ref = "";
            Notes = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string TraitLevel { get; set; }

        public string ControlRating { get; set; }

        public double Points { get; set; }

        public string Ref { get; set; }

        public string Notes { get; set; }

    }

    public class RepeatingItem
    {
        public RepeatingItem()
        {
            Idkey = "";
            Notes = "";
            Tl = "";
            LegalityClass = "";
            Ref = "";
            Count = 0;
            Cost = 0;
            Weight = 0;
            Notes = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string Tl { get; set; }

        public string LegalityClass { get; set; }

        public string Ref { get; set; }

        public double Count { get; set; }

        public double Cost { get; set; }

        public double Weight { get; set; }

        public string Notes { get; set; }

    }

    public class RepeatingLanguage
    {
        public RepeatingLanguage()
        {
            Idkey = "";
            Name = "";
            Spoken = 0;
            Written = 0;
            IsNative = false;
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public double Spoken { get; set; }

        public double Written { get; set; }

        public bool IsNative { get; set; }

    }

    public class RepeatingMelee
    {
        public RepeatingMelee()
        {
            Idkey = "";
            Name = "";
            Damage = "";
            Type = "";
            Reach = "";
            Skill = 10;
            ArmorDivisor = 1;
            Notes = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string Damage { get; set; }

        public string Type { get; set; }

        public string Reach { get; set; }

        public double Skill { get; set; }

        public double ArmorDivisor { get; set; }

        public string Notes { get; set; }

    }

    public class RepeatingPerk
    {
        public RepeatingPerk()
        {
            Idkey = "";
            Name = "";
            Foa = "";
            Points = 0;
            Ref = "";
            Notes = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string Foa { get; set; }

        public double Points { get; set; }

        public string Ref { get; set; }

        public string Notes { get; set; }
    }

    public class RepeatingQuirk
    {
        public RepeatingQuirk()
        {
            Idkey = "";
            Name = "";
            ControlRating = "";
            Points = 0;
            Ref = "";
            Notes = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string ControlRating { get; set; }

        public double Points { get; set; }

        public string Ref { get; set; }

        public string Notes { get; set; }

        
    }

    public class RepeatingRacial
    {
        public RepeatingRacial()
        {
            Idkey = "";
            Name = "";
            TraitLevel = "";
            ControlRating = "";
            Points = 0;
            Ref = "";
            Notes = "";

        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string TraitLevel { get; set; }

        public string ControlRating { get; set; }

        public double Points { get; set; }

        public string Ref { get; set; }

        public string Notes { get; set; }
    }

    public class RepeatingRanged
    {
        public RepeatingRanged()
        {
            Idkey = "";
            Name = "";
            Damage = "";
            Type = "";
            Acc = "";
            Range = "";
            Rof = "";
            Shots = "";
            Bulk = "";
            Recoil = "";
            Skill = 10;
            Malfunction = "";
            MalfunctionVerify = false;
            MalfunctionVeryReliable = false;
            ArmorDivisor = 1;
            Notes = "";
        }

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

        public double Skill { get; set; }

        public string Malfunction { get; set; }

        public bool MalfunctionVerify { get; set; }

        public bool MalfunctionVeryReliable { get; set; } 

        public double ArmorDivisor { get; set; }

        public string Notes { get; set; }
    }

    public class RepeatingSkill
    {
        public RepeatingSkill()
        {
            Idkey = "";
            Name = "";
            Tl = "";
            Base = "";
            Difficulty = "";
            Bonus = 0;
            Points = 0;
            Skill = 10;
            Ref = "";
            SkillModNotes = "";
            Notes = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string Tl { get; set; }

        public string Base { get; set; }

        public string Difficulty { get; set; }

        public double Bonus { get; set; }

        public double Points { get; set; }

        public double Skill { get; set; }

        public string Ref { get; set; }

        public string SkillModNotes { get; set; }

        public string Notes { get; set; }
    }

    public class RepeatingSpell
    {
        public RepeatingSpell()
        {
            Idkey = "";
            Name = "";
            Difficulty = "";
            SpellModifier = 0;
            Points = 0;
            SpellResistedBy = "";
            Duration = "";
            Cost = "";
            Skill = 10;
            Ref = "";
            Casttime = "";
            Maintain = "";
            SpellClass = "";
            SpellCollege = "";
            SpellCollegeSecondary = "";
            SpellModNotes = "";
            SpellNotes = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string Difficulty { get; set; }

        public double SpellModifier { get; set; }

        public double Points { get; set; }

        public string SpellResistedBy { get; set; }

        public string Duration { get; set; }

        public string Cost { get; set; }

        public double Skill { get; set; }

        public string Ref { get; set; }

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
        public RepeatingTechniquesrevised()
        {
            Idkey = "";
            Name = "";
            Parent = "";
            BaseLevel = "";
            Default = 0;
            MaxModifier = 0;
            Difficulty = "";
            SkillModifier = 0;
            Points = 0;
            Skill = 10;
            Ref = "";
            SkillModNotes = "";
            Notes = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string Parent { get; set; }

        public string BaseLevel { get; set; }

        public double Default { get; set; }

        public double MaxModifier { get; set; }

        public string Difficulty { get; set; }

        public double SkillModifier { get; set; }

        public double Points { get; set; }

        public double Skill { get; set; }

        public string Ref { get; set; }

        public string SkillModNotes { get; set; }

        public string Notes { get; set; }
    }

    public class RepeatingTrait
    {
        public RepeatingTrait()
        {
            Idkey = "";
            Name = "";
            TraitLevel = "";
            Foa = "";
            Points = 0;
            Ref = "";
            Notes = "";
        }

        public string Idkey { get; set; }

        public string Name { get; set; }

        public string TraitLevel { get; set; }

        public string Foa { get; set; }

        public double Points { get; set; }

        public string Ref { get; set; }

        public string Notes { get; set; }
    }

    public class Roll20Character
    {
        public Roll20Character()
        {
            CharacterName = "";
            Fullname = "";
            Playername = "";
            Nickname = "";
            Race = "";
            RaceRef = "";
            TemplateNames = "";
            Gender = "";
            Size = 0;
            ApplySizeModifier = false;
            Reactions = "";
            CampaignTl = 0;
            TotalPoints = 0;
            Tl = 0;
            TlPts = 0;
            Status = "";
            Wealth = "";
            Income = 0;
            CostOfLiving = 0;
            Stash = 0;
            Age = "";
            Height = "";
            Weight = 0;
            Appearance = 0;
            GeneralAppearance = "";
            StrengthMod = 0;
            StrengthPoints = 0;
            DexterityMod = 0;
            DexterityPoints = 0;
            IntelligenceMod = 0;
            IntelligencePoints = 0;
            HealthMod = 0;
            HealthPoints = 0;
            PerceptionMod = 0; 
            PerceptionPoints = 0;
            VisionMod = 0;
            VisionPoints = 0;
            HearingMod = 0;
            HearingPoints = 0;
            TasteSmellMod = 0;
            TasteSmellPoints = 0;
            TouchMod = 0;
            TouchPoints = 0;
            WillpowerMod = 0;
            WillpowerPoints = 0;
            FearCheckMod = 0;
            FearCheckPoints = 0;
            StunCheckMod = 0;
            KnockdownCheckMod = 0;
            UnconsciousCheckMod = 0;
            UnconsciousCheckPoints = 0;
            DeathCheckMod = 0;
            DeathCheckPoints = 0;
            BasicSpeedMod = 0;
            BasicSpeedPoints = 0;
            EnhancedGroundMoveMod = 0;
            EnhancedGroundMovePoints = 0;
            DodgeMod = 0;
            LiftStMod = 0;
            LiftStPoints = 0;
            StrikingStMod = 0;
            StrikingStPoints = 0;
            HitPointsMod = 0;
            HitPointsPoints = 0;
            HitPoints = 10;
            FatiguePointsMod = 0;
            FatiguePointsPoints = 0;
            FatiguePoints = 10;
            FlightChecked = false;
            BasicAirMoveMod = 0; 
            BasicAirMovePoints = 0;
            EnhancedAirLevel = 0;
            EnhancedAirMovePoints = 0;
            AmphibiousChecked = false;
            AmphibiousPoints = 0;
            BasicWaterMoveMod = 0;
            BasicWaterMovePoints = 0;
            EnhancedWaterLevel = 0;
            EnhancedWaterMovePoints = 0;
            SuperJumpEnteredLevel = 0;
            SuperJumpPoints = 0;
            SpellBonus = 0;
            CombatReflexes = false;
            RepeatingLanguages = new List<RepeatingLanguage>();
            RepeatingCultures = new List<RepeatingCulture>();
            RepeatingTraits = new List<RepeatingTrait>();
            RepeatingPerks = new List<RepeatingPerk>();
            RepeatingQuirks = new List<RepeatingQuirk>();
            RepeatingDisadvantages = new List<RepeatingDisadvantage>();
            RepeatingRacial = new List<RepeatingRacial>();
            RepeatingSkills = new List<RepeatingSkill>();
            RepeatingTechniquesrevised = new List<RepeatingTechniquesrevised>();
            RepeatingDefense = new List<RepeatingDefense>();
            RepeatingMelee = new List<RepeatingMelee>();
            RepeatingRanged = new List<RepeatingRanged>();
            RepeatingItem = new List<RepeatingItem>();
            RepeatingSpells = new List<RepeatingSpell>();

        }

        public string CharacterName { get; set; } = "";

        public string Fullname { get; set; } = "";

        public string Playername { get; set; } = "";

        public string Nickname { get; set; } = "";

        public string Race { get; set; } = "";

        public string RaceRef { get; set; } = "";

        public string TemplateNames { get; set; } = "";

        public string Gender { get; set; } = "";

        public double Size { get; set; } = 0;

        public bool ApplySizeModifier { get; set; } = false;

        public string Reactions { get; set; } = "";

        public double CampaignTl { get; set; } = 0;

        public double TotalPoints { get; set; } = 0;

        public double Tl { get; set; } = 0;

        public double TlPts { get; set; } = 0;

        public string Status { get; set; } = "";

        public string Wealth { get; set; } = "";

        public double Income { get; set; } = 0;

        public double CostOfLiving { get; set; } = 0;

        public double Stash { get; set; } = 0;

        public string Age { get; set; } = "";

        public string Height { get; set; } = "";

        public double Weight { get; set; } = 0;

        public double Appearance { get; set; } = 0;

        public string GeneralAppearance { get; set; } = "";

        public double StrengthMod { get; set; } = 0;

        public double StrengthPoints { get; set; } = 0;

        public double DexterityMod { get; set; } = 0;

        public double DexterityPoints { get; set; } = 0;

        public double IntelligenceMod { get; set; } = 0;

        public double IntelligencePoints { get; set; } = 0;

        public double HealthMod { get; set; } = 0;

        public double HealthPoints { get; set; } = 0;

        public double PerceptionMod { get; set; } = 0;

        public double PerceptionPoints { get; set; } = 0;

        public double VisionMod { get; set; } = 0;

        public double VisionPoints { get; set; } = 0;

        public double HearingMod { get; set; } = 0;

        public double HearingPoints { get; set; } = 0;

        public double TasteSmellMod { get; set; } = 0;

        public double TasteSmellPoints { get; set; } = 0;

        public double TouchMod { get; set; } = 0;

        public double TouchPoints { get; set; } = 0;

        public double WillpowerMod { get; set; } = 0;

        public double WillpowerPoints { get; set; } = 0;

        public double FearCheckMod { get; set; } = 0;

        public double FearCheckPoints { get; set; } = 0;

        public double StunCheckMod { get; set; } = 0;

        public double KnockdownCheckMod { get; set; } = 0;

        public double UnconsciousCheckMod { get; set; } = 0;

        public double UnconsciousCheckPoints { get; set; } = 0;

        public double DeathCheckMod { get; set; } = 0;

        public double DeathCheckPoints { get; set; } = 0;

        public double BasicSpeedMod { get; set; } = 0;

        public double BasicSpeedPoints { get; set; } = 0;

        public double BasicMoveMod { get; set; } = 0;

        public double BasicMovePoints { get; set; } = 0;

        public double EnhancedGroundMoveMod { get; set; } = 0;

        public double EnhancedGroundMovePoints { get; set; } = 0;

        public double DodgeMod { get; set; } = 0;

        public double LiftStMod { get; set; } = 0;

        public double LiftStPoints { get; set; } = 0;

        public double StrikingStMod { get; set; } = 0;

        public double StrikingStPoints { get; set; } = 0;

        public double HitPointsMod { get; set; } = 0;

        public double HitPointsPoints { get; set; } = 0;

        public double HitPoints { get; set; } = 0;

        public double FatiguePointsMod { get; set; } = 0;

        public double FatiguePointsPoints { get; set; } = 0;

        public double FatiguePoints { get; set; } = 0;

        public bool FlightChecked { get; set; } = false;

        public double FlightPoints { get; set; } = 0;

        public double BasicAirMoveMod { get; set; } = 0;

        public double BasicAirMovePoints { get; set; } = 0;

        public double EnhancedAirLevel { get; set; } = 0;

        public double EnhancedAirMovePoints { get; set; } = 0;

        public bool AmphibiousChecked { get; set; } = false;

        public double AmphibiousPoints { get; set; } = 0;

        public double BasicWaterMoveMod { get; set; } = 0;

        public double BasicWaterMovePoints { get; set; } = 0;

        public double EnhancedWaterLevel { get; set; } = 0;

        public double EnhancedWaterMovePoints { get; set; } = 0;

        public double SuperJumpEnteredLevel { get; set; } = 0;

        public double SuperJumpPoints { get; set; } = 0;

        public double SpellBonus { get; set; } = 0;

        public bool CombatReflexes { get; set; } = false;

        public List<RepeatingLanguage> RepeatingLanguages { get; set; } = new List<RepeatingLanguage>();

        public List<RepeatingCulture> RepeatingCultures { get; set; } = new List<RepeatingCulture>();

        public List<RepeatingTrait> RepeatingTraits { get; set; } = new List<RepeatingTrait>();

        public List<RepeatingPerk> RepeatingPerks { get; set; } = new List<RepeatingPerk>();

        public List<RepeatingQuirk> RepeatingQuirks { get; set; } = new List<RepeatingQuirk>();

        public List<RepeatingDisadvantage> RepeatingDisadvantages { get; set; } = new List<RepeatingDisadvantage>();

        public List<RepeatingRacial> RepeatingRacial { get; set; } = new List<RepeatingRacial>();

        public List<RepeatingSkill> RepeatingSkills { get; set; } = new List<RepeatingSkill>();

        public List<RepeatingTechniquesrevised> RepeatingTechniquesrevised { get; set; } = new List<RepeatingTechniquesrevised>();

        public List<RepeatingDefense> RepeatingDefense { get; set; } = new List<RepeatingDefense>();

        public List<RepeatingMelee> RepeatingMelee { get; set; } = new List<RepeatingMelee>();

        public List<RepeatingRanged> RepeatingRanged { get; set; } = new List<RepeatingRanged>();

        public List<RepeatingItem> RepeatingItem { get; set; } = new List<RepeatingItem>();

        public List<RepeatingSpell> RepeatingSpells { get; set; } = new List<RepeatingSpell>();

    }

}
