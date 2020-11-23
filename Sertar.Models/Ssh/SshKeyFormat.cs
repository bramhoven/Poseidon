namespace Sertar.Models.Ssh
{
    public enum SshKeyFormat
    {
        RSA = 0,
        DSA = 1,
        ECDSA = 2,
        ECDSA256 = 3,
        ECDSA384 = 4,
        ECDSA521 = 4,
        ED25519 = 5
    }
}