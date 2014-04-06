using System;
using Klut.Streams;

namespace Klut
{
    class TextProvider
    {
        public TextStream OutputStream { get; private set; }

        public TextProvider()
        {
            OutputStream = new TextStream();
        }

        public TextProvider( TextStream outputStream )
        {
            OutputStream = outputStream;
        }

        public void ReadFile( String filePath )
        {
            //todo: implement ReadFile as it should be
            string fileContents = "print( \"Hello, World!\" );\n";
            foreach ( char c in fileContents )
            {
                OutputStream.Send( c );
            }
        }
    }
}
