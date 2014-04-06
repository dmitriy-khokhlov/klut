using Klut.Parsing;
using Klut.Streams;

namespace Klut.Pipeline
{
    class CodeGenerator
    {
        public ParseStream InputStream { get; private set; }

        public CodeStream OutputStream { get; private set; }

        public CodeGenerator( ParseStream inputStream )
        {
            InputStream = inputStream;
            InputStream.OnItemAdded += _handleNewInput;
            OutputStream = new CodeStream();
        }

        private void _handleNewInput( int count )
        {
            for ( ; count > 0; count-- )
            {
                ParseTree inputTree = InputStream.Receive();

                // todo: implement _handleNewInput
            }
        }
    }
}
