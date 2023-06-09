using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static SkiaSharp.HarfBuzz.SKShaper;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace DesckCalcSH.ModelSource
{
    public class ModelView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private Model model = new Model() { RawString = "" };
        private string _input = "";
        private string _result = "";
        private int branches = 0;
        public string Result
        {
            get => _result;
            private set {
                 if (branches == 0 && Regex.IsMatch(_input, @"(\d|[)xX])$") && model.RawString != value)
                {
                    model.RawString = value;
                    model.PrepareString();
                    if (_input.Contains('x')) 
                    {
                        _result = "Press = end open chart page to build graph";
                    }
                    else
                    {
                        _result = model.Calculate().ToString();
                    }
                    OnPropertyChanged();
                }
            }
        }
        public string Input
        {
            get => _input;
            set
            {
                if (_input != value)
                {
                    _input = value;
                    Result = _input;
                    OnPropertyChanged();
                }
            }
        }
        
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public void RemoveLast() 
        {
            string text = _input;
            if (Regex.IsMatch(text, @"(\d|[\.\+\-\*\/\)xX])$"))
            {
                if (text.Last() == ')')
                {
                    branches++;
                }

                text = text.Remove(text.Length - 1, 1);
            }
            else if (Regex.IsMatch(text, @"[\(]$"))
            {
                branches--;
                text = text.Remove(text.Length - 1, 1);
                if (Regex.IsMatch(text, @"(ln)$"))
                {
                    text = text.Remove(text.Length - 2, 2);
                }
                else if (text.Length != 0 && !Regex.IsMatch(text, @"[\(]$"))
                {
                    text = text.Remove(text.Length - 3, 3);
                    if (Regex.IsMatch(text, @"[as]$"))
                    {
                        text = text.Remove(text.Length - 1, 1);
                    }
                }
            }
            else if (Regex.IsMatch(text, @"(\w)$"))
            {
                text = text.Remove(text.Length - 3, 3);
            }
            Input = text;
        }
        public void AllClear() 
        {
            branches = 0;
            Input = "";
        }
        public void SwitchSign() 
        {
            string text = _input;
            if (text.Last() == '-')
            {
                text = text.Remove(text.Length - 1, 1);
                text += '+';
            }
            else if (text.Last() == '+')
            {
                text = text.Remove(text.Length - 1, 1);
                text += "-";
            }
            Input = text;
        }
        public void AddString(string text) { Input += text; }
        public void AddOBranch() { branches++; Input += "("; }
        public void AddCBranch() { 
            if (branches != 0 && Regex.IsMatch(_input, @"(\d|[)]|[xX])$"))
            {
                branches--; 
                Input += ")"; 
            }
        }
        public void AddDot() {
            if (!Regex.IsMatch(_input, @"\d+[.]\d+$") && Regex.IsMatch(_input, @"\d+$"))
            {
                Input += ".";
            }
        }
        public void AddX() 
        {
            if (_input.Length == 0 || Regex.IsMatch(_input, @"([\+\-\*/^(]|mod)$"))
            {
                Input += "x";
            }
        }
        public void AddNum(string text)
        {
            if (_input.Length == 0 || Regex.IsMatch(_input, @"(\+\\\-|[\+\-\*/^\(\.]|mod|\d)$"))
            {
                AddString(text);
            }
        }
        public void AddOperator(string text) 
        {

            if (Regex.IsMatch(text, @"^([\*/^]|mod)$"))
            {
                if (Regex.IsMatch(_input, @"([)x]|\d)$"))
                {
                    Input += text;
                }
            }
            else
            {
                if (!Regex.IsMatch(_input, @"(([\+\\\-\*\/\^\(\)]|mod)[\+\\\-])$") && _input.Length != 1)
                {
                    Input += text;
                }
                else if (Regex.IsMatch(_input, @"([)xX]|\d)$"))
                {
                    Input += text;
                }
            }
        }
        public void AddFunction(string text) 
        {
            if (_input.Length == 0 || Regex.IsMatch(_input, @"([\+\-\*/^(]|mod)$"))
            {
                AddString(text);
                AddOBranch();
            }
        }

        public Model GetModel() 
        {
            if (branches == 0 && Regex.IsMatch(_input, @"(\d|[)xX])$"))
            {
                model.RawString = _input;
                model.PrepareString();
                return model;
            }
            else 
            {
                return null;
            }
        }
    }
}
