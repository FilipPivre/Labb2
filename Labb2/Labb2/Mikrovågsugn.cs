
using System.Security.Cryptography.X509Certificates;

namespace Labb2
{
    internal class Mikrovågsugn : Köksapparater
    {
        public Mikrovågsugn()
        {
            Type = "Mikrovågsugn";
            Brand = "Philips";
            IsFunctioning = true;
        }
    }
}
