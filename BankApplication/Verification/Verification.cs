namespace BankApplication
{
    class Verification
    {
        public string Verifier;
        public DateTime VerificationDate;
        public VerificationResult VerificationResult;
        private string furtherInfo;

        public string FurtherInfo
        {
            get
            {
                return furtherInfo;
            } set
            {
                if(VerificationResult == VerificationResult.Denied || VerificationResult == VerificationResult.FurtherVerificationNeeded)
                {
                    if(string.IsNullOrEmpty(value))
                    {
                        throw new Exception("Furtherinfo musí být vyplněné, jakmile je VerificationResult Denied nebo FurtherVerificationNeeded");
                    } else
                    {
                        furtherInfo = value;
                    }
                }
            }
        }

        public Verification(string verifier, DateTime verificationDate, VerificationResult verificationResult, string furtherInfo = "")
        {
            Verifier = verifier;
            VerificationDate = verificationDate;
            VerificationResult = verificationResult;
            FurtherInfo = furtherInfo; 
        }

    }

    public enum VerificationResult { Unknown, Verified, Denied, FurtherVerificationNeeded }
}
