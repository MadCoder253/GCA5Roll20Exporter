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
        public Roll20Character GetCharacter(Party party)
        {
            Roll20Character roll20Character = new Roll20Character();

            var currentCharacter = party.Current;
            
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
                int sizeMod = (int)traitSizeMod.Score; 
                roll20Character.Size = sizeMod;
                roll20Character.ApplySizeModifier = sizeMod > 0;

                // TODO: Get reactions
                roll20Character.Reactions = "";

                roll20Character.CampaignTl = int.Parse( currentCharacter.TL);
                // TODO: Use "Tech Level" attributes trait to determine characters TL and point cost
                roll20Character.Tl = int.Parse(currentCharacter.TL);
                roll20Character.TlPts = 0;


                

            }

            return roll20Character;

        }

        public string GetItemValueByName(GCACharacter myCharacter, string itemName, string defaultValue = "")
        {
            var x = myCharacter.ItemsByName(itemName, (int)TraitTypes.Attributes);
           
            var value = defaultValue;
            
            if (x.Count > 0)
            {
                GCATrait gCATrait = (GCATrait)x[1];
                value = gCATrait.Score.ToString();
            }

            return value;
        }
    }
}
