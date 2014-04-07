using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klut.Tokens;

namespace Klut.FinitAutomata
{
    class DfaState
    {
        public bool IsFinal
        {
            get { return FinalTokenType != TokenType.None; }
        }

        public TokenType FinalTokenType { get; private set; }

        private readonly Dictionary<char, DfaState> _transitions = new Dictionary<char, DfaState>();

        private DfaState _defaultTransitionState;

        public DfaState() {}

        public DfaState( TokenType finalTokenType )
            : this()
        {
            FinalTokenType = finalTokenType;
        }

        public void AddTransition( char triggeringChar, DfaState newState )
        {
            _transitions.Add( triggeringChar, newState );
        }

        public void SetDefaultTransitionState( DfaState state )
        {
            _defaultTransitionState = state;
        }

        public DfaState GetStateForChar( char triggeringChar )
        {
            DfaState newState;
            if ( _transitions.TryGetValue( triggeringChar, out newState ) )
            {
                return newState;
            }
            else
            {
                return _defaultTransitionState;
            }
        }

        public override string ToString()
        {
            string description = "";

            description += IsFinal
                ? "Final (" + GetType( TokenType ).GetEnumName( FinalTokenType ) +
                    ")"
                : "Non-final";

            description += ", " + _transitions.Count + " transition(s)";

            if ( _defaultTransitionState != null )
            {
                description += ", with default transition";
            }

            return description;
        }
    }
}
