using System;

namespace Task_NET01_1
{
    class TextMaterial : Material
    {
        public TextMaterial(string text, string descript = null) : base(descript)
        {
            Text = text;
        }
        public override object Clone()
        {
            return new TextMaterial(this.Text, this.Descript)
            {
                Guid = this.Guid
            };
        }

        private string _text;
        public string Text
        {
            get
            {
                return _text;
            }
            set 
            {
                const int _maxLengthText = 1000;
                if (value == null || _maxLengthText < value.Length || value == string.Empty)
                {
                    throw new Exception($"Text can't be null|empty or longer {_maxLengthText}");
                }

                _text = value;
            } 
        }

    }
}
