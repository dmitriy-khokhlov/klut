using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Klut.Tokens;

namespace Klut.FinitAutomata
{
    class Dfa
    {
        private readonly DfaState _initialState;
        private DfaState _currentState;
        private DfaState _previousState;
        private string _lexeme = "";

        public Dfa()
        {
            // todo: temporary fake implementation, rewrite

            _initialState = new DfaState( TokenType.Identifier );

            for ( char c = 'a'; c <= 'z'; c++ )
            {
                _initialState.AddTransition( c, _initialState );
                _initialState.AddTransition( Char.ToUpper( c ), _initialState );
            }
            _initialState.AddTransition( '_', _initialState );

            _initialState.AddTransition( '(',
                new DfaState( TokenType.OpenParenthesis ) );

            _initialState.AddTransition( ')',
                new DfaState( TokenType.CloseParenthesis ) );

            _initialState.AddTransition( ';',
                new DfaState( TokenType.Semicolon ) );

            var blankState = new DfaState( TokenType.Blank );
            foreach ( char c in " \n\r\t\v" )
            {
                _initialState.AddTransition( c, blankState );
                blankState.AddTransition( c, blankState );
            }

            var stringState = new DfaState();
            _initialState.AddTransition( '"', stringState );
            stringState.SetDefaultTransitionState( stringState );
            stringState.AddTransition( '"', new DfaState( TokenType.String ) );

            Rewind();
        }

        public void Transit( char transitionChar )
        {
            if ( TryTransitToNextState( transitionChar ) == false )
            {
                var isTokenRecognized = TryRecognizeToken();
                Rewind();
                var isTransitionValidFromInitialState = TryTransitToNextState( transitionChar );

                if ( !isTokenRecognized )
                {
                    throw new InvalidTransitionException( _previousState,
                        transitionChar, isTransitionValidFromInitialState );
                }
            }
        }

        public void Complete()
        {
            var isTokenRecognized = TryRecognizeToken();
            Rewind();

            if ( !isTokenRecognized )
            {
                throw new InvalidCompletionException( _currentState );
            }
        }

        public event EventHandler<TokenRecognizedEventArgs> TokenRecognized =
            delegate { };

        private bool TryTransitToNextState( char transitionChar )
        {
            var nextState = _currentState.GetStateForChar( transitionChar );
            var isTransitionExists = ( nextState != null );
            if ( isTransitionExists )
            {
                TransitToNextState( nextState, transitionChar );
            }
            return isTransitionExists;
        }

        private void TransitToNextState( DfaState nextState, char transitionChar )
        {
            _previousState = _currentState;
            _currentState = nextState;
            _lexeme += transitionChar;
        }

        private void Rewind()
        {
            _previousState = _currentState;
            _currentState = _initialState;
            _lexeme = "";
        }

        private bool TryRecognizeToken()
        {
            if ( _currentState.IsFinal )
            {
                TokenRecognized( this,
                    new TokenRecognizedEventArgs(
                        new Token( _currentState.FinalTokenType, _lexeme ) ) );
                return true;
            }
            else
            {
                return false;
            }
        }

        public class TokenRecognizedEventArgs
        {
            public Token RecognizedToken { get; set; }

            public TokenRecognizedEventArgs( Token recognizedToken )
            {
                RecognizedToken = recognizedToken;
            }
        }

        public class InvalidTransitionException : Exception
        {
            private readonly string _message;

            public DfaState DfaLastState { get; private set; }

            public char GivenChar { get; private set; }

            public bool IsValidFromInitialState { get; private set; }

            public override string Message
            {
                get { return _message; }
            }

            public InvalidTransitionException( DfaState dfaLastState, char givenChar, bool isValidFromInitialState )
            {
                DfaLastState = dfaLastState;
                GivenChar = givenChar;
                IsValidFromInitialState = isValidFromInitialState;

                _message = "Invalid transition. DFA last state: " +
                    dfaLastState + ", given char: '" + givenChar + "'. " +
                    ( isValidFromInitialState ? "Valid" : "Invalid" ) +
                    " from initial state" +
                    ( isValidFromInitialState ? "" : " too" ) + ".";
            }
        }

        public class InvalidCompletionException : Exception
        {
            private readonly string _message;

            public DfaState DfaLastState { get; private set; }

            public override string Message
            {
                get { return _message; }
            }

            public InvalidCompletionException( DfaState dfaLastState )
            {
                DfaLastState = dfaLastState;
                _message = "DFA is completed in non-final state: " +
                    dfaLastState + ".";
            }
        }
    }
}
