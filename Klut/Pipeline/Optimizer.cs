using Klut.Streams;

namespace Klut.Pipeline
{
    class Optimizer
    {
        public ParseStream InputStream { get; private set; }

        public ParseStream OutputStream { get; private set; }

        public Optimizer( ParseStream inputStream )
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
