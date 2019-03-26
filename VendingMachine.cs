using System.Collections.Generic;
using System.Linq;

public class VendingMachine
{
    private List<Juice> JuiceList;
    public int TotalMoney { get; private set; }
    
    public VendingMachine()
    {
       JuiceList = new List<Juice>();
    }
    
    public void AddJuice(Juice juice)
    {
       JuiceList.Add(juice);
    }
    
    public List<Juice> GetAll()
    {
        return JuiceList;
    }
    
    public void IncertCoin(int money)
    {
        TotalMoney += money;
    }
    
    public List<Juice> GetBuyableList()
    {
        return JuiceList.Where(x => x.Price <= TotalMoney).ToList();
    }
    
    public Juice Buy(string name)
    {
        var juice = GetBuyableList().FirstOrDefault(x => x.Name == name);
        if (juice != null)
        {
            TotalMoney -= juice.Price;
            JuiceList.Remove(juice);
        }
        return juice;
    }
    
    public int ReleaseMoney()
    {
        var releaseMoney = TotalMoney;
        TotalMoney = 0;
        return releaseMoney;
    }   
}