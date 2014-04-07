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
            InputStream.ItemsAdded += inputStream_ItemsAdded;
            OutputStream = new CodeStream();
        }

        private void inputStream_ItemsAdded( object sender, ParseStream.ItemsAddedEventArgs eventArgs )
        {
            for ( int i = 0; i < eventArgs.Count; i++ )
            {
                ParseTree inputTree = InputStream.Receive();

                // todo: implement inputStream_ItemsAdded
            }
        }
    }
}
