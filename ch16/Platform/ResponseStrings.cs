namespace Platform
{
	public class Responses
	{
		public static string DefaultResponse = @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset=""utf-8"" />
                <title>Error</title>
                <link href=""lib/bootstrap/dist/css/bootstrap.min.css"" rel=""stylesheet"" />
            </head>
            <body>
                <h3 class=""p-2"">Error {0}</h3>
                <h6>You can go back to the <a href=""/"">homepage</a> and try again.</h6>
            </body>
            </html>";
	}
}
