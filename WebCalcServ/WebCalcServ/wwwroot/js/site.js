// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function AddText(inputText) {
    var lab = document.getElementById("ResultLine");
    lab.innerHTML += inputText;
}

function AddNum(buttonText) {
    //if (_input.Length == 0 || Regex.IsMatch(_input, @"(\+\\\-|[\+\-\*/^\(\.]|mod|\d)$"))

    if (true) {
        AddText(buttonText);
    }
}

function AddOperator(buttonText) {

    //if (Regex.IsMatch(text, @"^([\*/^]|mod)$"))
    //{
    //    if (Regex.IsMatch(_input, @"([)x]|\d)$"))
    //    {
    //        Input += text;
    //    }
    //}
    //        else
    //{
    //    if (!Regex.IsMatch(_input, @"(([\+\\\-\*\/\^\(\)]|mod)[\+\\\-])$") && _input.Length != 1)
    //    {
    //        Input += text;
    //    }
    //            else if (Regex.IsMatch(_input, @"([)xX]|\d)$"))
    //    {
    //        Input += text;
    //    }
    //}


    if (true) {
        AddText(buttonText);
    }
}

function AddFunc(buttonText) {
    //if (_input.Length == 0 || Regex.IsMatch(_input, @"([\+\-\*/^(]|mod)$"))
    if (true) {
        AddText(buttonText);
        AddOBranch();
    }
}

function ClearAll() {
    var lab = document.getElementById("ResultLine");
    //branches = 0;
    lab.innerHTML = "";
}

function RemoveLast() {


    //string text = _input;
    //if (Regex.IsMatch(text, @"(\d|[\.\+\-\*\/\)xX])$"))
    //{
    //    if (text.Last() == ')') {
    //        branches++;
    //    }

    //    text = text.Remove(text.Length - 1, 1);
    //}
    //        else if (Regex.IsMatch(text, @"[\(]$"))
    //{
    //    branches--;
    //    text = text.Remove(text.Length - 1, 1);
    //    if (Regex.IsMatch(text, @"(ln)$"))
    //    {
    //        text = text.Remove(text.Length - 2, 2);
    //    }
    //            else if (text.Length != 0 && !Regex.IsMatch(text, @"[\(]$"))
    //    {
    //        text = text.Remove(text.Length - 3, 3);
    //        if (Regex.IsMatch(text, @"[as]$"))
    //        {
    //            text = text.Remove(text.Length - 1, 1);
    //        }
    //    }
    //}
    //        else if (Regex.IsMatch(text, @"(\w)$"))
    //{
    //    text = text.Remove(text.Length - 3, 3);
    //}
    //Input = text;


}

function SwitchSign() {
    //string text = _input;
    //if (text.Last() == '-') {
    //    text = text.Remove(text.Length - 1, 1);
    //    text += '+';
    //}
    //else if (text.Last() == '+') {
    //    text = text.Remove(text.Length - 1, 1);
    //    text += "-";
    //}
    //Input = text;

}


function AddDot() {
    ///if (!Regex.IsMatch(_input, @"\d+[.]\d+$") && Regex.IsMatch(_input, @"\d+$"))
    {
        AddText(".");
    }
}

function AddX() {
    //if (_input.Length == 0 || Regex.IsMatch(_input, @"([\+\-\*/^(]|mod)$"))
    {
        AddText("x");
    }
}

function AddOBranch() {
    {
        //branches++;
        AddText("(");
    }
}

function AddCBranch() {
    //if (branches != 0 && Regex.IsMatch(_input, @"(\d|[)]|[xX])$"))
    {
        //branches--; 
        AddText(")");
    }
}