using System;

namespace Unicorn.Tests.Unit.TestHelpers
{
    internal static class RandomExtensions
    {
        private static TableRuleStyle[] _validTableRuleStyles =
        {
            TableRuleStyle.None,
            TableRuleStyle.LinesMeet,
            TableRuleStyle.SolidColumnsBrokenRows,
            TableRuleStyle.SolidRowsBrokenColumns,
        };

        internal static TableRuleStyle NextTableRuleStyle(this Random rnd)
        {
            if (rnd is null)
            {
                throw new NullReferenceException();
            }
            return _validTableRuleStyles[rnd.Next(_validTableRuleStyles.Length)];
        }
    }
}
