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
        private string _spellLevel;
        private string _spellName;
        private string _castingTime;
        private string _spellRange;
        private string _spellComponents;
        private string _spellDuration;
        private string _school;
        private string _spellTarget;

        private bool _isConcentration;
        private bool _isRitual;
        private string _spellLevelIncreases;

        private string _spellDescription;
        #endregion

        #region Public Properties

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
// Range: {Self, touch, # feet, # yards }
// Area of Affect: {# foot radius, # foot sphere, # foot cone}
// Components: {V (Verbal), S (Somatic), M (Material) }
// Duration: {Instantaneous, # minutes, # rounds, # hours, # days, special, Until Dispelled}
// School: {Illusion, Conjuration, Abjuration, Transmutation
//          , Enchantment, Necromancy, Divination, Evocation}
