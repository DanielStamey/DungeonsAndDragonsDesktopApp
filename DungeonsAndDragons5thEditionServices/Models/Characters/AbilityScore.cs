using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DungeonsAndDragons5thEditionServices
{
    public abstract class AbilityScoreBase
    {
        #region Private Properties
        private string _abilityName;
        private int _baseValue;
        private List<int> _modifiers;
        #endregion

        #region Public Properties
        public string AbilityName { get => _abilityName; }
        public int BaseValue { get => _baseValue; }
        public int AbilityModifier
        {
            get
            {
                switch (Value)
                {
                    case 1:
                        {
                            return -5;
                        }
                    case 2:
                    case 3:
                        {
                            return -4;
                        }
                    case 4:
                    case 5:
                        {
                            return -3;
                        }
                    case 6:
                    case 7:
                        {
                            return -2;
                        }
                    case 8:
                    case 9:
                        {
                            return -1;
                        }
                    case 10:
                    case 11:
                        {
                            return 0;
                        }
                    case 12:
                    case 13:
                        {
                            return 1;
                        }
                    case 14:
                    case 15:
                        {
                            return 2;
                        }
                    case 16:
                    case 17:
                        {
                            return 3;
                        }
                    case 18:
                    case 19:
                        {
                            return 4;
                        }
                    case 20:
                    case 21:
                        {
                            return 5;
                        }
                    case 22:
                    case 23:
                        {
                            return 6;
                        }
                    case 24:
                    case 25:
                        {
                            return 7;
                        }
                    case 26:
                    case 27:
                        {
                            return 8;
                        }
                    case 28:
                    case 29:
                        {
                            return 9;
                        }
                    case 30:
                        {
                            return 10;
                        }
                    default:
                        return 0;
                }

            }
        }
        public List<int> Modifiers { get => _modifiers; set => _modifiers = value; }
        public int Value
        {
            get
            {
                int value = _baseValue;
                foreach (int val in _modifiers)
                {
                    value += val;
                }
                return value <= 30 ? value : 30;
            }
        }
        #endregion

        #region Constructors
        public AbilityScoreBase(string name, int baseValue)
        {
            _abilityName = name;
            _baseValue = baseValue;
            if (baseValue > 30)
            {
                _baseValue = 30;
            }
            else if (baseValue < 1)
            {
                _baseValue = 1;
            }
            Modifiers = new List<int>();
        }
        #endregion
    }

    public class AbilityScore : AbilityScoreBase
    {
        public AbilityScore(string name, int baseValue) : base(name, baseValue)
        {
        }
    }
}
