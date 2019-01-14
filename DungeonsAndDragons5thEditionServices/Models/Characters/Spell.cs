using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragons5thEditionServices.Models.Characters
{
    class Spell
    {
        #region Private Properties
        [BsonElement(elementName: "Level")]
        private int _spellLevel;
        [BsonElement(elementName: "Name")]
        private string _spellName;
        [BsonElement(elementName: "CastingTime")]
        private string _castingTime;
        [BsonElement(elementName: "Range")]
        private string _spellRange;
        [BsonElement(elementName: "Components")]
        private string _spellComponents;
        [BsonElement(elementName: "Duration")]
        private string _spellDuration;
        [BsonElement(elementName: "School")]
        private string _school;

        [BsonElement(elementName: "Description")]
        private string _spellDescription;

        [BsonElement(elementName: "AtHigherLevels")]
        private string _atHigherLevels;
        #endregion

        #region Public Properties
        public int SpellLevel { get => _spellLevel; set => _spellLevel = value; }
        public string SpellName { get => _spellName; set => _spellName = value; }
        public string CastingTime { get => _castingTime; set => _castingTime = value; }
        public string SpellRange { get => _spellRange; set => _spellRange = value; }
        public string SpellComponents { get => _spellComponents; set => _spellComponents = value; }
        public string SpellDuration { get => _spellDuration; set => _spellDuration = value; }
        public string School { get => _school; set => _school = value; }
        public string SpellDescription { get => _spellDescription; set => _spellDescription = value; }
        public string AtHigherLevels { get => _atHigherLevels; set => _atHigherLevels = value; }
        #endregion

        #region Constructors

        #endregion

        #region Private Functions

        #endregion

        #region Public Functions

        #endregion
    }
}

// Casting Times: {1 reaction, 1 bonus action, 1 action, # minutes, # hours, # days}
// Range: {Self, touch, # feet, # yards, # miles }
// Area of Affect: {# foot radius, # foot sphere, # foot cone}
// Components: {V (Verbal), S (Somatic), M (Material) }
// Duration: {Instantaneous, # minutes, # rounds, # hours, # days, special, Until Dispelled}
// School: {Illusion, Conjuration, Abjuration, Transmutation
//          , Enchantment, Necromancy, Divination, Evocation}
