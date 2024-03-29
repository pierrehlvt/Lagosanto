﻿using System;
using Lagosanto.Interpreter.Interfaces;
using Lagosanto.Interpreter.Parser.ChainOfResponsability;

namespace Lagosanto.Interpreter.Parser;

public abstract class Parser {
    public const char OpenCharacter = '(';
    public const char CloseCharacter = ')';
    public const char SeparatorCharacter = ',';

    public static IExpression Parse(String textToParse) {
        return Parse(new ParserTreeText(textToParse));
    }

    private static IExpression Parse(ParserTreeText treeText) {
        IExpression expression = null;
        return TokenHandlerChain.Instance.Execute(expression, treeText);
    }
}