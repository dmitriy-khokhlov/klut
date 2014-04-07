using Klut.FinitAutomata;
using Klut.Streams;
using Klut.Tokens;

namespace Klut.Pipeline
{
    class Lexer
    {
        private Dfa _dfa = new Dfa();

        public TextStream InputStream { get; private set; }

        public TokenStream OutputStream { get; private set; }

        public Lexer( TextStream inputStream )
        {
            InputStream = inputStream;
            InputStream.ItemsAdded += inputStream_ItemsAdded;
            OutputStream = new TokenStream();
        }

        private void inputStream_ItemsAdded( object sender,
            TextStream.ItemsAddedEventArgs eventArgs )
        {
            for ( int i = 0; i < eventArgs.Count; i++ )
            {
                _dfa.Transit( InputStream.Receive() );
            }
        }

        private void dfa_TokenRecognized( object sender,
            Dfa.TokenRecognizedEventArgs eventArgs )
        {
            OutputStream.Send( eventArgs.RecognizedToken );
        }
    }
}
