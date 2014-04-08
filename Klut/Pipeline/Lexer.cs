using Klut.FinitAutomata;
using Klut.Streams;
using Klut.Tokens;

namespace Klut.Pipeline
{
    class Lexer
    {
        private readonly Dfa _dfa = new Dfa();

        public TextStream InputStream { get; private set; }

        public TokenStream OutputStream { get; private set; }

        public Lexer( TextStream inputStream )
        {
            InputStream = inputStream;
            InputStream.ItemsAdded += InputStream_ItemsAdded;
            InputStream.EndOfStreamReceived += InputStream_EndOfStreamReceived;
            OutputStream = new TokenStream();
        }

        private void InputStream_ItemsAdded( object sender,
            TextStream.ItemsAddedEventArgs eventArgs )
        {
            for ( int i = 0; i < eventArgs.Count; i++ )
            {
                _dfa.Transit( InputStream.Receive() );
            }
        }

        private void InputStream_EndOfStreamReceived( object sender,
            TextStream.EndOfStreamReceivedEventArgs eventArgs )
        {
            // todo: implement
        }

        private void Dfa_TokenRecognized( object sender,
            Dfa.TokenRecognizedEventArgs eventArgs )
        {
            OutputStream.Send( eventArgs.RecognizedToken );
        }
    }
}
