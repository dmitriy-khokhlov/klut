using Klut.Streams;
using Klut.Tokens;

namespace Klut.Pipeline
{
    class Parser
    {
        public TokenStream InputStream { get; private set; }

        public ParseStream OutputStream { get; private set; }

        public Parser( TokenStream inputStream )
        {
            InputStream = inputStream;
            InputStream.OnItemAdded += _handleNewInput;
            OutputStream = new ParseStream();
        }

        private void _handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                Token inputToken = InputStream.Receive();

                //todo: implement _handleNewInput
            }
        }
    }
}
