namespace Sol3.Google.Auth
{
    public class GooglePlusAccessToken
    {
        private readonly GooglePlusAccessTokenInternal _token;

        public GooglePlusAccessToken(GooglePlusAccessTokenInternal token)
        {
            _token = token;
        }

        public string AccessToken => _token.access_token;
        public string TokenType => _token.token_type;
        public int ExpiresIn => _token.expires_in;
        public string RefreshToken => _token.refresh_token;
    }
}