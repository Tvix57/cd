// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var branches = 0; // branches count

function AddText(inputText) {
    var lab = document.getElementById("ResultLine");
    lab.innerHTML += inputText;
}

function AddNum(buttonText) {
    const regex = /(\+\\\-|[\+\-\*/^\(\.]|mod|\d)$/;
    var resLine = document.getElementById("ResultLine").innerHTML;
    if (resLine.length === 0 || regex.test(resLine)) {
        AddText(buttonText);
    }
}

function AddOperator(buttonText) {
    var resLine = document.getElementById("ResultLine").innerHTML;
    const regex1 = /^([\*/\^]|mod)$/;
    const regex2 = /([)xX]|\d)$/;
    const regex3 = /(([\+\\\-\*\/\^\(\)]|mod)[\+\\\-])$/;
    if (regex1.test(buttonText)) {
        if (regex2.test(resLine)) {
            AddText(buttonText);
        }
    } else {
        if (!(regex3.test(resLine)) && !(resLine.length === 1)) {
            AddText(buttonText);
        } else if (regex2.test(resLine)) {
            AddText(buttonText);
        }
    }
}

function AddFunc(buttonText) {
    const regex = /([\+\-\*/^(]|mod)$/;
    var resLine = document.getElementById("ResultLine").innerHTML;
    if (resLine.length === 0 || regex.test(resLine)) {
        AddText(buttonText);
        AddOBranch();
    }
}

function ClearAll() {
    var lab = document.getElementById("ResultLine");
    branches = 0;
    lab.innerHTML = "";
}

function RemoveLast() {
    const regex1 = /(\d|[\.\+\-\*\/\)xX])$/;
    const regex2 = /(\w)$/;
    var lab = document.getElementById("ResultLine");
    var resLine = lab.innerHTML;
    if (regex1.test(resLine)) {
        if (resLine[resLine.length - 1] === ")") {
            branches++;
        }
        resLine = resLine.slice(0, -1);
    } else if (resLine[resLine.length - 1] === "d") {
        resLine = resLine.slice(0, -3);
    } else if (resLine[resLine.length - 1] === "(") {
        branches--;
        resLine = resLine.slice(0, -1);
        while (regex2.test(resLine) && resLine[resLine.length - 1] !== "d") {
            resLine = resLine.slice(0, -1);
        }
    }
    lab.innerHTML = resLine;
}

function SwitchSign() {
    var resLine = document.getElementById("ResultLine").innerHTML;
    if (resLine[resLine.length - 1] === "-") {
        RemoveLast();
        AddText("+");
    } else if (resLine[resLine.length - 1] == "+") {
        RemoveLast();
        AddText("-");
    }
}


function AddDot() {
    const regex1 = /\d+[.]\d+$/;
    const regex2 = /\d+$/;
    var resLine = document.getElementById("ResultLine").innerHTML;
    if (!(regex1.test(resLine)) && regex2.test(resLine))
    {
        AddText(".");
    }
}

function AddX() {
    const regex = /([\+\-\*/^(]|mod)$/;
    var resLine = document.getElementById("ResultLine").innerHTML;
    if (resLine.length === 0 || regex.test(resLine)) {
        AddText("x");
    }
}

function AddOBranch() {
    const regex = /([\.\)]|\d)$/;
    var resLine = document.getElementById("ResultLine").innerHTML;
    if (!(regex.test(resLine)))
    {
        branches++;
        AddText("(");
    }
}

function AddCBranch() {
    const regex = /(\d|[)]|[xX])$/;
    var resLine = document.getElementById("ResultLine").innerHTML;
    if (branches > 0 && regex.test(resLine)) {
        branches--; 
        AddText(")");
    }
}