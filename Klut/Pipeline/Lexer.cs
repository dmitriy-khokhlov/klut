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
            InputStream.ItemsAdded += inputStream_ItemsAdded;
            OutputStream = new TokenStream();
        }

        private void inputStream_ItemsAdded( object sender, TextStream.ItemsAddedEventArgs eventArgs )
        {
            for ( int i = 0; i < eventArgs.Count; i++ )
            {
                char inputChar = InputStream.Receive();

                //todo: implement inputStream_ItemsAdded
            }
        }
    }
}
