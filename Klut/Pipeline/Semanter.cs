using Klut.Streams;

namespace Klut.Pipeline
{
    class Semanter
    {
        public ParseStream InputStream { get; private set; }

        public ParseStream OutputStream { get; private set; }

        public Semanter( ParseStream inputStream )
        {
            InputStream = inputStream;
            InputStream.ItemsAdded += inputStream_ItemsAdded;
            OutputStream = new ParseStream();
        }

        private void inputStream_ItemsAdded( object sender, ParseStream.ItemsAddedEventArgs eventArgs )
        {
            for ( int i = 0; i < eventArgs.Count; i++ )
            {
                OutputStream.Send( InputStream.Receive() );

                //todo: implement inputStream_ItemsAdded
            }
        }
    }
}
