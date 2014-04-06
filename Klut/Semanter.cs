using Klut.Streams;

namespace Klut
{
    class Semanter
    {
        public ParseStream InputStream { get; private set; }

        public ParseStream OutputStream { get; private set; }

        public Semanter( ParseStream inputStream )
        {
            InputStream = inputStream;
            InputStream.OnItemAdded += _handleNewInput;
            OutputStream = new ParseStream();
        }

        private void _handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                OutputStream.Send( InputStream.Receive() );
            }
        }
    }
}
