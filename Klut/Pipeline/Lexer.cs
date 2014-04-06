using Klut.Streams;

namespace Klut.Pipeline
{
    class Lexer
    {
        public TextStream InputStream { get; private set; }

        public TokenStream OutputStream { get; private set; }

        public Lexer( TextStream inputStream )
        {
            InputStream = inputStream;
            InputStream.OnItemAdded += _handleNewInput;
            OutputStream = new TokenStream();
        }

        private void _handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                char inputChar = InputStream.Receive();

                //todo: implement _handleNewInput
            }
        }
    }
}
