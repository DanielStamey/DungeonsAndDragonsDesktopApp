using System;

namespace DungeonsAndDragonsDice
{
    interface IDie
    {
        int Roll();
    }

    public abstract class DieBase : IDie
    {
        #region Private Properties
        private string _dieName;
        private int _sides;
        #endregion

        #region Public Properties
        public string DieName { get => _dieName; }
        public int Sides { get => _sides; }
        #endregion

        #region Constructors
        public DieBase(int Sides)
        {
            _dieName = "d" + Sides.ToString();
            _sides = Sides;
        }
        #endregion

        #region Public Functions
        public int Roll()
        {
            Random randomizer = new Random((int)DateTime.Now.Ticks);
            return randomizer.Next(1, _sides + 1);
        }
        #endregion
    }

    public class Die : DieBase
    {
        public Die(int Sides) : base(Sides)
        {
        }
    }

    public class D4 : Die
    {
        public D4() : base(4)
        {
        }
    }

    public class D6 : Die
    {
        public D6() : base(6)
        {
        }
    }

    public class D8 : Die
    {
        public D8() : base(8)
        {
        }
    }

    public class D10 : Die
    {
        public D10() : base(10)
        {
        }
    }

    public class D12 : Die
    {
        public D12() : base(12)
        {
        }
    }

    public class D20 : Die
    {
        public D20() : base(20)
        {
        }
    }

    public class D100 : Die
    {
        public D100() : base(100)
        {
        }
    }
}
