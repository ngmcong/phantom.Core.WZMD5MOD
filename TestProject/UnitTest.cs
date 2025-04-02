using phantom.Core.WZMD5MOD;
using System.Text;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestMD5_EncodeKeyVal()
        {
            MUMD5 md5Hash = new MUMD5();

            string input = "phantom@";
            int dwAccKey = md5Hash.MakeAccountKey("phantom");

            md5Hash.SetMagicNum(dwAccKey);
            md5Hash.Update(Encoding.UTF8.GetBytes(input), input.Length);

            // Attempt to get the hash before finalization (will throw an exception)
            //byte[] prematureDigest = md5Hash.GetDigest();

            byte[] digest = md5Hash.FinalizeMD5();
            byte[] finalDigest = md5Hash.GetDigest();
            string finalString = Convert.ToBase64String(finalDigest);

            Assert.IsTrue(finalString == "5j1tpkURLbNcp3+Q8FBQDg==");
        }
    }
}