using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DungeonsAndDragons5thEditionServices
{
    public abstract class SkillBase
    {
        #region Private Properties
        private string _skillName;
        private int _baseValue;
        private bool _expert = false;
        private bool _proficient = false;
        private int _proficiency;
        private List<int> _modifiers;
        #endregion

        #region Public Properties
        public string SkillName { get => _skillName; }
        public List<int> Modifiers { get => _modifiers; set => _modifiers = value; }
        public int Value
        {
            get
            {
                int value = _baseValue;
                if(_proficient)
                {
                    if(_expert)
                    {
                        value += 2 * _proficiency;
                    }
                    else
                    {
                        value += _proficiency;
                    }
                }
                foreach (int val in _modifiers)
                {
                    value += val;
                }
                return value;
            }
        }

        public bool Proficient { get => _proficient; set => _proficient = value; }
        #endregion

        #region Constructors
        public SkillBase(string name, int baseValue, int proficiency)
        {
            _skillName = name;
            _baseValue = baseValue;
            _proficiency = proficiency;
            Modifiers = new List<int>();
        }
        #endregion
    }

    public class Skill : SkillBase
    {
        public Skill(string name, int baseValue, int proficiency) : base(name, baseValue, proficiency)
        {
        }
    }
}
