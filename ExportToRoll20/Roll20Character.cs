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

        public string CharacterName { get; set; }

        public string Fullname { get; set; }

        public string Playername { get; set; }

        public string Nickname { get; set; }

        public string Race { get; set; }

        public string RaceRef { get; set; }

        public string TemplateNames { get; set; }

        public string Gender { get; set; }

        public double Size { get; set; } 

        public bool ApplySizeModifier { get; set; }

        public string Reactions { get; set; }

        public double CampaignTl { get; set; } 

        public double TotalPoints { get; set; }

        public double Tl { get; set; } 

        public double TlPts { get; set; } 

        public string Status { get; set; } 

        public string Wealth { get; set; } 

        public double Income { get; set; } 

        public double CostOfLiving { get; set; }

        public double Stash { get; set; } 

        public string Age { get; set; } 

        public string Height { get; set; } 

        public double Weight { get; set; } 

        public double Appearance { get; set; } 

        public string GeneralAppearance { get; set; } 

        public double StrengthMod { get; set; } 

        public double StrengthPoints { get; set; } 

        public double DexterityMod { get; set; } 

        public double DexterityPoints { get; set; } 

        public double IntelligenceMod { get; set; } 

        public double IntelligencePoints { get; set; } 

        public double HealthMod { get; set; } 

        public double HealthPoints { get; set; }

        public double PerceptionMod { get; set; } 

        public double PerceptionPoints { get; set; } 

        public double VisionMod { get; set; } 

        public double VisionPoints { get; set; } 

        public double HearingMod { get; set; }

        public double HearingPoints { get; set; }

        public double TasteSmellMod { get; set; } 

        public double TasteSmellPoints { get; set; } 

        public double TouchMod { get; set; } 

        public double TouchPoints { get; set; } 

        public double WillpowerMod { get; set; } 

        public double WillpowerPoints { get; set; } 

        public double FearCheckMod { get; set; } 

        public double FearCheckPoints { get; set; }

        public double StunCheckMod { get; set; } 

        public double KnockdownCheckMod { get; set; }

        public double UnconsciousCheckMod { get; set; } 

        public double UnconsciousCheckPoints { get; set; }

        public double DeathCheckMod { get; set; } 

        public double DeathCheckPoints { get; set; } 

        public double BasicSpeedMod { get; set; } 

        public double BasicSpeedPoints { get; set; } 

        public double BasicMoveMod { get; set; } 

        public double BasicMovePoints { get; set; } 

        public double EnhancedGroundMoveMod { get; set; } 

        public double EnhancedGroundMovePoints { get; set; } 

        public double DodgeMod { get; set; } 

        public double LiftStMod { get; set; }

        public double LiftStPoints { get; set; } 

        public double StrikingStMod { get; set; } 

        public double StrikingStPoints { get; set; } 

        public double HitPointsMod { get; set; } 

        public double HitPointsPoints { get; set; }

        public double HitPoints { get; set; }

        public double FatiguePointsMod { get; set; }

        public double FatiguePointsPoints { get; set; } 

        public double FatiguePoints { get; set; } 

        public bool FlightChecked { get; set; } 

        public double FlightPoints { get; set; }

        public double BasicAirMoveMod { get; set; } 

        public double BasicAirMovePoints { get; set; }
 
        public double EnhancedAirLevel { get; set; } 

        public double EnhancedAirMovePoints { get; set; } 

        public bool AmphibiousChecked { get; set; } 

        public double AmphibiousPoints { get; set; } 

        public double BasicWaterMoveMod { get; set; }

        public double BasicWaterMovePoints { get; set; } 

        public double EnhancedWaterLevel { get; set; } 

        public double EnhancedWaterMovePoints { get; set; } 

        public double SuperJumpEnteredLevel { get; set; } 

        public double SuperJumpPoints { get; set; } 

        public double SpellBonus { get; set; } 

        public bool CombatReflexes { get; set; }

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

    }

}
