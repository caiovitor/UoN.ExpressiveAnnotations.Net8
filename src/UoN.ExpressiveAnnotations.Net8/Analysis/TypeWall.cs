﻿/* https://github.com/MrDoe/UoN.ExpressiveAnnotations.Net8
 * Original work Copyright (c) 2014 Jarosław Waliszko
 * Modified work Copyright (c) 2018 The University of Nottingham
 * Modified work Copyright (c) 2023 Christoph Döllinger
 * Licensed MIT: http://opensource.org/licenses/MIT */

using System;
using System.Linq.Expressions;

namespace UoN.ExpressiveAnnotations.Net8.Analysis
{
    /// <summary>
    ///     Demands types compatibility for operations.
    /// </summary>
    internal class TypeWall
    {
        public TypeWall(string expression)
        {
            ExprString = expression;
        }

        private string ExprString { get; set; }

        public void LOr(Expression arg1, Expression arg2, Token oper)
        {
            LOrLAnd(arg1, arg2, oper);
        }

        public void LAnd(Expression arg1, Expression arg2, Token oper)
        {
            LOrLAnd(arg1, arg2, oper);
        }

        private void LOrLAnd(Expression arg1, Expression arg2, Token oper)
        {
            AssertArgsNotNullLiterals(arg1, arg2, oper);
        }

        public void BOr(Expression arg1, Expression arg2, Token oper)
        {
            BOrBAndXor(arg1, arg2, oper);
        }

        public void Xor(Expression arg1, Expression arg2, Token oper)
        {
            BOrBAndXor(arg1, arg2, oper);
        }

        public void BAnd(Expression arg1, Expression arg2, Token oper)
        {
            BOrBAndXor(arg1, arg2, oper);
        }

        private void BOrBAndXor(Expression arg1, Expression arg2, Token oper)
        {
            AssertArgsNotNullLiterals(arg1, arg2, oper);
        }

        public void Eq(Expression arg1, Expression arg2, Type type1, Type type2, Token oper)
        {
            if (type1.IsNonNullableValueType() && arg2.IsNullLiteral())
                throw new ParseErrorException(
                    $"Operator '{oper.Value}' cannot be applied to operands of type '{type1}' and 'null'.", ExprString, oper.Location);
            if (arg1.IsNullLiteral() && type2.IsNonNullableValueType())
                throw new ParseErrorException(
                    $"Operator '{oper.Value}' cannot be applied to operands of type 'null' and '{type2}'.", ExprString, oper.Location);
        }

        public void Rel(Expression arg1, Expression arg2, Type type1, Type type2, Token oper)
        {
            AssertArgsNotNullLiterals(arg1, type1, arg2, type2, oper);
        }

        public void Shift(Expression arg1, Expression arg2, Token oper)
        {
            AssertArgsNotNullLiterals(arg1, arg2, oper);
        }

        public void Add(Expression arg1, Expression arg2, Type type1, Type type2, Token oper)
        {
            AssertArgsNotNullLiterals(arg1, type1, arg2, type2, oper);
        }

        public void Mul(Expression arg1, Expression arg2, Type type1, Type type2, Token oper)
        {
            AssertArgsNotNullLiterals(arg1, type1, arg2, type2, oper);
        }

        public void Unary(Expression arg, Token oper)
        {
            if (arg.IsNullLiteral())
                throw new ParseErrorException(
                    $"Operator '{oper.Value}' cannot be applied to operand of type 'null'.", ExprString, oper.Location);
        }

        public void Cond(Expression arg1, Expression arg2, Expression arg3, Type type2, Type type3, Location start, Location qmark)
        {
            OfType<bool>(arg1, start);

            if (arg2.IsNullLiteral() && !arg3.IsNullLiteral())
                throw new ParseErrorException(
                    $"Type of conditional expression cannot be determined because there is no implicit conversion between 'null' and '{type3}'.", ExprString, qmark);
            if (!arg2.IsNullLiteral() && arg3.IsNullLiteral())
                throw new ParseErrorException(
                    $"Type of conditional expression cannot be determined because there is no implicit conversion between '{type2}' and 'null'.", ExprString, qmark);
            if (arg2.Type != arg3.Type)
                throw new ParseErrorException(
                    $"Type of conditional expression cannot be determined because there is no implicit conversion between '{type2}' and '{type3}'.", ExprString, qmark);
        }

        public void OfType<T>(Expression arg, Location pos)
        {
            if (arg.Type != typeof(T))
                throw new ParseErrorException(
                    $"Argument must be of type '{typeof(T)}'.", ExprString, pos);
        }

        private void AssertArgsNotNullLiterals(Expression arg1, Expression arg2, Token oper)
        {
            AssertArgsNotNullLiterals(arg1, arg1.Type, arg2, arg2.Type, oper);
        }

        private void AssertArgsNotNullLiterals(Expression arg1, Type type1, Expression arg2, Type type2, Token oper)
        {
            if (arg1.IsNullLiteral() && arg2.IsNullLiteral())
                throw new ParseErrorException(
                    $"Operator '{oper.Value}' cannot be applied to operands of type 'null' and 'null'.", ExprString, oper.Location);
            if (!arg1.IsNullLiteral() && arg2.IsNullLiteral())
                throw new ParseErrorException(
                    $"Operator '{oper.Value}' cannot be applied to operands of type '{type1}' and 'null'.", ExprString, oper.Location);
            if (arg1.IsNullLiteral() && !arg2.IsNullLiteral())
                throw new ParseErrorException(
                    $"Operator '{oper.Value}' cannot be applied to operands of type 'null' and '{type2}'.", ExprString, oper.Location);
        }
    }
}
