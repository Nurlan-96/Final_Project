namespace Identity.Module.Response
{
    public class JWTResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }

        public override string ToString()
        {
            return Token;
        }
    }
}
