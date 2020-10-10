using System;

[Serializable]
public class UserData {
    public string name;
    int coins;

    public string GetName() => name;
    public int GetCoins() => coins;

    public string SetName(string _n) {
        name = _n;
        return GetName();
    }
    public int SetCoins(int _c) {
        coins = _c;
        return GetCoins();
    }
}
