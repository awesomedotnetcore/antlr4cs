// Copyright (c) Terence Parr, Sam Harwell. All Rights Reserved.
// Licensed under the BSD License. See LICENSE.txt in the project root for license information.

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Atn
{
    public sealed class ActionTransition : Transition
    {
        public readonly int ruleIndex;

        public readonly int actionIndex;

        public readonly bool isCtxDependent;

        public ActionTransition([NotNull] ATNState target, int ruleIndex)
            : this(target, ruleIndex, -1, false)
        {
        }

        public ActionTransition([NotNull] ATNState target, int ruleIndex, int actionIndex, bool isCtxDependent)
            : base(target)
        {
            // e.g., $i ref in action
            this.ruleIndex = ruleIndex;
            this.actionIndex = actionIndex;
            this.isCtxDependent = isCtxDependent;
        }

        public override Antlr4.Runtime.Atn.TransitionType TransitionType
        {
            get
            {
                return Antlr4.Runtime.Atn.TransitionType.Action;
            }
        }

        public override bool IsEpsilon
        {
            get
            {
                return true;
            }
        }

        // we are to be ignored by analysis 'cept for predicates
        public override bool Matches(int symbol, int minVocabSymbol, int maxVocabSymbol)
        {
            return false;
        }

        public override string ToString()
        {
            return "action_" + ruleIndex + ":" + actionIndex;
        }
    }
}
