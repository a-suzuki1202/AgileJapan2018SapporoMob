using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class VendingMachineTest
{
    [Test]
    public void すべての商品を取得()
    {
        // a simple example to start you off
        var target = new VendingMachine();
        var cola = new Juice(120, "コーラ");
        target.AddJuice( cola);
        var actual = target.GetAll();
        Assert.That(actual, Has.Count.EqualTo(1));
        Assert.That(actual.First().Name, Is.EqualTo("コーラ"));
        Assert.That(actual.First().Price, Is.EqualTo(120));
        
        Console.WriteLine("test");
    }

    [Test]
    public void 商品を買う()
    {
        var target = new VendingMachine();
        var cola = new Juice(120, "コーラ");
        var ramune = new Juice(250, "ラムネ");
        var greentea = new Juice(150, "緑茶");
        var coffee = new Juice(120, "コーヒー");

        target.AddJuice( cola);
        target.AddJuice( ramune);
        target.AddJuice( greentea);
        target.AddJuice( coffee);

        target.IncertCoin(100);
        var nullList = target.GetBuyableList();
        Assert.That(nullList, Has.Count.EqualTo(0));

        target.IncertCoin(100);
        var buyableList = target.GetBuyableList();
        Assert.That(buyableList, Has.Count.EqualTo(3));
        Assert.That(buyableList.Select( x => x.Name ), Does.Contain("コーラ"));
        Assert.That(buyableList.First().Price, Is.EqualTo(120));
        
        var targetJuice = buyableList.First();
        var actualJuice = target.Buy(targetJuice.Name);
        Assert.That(actualJuice.Name, Is.EqualTo("コーラ"));
        Assert.That(actualJuice.Price, Is.EqualTo(120));
        Assert.That(target.TotalMoney, Is.EqualTo(80));
        Assert.That(target.GetAll(), Has.Count.EqualTo(3));
        
        Assert.That(target.ReleaseMoney(), Is.EqualTo(80));
        Assert.That(target.TotalMoney, Is.EqualTo(0));
    }
}