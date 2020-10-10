using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] UserData userData;

    [SerializeField] Text nameT;
    [SerializeField] Text coinsT;

    [SerializeField] InputField nameI;
    [SerializeField] InputField coinsI;

    void Start()
    {
        if(ManagerData.Exist(typeof(UserData)))
            userData = ManagerData.Load<UserData>(true);
        else{
            userData = new UserData();
            userData.Save<UserData>(true);
        }
        ShowData();
    }

    void ShowData(){
        nameT.text = "Nombre: " + userData.GetName();
        coinsT.text = "Monedas: " + userData.GetCoins();
    }
    
    public void Cargar(){
        if(ManagerData.Exist(typeof(UserData)))
            userData = ManagerData.Load<UserData>(true);
        ShowData();
    }
    public void Guardar(){
        SetValues();
        userData?.Save<UserData>(true);
    }
    public void SetValues() {
        SetName(nameI.text);
        SetCoins(int.Parse(coinsI.text));

        userData.Save<UserData>(true);
        ShowData();
    }

    void SetName(string n) => userData.SetName(n);
    void SetCoins(int c) => userData.SetCoins(c);

    public void Reset() {
        userData = new UserData();
        ShowData();
    }
}
