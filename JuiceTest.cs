using NUnit.Framework;

[TestFixture]
public class JuiceTest
{
    [Test]
    public void create_juice()
    {
        var j = new Juice(120, "コーラ");
        Assert.AreEqual(120, j.Price);
        Assert.AreEqual("コーラ", j.Name);
    }
}
