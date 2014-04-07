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
            InputStream.ItemsAdded += inputStream_ItemsAdded;
        }

        private void inputStream_ItemsAdded( object sender, CodeStream.ItemsAddedEventArgs eventArgs )
        {
            for ( int i = 0; i < eventArgs.Count; i++ )
            {
                byte inputTree = InputStream.Receive();

                //todo: implement inputStream_ItemsAdded
            }
        }
    }
}
