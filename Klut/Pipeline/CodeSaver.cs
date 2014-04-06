using Klut.Parsing;
using Klut.Streams;

namespace Klut.Pipeline
{
    class CodeSaver
    {
        public CodeStream InputStream { get; private set; }

        public string OutputFilePath { get; set; }

        public CodeSaver( CodeStream inputStream )
        {
            InputStream = inputStream;
        }

        private void _handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                byte inputTree = InputStream.Receive();

                // todo: implement handleNewInput
            }
        }
    }
}
