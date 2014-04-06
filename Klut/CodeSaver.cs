using Klut.Parsing;
using Klut.Streams;

namespace Klut
{
    class CodeSaver
    {

        public ParseStream InputStream { get; private set; }

        public string OutputFilePath { get; set; }

        public CodeSaver() {}

        private void _handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                ParseTree inputTree = InputStream.Receive();

                // todo: implement handleNewInput
            }
        }
    }
}
